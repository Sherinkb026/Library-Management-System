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
using LMSAPI.Models;
using LMSFrontend.ViewModel;

namespace LMSFrontend.Views
{
    /// <summary>
    /// Interaction logic for UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow(Books selectedBook)
        {
            InitializeComponent();
            DataContext = new UserInfoViewModel(selectedBook);
        }
    }
}
