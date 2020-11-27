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
using Velacro.DataStructures;
using Velacro.UIElements.Basic;
using assetnest_wpf.Profile;

namespace assetnest_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MyWindow
    {
        private MyPage profilePage;
        public MainWindow()
        {
            InitializeComponent();
            profilePage = new ProfilePage();
        }
    }
}
