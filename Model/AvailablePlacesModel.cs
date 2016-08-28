using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AvailablePlacesModel
    {
        public String CountryName { get; set; }
        public String CountryIsoCode { get; set; }
        public List<String> CityNames { get; set; }
    }
}
