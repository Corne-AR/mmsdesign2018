using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.IO
{
    public class Export
    {
        public string ID { get; private set; }
        public string ClientName { get; set; }
        public string Catagory { get; set; } //CA0323
        public string Person { get; set; }
        public string Email { get; set; }
        public string PostalAddress { get; set; } //CA0921
        public string ContactNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public HashSet<Products> Products { get; set; }

        public Export()
        {
        }

        public Export(Data.People.Client Client, HashSet<Products> Products)
        {
            this.ClientName = Client.Name;
            this.Person = Client.GetMainContact.DisplayName;
            this.PostalAddress = Client.PostalAddress; //CA0921
            this.Email = Client.Email;
            this.ContactNumber = Client.Telephone;
            this.ExpiryDate = Client.Expirydate;
            this.Catagory = Client.Catagory;  //CA0323

            this.Products = Products;

            if (string.IsNullOrEmpty(ID)) ID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// For separating people
        /// </summary>
        /// <param name="ClientName"></param>
        /// <param name="Person"></param>
        public Export(string ClientName, Data.People.Person Person)
        {
            this.ClientName = ClientName;
            this.Person = Person.DisplayName;
            this.PostalAddress = PostalAddress; //CA0921
            this.Email = Person.Email;
            this.ContactNumber = Person.ContactNumber;
            this.Catagory = Catagory; //CA0323

            if (string.IsNullOrEmpty(ID)) ID = Guid.NewGuid().ToString();
        }

        private string HashID
        {
            get
            {
                return ClientName + Person + Email + ContactNumber;
            }
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as Export;
            if (other == null)
            {
                return false;
            }
            if (HashID == null) return false;
            return HashID == other.HashID;
        }

        public override int GetHashCode()
        {
            return (HashID).GetHashCode();
        }

        #endregion
    }
}
