using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AccountModel
    {
        public Guid AccountID { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String NewPassword { get; set; }
    }
}
