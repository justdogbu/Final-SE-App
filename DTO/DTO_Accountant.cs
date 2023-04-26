namespace DTO
{
    public class DTO_Accountant
    {
        private int AccountantID, WarehouseID;
        private string AccountantName, AccountantEmail, AccountantPassword;

        public string _ACCOUNTANTNAME {
            get
            {
                return AccountantName;
            }
            set 
            {
                AccountantName = value;
            } 
        }

        public string _ACCOUNTANTEMAIL
        {
            get
            {
                return AccountantEmail;
            }
            set 
            { 
                AccountantEmail = value; 
            }
        }

        public string _ACCOUNTANTPASSWORD
        {
            get
            {
                return AccountantPassword;
            }
            set 
            { 
                AccountantPassword = value; 
            }
        }

        public int _ACCOUNTANTID
        {
            get
            {
                return AccountantID;
            }
            set
            {
                AccountantID = value;
            }
        }

        public int _WAREHOUSEID
        {
            get
            {
                return WarehouseID;
            }
            set
            {
                WarehouseID = value;
            }
        }

        public DTO_Accountant(int AccountantID, string AccountantName, string AccountantEmail, string AccountantPassword, int WarehouseID) 
        {
            this.AccountantID = AccountantID;
            this.AccountantName = AccountantName;
            this.AccountantEmail = AccountantEmail;
            this.AccountantPassword = AccountantPassword;
            this.WarehouseID = WarehouseID;
        }
    }
}