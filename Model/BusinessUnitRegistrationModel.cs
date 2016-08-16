using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusinessUnitRegistrationModel
    {
        public Guid BusinessUnitID { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String FullDescription { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public AddressModel Address { get; set; }
        public AccountModel Account { get; set; }

    }
}
