using BUS;
using GUI.Properties;
using iTextSharp.text.pdf;
using iTextSharp.text;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class Home : Form
    {
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
        PrintPreviewDialog printPreviewDialog3 = new PrintPreviewDialog();
        PrintPreviewDialog printPreviewDialog4 = new PrintPreviewDialog();
        PrintDocument printDocument1 = new PrintDocument();
        PrintDocument printDocument2 = new PrintDocument();
        PrintDocument printDocument3 = new PrintDocument();
        PrintDocument printDocument4 = new PrintDocument();
        BUS_ExportReceiptDetails exportReceiptDetails;
        BUS_ExportReceipt exportReceipt;
        BUS_ResellerImportReceiptDetails resellerReceiptDetails;
        BUS_Reseller reseller;
        BUS_ResellerImportReceipt resellerBill;
        BUS_Accountant acc;
        BUS_Receipt receipt;
        BUS_ReceiptDetails receiptDetails;
        BUS_WarehouseProducts warehouseProducts;
        private string accountantName, accountantEmail, accountantPassword;
        private int accountantID, warehouseID;
        public Home()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public Home(string email, string password)
        {
            InitializeComponent();
            acc = new BUS_Accountant(0, "", email, password, 0);
            accountantName = acc.selectName().Rows[0][0].ToString();
            accountantID = (int) acc.selectID().Rows[0][0];
            warehouseID = (int) acc.selectWarehouse().Rows[0][0];
            accountantEmail = email;
            accountantPassword = password;
            loadPhone();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog3.Document = printDocument3;
            printPreviewDialog4.Document = printDocument4;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument2.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage2);
            printDocument3.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage3);
            printDocument4.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage4);

            lblName.Text = accountantName;
            lblWarehouse.Text = "Warehouse " + warehouseID.ToString();
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
            panelImport.Visible = false;
            panelComfirm.Visible = false;
            panelEDetails.Visible = false;
            panelReceipts.Visible = false;
            panelImportReceipt.Visible = false;
            panelExportReceipt.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelPhoneDashboard.Visible = false;
        }


        private void picMenu1_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = true;
        }

        private void picMenu2_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMaximum_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = false;
            panelButtonI.Visible = true;
            panelButtonR.Visible = false;

            panelComfirm.Visible = false;
            panelExport.Visible = false;
            panelImport.Visible = true;
            panelEDetails.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelReceipts.Visible = false;
            panelImportReceipt.Visible = false;
            panelExportReceipt.Visible = false;
            panelDashboard.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelPhoneDashboard.Visible = false;
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = true;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;

            fBillDetails.Controls.Clear();
            panelComfirm.Visible = false;
            panelImport.Visible = false;
            panelExport.Visible = true;
            panelEDetails.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelReceipts.Visible = false;
            panelImportReceipt.Visible = false;
            panelExportReceipt.Visible = false;
            panelDashboard.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelPhoneDashboard.Visible = false;
            cbSorting.Text = "Default";
            //loadImportBill("Default");
        }

        private void bReceipts_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = true;
            panelDashboard.Visible = false;
            panelAccountantDashboard.Visible = false;
            panelPhoneDashboard.Visible = false;
            panelImportReceipt.Visible = false;
            panelExportReceipt.Visible = false;

            panelReceipts.Visible = true;
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;

            panelImport.Visible = false;
            panelExport.Visible = false;
            panelAccountantDashboard.Visible = true;
            panelReceipts.Visible = false;
            panelImportReceipt.Visible = false;
            panelExportReceipt.Visible = false;
            panelDashboard.Visible = true;
            panelAccountantDashboard.Visible = false;
            panelPhoneDashboard.Visible = false;
        }


        private void bImportIP14_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelExport.Visible = false;
            panelComfirm.Visible = true;

            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "iPhone 14")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product iPhone14 = new Product();
            iPhone14.Name = "iPhone 14";
            BUS_Phone ip14Phone = new BUS_Phone(iPhone14.Name);
            iPhone14.Price = ip14Phone.getPrice();
            iPhone14.ID = ip14Phone.getPhoneID();
            iPhone14.Icon = Resources.ip14;
            iPhone14.Number = "1";
            iPhone14.DeleteButtonClicked += UserControl_DeleteButtonClicked;
            fPanelProduct.Controls.Add(iPhone14);

            iPhone14.Index = fPanelProduct.Controls.IndexOf(iPhone14);


        }

        private void bImportRN8_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelExport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Redmi Note 8")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product redmi8 = new Product();
            redmi8.Name = "Redmi Note 8";
            BUS_Phone redmi8Phone = new BUS_Phone(redmi8.Name);
            redmi8.Price = redmi8Phone.getPrice();
            redmi8.ID = redmi8Phone.getPhoneID();
            redmi8.Icon = Resources.redmi_note_8;
            redmi8.Number = "1";
            redmi8.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(redmi8);
            redmi8.Index = fPanelProduct.Controls.IndexOf(redmi8);

        }

        private void UserControl_DeleteButtonClicked(object sender, EventArgs e)
        {
            Product control = sender as Product;
            if (control != null)
            {
                fPanelProduct.Controls.Remove(control);
                updateTotal();
            }
            Debug.WriteLine(lblSubtotal.Text);
        }

        private void panelImport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bImportXiaomi13_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Xiaomi 13")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product xm13 = new Product();
            xm13.Name = "Xiaomi 13";
            BUS_Phone xm13Phone = new BUS_Phone(xm13.Name);
            xm13.Price = xm13Phone.getPrice();
            xm13.ID = xm13Phone.getPhoneID();
            xm13.Icon = Resources.xiaomi_13;
            xm13.Number = "1";
            xm13.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(xm13);
            xm13.Index = fPanelProduct.Controls.IndexOf(xm13);

        }

        private void bImportA34_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Samsung Galaxy A34")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product a34 = new Product();
            a34.Name = "Samsung Galaxy A34";
            BUS_Phone a34Phone = new BUS_Phone(a34.Name);
            a34.Price = a34Phone.getPrice();
            a34.ID = a34Phone.getPhoneID();
            a34.Icon = Resources.a343;
            a34.Number = "1";
            a34.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(a34);
            a34.Index = fPanelProduct.Controls.IndexOf(a34);

        }

        private void bImportN2_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "OPPO Find N2 Flip")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product n2flip = new Product();
            n2flip.Name = "OPPO Find N2 Flip";
            BUS_Phone n2flipPhone = new BUS_Phone(n2flip.Name);
            n2flip.Price = n2flipPhone.getPrice();
            n2flip.ID = n2flipPhone.getPhoneID();
            n2flip.Icon = Resources.images_kv_en_purple_mo_1_png;
            n2flip.Number = "1";
            n2flip.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(n2flip);
            n2flip.Index = fPanelProduct.Controls.IndexOf(n2flip);
        }

        private void bBack_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = true;
            panelComfirm.Visible = false;
        }

        private void bComfirm_Click_1(object sender, EventArgs e)
        {
            receipt = new BUS_Receipt(0, 0, "", 0);
            if(lblSubtotal.Text == "$NULL" || lblSubtotal.Text == "$0" || lblSubtotal.Text == "0 ₫")
            {
                MessageBox.Show("You should update your cart first");
            }
            else
            {
                int id = receipt.getReceiptID();
                int total = int.Parse(lblSubtotal.Text.Replace(".", "").Replace("₫", ""));

                receipt = new BUS_Receipt(id, total, "", accountantID);
                receipt.addQuery();
                clearCart(id);
                lblTotal.Text = "$NULL";
                lblSubtotal.Text = "$NULL";

                panelComfirm.Visible = false;
                panelImport.Visible = true;
            }
            

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            updateTotal();
        }

        private void panelExport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateTotal()
        {
            int total = 0;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && int.Parse(product.Number) > 0)
                {
                    Debug.WriteLine(product.Number);
                    int sum = product.Price * int.Parse(product.Number);
                    total += sum;
                }
            }

            lblTotal.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));

            lblSubtotal.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
        }

        private void cbSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbSorting.SelectedItem.ToString();
            loadImportBill(selectedValue);
        }

        private void clearCart(int id)
        {
            for(int i = fPanelProduct.Controls.Count - 1; i >= 0; i--)
            {   
                Control control = fPanelProduct.Controls[i];
                if(control is Product product)
                {
                    int number = int.Parse(product.Number);
                    receiptDetails = new BUS_ReceiptDetails(id, product.ID, number, product.Price * number);
                    receiptDetails.addQuery();

                    warehouseProducts = new BUS_WarehouseProducts(warehouseID, product.ID, number);
                    int stock = warehouseProducts.selectQuantity();
                    if (stock == -1)
                    {
                        warehouseProducts.addQuery();
                    }
                    else
                    {
                        warehouseProducts = new BUS_WarehouseProducts(warehouseID, product.ID, number + stock);
                        warehouseProducts.updateQuery();
                    }
                    control.Dispose();
                }
            }
        }

        private void loadImportBill(string state)
        {
            fExport.Controls.Clear();
            resellerBill = new BUS_ResellerImportReceipt(0, 0);
            DataTable table = null;

            if (state == "Default")
            {
                table = resellerBill.selectReceipt();
            }
            else if(state == "Descending by Date")
            {
                table = resellerBill.sortDateDesc();
            }
            else if (state == "Ascending by Date")
            {
                table = resellerBill.sortDateAsc();
            }
            else if(state == "Descending by Price")
            {
                table = resellerBill.sortPriceDesc();
            }
            else if(state == "Ascending by Price")
            {
                table = resellerBill.sortPriceAsc();
            }

            if (table != null)
            {
                int number = table.Rows.Count ;
                int billID;
                int totalPrice;
                DateTime date;
                int resellerID;
                string resellerName;
                string payment;
                for (int i = 0; i < number; i++)
                {
                    billID = (int)table.Rows[i][0];
                    totalPrice = (int)table.Rows[i][1];
                    date = (DateTime)table.Rows[i][2];
                    payment = (string)table.Rows[i][3];
                    resellerID = (int)table.Rows[i][5];
                    Debug.WriteLine(billID + " " + totalPrice + " " + date + " " + resellerID);
                    Bill bill = new Bill();
                    bill._BILLID = billID;
                    bill._TOTAL = totalPrice;
                    bill._DATE = date;
                    reseller = new BUS_Reseller(resellerID);
                    bill._RESELLERNAME = reseller.getShopname();
                    bill._PAYMENTMETHOD = payment;
                    bill.ApproveButtonClicked += UserControl_ApproveButtonClicked;
                    bill.Margin = new Padding(10, 10, 35, 35);

                    fExport.Controls.Add(bill);
                    Debug.WriteLine(fExport.Controls.Count);
                }
            }
            
        }

        private void bBackExport_Click(object sender, EventArgs e)
        {
            fBillDetails.Controls.Clear();
            panelExport.Visible = true;
            panelEDetails.Visible = false;
            //loadImportBill("Default");
        }

        private void bApproveExport_Click(object sender, EventArgs e)
        {
            if (!isSufficient())
            {
                MessageBox.Show("Insufficient");
            }
            else
            {
                int exportReceiptID = createExportReceipt();
                insertExportReceiptDetails(exportReceiptID);
                loadImportBill("Default");

                lblTotal.Text = "$NULL";
                lblSubtotal.Text = "$NULL";

                panelEDetails.Visible = false;
                panelExport.Visible = true;
            }
        }

        private void loadBillDetails(int billID)
        {
            panelExport.Visible = false;
            panelEDetails.Visible = true;

            fBillDetails.Controls.Clear();
            resellerReceiptDetails = new BUS_ResellerImportReceiptDetails(billID);
            DataTable table = resellerReceiptDetails.selectReceipt();
            foreach(DataRow row in table.Rows)
            {
                BillDetails billDetails = new BillDetails();
                int phoneID = (int) row[1];
                int quantity = (int) row[2];
                int price = (int) row[3];
                int warehouseID = (int)row[4];
                string name = findPhoneName(phoneID);
                Debug.WriteLine(phoneID);

                billDetails.Icon = findPicture(phoneID);
                billDetails.Name = name;
                billDetails.BillID = billID;
                billDetails.Number = quantity;
                billDetails.Price = price;
                billDetails.ID = phoneID;
                billDetails.WarehouseID = warehouseID;
                
                fBillDetails.Controls.Add(billDetails);
            }

            updateExportTotal();
        }

        private void UserControl_ApproveButtonClicked(object sender, EventArgs e)
        {
            Bill control = sender as Bill;
            if (control != null)
            {
                loadBillDetails(control._BILLID);
            }
        }
        private void panelComfirm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateExportTotal()
        {
            int total = 0;
            foreach (Control control in fBillDetails.Controls)
            {
                if (control is BillDetails bill && bill.Number > 0)
                {
                    Debug.WriteLine(bill.Number);
                    int sum = bill.Price * bill.Number;
                    total += sum;
                }
            }

            lblTotalExport.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
            lblSubTotalExport.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
        }

        private bool isSufficient()
        {
            foreach(Control control in fBillDetails.Controls){
                if(control is BillDetails bill && bill.Number > 0)
                {
                    warehouseProducts = new BUS_WarehouseProducts(bill.WarehouseID, bill.ID, 0);
                    int quantity = warehouseProducts.selectQuantity();
                    if(bill.Number > quantity)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picIP14_Click(object sender, EventArgs e)
        {

        }

        private int createExportReceipt()
        {
            exportReceipt = new BUS_ExportReceipt(0, 0, "", 0);
            int id = exportReceipt.getReceiptID();
            int totalInt = int.Parse(lblTotalExport.Text.Replace(".", "").Replace("₫", ""));
            //decimal totalDecimal = decimal.Parse(lblTotalExport.Text, NumberStyles.Currency);
            //int totalInt = Decimal.ToInt32(totalDecimal);
            Debug.WriteLine(accountantID);
            Debug.WriteLine(accountantName);
            Debug.WriteLine(id + " " + totalInt + " " + accountantID);
            exportReceipt = new BUS_ExportReceipt(id, totalInt, "", accountantID);
            exportReceipt.addQuery();
            return id;
        }

        private void insertExportReceiptDetails(int id)
        {
            int resellerImportID = 0;
            foreach (Control control in fBillDetails.Controls)
            {
                if (control is BillDetails bill && bill.Number > 0)
                {
                    resellerImportID = bill.BillID;

                    warehouseProducts = new BUS_WarehouseProducts(bill.WarehouseID, bill.ID, bill.Number);
                    warehouseProducts.updateQuantity();

                    exportReceiptDetails = new BUS_ExportReceiptDetails(accountantID, id, bill.ID, bill.Number, bill.Price);
                    exportReceiptDetails.addQuery();
                }
            }

            resellerBill = new BUS_ResellerImportReceipt(resellerImportID, 0);
            resellerBill.updateStatus();
        }

        private void loadDashboard()
        {
            acc = new BUS_Accountant(accountantID, accountantName, accountantEmail, accountantPassword, warehouseID);
            grdDashboard.DataSource = acc.selectProfit();

            List<string> labels = new List<string>();
            List<int> export = new List<int>();
            List<int> import = new List<int>();
            int totalExport = 0;
            int totalImport = 0;

            foreach (DataGridViewRow row in grdDashboard.Rows)
            {
                if (!row.IsNewRow)
                {
                    labels.Add(row.Cells[1].Value.ToString().Substring(0, 9));
                    export.Add((int) row.Cells[2].Value);
                    import.Add((int) row.Cells[3].Value);
                    totalExport += (int)row.Cells[2].Value;
                    totalImport += (int)row.Cells[3].Value;

                    Debug.WriteLine(row.Cells[1].Value.ToString());
                }
            }

            cartesianChart1.Series = new ISeries[]{
                new ColumnSeries<int>
                {
                    Values = export,
                    Fill = new SolidColorPaint(SKColors.Blue),
                    Stroke = null,
                    Name = "Income: "

                },
                new ColumnSeries<int>
                {
                    Values = import,
                    Fill = new SolidColorPaint(SKColors.Red),
                    Stroke = null,
                    Name = "Outcome: "
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    TextSize = 20,
                }
            };
            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    TextSize = 20,
                }
            };


            pieChart1.Series = new ISeries[]
            {
                new PieSeries<int>
                {
                    Values = new List<int>{ totalExport },
                    Name = "Income: ",
                    Stroke = null,
                    Fill = new SolidColorPaint(SKColors.Blue),
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int>{ totalImport },
                    Name = "Outcome: ",
                    Fill = new SolidColorPaint(SKColors.Red),
                    Stroke = null,
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,                
                }
            };
        }
        private void LoadImageFromUrl(string imageUrl, out System.Drawing.Image image)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            httpWebRequest.AllowWriteStreamBuffering = true;
            httpWebRequest.Timeout = 30000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream stream = httpWebResponse.GetResponseStream();
            image = System.Drawing.Image.FromStream(stream);

            httpWebResponse.Close();
        }

        private void loadPhone()
        {
            BUS_Phone phones = new BUS_Phone("");
            DataTable table = phones.selectTable();
            foreach(DataRow row in table.Rows)
            {
                Phone phone = new Phone();
                phone.ID = (int) row[0];
                phone.Name = (string) row[1];
                phone.Icon = findPicture(phone.ID);
                phone.Price = (int) row[5];
                phone.ImportButtonClicked += UserControl_ImportButtonCliked;
                phone.Margin = new Padding(10, 10, 35, 35);

                fpanelPhone.Controls.Add(phone);
            }
        }

        private System.Drawing.Image findPicture(int id)
        {
            if(id == 1)
            {
                return Resources.iPhone14;
            }          
            else if(id == 2)
            {
                return Resources.Samsung_Galaxy_S23;
            }
            else if(id == 3)
            {
                return Resources.realme_9;
            }
            else if(id == 4)
            {
                return Resources.realme_10;
            }
            else if (id == 5)
            {
                return Resources.Samsung_Galaxy_S22;
            }
            else if (id == 6)
            {
                return Resources.Samsung_Galaxy_Z_Flip4;
            }
            return Resources.lock_removebg_preview;
        }

        private void grdIR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdIR.CurrentRow != grdIR.Rows[grdIR.Rows.Count - 1])
            {
                int id = (int)grdIR.CurrentRow.Cells[0].Value;
                receiptDetails = new BUS_ReceiptDetails(id);
                DataTable tableIRD = receiptDetails.selectReceiptDetail();
                grdIRD.DataSource = tableIRD;
                grdIRD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            

        }

        private void cbSorting2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbSorting2.SelectedItem.ToString();
            loadImportReceipt(selectedValue);
        }

        private string findPhoneName(int id)
        {
            BUS_Phone phone = new BUS_Phone(id);
            string name = phone.selectName();
            return name;
        }

        private void rbL10_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting2.Text.ToString();
            if(state == "") {
                loadImportReceipt("Default");
                return;
            }
            loadImportReceipt(state);
        }

        private void rbL100_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting2.Text.ToString();
            if (state == "")
            {
                loadImportReceipt("Default");
                return;
            }
            loadImportReceipt(state);
        }

        private void rbG100_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting2.Text.ToString();
            if (state == "")
            {
                loadImportReceipt("Default");
                return;
            }
            loadImportReceipt(state);
        }

        private void bPrintR_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.ShowDialog();
            if (grdIR.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdIR.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdIR.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdIR.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Receipt Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void UserControl_ImportButtonCliked(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelExport.Visible = false;
            panelComfirm.Visible = true;
            Phone thisPhone = (sender as Phone);

            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == thisPhone.Name)
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }


            Product phone = new Product();
            phone.Name = thisPhone.Name;
            //BUS_Phone ip14Phone = new BUS_Phone(iPhone14.Name);
            phone.Price = thisPhone.Price;
            phone.ID = thisPhone.ID;
            phone.Icon = thisPhone.Icon;
            phone.Number = "1";
            phone.DeleteButtonClicked += UserControl_DeleteButtonClicked;
            fPanelProduct.Controls.Add(phone);

            phone.Index = fPanelProduct.Controls.IndexOf(phone);
            updateTotal();
        }

        private void loadImportReceipt()
        {
            receipt = new BUS_Receipt(accountantID);


            DataTable tableIR = receipt.getReceipt();
            grdIR.DataSource = tableIR;
            grdIR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void loadImportReceipt(string state)
        {
            receipt = new BUS_Receipt(accountantID);
            DataTable table = null;

            if (state == "Default")
            {
                if(rbL10.Checked)
                {
                    table = receipt.sortLessThan10();
                }
                else if (rbL100.Checked)
                {
                    table = receipt.sortLessThan100();
                }
                else if (rbG100.Checked)
                {
                    table = receipt.sortGreaterThan100();
                }
                else
                {
                    table = receipt.getReceipt();
                }
            }
            else if (state == "Descending by Date")
            {
                if (rbL10.Checked)
                {
                    table = receipt.sortDateDescLessThan10();
                }
                else if (rbL100.Checked)
                {
                    table = receipt.sortDateDescLessThan100();
                }
                else if (rbG100.Checked)
                {
                    table = receipt.sortDateDescGreaterThan100();
                }
                else
                {
                    table = receipt.sortDateDesc();
                }
            }
            else if (state == "Ascending by Date")
            {
                if (rbL10.Checked)
                {
                    table = receipt.sortDateAscLessThan10();
                }
                else if (rbL100.Checked)
                {
                    table = receipt.sortDateAscLessThan100();
                }
                else if (rbG100.Checked)
                {
                    table = receipt.sortDateAscGreaterThan100();
                }
                else
                {
                    table = receipt.sortDateAsc();
                }
            }
            else if (state == "Descending by Price")
            {
                if (rbL10.Checked)
                {
                    table = receipt.sortPriceDescLessThan10();
                }
                else if (rbL100.Checked)
                {
                    table = receipt.sortPriceDescLessThan100();
                }
                else if (rbG100.Checked)
                {
                    table = receipt.sortPriceDescGreaterThan100();
                }
                else
                {
                    table = receipt.sortPriceDesc();
                }
            }
            else if (state == "Ascending by Price")
            {
                if (rbL10.Checked)
                {
                    table = receipt.sortPriceAscLessThan10();
                }
                else if (rbL100.Checked)
                {
                    table = receipt.sortPriceAscLessThan100();
                }
                else if (rbG100.Checked)
                {
                    table = receipt.sortPriceAscGreaterThan100();
                }
                else
                {
                    table = receipt.sortPriceAsc();
                }
            }

            grdIR.DataSource = table;
            grdIR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void loadExportReceipt(string state)
        {
            exportReceipt = new BUS_ExportReceipt(accountantID);
            DataTable table = null;

            if (state == "Default")
            {
                if (rbLT10.Checked)
                {
                    table = exportReceipt.sortLessThan10();
                }
                else if (rbLT100.Checked)
                {
                    table = exportReceipt.sortLessThan100();
                }
                else if (rbGT100.Checked)
                {
                    table = exportReceipt.sortGreaterThan100();
                }
                else
                {
                    table = exportReceipt.getReceipt();
                }
            }
            else if (state == "Descending by Date")
            {
                if (rbLT10.Checked)
                {
                    table = exportReceipt.sortDateDescLessThan10();
                }
                else if (rbLT100.Checked)
                {
                    table = exportReceipt.sortDateDescLessThan100();
                }
                else if (rbGT100.Checked)
                {
                    table = exportReceipt.sortDateDescGreaterThan100();
                }
                else
                {
                    table = exportReceipt.sortDateDesc();
                }
            }
            else if (state == "Ascending by Date")
            {
                if (rbLT10.Checked)
                {
                    table = exportReceipt.sortDateAscLessThan10();
                }
                else if (rbLT100.Checked)
                {
                    table = exportReceipt.sortDateAscLessThan100();
                }
                else if (rbGT100.Checked)
                {
                    table = exportReceipt.sortDateAscGreaterThan100();
                }
                else
                {
                    table = exportReceipt.sortDateAsc();
                }
            }
            else if (state == "Descending by Price")
            {
                if (rbLT10.Checked)
                {
                    table = exportReceipt.sortPriceDescLessThan10();
                }
                else if (rbLT100.Checked)
                {
                    table = exportReceipt.sortPriceDescLessThan100();
                }
                else if (rbGT100.Checked)
                {
                    table = exportReceipt.sortPriceDescGreaterThan100();
                }
                else
                {
                    table = exportReceipt.sortPriceDesc();
                }
            }
            else if (state == "Ascending by Price")
            {
                if (rbLT10.Checked)
                {
                    table = exportReceipt.sortPriceAscLessThan10();
                }
                else if (rbLT100.Checked)
                {
                    table = exportReceipt.sortPriceAscLessThan100();
                }
                else if (rbGT100.Checked)
                {
                    table = exportReceipt.sortPriceAscGreaterThan100();
                }
                else
                {
                    table = exportReceipt.sortPriceAsc();
                }
            }

            grdER.DataSource = table;
            grdER.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void bPrintRD_Click(object sender, EventArgs e)
        {
            //printPreviewDialog2.ShowDialog();
            if (grdIRD.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdIRD.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdIRD.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdIRD.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Receipt Detail Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            printReceipt(e.Graphics);
        }

        private void printDocument1_PrintPage3(object sender, PrintPageEventArgs e)
        {
            printExportReceipt(e.Graphics);
        }

        private void printDocument1_PrintPage4(object sender, PrintPageEventArgs e)
        {
            printExportReceiptDetail(e.Graphics);
        }
        private void rbLT10_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting3.Text.ToString();
            if (state == "")
            {
                loadExportReceipt("Default");
                return;
            }
            loadExportReceipt(state);
        }

        private void rbLT100_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting3.Text.ToString();
            if (state == "")
            {
                loadExportReceipt("Default");
                return;
            }
            loadExportReceipt(state);
        }

        private void rbGT100_CheckedChanged(object sender, EventArgs e)
        {
            string state = cbSorting3.Text.ToString();
            if (state == "")
            {
                loadExportReceipt("Default");
                return;
            }
            loadExportReceipt(state);
        }

        private void cbSorting3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbSorting3.SelectedItem.ToString();
            loadExportReceipt(selectedValue);
        }

        private void grdER_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdER.CurrentRow != grdER.Rows[grdER.Rows.Count - 1])
            {
                int id = (int)grdER.CurrentRow.Cells[0].Value;
                exportReceiptDetails = new BUS_ExportReceiptDetails(id);
                DataTable tableIRD = exportReceiptDetails.selectExportReceiptDetails();
                grdERD.DataSource = tableIRD;
                grdERD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
        }

        private void printDocument1_PrintPage2(object sender, PrintPageEventArgs e)
        {
            printReceiptDetail(e.Graphics);
        }

        private void printReceipt(Graphics g)
        {
            int cellHeight = 40;
            int cellWidthPadding = 5;
            int cellHeightPadding = 5;

            int y = 0;
            int x = 0;

            for (int i = 0; i < grdIR.RowCount; i++)
            {
                x = 0;
                for (int j = 0; j < grdIR.ColumnCount; j++)
                {
                    System.Drawing.Rectangle cellBounds = new System.Drawing.Rectangle(x, y, grdIR.Columns[j].Width - cellWidthPadding, cellHeight - cellHeightPadding);

                    g.DrawString(grdIR[j, i].FormattedValue.ToString(), grdIR.Font, Brushes.Black, cellBounds);

                    x += grdIR.Columns[j].Width;
                }
                y += cellHeight;
            }
        }

        private void bPrintER_Click(object sender, EventArgs e)
        {
            //printPreviewDialog3.ShowDialog();
            if (grdER.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdER.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdER.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdER.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Receipt Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

        }

        private void bPrintERD_Click(object sender, EventArgs e)
        {
            //printPreviewDialog4.ShowDialog();
            if (grdERD.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdERD.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdERD.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdERD.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if(cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Receipt Detail Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void bImportPanel_Click(object sender, EventArgs e)
        {
            panelReceipts.Visible = false;
            panelImportReceipt.Visible = true;

            loadImportReceipt("Default");
        }

        private void bExportPanel_Click(object sender, EventArgs e)
        {
            panelReceipts.Visible = false;
            panelExportReceipt.Visible = true;

            loadExportReceipt("Default");
        }

        private void printReceiptDetail(Graphics g)
        {
            int cellHeight = 40;
            int cellWidthPadding = 5;
            int cellHeightPadding = 5;

            int y = 0;
            int x = 0;

            for (int i = 0; i < grdIRD.RowCount; i++)
            {
                x = 0;
                for (int j = 0; j < grdIRD.ColumnCount; j++)
                {
                    System.Drawing.Rectangle cellBounds = new System.Drawing.Rectangle(x, y, grdIRD.Columns[j].Width - cellWidthPadding, cellHeight - cellHeightPadding);

                    g.DrawString(grdIRD[j, i].FormattedValue.ToString(), grdIRD.Font, Brushes.Black, cellBounds);

                    x += grdIRD.Columns[j].Width;
                }
                y += cellHeight;
            }
        }

        private void printExportReceipt(Graphics g)
        {
            int cellHeight = 40;
            int cellWidthPadding = 5;
            int cellHeightPadding = 5;

            int y = 0;
            int x = 0;

            for (int i = 0; i < grdER.RowCount; i++)
            {
                x = 0;
                for (int j = 0; j < grdER.ColumnCount; j++)
                {
                    System.Drawing.Rectangle cellBounds = new System.Drawing.Rectangle(x, y, grdER.Columns[j].Width - cellWidthPadding, cellHeight - cellHeightPadding);

                    g.DrawString(grdER[j, i].FormattedValue.ToString(), grdER.Font, Brushes.Black, cellBounds);

                    x += grdER.Columns[j].Width;
                }
                y += cellHeight;
            }
        }

        private void bAccountantDB_Click(object sender, EventArgs e)
        {
            panelDashboard.Visible = false;
            panelAccountantDashboard.Visible = true;

            loadDashboard();
        }

        private void bPhoneDB_Click(object sender, EventArgs e)
        {
            loadPhoneTable();
            loadPhonePie();
            panelDashboard.Visible = false;
            panelPhoneDashboard.Visible = true;
        }

        private void bPrintAccountant_Click(object sender, EventArgs e)
        {
            if (grdDashboard.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdDashboard.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdDashboard.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdDashboard.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Accountant Dashboard Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void bPrintPhoneDB_Click(object sender, EventArgs e)
        {
            if (grdPhone.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grdPhone.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grdPhone.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grdPhone.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Accountant Dashboard Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }


        private void printExportReceiptDetail(Graphics g)
        {
            int cellHeight = 40;
            int cellWidthPadding = 5;
            int cellHeightPadding = 5;

            int y = 0;
            int x = 0;

            for (int i = 0; i < grdERD.RowCount; i++)
            {
                x = 0;
                for (int j = 0; j < grdERD.ColumnCount; j++)
                {
                    System.Drawing.Rectangle cellBounds = new System.Drawing.Rectangle(x, y, grdERD.Columns[j].Width - cellWidthPadding, cellHeight - cellHeightPadding);

                    g.DrawString(grdERD[j, i].FormattedValue.ToString(), grdERD.Font, Brushes.Black, cellBounds);

                    x += grdERD.Columns[j].Width;
                }
                y += cellHeight;
            }
        }

        private void loadPhoneTable()
        {
            BUS_Phone phone = new BUS_Phone();
            DataTable table = phone.selectPhone();

            grdPhone.DataSource = table;
            grdPhone.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void loadPhonePie()
        {
            List<string> labels = new List<string>();
            List<int> export = new List<int>();
            List<int> import = new List<int>();

            foreach (DataGridViewRow row in grdPhone.Rows)
            {
                if (!row.IsNewRow)
                {
                    labels.Add(row.Cells[0].Value.ToString() + ":");
                    if(row.Cells[2].Value != DBNull.Value)
                    {
                        import.Add((int)row.Cells[2].Value);
                    }
                    else
                    {
                        import.Add(0);
                    }
                    if(row.Cells[3].Value != DBNull.Value)
                    {
                        export.Add((int)row.Cells[3].Value);
                    }
                    else
                    {
                        export.Add(0);

                    }
                }
            }

            pieChartImport.Series = new ISeries[]
            {

                new PieSeries<int>
                {
                    Values = new List<int> { import[0] } ,
                    Name = labels[0],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[0]),
                    Fill = new SolidColorPaint(SKColors.Blue),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { import[1] } ,
                    Name = labels[1],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[1]),
                    Fill = new SolidColorPaint(SKColors.Red),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { import[2] } ,
                    Name = labels[2],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[2]),
                    Fill = new SolidColorPaint(SKColors.Purple),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { import[3] } ,
                    Name = labels[3],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[3]),
                    Fill = new SolidColorPaint(SKColors.Yellow),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { import[4] } ,
                    Name = labels[4],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[4]),
                    Fill = new SolidColorPaint(SKColors.Brown),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { import[5] } ,
                    Name = labels[5],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(import[5]),
                    Fill = new SolidColorPaint(SKColors.Green),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
            };
            pieChartExport.Series = new ISeries[]
            {

                new PieSeries<int>
                {
                    Values = new List<int> { export[0] } ,
                    Name = labels[0],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(export[0]),
                    Fill = new SolidColorPaint(SKColors.Blue),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { export[1] } ,
                    Name = labels[1],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(export[1]),
                    Fill = new SolidColorPaint(SKColors.Red),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { export[2] } ,
                    Name = labels[2],
                    Stroke = null,                    
                    IsVisible = Convert.ToBoolean(export[2]),
                    Fill = new SolidColorPaint(SKColors.Purple),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { export[3] } ,
                    Name = labels[3],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(export[3]),
                    Fill = new SolidColorPaint(SKColors.Yellow),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { export[4] } ,
                    Name = labels[4],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(export[4]),
                    Fill = new SolidColorPaint(SKColors.Brown),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
                new PieSeries<int>
                {
                    Values = new List<int> { export[5] } ,
                    Name = labels[5],
                    Stroke = null,
                    IsVisible = Convert.ToBoolean(export[5]),
                    Fill = new SolidColorPaint(SKColors.Green),
                    //DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    //DataLabelsSize = 14,
                    //DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                },
            };

        }


    }
}
