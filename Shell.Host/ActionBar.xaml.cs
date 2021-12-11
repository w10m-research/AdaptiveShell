﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Management.Deployment;
using Windows.System;

namespace Shell.Host {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ActionBar : Window {
        public ActionBar() {
            this.InitializeComponent();

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = SystemParameters.VirtualScreenHeight - Functions.ACTIONBAR_HEIGHT;
        }

        private void Window_Loaded(Object sender, RoutedEventArgs e) {
            var wndHelper = new WindowInteropHelper(this);

            Int32 exStyle = (Int32)WinAPI.GetWindowLong(wndHelper.Handle, (Int32)WinAPI.GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (Int32)WinAPI.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            WinAPI.SetWindowLong(wndHelper.Handle, (Int32)WinAPI.GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

        private void BackBtn_Click(Object sender, RoutedEventArgs e) {
            this.Close();
        }


        public Action ToggleStart;
        private void StartBtn_Click(Object sender, RoutedEventArgs e) {
            if (this.ToggleStart == null) return;

            this.ToggleStart();
        }
    }
}
