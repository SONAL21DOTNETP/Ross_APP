using System;

namespace RossBoiler.Common
{
    public class RegexConstants
    {
        //  Regex for Alphabetic validation (Letters and spaces allowed)
        public static string AlphabeticRegex => @"^[a-zA-Z\s]+$";

        //  Regex for Email validation
        public static string EmailRegex => @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        //  Regex for Phone Number validation (Supports International Format)
        public static string PhoneNumberRegex => @"^\+?[1-9][0-9]{9,14}$";

        //  Regex for Date format validation (yyyy-MM-dd)
        public static string DateRegex => @"^\d{4}-\d{2}-\d{2}$";

        //  Regex for Password validation (Minimum 8 characters, at least one number, one lowercase, one uppercase letter)
        public static string PasswordRegex => @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$";

        //  Regex for URL validation
        public static string UrlRegex => @"^(http[s]?:\/\/)?[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)+([\/\w .-]*)*\/?$";

        //  Regex for Alphanumeric validation (letters and numbers only)
        public static string AlphanumericRegex => @"^[a-zA-Z0-9]+$";

        //  Regex for Pincode (India - 6 digits)
        public static string PincodeRegex => @"^\d{6}$";

        //  Regex for Percentage (0-100 with optional decimals)
        public static string PercentageRegex => @"^(100|[0-9]{1,2})(\.\d+)?$";

        //  Regex for Price (Supports decimals with at least one digit before decimal)
        public static string PriceRegex => @"^\d+(\.\d{1,2})?$";

        //  Regex for Dimensions (Supports formats like 10x20x30, 10*20*30, or 10.5x20.5x30.5)
        public static string DimensionsRegex => @"^\d+(\.\d+)?[xX*]\d+(\.\d+)?[xX*]\d+(\.\d+)?$";

        //  Regex for Age (Must be 1-3 digit number, valid age range 1-120)
        public static string AgeRegex => @"^(?:1[01][0-9]|120|[1-9][0-9]?)$";

        //  Regex for Address (Allows letters, numbers, spaces, commas, and basic symbols)
        public static string AddressRegex => @"^[a-zA-Z0-9\s,.-]+$";

        //  Regex for PAN Card (India - 10 characters, alphanumeric, format: 5 letters, 4 digits, 1 letter)
        public static string PanCardRegex => @"^[A-Z]{5}[0-9]{4}[A-Z]$";

        //  Regex for Aadhaar Card (India - 12-digit numeric)
        public static string AadhaarCardRegex => @"^\d{12}$";

        // Regex for CTC (Supports decimal format, min 1 digit)
        public static string CTCRegex => @"^\d+(\.\d{1,2})?$";

        // Date validation (handled via DateTime in C#)
        public static DateTime CreatedDate => DateTime.Now;
    }
}
