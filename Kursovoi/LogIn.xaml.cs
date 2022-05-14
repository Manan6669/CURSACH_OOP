using Microsoft.EntityFrameworkCore;
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

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
             InitializeComponent();
        }
        //private bool authcode;
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            string loqin = User.Text.Trim();
            string password = Password.Password.Trim();

            Users authus = null;
           
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                authus = db.Users.Where(b=>b.UsersLoqin == loqin && b.UsersPassword == password).FirstOrDefault();
                 Application.Current.Resources["AdminEntUser"] = loqin;
                    Application.Current.Resources["AdminPassw"] = password;

                if (authus != null && authus.UsersLoqin == "Admin" && authus.UsersPassword == "admin")
            {
                   

                WindowMainAdmin winm = new WindowMainAdmin();
                winm.Show();
                var window = Application.Current.Windows[0];
                if (window != null)
                window.Close();
            }
            else
            {
                   
                var authcode = authus.UnicCodeUsers;
                Application.Current.Resources["EntUser"] = loqin;
                Application.Current.Resources["EntPassw"] = password;
                Application.Current.Resources["CodeUser"] = authcode;
                WindowMain winm = new WindowMain();
                winm.Show();
                var window = Application.Current.Windows[0];
                if (window != null)
                    window.Close();
            }
            if(authus.UsersLoqin != loqin || authus.UsersPassword != password)
            {
                MessageBox.Show("Неверный логин или пароль!", $"Ошибка");
                LogIn log = new LogIn();
                log.Show();
                var window = Application.Current.Windows[0];
                if (window != null)
                window.Close();

                }
             }   

        }
        private void AdminC (object sender, EventArgs e)
        {

        }
        private void EnterToProgrammWithRegistr(object sender, RoutedEventArgs e)
        {
            using (CURSOVOIContext db = new CURSOVOIContext())
            {
                string loqin = User.Text;
                string password = Password.Password;
                int id = db.Users.Max(m => m.UnicCodeUsers);
                try
                {
                    Users newus = new Users
                    {
                        UsersLoqin = loqin,
                        UsersPassword = password,
                        UnicCodeUsers = id + 1
                    };
                    db.Users.Add(newus);
                    db.SaveChanges();
                    Users user = db.Users.FirstOrDefault((u) => u.UsersLoqin == loqin);
                    MessageBox.Show("Войдите, пожалуйста, снова!", $"Добро пожаловать, {user.UsersLoqin}!");
                    LogIn log = new LogIn();
                    log.Show();
                    var window = Application.Current.Windows[0];
                    if (window != null)
                        window.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка!", $"Неверный логин или пароль!");
                }
            }
        }
    }
}
