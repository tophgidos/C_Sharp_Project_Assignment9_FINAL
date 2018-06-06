// CSD 228 - Assignment 8 Solution - Nat Ballou
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employees
{
    /// <summary>
    /// Interaction logic for CompHome.xaml
    /// </summary>
    public partial class CompHome : Page
    {
        #region Data members
        static EmployeeList empList = EmployeeList.GetEmployees();
        #endregion

        #region Constructors
        public CompHome()
        {
            InitializeComponent();

            // Set event handler for Employee type radio button
            this.optEmployeeType.SelectionChanged += new SelectionChangedEventHandler(EmployeeType_SelectionChanged);

            // Select the first employee type radio button
            this.optEmployeeType.SelectedIndex = 0;
            RefreshEmployeeList();
        }
        #endregion

        #region Class methods
        // Handle Details button execute
        private void Details_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Create Details page and navigate to page
            CompDetails detailsPage = new CompDetails(this.dgEmps.SelectedItem);
            this.NavigationService.Navigate(detailsPage);
        }

        // Handle enable/disable of Details button
        private void Details_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if an Employee is selected to enable Details button
            e.CanExecute = dgEmps.SelectedIndex >= 0;
        }

        // This also works for Button Click property, but does not enable/disable button
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            // Show Employee details if one selected
            if (dgEmps.SelectedIndex >= 0)
            {
                this.NavigationService.Navigate(new CompDetails(this.dgEmps.SelectedItem));
            }
        }

        // Handle Double click event on data grid row 
        private void Details_DoubleClick(object sender, RoutedEventArgs e)
        {
            Details_Click(sender, e);
        }

        // Handle changes to Employee type radio buttons
        void EmployeeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeeList();
        }

        // Filter Employee list according to radio button setting
        void RefreshEmployeeList()
        {
            // Apply the selection
            switch (this.optEmployeeType.SelectedIndex)
            {
                // Managers
                case 1: dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => obj is Manager);
                    break;

                // Sales
                case 2:
                    dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => obj is SalesPerson);
                    break;

                // Other
                case 3:
                    dgEmps.ItemsSource = (List<Employee>)empList.FindAll(obj => !(obj is Manager || obj is SalesPerson));
                    break;

                // All 
                default: dgEmps.ItemsSource = empList;
                    break;
            }

            dgEmps.Items.Refresh();
        }
        #endregion
    }
}
