﻿using BLAPI;
using BO;
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

namespace PL.WPF
{
    /// <summary>
    /// Interaction logic for AddBusWindow.xaml
    /// </summary>
    public partial class AddBusWindow : Window
    {
        IBL bl;
        public AddBusWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // busViewSource.Source = [generic data source]
        }
        private void AddBus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HelpExceptions();
                int licenseNum;
                if(!Int32.TryParse(licenseNumTextBox.Text, out licenseNum))
                    throw new BadInputException(6, "מחרוזת קלט לא היתה בתבנית הנכונה");
                DateTime startDate = DateTime.Parse(startDateDatePicker.Text);
                DateTime lastDate = DateTime.Parse(dateLastTreatDatePicker.Text);
                double kmLastTreat;
                if(!Double.TryParse(kmLastTreatTextBox.Text, out kmLastTreat))
                    throw new BadInputException(4, "מחרוזת קלט לא היתה בתבנית הנכונה");
                double fuel;
                if (!Double.TryParse(fuelTankTextBox.Text, out fuel))
                    throw new BadInputException(5, "מחרוזת קלט לא היתה בתבנית הנכונה");
                double totalKm;
                if (!Double.TryParse(totalKmTextBox.Text, out totalKm))
                    throw new BadInputException(3, "מחרוזת קלט לא היתה בתבנית הנכונה");
                BO.Bus b = new BO.Bus() { LicenseNum = licenseNum, FuelTank = fuel, StartDate = startDate, DateLastTreat = lastDate, StatusBus = BusStatus.Available, TotalKm = totalKm, KmLastTreat = kmLastTreat };
                if(b!=null)
                { 
                    bl.AddBus(b);              
                    MessageBox.Show("הפעולה בוצעה בהצלחה", "successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (BO.BadLicenseNumException ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.licenseNum, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadInputException ex)
            {
                Exceptions(ex.num, ex.Message);          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
       

        }
        private void HelpExceptions()
        {
            licenseNumTextBox.BorderBrush = Brushes.Gray;
            startDateDatePicker.BorderBrush = Brushes.Gray;
            dateLastTreatDatePicker.BorderBrush = Brushes.Gray;
            kmLastTreatTextBox.BorderBrush = Brushes.Gray;
            fuelTankTextBox.BorderBrush = Brushes.Gray;
            totalKmTextBox.BorderBrush = Brushes.Gray;
        }
        /// <summary>
        /// הפונקציה הזאת זורקת חריגה עם ההודעה המתאימה ומסמנת את הטעות עם מסגרת אדומה, בפונקציה מקבלת מספר כך שכל מספר מתאים לחריגה של טעות קלט אחרת
        /// </summary>
        /// <param name="num"></param>
        /// <param name="massage"></param>
        void Exceptions(int num,string massage)
        {
            if (num == 1)
            {
                HelpExceptions();
                startDateDatePicker.BorderBrush = Brushes.Red;        
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (num == 2)
            {
                HelpExceptions();
                dateLastTreatDatePicker.BorderBrush = Brushes.Red;
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (num == 3)
            {
                HelpExceptions();
                totalKmTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (num == 4)
            {
                HelpExceptions();    
                kmLastTreatTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (num == 5)
            {
                HelpExceptions();
                fuelTankTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (num == 6)
            {
                HelpExceptions();
                licenseNumTextBox.BorderBrush = Brushes.Red;           
                MessageBox.Show(massage, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }
        private void keyCheck(object sender, KeyEventArgs e)// הפונקציה גורמת לזה שיוכלו להכניס רק קלט של מספרים ולא אותיות
        {
            if (((int)e.Key < (int)Key.D0 || (int)e.Key > (int)Key.D9) && ((int)e.Key < (int)Key.NumPad0 || (int)e.Key > (int)Key.NumPad9) && e.Key != Key.OemPeriod /*&& e.Key != Key.Escape */&& e.Key != Key.Back)
                e.Handled = true;
        }


    }
}
