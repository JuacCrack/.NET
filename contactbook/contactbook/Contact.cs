using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactbook
{
    public class Contact
    {
        public int Id { get; set; }
        public string txtname { get; set; }
        public string txtcompany { get; set; }
        public string txtprofile { get; set; }
        public string txtimage { get; set; }
        public string txtemail { get; set; }
        public string txtbirthdate { get; set; }
        public string txtphonew { get; set; }
        public string txtphonep { get; set; }
        public string txtaddress { get; set; }

    }
}
