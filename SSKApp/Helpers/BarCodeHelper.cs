using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows;
using System.Windows.Shapes;
using QRCoder;
using SSKApp.Helpers.ChromiumObjects;
using static QRCoder.QRCodeData;

namespace SSKApp.Helpers
{
    public static class BarCodeHelper
    {
        public static Bitmap GenerateQRcodeBit(string data)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        return qrCode.GetGraphic(20, Color.Black, Color.White, false);
                    }
                }
            }
        }

        public static void GenerateQRcode(string caseNumber) {

            using (var generator = new QRCodeGenerator())
            {
                using (QRCodeData data = generator.CreateQrCode(caseNumber, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode code = new QRCode(data))
                    {
                        using (Bitmap bitmap = code.GetGraphic(20, Color.Black, Color.White, false))
                        {
                            string qrCodePath = @"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg";
                            using (MemoryStream stream = new MemoryStream())
                            {
                                bitmap.Save(stream, ImageFormat.Jpeg);
                                byte[] byteImage = stream.ToArray();

                                
                                using (Image image = Image.FromStream(new MemoryStream(byteImage)))
                                {
                                    image.Save(qrCodePath, ImageFormat.Jpeg);
                                }


                            }

                            using (Bitmap bmp = new Bitmap(qrCodePath)) {
                                bmp.Save(qrCodePath, ImageFormat.Jpeg);
                            }
                          //  bitmap.Dispose();
                        }

                    }
                }
            }
            //var filePath = @"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg";
            //using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.Read))
            //{

            //    if (File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //    }

            //}

            //using (var ms = new MemoryStream())
            //{
            //    string qrCodePath = @"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg";
            //    Bitmap bitmap = GenerateQRcodeBit(caseNumber);
            //    bitmap.Save(qrCodePath, ImageFormat.Jpeg);
            //    bitmap.Dispose();


            //}
            //string qrCodePath = @"C:\Project\KIOSK_TAISENG\SSKApp\wwwroot\barCode\QR-Code.jpg";
            //var bitmap = GenerateQRcodeBit(caseNumber);
            ////  bitmap.Save(qrCodePath, ImageFormat.Jpeg);


            //bitmap.Save(ms, ImageFormat.Jpeg);
            //byte[] byteImage = ms.ToArray();


            //using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(byteImage)))
            //{
            //    image.Save(qrCodePath, ImageFormat.Jpeg);
            //}
        }
    }
}
