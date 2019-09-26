﻿using System;
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

namespace ConfigurationControlLib.Views
{
    /// <summary>
    /// Interaction logic for MonitorConfigurationView.xaml
    /// </summary>
    public partial class MonitorConfigurationView : UserControl
    {
        public MonitorConfigurationView()
        {
            InitializeComponent();
        }


        private void AddMonitorClosePopUpButton_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }

        private void btnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnShowPopup)
            {
                myPopup.IsOpen = true;
            }
        }
    }
}
