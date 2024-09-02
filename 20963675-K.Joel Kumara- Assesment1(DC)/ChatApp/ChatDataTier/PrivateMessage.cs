using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    public class PrivateMessage
    {
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public string Content { get; set; }
    }
}
