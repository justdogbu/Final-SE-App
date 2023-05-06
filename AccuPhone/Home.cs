using BUS;
using GUI.Properties;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class Home : Form
    {
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

        public Home(string email, string password)
        {
            InitializeComponent();
            acc = new BUS_Accountant(0, "", email, password, 0);
            accountantName = acc.selectName().Rows[0][0].ToString();
            accountantID = (int) acc.selectID().Rows[0][0];
            warehouseID = (int) acc.selectWarehouse().Rows[0][0];
            accountantEmail = email;
            accountantPassword = password;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblName.Text = accountantName;
            lblWarehouse.Text = "Warehouse " + warehouseID.ToString();
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
            panelImport.Visible = false;
            panelComfirm.Visible = false;
            panelEDetails.Visible = false;

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
            panelDashboard.Visible = false;

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
            panelDashboard.Visible = false;
            loadImportBill("Default");
        }

        private void bReceipts_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = true;
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;

            panelDashboard.Visible = true;
            loadDashboard();
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
            if(lblSubtotal.Text == "$NULL" || lblSubtotal.Text == "$0")
            {
                MessageBox.Show("You should update your cart first");
            }
            else
            {
                int id = receipt.getReceiptID();
                int total = int.Parse(lblSubtotal.Text.Substring(1, lblSubtotal.Text.Length - 1));

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

            lblTotal.Text = "$" + total.ToString();
            lblSubtotal.Text = "$" + total.ToString();
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
                cbSorting.Text = "Default";
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
                int number = resellerBill.countReceipt();
                int billID;
                int totalPrice;
                DateTime date;
                int resellerID;
                string resellerName;
                for (int i = 0; i < number; i++)
                {
                    billID = (int)table.Rows[i][0];
                    totalPrice = (int)table.Rows[i][1];
                    date = (DateTime)table.Rows[i][2];
                    resellerID = (int)table.Rows[i][5];
                    Debug.WriteLine(billID + " " + totalPrice + " " + date + " " + resellerID);
                    Bill bill = new Bill();
                    bill._BILLID = billID;
                    bill._TOTAL = totalPrice;
                    bill._DATE = date;
                    reseller = new BUS_Reseller(resellerID);
                    bill._RESELLERNAME = reseller.getShopname();
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
            loadImportBill("Default");
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
            int num = resellerReceiptDetails.countReceipt();
            DataTable table = resellerReceiptDetails.selectReceipt();
            foreach(DataRow row in table.Rows)
            {
                BillDetails billDetails = new BillDetails();
                int phoneID = (int) row[1];
                int quantity = (int) row[2];
                int price = (int) row[3];
                switch (phoneID)
                {
                    case 1:
                        billDetails.Icon = Resources.ip14;
                        billDetails.Name = "iPhone 14";
                        break;
                    case 2:
                        billDetails.Icon = Resources.redmi_note_8;
                        billDetails.Name = "Redmi Note 8";
                        break;
                    case 3:
                        billDetails.Icon = Resources.xiaomi_13;
                        billDetails.Name = "Xiaomi 13";
                        break;
                    case 4:
                        billDetails.Icon = Resources.a343;
                        billDetails.Name = "Samsung Galaxy A34";
                        break;
                    case 5:
                        billDetails.Icon = Resources.images_kv_en_purple_mo_1_png;
                        billDetails.Name = "OPPO Find N2 Flip";
                        break;
                }
                billDetails.BillID = billID;
                billDetails.Number = quantity;
                billDetails.Price = price;
                billDetails.ID = phoneID;
                
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

            lblTotalExport.Text = total.ToString("C");
            lblSubTotalExport.Text = total.ToString("C");
        }

        private bool isSufficient()
        {
            foreach(Control control in fBillDetails.Controls){
                if(control is BillDetails bill && bill.Number > 0)
                {
                    warehouseProducts = new BUS_WarehouseProducts(warehouseID, bill.ID, 0);
                    int quantity = warehouseProducts.selectQuantity();
                    if(bill.Number > quantity)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private int createExportReceipt()
        {
            exportReceipt = new BUS_ExportReceipt(0, 0, "", 0);
            int id = exportReceipt.getReceiptID();
            decimal totalDecimal = decimal.Parse(lblTotalExport.Text, NumberStyles.Currency);
            int totalInt = Decimal.ToInt32(totalDecimal);
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

                    warehouseProducts = new BUS_WarehouseProducts(warehouseID, bill.ID, bill.Number);
                    warehouseProducts.updateQuantity();

                    exportReceiptDetails = new BUS_ExportReceiptDetails(id, bill.ID, bill.Number, bill.Price);
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
    }
}
