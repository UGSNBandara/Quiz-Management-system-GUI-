﻿using Quiz_GUI.ViewModels;
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

namespace Quiz_GUI
{
    /// <summary>
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        public AddPlayerWindow()
        {
            InitializeComponent();
            DataContext = new AddPlayerViewModel();
        }
    }
}
