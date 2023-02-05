namespace ContactsAPI.Models
{
    public class AddContactRequest
    {


        public string? name { get; set; }
        public string? company { get; set; }
        public string? profile { get; set; }
        public string? image { get; set; }
        public string? email { get; set; }
        public string? birthdate { get; set; }
        public string? phonew { get; set; }
        public string? phonep { get; set; }
        public string? address { get; set; }

        public int CityFK { get; set; }

    }
}
