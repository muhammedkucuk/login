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
using WpfApplicationLogin.Models;

namespace WpfApplicationLogin
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var a = Diary.Text;
            App.CurrentLog.logs = a;
            App.Repo.SaveChanges();
            UserWindow x = new UserWindow();
            x.liste.ItemsSource = App.CurrentUser.Logs;
            x.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            UserWindow x = new UserWindow();
            x.liste.ItemsSource = App.CurrentUser.Logs;
            x.Show();
            this.Close();
        }

        private string gunluk;

        public string Gunluk
        {
            get { return gunluk; }
            set
            {
                gunluk = value;
                Diary.Text = gunluk;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
