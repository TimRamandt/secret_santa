using Logic.Data;
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

namespace Secret_Santa.SubWindows {
    /// <summary>
    /// Interaction logic for ListManagement.xaml
    /// </summary>
    public partial class ListManagement : Window {

        private DataFile dataFile; 
        public ListManagement(DataFile dataFile)
        {
            this.dataFile = dataFile;
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            var mailingWindow = new Mailing();
            mailingWindow.Show();
        }
    }
}
