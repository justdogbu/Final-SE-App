namespace DTO
{
    public class DTO_ResellerStorage
    {
        private int ResellerID;
        private int PhoneID;
        private int Quantity;

        public int _RESELLERID
        {
            get
            {
                return ResellerID;
            }
            set
            {
                ResellerID = value;
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

        public int _QUANTITY
        {
            get
            {
                return Quantity;
            }
            set
            {
                Quantity = value;
            }
        }





        public DTO_ResellerStorage(int ResellerID) 
        {
            this.ResellerID = ResellerID;
        }

        public DTO_ResellerStorage(int ResellerID, int PhoneID, int Quantity)
        {
            this.ResellerID = ResellerID;
            this.PhoneID = PhoneID;
            this.Quantity = Quantity;
        }
    }
}