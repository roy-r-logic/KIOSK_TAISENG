using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Helpers.Libraries.Printer
{
    public class MasungPrinterManagementHelper:MasungPrint
    {
        private static MasungPrintConfiguration _config;

        public static void Print(MasungPrintConfiguration config, string printerName)
        {
            _config = new MasungPrintConfiguration();
            _config = config;

            PrintDocument ptdoc = new PrintDocument();
            ptdoc.DocumentName = string.Empty;
            ptdoc.DefaultPageSettings.Margins.Bottom = _config.BottomPadding;

            if(!string.IsNullOrEmpty(printerName))
            {
                ptdoc.PrinterSettings.PrinterName = printerName;
            }

          //  purpose 10000 is for print roll papar, change 10000 to 300 for print A4 size paper, if not printer will hang
            switch (_config.PaperSize)
            {
                case MasungPaperSize.A4Paper: PaperSize a4Size = new PaperSize("210 x 297 mm", 1000, 1100); ptdoc.DefaultPageSettings.PaperSize = a4Size; break;
                case MasungPaperSize.Receipt80mm: PaperSize receipt80mm = _config.Orientation == MasungOrientation.Potrait ? new PaperSize("Report Size", 280, 10000) : new PaperSize("Report Size", 380, 10000); ptdoc.DefaultPageSettings.PaperSize = receipt80mm; break;
                case MasungPaperSize.Receipt60mm: PaperSize recept60mm = _config.Orientation == MasungOrientation.Landscape ? new PaperSize("Label Size", 236, 110) : new PaperSize("Report Size", 380, 10000); ptdoc.DefaultPageSettings.PaperSize = recept60mm; break;
            }

            switch (_config.Orientation)
            {
                case MasungOrientation.Potrait: ptdoc.DefaultPageSettings.Landscape = false; break;
                case MasungOrientation.Landscape: ptdoc.DefaultPageSettings.Landscape = true; break;
            }

            ptdoc.PrintPage += new PrintPageEventHandler(MasungPrintPage);
            ptdoc.PrintController = new StandardPrintController();

            if (ptdoc.PrinterSettings.IsValid)
            {
                ptdoc.Print();
            }

            ResetAxis();
        }

        private static void MasungPrintPage(object sender, PrintPageEventArgs ev)
        {
            MasungPrintLineBreak(ev, _config.TopPadding);

            if (_config.Logo != null)
            {
                MasungPrintImage(ev, _config.Logo, MasungAlignment.Center);
            }

            FontStyle fontStyle;
            Font font;

            //Add header
            if (_config.HeaderContent != null)
            {
                using (StringReader reader = new StringReader(_config.HeaderContent))
                {
                    fontStyle = _config.IsHeaderBold ? FontStyle.Bold : FontStyle.Regular;
                    font = new Font(GetDescription(_config.HeaderFont), _config.HeaderFontSize, fontStyle);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        MasungPrintLine(ev, font, line, _config.HeaderAlignment, _config.IsHeaderJustify);
                    }
                }

                if(_config.IsHeaderSeperate)
                {
                    MasungPrintSeparator(ev);
                }
            }

            if (_config.BodyContent != null)
            {
                //Add content
                fontStyle = _config.IsBodyBold ? FontStyle.Bold : FontStyle.Regular;
                font = new Font(GetDescription(_config.BodyFont), _config.BodyFontSize, fontStyle);
                MasungPrintContentLine(ev, font, _config.BodyContent, _config.BodyAlignment, _config.IsBodyJustify);

                if(_config.IsBodySeperate)
                {
                    MasungPrintSeparator(ev);
                }
            }

            if (_config.FooterContent != null)
            {
                //Add footer
                using (StringReader reader = new StringReader(_config.FooterContent))
                {
                    fontStyle = _config.IsFooterBold ? FontStyle.Bold : FontStyle.Regular;
                    font = new Font(GetDescription(_config.FooterFont), _config.FooterFontSize, fontStyle);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        MasungPrintLine(ev, font, line, _config.FooterAlignment, _config.IsFooterJustify);
                    }
                }
            }
        }
    }

    public class MasungPrint
    {
        public static int xAxis = 0;
        public static int yAxis = 0;

        public static void MasungPrintLine(PrintPageEventArgs ev, Font font, string content, MasungAlignment alignment, bool isJustify)
        {
            var format = new StringFormat() { Alignment = StringAlignment.Near };

            switch (alignment)
            {
                case MasungAlignment.Left: format.Alignment = StringAlignment.Near; break;
                case MasungAlignment.Center: format.Alignment = StringAlignment.Center; break;
                case MasungAlignment.Right: format.Alignment = StringAlignment.Far; break;
            }

            Rectangle displayRectangle = new Rectangle(new Point(0, yAxis), new Size(ev.PageBounds.Width, (int)font.GetHeight(ev.Graphics) + 1));

            if (isJustify)
            {
                string[] words = content.Split(' ');
                MasungDrawJustifiedLine(ev.Graphics, displayRectangle, font, new SolidBrush(Color.Black), words);
            }
            else
            {
                ev.Graphics.DrawRectangle(Pens.Transparent, displayRectangle);
                ev.Graphics.DrawString(content, font, new SolidBrush(Color.Black), displayRectangle, format);
            }

            yAxis += (int)font.GetHeight(ev.Graphics) + 4;
        }

        public static void MasungPrintContentLine(PrintPageEventArgs ev, Font font, List<string[]> content, MasungAlignment alignment, bool isJustify)
        {
            var format = new StringFormat() { Alignment = StringAlignment.Near };

            switch (alignment)
            {
                case MasungAlignment.Left: format.Alignment = StringAlignment.Near; break;
                case MasungAlignment.Center: format.Alignment = StringAlignment.Center; break;
                case MasungAlignment.Right: format.Alignment = StringAlignment.Far; break;
            }

            foreach (var item in content)
            {
                if(item != null)
                {
                    Rectangle displayRectangle = new Rectangle(new Point(0, yAxis), new Size(ev.PageBounds.Width, (int)font.GetHeight(ev.Graphics) + 1));

                    if (isJustify)
                    {
                        MasungDrawJustifiedLine(ev.Graphics, displayRectangle, font, new SolidBrush(Color.Black), item);
                    }
                    else
                    {
                        string text = String.Join("", item);
                        ev.Graphics.DrawRectangle(Pens.Transparent, displayRectangle);
                        ev.Graphics.DrawString(text, font, new SolidBrush(Color.Black), displayRectangle, format);
                    }
                    yAxis += (int)font.GetHeight(ev.Graphics) + 4;
                }
                else
                {
                    MasungPrintLineBreak(ev, 15);
                }
            }
        }

        public static void MasungDrawJustifiedLine(Graphics gr, RectangleF rect, Font font, Brush brush, string[] words)
        {
            // Add a space to each word and get their lengths.
            float[] word_width = new float[words.Length];
            float total_width = 0;
            for (int i = 0; i < words.Length; i++)
            {
                // See how wide this word is.
                SizeF size = gr.MeasureString(words[i], font);
                word_width[i] = size.Width;
                total_width += word_width[i];
            }

            // Get the additional spacing between words.
            float extra_space = rect.Width - total_width;
            int num_spaces = words.Length - 1;
            if (words.Length > 1) extra_space /= num_spaces;

            // Draw the words.
            float x = rect.Left;
            float y = rect.Top;
            for (int i = 0; i < words.Length; i++)
            {
                // Draw the word.
                gr.DrawString(words[i], font, brush, x, y);

                // Move right to draw the next word.
                x += word_width[i] + extra_space;
            }
        }

        public static void MasungPrintSeparator(PrintPageEventArgs ev)
        {
            Pen horizontalPen = new Pen(Color.Black, 1);
            ev.Graphics.DrawLine(horizontalPen, xAxis, yAxis, ev.PageBounds.Width, yAxis);
            yAxis += 4;
        }

        public static void MasungPrintLineBreak(PrintPageEventArgs ev, int breakSize, int lineCount = 1)
        {
            for (int i = 0; i < lineCount; i++)
            {
                yAxis += breakSize;
            }
        }

        public static void MasungPrintImage(PrintPageEventArgs ev, Bitmap image, MasungAlignment alignment)
        {
            if (image != null)
            {
                int nX;
                //if (DCPublic.m_config != null) nX = Convert.ToInt32(DCPublic.m_config.GetString("PRINT", "logo_left"));
                nX = (ev.PageBounds.Width - image.Width) / 2;
                ev.Graphics.DrawImage(image, nX, yAxis, image.Width, image.Height);
                yAxis += image.Height;
                MasungPrintLineBreak(ev, 4);
            }
        }

        #region Alignment Function
        public static string ProcessLine(string line, MasungAlignment alignment, float pageWidth, float fontWidth)
        {
            switch (alignment)
            {
                case MasungAlignment.Left: line = LeftAline(line, 1); break;
                case MasungAlignment.Center: line = CenterAline(line, 30); break;
                case MasungAlignment.Right: line = RightAline(line, 1); break;
            }

            return line;
        }

        public static string LeftAline(string src, int byte_len)
        {
            string des = src;
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(src);
            int dl = byte_len - buf.Length;

            for (int i = 0; i < dl; i++)
            {
                des += " ";
            }
            return des;
        }

        public static string RightAline(string src, int byte_len)
        {
            string des = src;
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(src);
            int dl = byte_len - buf.Length;

            for (int i = 0; i < dl; i++)
            {
                des = " " + des;
            }
            return des;
        }

        public static string CenterAline(string src, int byte_len)
        {
            string des = src;
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(src);
            int dl = (byte_len - buf.Length) / 2;
            var mod = (byte_len - buf.Length) % 2;

            for (int i = 0; i < dl + mod; i++)
            {
                des = " " + des;
            }
            return des.PadRight(byte_len);
        }
        #endregion

        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                                Attribute.GetCustomAttribute(field,
                                typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static void ResetAxis()
        {
            xAxis = 0;
            yAxis = 0;
        }
    }

    public class MasungPrintConfiguration
    {
        public Bitmap Logo { get; set; }
        public int TopPadding { get; set; } = 0;
        public int BottomPadding { get; set; } = 0;
        public MasungOrientation Orientation { get; set; } = MasungOrientation.Potrait;

        public MasungPaperSize PaperSize { get; set; } = MasungPaperSize.A4Paper;

        #region Header
        public string HeaderContent { get; set; }
        public MasungPrintFont HeaderFont { get; set; }
        public MasungAlignment HeaderAlignment { get; set; }
        public int HeaderFontSize { get; set; }
        public bool IsHeaderJustify { get; set; } = false;
        public bool IsHeaderBold { get; set; } = false;
        public bool IsHeaderSeperate { get; set; } = false;
        #endregion

        #region Body



        public List<string[]> BodyContent { get; set; }
        public MasungPrintFont BodyFont { get; set; }
        public MasungAlignment BodyAlignment { get; set; }
        public int BodyFontSize { get; set; }
        public bool IsBodyJustify { get; set; } = false;
        public bool IsBodyBold { get; set; } = false;
        public bool IsBodySeperate { get; set; } = false;
        #endregion

        #region Footer
        public string FooterContent { get; set; }
        public MasungPrintFont FooterFont { get; set; }
        public MasungAlignment FooterAlignment { get; set; }
        public int FooterFontSize { get; set; }
        public bool IsFooterJustify { get; set; } = false;
        public bool IsFooterBold { get; set; } = false;
        #endregion

        public bool HasCustomerCopy { get; set; } = false;
    }

    public enum MasungPrintFont
    {
        [Description("Times New Roman")]
        TimesNewRoman,
        [Description("Arial")]
        Arial,
        [Description("Cambria")]
        Cambria,
        [Description("Consolas")]
        Consolas


    }

    public enum MasungAlignment
    {
        Left,
        Center,
        Right
    }

    public enum MasungOrientation
    {
        Potrait,
        Landscape
    }

    public enum MasungPaperSize
    {
        Receipt80mm,
        Receipt60mm,
        A4Paper
    }
}
