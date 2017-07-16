using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace UserRegistrationAndLoginDemo.Core.Model
{
    public class UserCredential : TableEntity
    {
        public UserCredential() { }

        public UserCredential(string userName, string hashedPassword)
        {
            PartitionKey = userName;
            RowKey = hashedPassword;
            Id = Guid.NewGuid().ToString("N");
        }

        public bool Agree { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salt { get; set; }

        public string Id { get; set; }
        public string Address { get; set; }
        public string Secret { get; set; }
    }
}
