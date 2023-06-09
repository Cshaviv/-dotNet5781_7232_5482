﻿//llll/
using BLAPI;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.WPF
{
    /// <summary>
    /// Interaction logic for managementWindow.xaml
    /// </summary>
    public partial class managementWindow : Window
    {
        IBL bl;
        int historyNum = 1;
        int availableNum = 1;
        public managementWindow(IBL _bl, string userName)
        {
            InitializeComponent();
            bl = _bl;
            RefreshAllBuses();
            RefreshAllLinesList();
            RefreshAllStations();
            userNameTextBlock.Text = ("Hi " + userName).ToString(); 
            sarchLineInArea.ItemsSource= Enum.GetValues(typeof(BO.Area));
            sarchLineInArea.Visibility = Visibility.Hidden;
            areaLabel.Visibility = Visibility.Hidden;
            
        }

        #region Buses 
        private void Bus_Click(object sender, RoutedEventArgs e)
        {
             Hidden();
            busesListBox.Visibility = Visibility.Visible;
            AddBus.Visibility = Visibility.Visible;
            historyNum = 1;
            availableNum = 1;
            RefreshAllBuses();
        }//
        private void doubleClickBusInfromation(object sender, RoutedEventArgs e)// Clicking "double click" on a bus in the list will open a window showing the bus data
        {
            Bus myBus = (sender as ListBox).SelectedItem as Bus;
            if (myBus != null)
            {
                bool isDelete = false;
                if (myBus.IsDeleted == true)
                {
                    isDelete = true;
                }
                BusData win = new BusData(isDelete, myBus, bl, busesListBox);
                win.ShowDialog();
            }

        }
        private void RefuelClick(object sender, RoutedEventArgs e)
        {
            Bus myBus = (sender as Button).DataContext as Bus;
            if (myBus.StatusBus == BusStatus.InTravel || myBus.StatusBus == BusStatus.OnTreatment || myBus.StatusBus == BusStatus.OnRefueling)// Check if the bus can be sent for refueling
            {
                MessageBox.Show("The bus is unavailable.", "WARNING", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (myBus.FuelTank == 0)//When the fuel tank is full to the end can not be sent for refueling.
            {
                MessageBox.Show("The fuel tank if full", "WARNING", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            myBus.StatusBus = BusStatus.OnRefueling;//update status
            myBus.FuelTank = 0;//update fields
        }//
        private void TreatClick(object sender, RoutedEventArgs e)//
        {
            Bus myBus = (sender as Button).DataContext as Bus;
            if (myBus.StatusBus == BusStatus.InTravel || myBus.StatusBus == BusStatus.OnTreatment || myBus.StatusBus == BusStatus.OnRefueling)// Check if the bus can be sent for refueling
            {
                MessageBox.Show("The bus is unavailable.", "WARNING", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (myBus.FuelTank == 0 && (DateTime.Now == myBus.DateLastTreat))//If he did the treatment today and has not traveled since
            {
                MessageBox.Show("The bus was already treatmented", "WARNING", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            myBus.StatusBus = BusStatus.OnTreatment;//update status
            myBus.FuelTank = 0;//update fields
            myBus.DateLastTreat = DateTime.Now;
            if (myBus.FuelTank == 1200)
            {
                myBus.FuelTank = 0;
            }
        }
        private void AddBus_Click(object sender, RoutedEventArgs e)//
        {
            AddBusWindow win = new AddBusWindow(bl);
            win.ShowDialog();
            RefreshAllBuses();// refresh the list of buses
        }
        void RefreshAllBuses()
        {
            busesListBox.ItemsSource = bl.GetAllBuses().ToList();
        }
        void RefreshAllDeleteBuses()
        {
            busesListBox.ItemsSource = bl.GetAllDeleteBuses().ToList();
        } 
        #endregion

        #region Lines 
        public void RefreshAllLinesList()
        {
            LineesListBox.ItemsSource = bl.GetAllLines().ToList();
        }
        public void RefreshAllDeletedLinesList()
        {
            LineesDeletedListBox.ItemsSource = bl.GetAllDeletedLines().ToList();
        }
        private void Line_Click(object sender, RoutedEventArgs e)
        {
           
             Hidden();
            sarchLineInArea.Visibility = Visibility.Visible;
            LineesListBox.Visibility = Visibility.Visible;
            AddLine.Visibility = Visibility.Visible;
            areaLabel.Visibility = Visibility.Visible;
            Line.Background = Brushes.Gray;
            RefreshAllLinesList();
            historyNum = 2;
            availableNum = 2;

        }
        private void areaChangeClick(object sender, SelectionChangedEventArgs e)
        {
            if (sarchLineInArea.SelectedItem == null)
                LineesListBox.ItemsSource = bl.GetAllLines().ToList();
            else
                LineesListBox.ItemsSource = bl.GetAllLinesInArea(sarchLineInArea.SelectedItem.ToString()).ToList();

        }
        private void doubleClickLineInfromation(object sender, MouseButtonEventArgs e)
        {
            BO.Line line = (sender as ListBox).SelectedItem as BO.Line;
            if (line == null)
            {
                MessageBox.Show("לקו זה אין נתונים להציג", "Empty", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            ListBoxItem myListBoxItem = (ListBoxItem)(LineesListBox.ItemContainerGenerator.ContainerFromItem(line));
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            LineDeta win = new LineDeta(bl, line);
            win.Closing += winUpdate_Closing;
            win.ShowDialog();
        }
        private void doubleClickDeletedLine(object sender, MouseButtonEventArgs e)
        {
            BO.Line line = (sender as ListBox).SelectedItem as BO.Line;
            if (line == null)
            {
                MessageBox.Show("לקו זה אין נתונים להציג", "Empty", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ListBoxItem myListBoxItem = (ListBoxItem)(LineesDeletedListBox.ItemContainerGenerator.ContainerFromItem(line));
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            LineDataUser win = new LineDataUser(bl, line);
            win.ShowDialog();
        }
        private void winUpdate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RefreshAllLinesList();
        }
        private void AddLine_Click(object sender, RoutedEventArgs e)
        {
            AddNewLine win = new AddNewLine(bl);
            win.ShowDialog();
            RefreshAllLinesList();
        }  
        #endregion

        #region Station
        private void Station_Click(object sender, RoutedEventArgs e)
        {
 
             Hidden();     
            stationsListBox.Visibility = Visibility.Visible;
            AddStation.Visibility = Visibility.Visible;
            RefreshAllStations();
            historyNum = 3;
            availableNum = 3;
        }
        void RefreshAllStations()
        {
            try
            {
                stationsListBox.ItemsSource = bl.GetAllStations().ToList();
            }
            catch (BO.BadLineIdException)
            {
                MessageBox.Show("מצטערים חסר למערכת מידע", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadStationCodeException)
            {
                MessageBox.Show("מצטערים חסר למערכת מידע", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void RefreshAllDeletedStations()
        {
            try
            {
                stationsListBox.ItemsSource = bl.GetAllDeletedStations().ToList();
            }
            catch (BO.BadLineIdException)
            {
                MessageBox.Show("מצטערים חסר למערכת מידע", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadStationCodeException)
            {
                MessageBox.Show("מצטערים חסר למערכת מידע", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            AddNewStation win = new AddNewStation(bl);
            win.ShowDialog();
            RefreshAllStations();
        }
        private void doubleClickStationInfromation(object sender, MouseButtonEventArgs e)
        {
            bool isDeleted = false;
            BO.Station station = (sender as ListBox).SelectedItem as BO.Station;
            if (station == null)
                return;
            ListBoxItem myListBoxItem = (ListBoxItem)(stationsListBox.ItemContainerGenerator.ContainerFromItem(station));
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            if (station.IsDeleted == true)
            {
                isDeleted = true;
            }
            StationData win = new StationData(isDeleted, bl, station, stationsListBox);
            win.ShowDialog();
        }
        #endregion
        
        /// <summary>
        ///   The function hides all the lists and buttons that are in the window and each time we define in the appropriate function what things will be seen  
        /// </summary>
        private void Hidden()
        {
            stationsListBox.Visibility = Visibility.Hidden;
            busesListBox.Visibility = Visibility.Hidden;
            LineesDeletedListBox.Visibility = Visibility.Hidden;
            LineesListBox.Visibility = Visibility.Hidden;
            AddBus.Visibility = Visibility.Hidden;
            AddLine.Visibility = Visibility.Hidden;
            AddStation.Visibility = Visibility.Hidden;
            available.Visibility = Visibility.Hidden;
            History.Visibility = Visibility.Visible;
            areaLabel.Visibility = Visibility.Hidden;
            sarchLineInArea.Visibility = Visibility.Hidden;
        }
        private void HistoryClick(object sender, RoutedEventArgs e)
        {
            if (historyNum == 1)
            {
                RefreshAllDeleteBuses();
                available.Visibility = Visibility.Visible;
                History.Visibility = Visibility.Hidden;
            }
            if (historyNum == 2)
            {
                LineesListBox.Visibility = Visibility.Hidden;
                LineesDeletedListBox.Visibility = Visibility.Visible;
                RefreshAllDeletedLinesList();
                available.Visibility = Visibility.Visible;
                History.Visibility = Visibility.Hidden;
                areaLabel.Visibility = Visibility.Hidden;
                sarchLineInArea.Visibility = Visibility.Hidden;
            }
            if (historyNum == 3)
            {
                RefreshAllDeletedStations();
                available.Visibility = Visibility.Visible;
                History.Visibility = Visibility.Hidden;
            }

        }
        private void AvailableClick(object sender, RoutedEventArgs e)
        {
            if (availableNum == 1)
            {
                RefreshAllBuses();
                available.Visibility = Visibility.Hidden;
                History.Visibility = Visibility.Visible;
            }
            if (availableNum == 2)
            {
                LineesListBox.Visibility = Visibility.Visible;
                LineesDeletedListBox.Visibility = Visibility.Hidden;
                RefreshAllLinesList();
                available.Visibility = Visibility.Hidden;
                History.Visibility = Visibility.Visible;
                areaLabel.Visibility = Visibility.Visible;
                sarchLineInArea.Visibility = Visibility.Visible;
            }
            if (availableNum == 3)
            {
                RefreshAllStations();
                available.Visibility = Visibility.Hidden;
                History.Visibility = Visibility.Visible;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }  



    }
}
