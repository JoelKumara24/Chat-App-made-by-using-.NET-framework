using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    public class User
    {
        public String Name { get; set; }
        public List<string> MessageHistory { get; } = new List<string>();
    }
}
