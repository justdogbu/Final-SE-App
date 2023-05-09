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
        private int PhoneID;

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

        public int _PHONEID
        {
            get
            {
                return PhoneID;
            }
            set
            {
                PhoneID = value;
            }
        }
        public DTO_Phone(string phoneName)
        {
            this.PhoneName = phoneName;
        }

        public DTO_Phone(int phoneId)
        {
            this.PhoneID = phoneId;
        }

        public DTO_Phone()
        {

        }
    }
}
