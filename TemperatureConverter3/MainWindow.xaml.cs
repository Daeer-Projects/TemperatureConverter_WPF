using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemperatureConverter3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare the varibles.
        private double inputTemp;
        private double celTemp;
        private double farenTemp;
        private double kelvTemp;
        private double gasTemp;
        int choice1;
        int choice2;

        public MainWindow()
        {
            InitializeComponent();
            this.Reset();
        }
   
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }
        
        public void Reset()
        {
            inputBox.Text = String.Empty;
            fromCelButton.IsChecked = true;
            toCelButton.IsChecked = true;
            resultBox.Text = String.Empty;
        }

         private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
         {
             MessageBoxResult key = MessageBox.Show("Are you sure you want to quit?",
                                                    "Confirm",
                                                    MessageBoxButton.YesNo,
                                                    MessageBoxImage.Question,
                                                    MessageBoxResult.No);
             e.Cancel = (key == MessageBoxResult.No);
         }

         private void convertButton_Click(object sender, RoutedEventArgs e)
         {
             // To do...
             // Get the first temp that the user wants to convert.
             try
             {
                 inputTemp = double.Parse(inputBox.Text);

                 // Need to start a switch for the 3 choices.
                 int get1 = getChoice1();
                 int get2 = getChoice2();


                 switch (get1)
                 {
                     case 1:
                         if (get2 == 1)
                         {
                             resultBox.Text = celToCel(inputTemp).ToString() + "°C";
                         }
                         else if (get2 == 2)
                         {
                             resultBox.Text = celToFaren(inputTemp).ToString() + "°F";
                         }
                         else if (get2 == 3)
                         {
                             resultBox.Text = celToKelv(inputTemp).ToString() + "°K";
                         }
                         else
                         {
                             resultBox.Text = celToGas(inputTemp).ToString();
                         }
                         break;

                     case 2:
                         if (get2 == 1)
                         {
                             resultBox.Text = farenToCel(inputTemp).ToString() + "°C";
                         }
                         else if (get2 == 2)
                         {
                             resultBox.Text = farenToFaren(inputTemp).ToString() + "°F";
                         }
                         else if (get2 == 3)
                         {
                             resultBox.Text = farenToKelv(inputTemp).ToString() + "°K";
                         }
                         else
                         {
                             resultBox.Text = farenToGas(inputTemp).ToString();
                         }
                         break;

                     case 3:
                         if (get2 == 1)
                         {
                             resultBox.Text = kelvToCel(inputTemp).ToString() + "°C";
                         }
                         else if (get2 == 2)
                         {
                             resultBox.Text = kelvToFaren(inputTemp).ToString() + "°F";
                         }
                         else if (get2 == 3)
                         {
                             resultBox.Text = kelvToKelv(inputTemp).ToString() + "°K";
                         }
                         else
                         {
                             resultBox.Text = kelvToGas(inputTemp).ToString();
                         }
                         break;

                     case 4:
                         if (get2 == 1)
                         {
                             resultBox.Text = gasToCel(inputTemp).ToString() + "°C";
                         }
                         else if (get2 == 2)
                         {
                             resultBox.Text = gasToFaren(inputTemp).ToString() + "°F";
                         }
                         else if (get2 == 3)
                         {
                             resultBox.Text = gasToKelv(inputTemp).ToString() + "°K";
                         }
                         else
                         {
                             resultBox.Text = gasToGas(inputTemp).ToString();
                         }
                         break;

                     default:
                         resultBox.Text = "Unable to convert, please try again.";
                         break;
                 }
             }
             catch (FormatException fEx)
             {
                 resultBox.Text = fEx.Message;
             }
             catch (ArgumentOutOfRangeException aEx)
             {
                 resultBox.Text = "Value out of range for gas mark!";
             }

         }

         public int getChoice1()
         {
             if (fromCelButton.IsChecked == true)
             {
                 choice1 = 1;
             }
             else if (fromFarenButton.IsChecked == true)
             {
                 choice1 = 2;
             }
             else if (fromKelvButton.IsChecked == true)
             {
                 choice1 = 3;
             }
             else
             {
                 choice1 = 4;
             }
             return choice1;
        }

         public int getChoice2()
         {
             if (toCelButton.IsChecked == true)
             {
                 choice2 = 1;
             }
             else if (toFarenButton.IsChecked == true)
             {
                 choice2 = 2;
             }
             else if (toKelvButton.IsChecked == true)
             {
                 choice2 = 3;
             }
             else
             {
                 choice2 = 4;
             }
             return choice2;
         }

        public double celToCel(double firstTemp)
        {
            // To do..
            return firstTemp;
        }

        public double celToFaren(double firstTemp)
        {
            inputTemp = firstTemp;
            farenTemp = (inputTemp * 1.8) + 32;
            return farenTemp;
        }

        public double celToKelv(double firstTemp)
        {
            inputTemp = firstTemp;
            kelvTemp = inputTemp + 273.15;
            return kelvTemp;
        }

        public double celToGas(double firstTemp)
        {
            inputTemp = firstTemp;
            if (inputTemp < 80)
            {
                throw new ArgumentOutOfRangeException("Temp too low for gas mark!");
            }
            else if (inputTemp < 115)
            { gasTemp = 0.25; }
            else if (inputTemp < 135)
            { gasTemp = 0.5; }
            else if (inputTemp < 145)
            { gasTemp = 1; }
            else if (inputTemp < 155)
            { gasTemp = 2; }
            else if (inputTemp < 175)
            { gasTemp = 3; }
            else if (inputTemp < 185)
            { gasTemp = 4; }
            else if (inputTemp < 195)
            { gasTemp = 5; }
            else if (inputTemp < 210)
            { gasTemp = 6; }
            else if (inputTemp < 225)
            { gasTemp = 7; }
            else if (inputTemp < 235)
            { gasTemp = 8; }
            else if (inputTemp < 245)
            { gasTemp = 9; }
            else if (inputTemp < 270)
            { gasTemp = 10; }
            else
            {
                throw new ArgumentOutOfRangeException("Temp too high for gas mark!");
            }
            return gasTemp;
        }

        public double farenToCel(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = (inputTemp - 32) * 5 / 9;
            return celTemp;
        }

        public double farenToFaren(double firstTemp)
        {
            return firstTemp;
        }

        public double farenToKelv(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = farenToCel(inputTemp);
            kelvTemp = celToKelv(celTemp);
            return kelvTemp;
        }

        public double farenToGas(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = farenToCel(inputTemp);
            gasTemp = celToGas(celTemp);
            return gasTemp;
        }

        public double kelvToCel(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = inputTemp - 273.15;
            return celTemp;
        }

        public double kelvToFaren(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = kelvToCel(inputTemp);
            farenTemp = celToFaren(celTemp);
            return farenTemp;
        }

        public double kelvToKelv(double firstTemp)
        {
            return firstTemp;
        }

        public double kelvToGas(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = kelvToCel(inputTemp);
            gasTemp = celToGas(celTemp);
            return gasTemp;
        }

        public double gasToCel(double firstTemp)
        {
            inputTemp = firstTemp;
            if (inputTemp < .25 || inputTemp > 10)
            { throw new ArgumentOutOfRangeException("Gas mark only goes up to 10!"); }
            else if (inputTemp < 1)
            { celTemp = 125; }
            else if (inputTemp < 1.5)
            { celTemp = 140; }
            else if (inputTemp < 2.5)
            { celTemp = 150; }
            else if (inputTemp < 3.5)
            { celTemp = 165; }
            else if (inputTemp < 4.5)
            { celTemp = 180; }
            else if (inputTemp < 5.5)
            { celTemp = 190; }
            else if (inputTemp < 6.5)
            { celTemp = 200; }
            else if (inputTemp < 7.5)
            { celTemp = 220; }
            else if (inputTemp < 8.5)
            { celTemp = 230; }
            else if (inputTemp < 9.5)
            { celTemp = 240; }
            else
            { celTemp = 260; }
            return celTemp;
        }

        public double gasToFaren(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = gasToCel(inputTemp);
            farenTemp = celToFaren(celTemp);
            return farenTemp;
        }

        public double gasToKelv(double firstTemp)
        {
            inputTemp = firstTemp;
            celTemp = gasToCel(inputTemp);
            kelvTemp = celToKelv(celTemp);
            return kelvTemp;
        }

        public double gasToGas(double firstTemp)
        {
            if (firstTemp <.25 || firstTemp > 10)
            {
                throw new ArgumentOutOfRangeException("Gas mark only goes up to 10!"); 
            }
            else
                return firstTemp;
        }

        private void MenuReset_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

    }
}
