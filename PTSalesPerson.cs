using System;

namespace Employees
{
    [System.Serializable]
    sealed class PTSalesPerson : SalesPerson
    {
        #region Constructors
        public PTSalesPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn, numbOfSales)
        {
        }
        #endregion
    }
}
