﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        private string key;
        private Window originator;
        public HelpViewer(string key, Window originator)
        {
            InitializeComponent();
            InitializeComponent();
            string curDir = "C:/Users/DELL/Desktop/HCI/SIMS_grupaAMNP/Hospital/Hospital/Help";
            string path = String.Format("{0}/{1}.html", curDir, key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            wbHelp.Source = new Uri(path);

        }
        
        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
    
}
