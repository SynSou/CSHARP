using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseNewFontOCRB
{
    public partial class Form1 : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        /// <summary>
        /// OCRBフォント定義
        /// </summary>
        private void CargoPrivateFontCollection()
        {
            // Create the byte array and get its length

            byte[] fontArray = UseNewFontOCRB.Properties.Resources.OCRB;
            int dataLength = UseNewFontOCRB.Properties.Resources.OCRB.Length;


            // ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);


            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            pfc.AddMemoryFont(ptrData, dataLength);



            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);

            //FREE THE  "UNSAFE" MEMORY
            Marshal.FreeCoTaskMem(ptrData);
        }

        /// <summary>
        /// OCRB使うところ
        /// </summary>
        /// <param name="font"></param>
        private void CargoEtiqueta(Font font)
        {
            float size = 9f;
            FontStyle fontStyle = FontStyle.Regular;

            this.textBox1.Font = new Font(ff, size, fontStyle);
        }

        public Form1()
        {
            InitializeComponent();
            //20160204 WANG.XIANSHOU ADD BEGIN
            //ORCBフォント対応
            CargoPrivateFontCollection();
            CargoEtiqueta(font);
            //20160204 WANG.XIANSHOU ADD END

        }
    }
}
