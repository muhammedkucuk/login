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
using System.Data.Entity;
using WpfApplicationLogin.Models;

namespace WpfApplicationLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            var user = App.Repo.Users.FirstOrDefault(f => f.name == tbxUserName.Text && f.password == pbxPassword.Password);

            if (user != null)
            {
                App.CurrentUser = user;
                UserWindow a = new UserWindow();
                a.liste.ItemsSource = user.Logs;
                a.Show();
            }
            else
            {
                MessageBox.Show("INVALID!!!");
            }

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var user = App.Repo.Users.FirstOrDefault(f => f.name == tbxUserName.Text);

            if (user != null) MessageBox.Show("username taken!");

            else
            {
                var a = pbxPassword.Password;
                var b = tbxUserName.Text;
                App.Repo.Users.Add(new User { name = b, password = a });
                App.Repo.SaveChanges();
            }
        }
    }
}





