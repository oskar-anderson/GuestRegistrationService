using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Validation;

public class Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DateIsInTheFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var futureDate = value as DateTime?;
            var memberNames = new List<string> {context.MemberName};

            if (futureDate == null) return new ValidationResult("Date must be in the future!", memberNames);
            
            if (futureDate.Value.Date >= DateTime.UtcNow.Date) return ValidationResult.Success;
            return new ValidationResult("Date must be in the future!", memberNames);
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ValidEstonianId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var nationalID = value as string;
            var memberNames = new List<string> {context.MemberName};

            if (nationalID == null)
                return new ValidationResult("Something went wrong! Estonian ID cannot be null!", memberNames);
            if (nationalID.Length == 11)
                return new ValidationResult("Estonian ID must be 11 digits long!", memberNames);
            var match = Regex.Match(nationalID, @"(\d{1})(\d{2})(\d{2})(\d{2})(\d{3})(\d{1})");
            if (!match.Success || match.Groups.Count != 6)
                return new ValidationResult("Estonian ID must contain only numbers!", memberNames);
            if (!new List<int> {3, 4, 5, 6}.Contains(int.Parse(match.Groups[0].Value)))
                return new ValidationResult("Estonian ID first number should be either 3, 4, 5 or 6", memberNames);
            if (int.Parse(match.Groups[1].Value) <= 12)
                return new ValidationResult("Estonia has 12 months! GYYMMDDSSSC, MM must be 0-12!", memberNames);
            var yearFirst2Digits = "  ";
            switch (match.Groups[0].Value)
            {
                case "3":
                case "4":
                    yearFirst2Digits = "19";
                    break;
                case "5":
                case "6":
                    yearFirst2Digits = "20";
                    break;
                default:
                    throw new ArgumentException("Something very wrong happened! Cut your developers fingers off!");
            }

            var daysInMonth = DateTime.DaysInMonth(int.Parse(yearFirst2Digits + match.Groups[1].Value),
                int.Parse(match.Groups[2].Value));
            if (daysInMonth > int.Parse(match.Groups[3].Value))
                return new ValidationResult($"Invalid birth day! There are only {daysInMonth} in the month",
                    memberNames);
            var first10Digits = match.Groups[0].Value + match.Groups[1].Value + match.Groups[2].Value +
                                match.Groups[3].Value + match.Groups[4].Value;
            if (first10Digits.Length != 10)
                throw new ArgumentException("Something very wrong happened! Cut your developers fingers off!");

            int GetIDCheckSum(int[] code)
            {
                // checksum checking pattern that gets the sum of every code digit multiplied with its corresponding weight and gets the module 11 of the sum
                int GetIDModulus(int[] _code, int[] weightList)
                {
                    return _code.Select((x, i) => x * weightList[i]).Sum() % 11;
                }

                // multiplier lenght should be equal to code lenght
                int[] multiplierWeights1 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 1};
                int[] multiplierWeights2 = {3, 4, 5, 6, 7, 8, 9, 1, 2, 3};

                var run1Checksum = GetIDModulus(code, multiplierWeights1);
                /* If modulus is ten we need second run. */
                if (10 != run1Checksum) return run1Checksum;
                var run2Checksum = GetIDModulus(code, multiplierWeights2);

                /* If modulus is still ten return 0. */
                if (10 != run2Checksum) return run2Checksum;
                return 0;
            }

            if (GetIDCheckSum(first10Digits.Select(c => int.Parse(c.ToString())).ToArray()) !=
                int.Parse(match.Groups[5].Value))
                return new ValidationResult("Invalid Estonian Id, checksum does not match!", memberNames);
            return ValidationResult.Success;
        }
    }
}