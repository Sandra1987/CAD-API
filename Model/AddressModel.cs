using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AddressModel
    {
        public Guid AddressID { get; set; }
        public String Country { get; set; }
        public String CountryISOCode {get; set;}
        public String City { get; set; }
        public String ZIP { get; set; }
        public String StreetName { get; set; }
        public String StreetNumber { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
