using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{

    public class Contact//MODELO DE CONTACTO
    {
        public int ContactId { get; set; }
        public string fullname { get; set; }
        public string company { get; set; }
        public string profile { get; set; }
        public string image { get; set; }
        public string email { get; set; }
        public string birthdate { get; set; }
        public string phonew { get; set; }
        public string phonep { get; set; }
        public string address { get; set; }

        public int CityFK { get; set; }//CLAVE FORANEA RELACIONADO CON EL MODELO CITY
        public City City { get; set; }

    }

}
