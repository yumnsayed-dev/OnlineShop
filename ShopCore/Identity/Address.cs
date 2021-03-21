namespace ShopCore.identity
{
    public class Address :BaseObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }


    }
}