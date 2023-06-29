using MVVM_Pet_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

namespace MVVM_Pet_2.View
{
    /// <summary>
    /// Логика взаимодействия для PetsWindow.xaml
    /// </summary>
    public partial class PetsWindow : Window
    {
        public PetsWindow()
        {
            InitializeComponent();
            DataContext = new PetsWindowViewModel();
        }
    }
}
