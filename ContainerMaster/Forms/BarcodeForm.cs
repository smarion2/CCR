using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;

namespace CCR
{
    public partial class BarcodeForm : Form
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        public BarcodeForm()
        {
            InitializeComponent();
            b.IncludeLabel = true;
            b.LabelFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        }

        int width = 300;
        int height = 150;
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UPCA;
        private void previewButton_Click(object sender, EventArgs e)
        {
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.LabelFont = new Font("Microsoft Sans Serif", Convert.ToInt32(fontTextBox.Text), FontStyle.Bold);

            width = Convert.ToInt32(widthTextBox.Text.Trim());
            height = Convert.ToInt32(heightTextBox.Text.Trim());
            switch (encodingComboBox.SelectedItem.ToString().Trim())
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 39 Mod 43": type = BarcodeLib.TYPE.CODE39_Mod43; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: MessageBox.Show("Please specify the encoding type."); break;
            }

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {

                    // for each item in CSV create encode of barcode
                    barcode.BackgroundImage = b.Encode(type, "12345678965", width, height);
                }
                barcode.Location = new Point((this.barcode.Location.X + this.barcode.Width / 2) - barcode.Width / 2, (this.barcode.Location.Y + this.barcode.Height / 2) - barcode.Height / 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // open csv file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);
                
                // open save dialog after open dialog
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
                sfd.FilterIndex = 4;
                                
                //sfd.AddExtension = false;
                BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.UNSPECIFIED;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: /* BMP */  savetype = BarcodeLib.SaveTypes.BMP; break;
                        case 2: /* GIF */  savetype = BarcodeLib.SaveTypes.GIF; break;
                        case 3: /* JPG */  savetype = BarcodeLib.SaveTypes.JPG; break;
                        case 4: /* PNG */  savetype = BarcodeLib.SaveTypes.PNG; break;
                        case 5: /* TIFF */ savetype = BarcodeLib.SaveTypes.TIFF; break;
                        default: break;
                    }
                    // foreach item in csv create barcode.
                }

                using (CsvReader csv = new CsvReader(
                                      new StreamReader(filePath), false))
                {
                    DataTable csvTable = new DataTable();
                    csvTable.Load(csv);

                    // count records and insert unique key to each row
                    foreach (DataRow row in csvTable.Rows)
                    {
                        string path = Path.GetDirectoryName(sfd.FileName) + "\\";
                        string ext = Path.GetExtension(sfd.FileName);
                        string newName = path + row[0].ToString() + ext;
                        b.Encode(type, row[0].ToString(), width, height);
                        b.SaveImage(newName, savetype);
                    }
                }
            }
        }
    }
}
