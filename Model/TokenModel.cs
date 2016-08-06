using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TokenModel
    {
        public Guid AccountID { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
