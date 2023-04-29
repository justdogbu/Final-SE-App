using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Phone
    {
        private string PhoneName;

        public string _PHONENAME
        {
            get
            {
                return PhoneName;
            }
            set
            {
                PhoneName = value;
            }
        }
        public DTO_Phone(string phoneName)
        {
            this.PhoneName = phoneName;
        }
    }
}
