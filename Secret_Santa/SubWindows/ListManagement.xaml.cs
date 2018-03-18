using Logic.Data;
using Logic.Models;
using Microsoft.Win32;
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
            this.lstParticipants.ItemsSource = this.dataFile.Participants;
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            var mailingWindow = new Mailing();
            mailingWindow.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var nameList = txtNameList.Text;
            if (string.IsNullOrWhiteSpace(nameList)) {
                this.InvalidInputGUI(txtNameList, lblErrorName, "Missing name");
                return;
            }

            this.ResetTextBox(txtNameList);
            lblErrorName.Content = "";

            if (this.dataFile.Path == null) {
                var saveDialog = new SaveFileDialog();
                saveDialog.ShowDialog();
                dataFile.Path = saveDialog.FileName;
            }
            this.dataFile.SaveData();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            this.ResetTextBox(txtName);
            this.ResetTextBox(txtEmail);
            lblErrorAdd.Content = string.Empty;

            bool valid = true;
            var name = txtName.Text;
            if(string.IsNullOrEmpty(name)) {
                this.InvalidInputGUI(txtName, lblErrorAdd, "Name can not be empty.");
                valid = false;
            }

            if(this.dataFile.Participants.Any(p => p.Name == name))
            {
                this.InvalidInputGUI(txtName, lblErrorAdd, $"{name} is already registered.");
                valid = false;
            }

            var email = txtEmail.Text;
            if (!FileParser.ValidEmailAddress(email)) {
                this.InvalidInputGUI(txtEmail, lblErrorAdd, "Invalid e-mail.");
                valid = false;
            }

            if(this.dataFile.Participants.Any(p => p.Email == email))
            {
                this.InvalidInputGUI(txtEmail, lblErrorAdd, $"{email} is already registered.");
                valid = false;
            }

            if (valid) {
                this.dataFile.AddParticipant(new Participant() {
                    Name = name,
                    Email = email
                });
                txtEmail.Clear();
                txtName.Clear();
            }
        }


        private void InvalidInputGUI(TextBox textBox, Label errorLabel, string errorText)
        {
            textBox.Background = Brushes.LightPink;
            errorLabel.Content += errorText + '\n';
            textBox.Clear();
        }

        private void ResetTextBox(TextBox textBox)
        {
            textBox.Background = Brushes.White;
        }
        
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btwRemove_Click(object sender, RoutedEventArgs e)
        {
            var participant = lstParticipants.SelectedItem as Participant;
            if (participant == null) return;

            this.dataFile.RemoveParticipant(participant);
            
        }
    }
}
