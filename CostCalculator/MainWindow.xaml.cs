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

namespace CostCalculator
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

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            // Adjust price depending on material
            float pricePerSheet = 0;
            switch (this.MaterialSelection.SelectedIndex)
            {
                case 0:
                    pricePerSheet = 5.5f;
                    break;
                case 1:
                    pricePerSheet = 10.25f;
                    break;
                case 2:
                    pricePerSheet = 7.5f;
                    break;
            }

            // Check for valid numerical input
            int i;
            bool validInput = int.TryParse(this.SheetAmount.Text, out i);
            if (!validInput) 
            {
                MessageBox.Show("Number of sheets invalid!", "Cost Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; 
            } 

            // Calculate and display final cost
            float finalCost = pricePerSheet * i;

            this.CostText.Text = "£" + string.Format("{0:#.00}", finalCost);
        }
    }
}
