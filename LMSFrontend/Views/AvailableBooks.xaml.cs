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
using LMSFrontend.ViewModel;

namespace LMSFrontend.Views
{
    /// <summary>
    /// Interaction logic for AvailableBooks.xaml
    /// </summary>
    public partial class AvailableBooks : Window
    {
        public AvailableBooks()
        {
            InitializeComponent();
            var viewModel = new AvailableBooksViewModel();
            DataContext = viewModel;
            viewModel.LoadAvailableBooks();
        }
    }
}
