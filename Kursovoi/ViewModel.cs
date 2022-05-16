using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using iTextSharp.text.pdf;          //*iTextSharp
using Syncfusion.Windows.PdfViewer;
using iTextSharp.text.pdf.parser;
using System.Diagnostics;
using iTextSharp.text;

namespace Kursovoi
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Stream documentStream;

        public event PropertyChangedEventHandler PropertyChanged;

        public Stream DocumentStream
        {
            get { return documentStream; }
            set
            {
                documentStream = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public ViewModel(object sender, RoutedEventArgs e)
         {
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                var code = Application.Current.Resources["TT"];
                string shortcode = code.ToString();
                shortcode = shortcode.Remove(0, 5);

                var sourc = db.Photochepter.FirstOrDefault(p => p.CodeTitle == int.Parse(shortcode));
                var str = sourc.PathPhChepter;
                PdfViewerControl pdfViewer = new PdfViewerControl();
               // HomeGrid.Children.Add(pdfViewer);

                documentStream = new FileStream(str, FileMode.OpenOrCreate);
                //OnPropertyChanged(new RoutedPropertyChangedEventArgs("DocumentStream"));
                //   ReaderPDF.Con(pathch);

                /*  PdfReader pdf_readtit = new PdfReader(pathch);
                  for (int i = 1; i <= pdf_readtit.NumberOfPages; i++)

                  {
                     sText +=  PdfImageObject.Equals(pdf_readtit, i);
                  }*/
                // PDFReader.Source = sText;

                //pdfWebViewer.Navigate(fullPathToPDF);
                // StorageFile file = await StorageFile.GetFileFromPathAsync(pathch);

            }
        }
    }
}
