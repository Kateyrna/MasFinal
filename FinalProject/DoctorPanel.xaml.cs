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

namespace MAS_FinalProject
{
    /// <summary>
    /// Interaction logic for DoctorPanel.xaml
    /// </summary>
    public partial class DoctorPanel : Window
    {
        public DoctorPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new VisitDetails().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ViewAppointments().Show();
            this.Close();
         
        }
    }
}
