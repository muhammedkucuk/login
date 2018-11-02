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
using System.Data.Entity;
using WpfApplicationLogin.Models;


namespace WpfApplicationLogin
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            UserWindow x = new UserWindow();
            x.liste.ItemsSource = App.CurrentUser.Logs;
            x.Show();
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var a = Diary.Text;
            App.Repo.Logs.Add(new Log { userID = App.CurrentUser.Id, logs = a });
            App.Repo.SaveChanges();
            UserWindow x = new UserWindow();
            x.liste.ItemsSource = App.CurrentUser.Logs;
            x.Show();
            this.Close();
        }
    }
}