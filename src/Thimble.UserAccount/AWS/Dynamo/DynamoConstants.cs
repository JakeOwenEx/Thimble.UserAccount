namespace Thimble.UserAccount.AWS.Dynamo
{
    public static class DynamoConstants
    {
        public const string PII_TABLE = "Thimble.UserAccount.PII";
        public const string UserIdKey = "UserId";
        public const string EmailKey = "Email";
        public const string AddressLine1Key = "AddressLine1";
        public const string AddressLine2Key = "AddressLine2";
        public const string CityKey = "City";
        public const string CountyKey = "County";
        public const string PostcodeKey = "Postcode";
        public const string PhoneNumberKey = "PhoneNumber";
        public const string LastNameKey = "LastName";
        public const string FirstNameKey = "FirstName";
    }
}