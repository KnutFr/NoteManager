using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using NoteManager.Models;
using System.Collections.Generic;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System;
using System.ComponentModel;
using NoteManager.ViewModels;

namespace NoteManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            new SearchWindow().ShowDialog();
        }

        private void MenuItemDatabase_Click(object sender, RoutedEventArgs e)
        {
            new DatabaseWindow().ShowDialog();
        }

        private void MenuItemUser_Click(object sender, RoutedEventArgs e)
        {
            new UserWindow().ShowDialog();
        }

        private void MenuItemWebService_Click(object sender, RoutedEventArgs e)
        {
            new WebServiceWindow().ShowDialog();
        }
    }
}
