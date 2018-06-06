using System;

namespace Employees
{
	// SupportPerson works a shift
    public enum ShiftName { One, Two, Three }

    [System.Serializable]
    public class SupportPerson : Employee
    {
        #region Data members
        public ShiftName Shift { get; set; } = ShiftName.One;
        #endregion

        #region Constructors 
        public SupportPerson() { }

		public SupportPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, ShiftName shift)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the SupportPerson class.
            Shift = shift;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Shift: {0}", Shift);
		}

        // Spare prop for Shift
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Shift:";
            propValue = Shift.ToString();
        }
        #endregion
    }
}
