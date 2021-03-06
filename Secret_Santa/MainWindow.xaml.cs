﻿using Logic.Data;
using Microsoft.Win32;
using Secret_Santa.SubWindows;
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

namespace Secret_Santa {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewList(object sender, RoutedEventArgs e)
        {
            this.OpenListManagement();
        }

        private void ExistingList(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            this.OpenListManagement(fileDialog.FileName);
        }

        private void OpenListManagement(string filePath = "")
        {
            var window = (filePath == "") ? 
                new ListManagement(new DataFile()) : new ListManagement(new DataFile(filePath)); 
            window.Show();
            this.Close();
        }
    }
}
