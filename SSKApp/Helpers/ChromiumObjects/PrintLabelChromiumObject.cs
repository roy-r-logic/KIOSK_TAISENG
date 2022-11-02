using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;

namespace SSKApp.Helpers.ChromiumObjects
{
    public class FileContent
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
    }

    public class PrintLabelChromiumObject
    {

        public string Name { get; set; }
        public string Contact { get; set; }
        public string CaseNumber { get; set; }
        public string Serial { get; set; }
        public string WarrantyType { get; set; }


        public async Task Print(string name, string contact, string caseNumber, string serial, string warrantyType)
        {

            this.Name = name;
            this.Contact = contact;
            this.CaseNumber = caseNumber;
            this.Serial = serial;
            this.WarrantyType = warrantyType;

            if (string.IsNullOrWhiteSpace(this.CaseNumber))
            {
                CaseNumber = "SGLV202200164";
            }

           // BarCodeHelper.GenerateQRcode(this.CaseNumber);

            var printerSetting = new PrinterSettings(); //get default printer name
            var document = new PrintDocument();
            PrintController printController = new StandardPrintController();
            document.PrintController = printController; // hide print dialog
            document.PrinterSettings.PrinterName = printerSetting.PrinterName;
            document.DefaultPageSettings.PaperSize = new PaperSize("Custom", 410, 311);
            document.PrintPage += document_PrintPage;
            document.Print();


            //await Task.CompletedTask;

            //MasungPrintConfiguration config = new MasungPrintConfiguration();

            //config.HeaderContent = "*** Welcome to Orchid Country Club ***\n" + Properties.Settings.Default.TerminalName + "\nGST Reg No: M4-0005809-01";
            //config.HeaderFont = MasungPrintFont.TimesNewRoman;
            //config.HeaderFontSize = 8;

            //config.HeaderAlignment = MasungAlignment.Center;

            //var stringArr = new List<string[]>();

            //stringArr.Add(new string[] { string.Format("{0,-22}", "Transaction Type"), "  ",
            //        string.Format("{0,-35}", ":" + "Card Top Up") });
            //stringArr.Add(new string[] { string.Format("{0,-22}", "Payment Mode"), "  ",
            //        string.Format("{0,-35}", ":" + "NA") });
            //stringArr.Add(new string[] {
            //        string.Format("{0,-22}", "Date Time"), "  ", string.Format("{0,-35}",
            //        ":" + DateTime.Now.ToString("dd/MM/yyyy"))
            //    });

            //config.IsBodyJustify = false;
            //config.BodyContent = stringArr;
            //config.BodyFont = MasungPrintFont.Consolas;
            //config.BodyFontSize = 9;
            //config.FooterFont = MasungPrintFont.TimesNewRoman;
            //config.FooterFontSize = 9;
            //config.FooterAlignment = MasungAlignment.Left;
            //config.PaperSize = MasungPaperSize.Receipt60mm;
            //config.BottomPadding = 3;


            //MasungPrinterManagementHelper.Print(config, "ZDesigner TLP 2844 (Copy 1)");

            await Task.CompletedTask;

        }


        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            var guid_qrcode = Guid.NewGuid().ToString();
            //using (var ms = new MemoryStream())
            //{
            //    string qrCodePath = @"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg";
            //    var bitmap = BarCodeHelper.Generate(CaseNumber);
            //    bitmap.Save(qrCodePath, ImageFormat.Jpeg);

            //}

            var graphics = e.Graphics;

            var lineHeight = 2;
            //var normalFont = new Font("Calibri", 14);

            Font normalFont = new Font("Calibri", 16, FontStyle.Regular, GraphicsUnit.Pixel);

            var pageBounds = e.MarginBounds;
            var drawingPoint = new PointF(0, -10);



            Rectangle m = e.MarginBounds;
            m.Height = 150;
            m.Width = 150;

            //m.Left = 150;
            //m.Right = 150;
            //m.Top = 150;
            //m.Bottom = 150;


            System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg");
            Bitmap myBitmap1 = new Bitmap(img.Width, img.Height);
            Point loc = new Point(100, 100);
            graphics.DrawImage(img, new Rectangle(50, 20, 130, 130), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            myBitmap1.Dispose();
            drawingPoint.Y += 170;
            // 
            //graphics.DrawString(string.Format("Name : {0}",Name), normalFont, Brushes.Black, drawingPoint);
            //drawingPoint.Y += normalFont.Height;

            //graphics.DrawString(string.Format("Contact: {0}",Contact), normalFont, Brushes.Black, drawingPoint);
            //drawingPoint.Y += normalFont.Height;
            //graphics.DrawImage();
            var a = new PointF(0, -10);
            a.Y = drawingPoint.Y + 8;
            a.X = 10;
            graphics.DrawString("Case Number: ", normalFont, Brushes.Black, a);
            drawingPoint.X = 110;
            graphics.DrawString(CaseNumber, new Font("Calibri", 25, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            drawingPoint.Y += normalFont.Height;
            drawingPoint.Y += 10;

            drawingPoint.X = 0;
            var c = new PointF(0, -10);
            c.Y = drawingPoint.Y + 8;
            c.X = 10;
            graphics.DrawString("Serial: ", normalFont, Brushes.Black, c);
            drawingPoint.X = 110;
            graphics.DrawString(Serial, new Font("Calibri", 25, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            drawingPoint.Y += normalFont.Height;
            drawingPoint.Y += 10;

            drawingPoint.X = 0;
            var b = new PointF(0, -10);
            b.Y = drawingPoint.Y + 8;
            b.X = 10;
            graphics.DrawString("Warranty Type: ", normalFont, Brushes.Black, b);
            drawingPoint.X = 110;
            if (WarrantyType == "IW")
            {
                graphics.DrawString("In Warranty", new Font("Calibri", 25, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            }
            else if (WarrantyType == "OW")
            {
                graphics.DrawString("Out Warranty", new Font("Calibri", 25, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            }

            drawingPoint.Y += normalFont.Height;
            drawingPoint.Y += 10;



            drawingPoint.X = 10;
            graphics.DrawString("I acknowledged that all my personal data and self-", new Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            drawingPoint.Y += 10;
            drawingPoint.X = 10;
            graphics.DrawString("installed software will be lost during repair. ", new Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            drawingPoint.X = 0;
            drawingPoint.Y += normalFont.Height;
            drawingPoint.Y += 10;

            drawingPoint.X = 30;
            graphics.DrawString(@"Sign:", normalFont, Brushes.Black, drawingPoint);
            drawingPoint.X = 70;
            graphics.DrawRectangle(Pens.Black, drawingPoint.X, drawingPoint.Y + 20, 150, 1);
            drawingPoint.Y += normalFont.Height;
            drawingPoint.Y += normalFont.Height;

            drawingPoint.X = 20;
            graphics.DrawRectangle(Pens.Black, drawingPoint.X - 5, drawingPoint.Y, 230, 40);
            drawingPoint.Y += 5;
            //drawingPoint.X = 30;
            graphics.DrawString(@"Collect By: ", new Font("Calibri", 18, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, drawingPoint);
            drawingPoint.Y += normalFont.Height;






            //string infoString = "";  // enough space for one line of output
            //int ascent;             // font family ascent in design units
            //float ascentPixel;      // ascent converted to pixels
            //int descent;            // font family descent in design units
            //float descentPixel;     // descent converted to pixels
            //int lineSpacing;        // font family line spacing in design units
            //float lineSpacingPixel; // line spacing converted to pixels

            //FontFamily fontFamily = new FontFamily("Arial");
            //Font font = new Font(
            //   fontFamily,
            //   16, FontStyle.Regular,
            //   GraphicsUnit.Pixel);
            //PointF pointF = new PointF(10, 10);
            //SolidBrush solidBrush = new SolidBrush(Color.Black);

            //// Display the font size in pixels.
            //infoString = "font.Size returns " + font.Size + ".";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            //// Move down one line.
            //pointF.Y += font.Height;

            //// Display the font family em height in design units.
            //infoString = "fontFamily.GetEmHeight() returns " +
            //   fontFamily.GetEmHeight(FontStyle.Regular) + ".";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            //// Move down two lines.
            //pointF.Y += 2 * font.Height;

            //// Display the ascent in design units and pixels.
            //ascent = fontFamily.GetCellAscent(FontStyle.Regular);

            //// 14.484375 = 16.0 * 1854 / 2048
            //ascentPixel =
            //   font.Size * ascent / fontFamily.GetEmHeight(FontStyle.Regular);
            //infoString = "The ascent is " + ascent + " design units, " + ascentPixel +
            //   " pixels.";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            //// Move down one line.
            //pointF.Y += font.Height;

            //// Display the descent in design units and pixels.
            //descent = fontFamily.GetCellDescent(FontStyle.Regular);

            //// 3.390625 = 16.0 * 434 / 2048
            //descentPixel =
            //   font.Size * descent / fontFamily.GetEmHeight(FontStyle.Regular);
            //infoString = "The descent is " + descent + " design units, " +
            //   descentPixel + " pixels.";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            //// Move down one line.
            //pointF.Y += font.Height;

            //// Display the line spacing in design units and pixels.
            //lineSpacing = fontFamily.GetLineSpacing(FontStyle.Regular);

            //// 18.398438 = 16.0 * 2355 / 2048
            //lineSpacingPixel =
            //font.Size * lineSpacing / fontFamily.GetEmHeight(FontStyle.Regular);
            //infoString = "The line spacing is " + lineSpacing + " design units, " +
            //   lineSpacingPixel + " pixels.";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            e.HasMorePages = false; // No pages after this page.
        }
    }

}
