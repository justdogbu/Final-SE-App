namespace DTO
{
    public class DTO_Reseller
    {
        private int ResellerID;


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



        public DTO_Reseller(int ResellerID) 
        {
            this.ResellerID = ResellerID;
        }
    }
}