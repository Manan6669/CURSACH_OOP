﻿
using Microsoft.EntityFrameworkCore;
//using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text.pdf;          //*iTextSharp
using Syncfusion.Windows.PdfViewer;
using iTextSharp.text.pdf.parser;
using System.Diagnostics;
using iTextSharp.text;
using System.Runtime.InteropServices;
using System.Web;
using System.Reflection;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для ReadPdf.xaml
    /// </summary>
    public partial class ReadPdf : Page
    {
        
        public ReadPdf()
        {
            InitializeComponent();
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                var code = Application.Current.Resources["TT"];
                string shortcode = code.ToString();
                shortcode = shortcode.Remove(0, 5);
                
                
                var sourc = db.Photochepter.Where(p => p.CodeTitle == int.Parse(shortcode)).ToList();
                var k = sourc.Count;
               // FlowDocumentPageViewer[] pg = new FlowDocumentPageViewer[k];
                foreach(Photochepter phch in sourc)
                {
                   // System.Text.Encoding.Default;
                    var pth = phch.PathPhChepter;
                    ReadPdfTitle.Navigated += (sender, args) => { HideScriptErrors((WebBrowser)sender, true); };

                    ReadPdfTitle.Navigate($"{pth}");
                 
                }
            }
        }
        public void HideScriptErrors(WebBrowser ReadPdfTitle, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(ReadPdfTitle);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }

       
       
        private void ButtonIMGPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        

        

        
    }
}
