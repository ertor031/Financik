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

namespace Financik.View
{
    /// <summary>
    /// Логика взаимодействия для LogReg.xaml
    /// </summary>
    public partial class LogReg : Window
    {
        public LogReg()
        {
            InitializeComponent();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Checkboxer.IsChecked == true)
            {

                Authorisation.IsEnabled = true;
                Regestration.IsEnabled = true;
            }
            else
            {
                Authorisation.IsEnabled = false;
                Regestration.IsEnabled = false;
            }
        }

        private void Regestration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
