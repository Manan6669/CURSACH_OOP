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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ShabTitle : Page
    {
        public ShabTitle()
        {
            InitializeComponent();
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                var code = Application.Current.Resources["TT"];
                string shortcode = code.ToString();
                shortcode = shortcode.Remove(0, 5);

                var sourc = db.Title.FirstOrDefault(p => p.CodeTitle == int.Parse(shortcode));

                NameTitle.Text = sourc.NameOfTitle;

                int code2 = sourc.CodeCodeTypeOfComics;
                var ty = db.TypeOfComics.FirstOrDefault(t => t.CodeTypeOfComics == code2);
                string typecom2 = ty.TypeOfComics1;
                type.Text = ty.TypeOfComics1;

                string yaer = sourc.ReleaseDate.ToString();
                yaer = yaer.Remove(0, 6);
                year.Text = yaer.Remove(4, 9);

                int code3 = sourc.CodeAuthor;
                var aut = db.Author.FirstOrDefault(a => a.CodeAuthor == code3);
                string authofcom = aut.Author1;
                auth.Text = authofcom;

                string publish = sourc.Publisher;
                publ.Text = publish;

                string gen = sourc.Genre;
                genre.Text = gen;

                int des = sourc.CodeDescription;
                var decripTitle = db.Description.FirstOrDefault(d => d.CodeDescription == des);
                string descripCom = decripTitle.Description1;
                destit.Text = descripCom;

                var trans = sourc.CodeTranslator;
                var tr = db.Translator.FirstOrDefault(t => t.CodeTranslator == trans);
                string transCom = tr.Translator1;
                translator.Text = transCom;

                string path = Environment.CurrentDirectory + "/PHOTOTITLE/" + $"{sourc.Photo}";
                ImgTit.Source = new BitmapImage(new Uri(path));

                var t = sourc.Link;

                Application.Current.Resources["lk"] = t;


                var LoqUsAd = Application.Current.Resources["AdminEntUser"];
                var PasUsAd = Application.Current.Resources["AdminPassw"];

                // var CodUs = Application.Current.Resources["CodeUser"];
                // var authusers = db.Users.Where(b => b.UsersLoqin == LoqUs.ToString() && b.UsersPassword == PasUs.ToString()).FirstOrDefault();
                if (LoqUsAd.ToString() != "Admin" && PasUsAd.ToString() != "admin")
                {
                    DelBut.Visibility = Visibility.Hidden;
                }
                else
                {
                    DelBut.Visibility = Visibility.Visible;
                }
            

            };
        }
      /*  private void Visab(object sender, RoutedEventArgs e)
        {
           
        }*/
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            var LoqUs = Application.Current.Resources["AdminEntUser"];
            var PasUs = Application.Current.Resources["AdminPassw"];
            var CodUs = Application.Current.Resources["CodeUser"];
            Users authus = null;
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                authus = db.Users.Where(b => b.UsersLoqin == LoqUs.ToString() && b.UsersPassword == PasUs.ToString()).FirstOrDefault();
                //  var sourc = db.Users.FirstOrDefault(s => s.UsersLoqin == LoqUs.ToString() && s.UsersPassword == PasUs.ToString());
                if (authus.UsersLoqin == "Admin" && authus.UsersPassword == "admin")
                {
                    this.NavigationService.Navigate(new Uri("CatalogAdmin.xaml", UriKind.Relative));
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("Catalog.xaml", UriKind.Relative));
                }
            }
        }

        private void LinkClick(object sender, EventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var t = Application.Current.Resources["lk"];
                Process.Start(new ProcessStartInfo("cmd", $"/c start {(string)t}") { CreateNoWindow = true });
            }

        }


        private void AddToBookM_Click(object sender, RoutedEventArgs e)
        {
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                int k = 0;
                var LoqUs = Application.Current.Resources["EntUser"];
                var PasUs = Application.Current.Resources["EntPassw"];
                var CodUs = Application.Current.Resources["CodeUser"];
                var code = Application.Current.Resources["TT"];
                string codd = CodUs.ToString();
                int CodeBook = db.Bookmarks.Max(b => b.CodeBookmarks);
                string shortcode = code.ToString();
                shortcode = shortcode.Remove(0, 5);
                var sas = db.Bookmarks.Where(p => p.UnicCodeUsers == int.Parse(codd)).ToList();
                if (sas != null)
                {
                    foreach (var item in sas)
                    {
                        if (item.CodeTitle == int.Parse(shortcode))
                        {
                            k++;
                        }
                    }

                    if (k == 0)
                    {

                        Bookmarks book = new Bookmarks
                        {
                            CodeBookmarks = CodeBook + 1,
                            UnicCodeUsers = (int)CodUs,
                            CodeTitle = int.Parse(shortcode),

                        };
                        db.Bookmarks.Add(book);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Тако тайтл у е");
                    }


                }






                /*
                                var sourc = db.Title.Select(p => p.CodeTitle == int.Parse(shortcode));
                                var authus = db.Users.Where(b => b.UsersLoqin == LoqUs.ToString() && b.UsersPassword == PasUs.ToString()).FirstOrDefault();
                                var aucode = authus.UnicCodeUsers;
                                //  var sbk = db.Bookmarks.Select(s=>s.CodeTitle);
                                var sbk = db.Bookmarks.FirstOrDefault(s=>s.CodeTitle == int.Parse(shortcode));
                                var cldf = db.Bookmarks.Where(p => EF.Functions.Like(p.CodeTitle.ToString(), $"%{shortcode}%")).ToList();
                                var c = cldf.Count;
                                // var b = sbk.CodeTitle;
                                //int b = sbk.Count();
                                // int sc = sourc.CodeTitle;
                                var sourcBook = db.Bookmarks.Where(b => b.UnicCodeUsers == aucode).ToList();
                                   if ( sourcBook != null)
                                   {
                                    foreach (Bookmarks b in sourcBook)
                                    {
                                        string NameTitUs = NameTitle.Text.Trim();

                                        try
                                        {
                                            Bookmarks book = new Bookmarks
                                            {
                                                CodeBookmarks = CodeBook + 1,
                                                UnicCodeUsers = (int)CodUs,
                                                CodeTitle = int.Parse(shortcode),

                                            };
                                            db.Bookmarks.Add(book);
                                            db.SaveChanges();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error");
                                        }
                                    }
                                   }
                                   else
                                   {
                                       MessageBox.Show("Такой комикс уже есть в закладках!");
                                   }

                           /*     if (sourcBook != null)
                                {
                                    foreach (var s in sourcBook)
                                    {

                                    }
                                }
                           */
            }
        }

        private void ReadPdfTit(object sender, RoutedEventArgs e)
        {
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                var code = Application.Current.Resources["TT"];
                string shortcode = code.ToString();
                shortcode = shortcode.Remove(0, 5);


                var sourc = db.Photochepter.FirstOrDefault(p => p.CodeTitle == int.Parse(shortcode));
                if (sourc.PathPhChepter == null)
                {
                    MessageBox.Show("Глав комикса нет!");
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("ReadPdf.xaml", UriKind.Relative));
                }
            }
        }

        private void DelFromBd_Click(object sender, RoutedEventArgs e)
        {
           
            var code = Application.Current.Resources["TT"];
            string shortcode = code.ToString();
            shortcode = shortcode.Remove(0, 5);
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                var delTit = db.Title.FirstOrDefault(s => s.CodeTitle == int.Parse(shortcode));
                var desc = delTit.CodeDescription;
                var descTit = db.Description.FirstOrDefault(d => d.CodeDescription == desc);
              //  db.Description.Remove(descTit);
                db.Title.Remove(delTit);
                db.SaveChanges();

            }
        }
    }
}
    
