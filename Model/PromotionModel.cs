using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PromotionModel
    {
        public Guid PromotionID { get; set; }
        public Guid BusinessUnitRefID { get; set; }
        public String BusinessUnitName { get; set; }
        public String Title { get; set; }
        public String Desctiption { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
