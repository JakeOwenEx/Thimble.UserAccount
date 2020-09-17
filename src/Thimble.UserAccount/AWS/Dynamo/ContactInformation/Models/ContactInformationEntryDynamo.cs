using Amazon.DynamoDBv2.DataModel;

namespace Thimble.UserAccount.AWS.Dynamo.ContactInformation.Models
{
    [DynamoDBTable("Thimble.UserAccount.PII")]
    public class ContactInformationEntryDynamo
    {
        [DynamoDBHashKey]
        public string UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string AddressLine1 { get; set; }
        
        public string AddressLine2 { get; set; }
        
        public string City { get; set; }
        
        public string County { get; set; }
        
        public string Postcode { get; set; }
    }
}