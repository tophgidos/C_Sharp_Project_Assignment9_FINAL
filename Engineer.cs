using System;

namespace Employees
{
	// Engineers have degrees
    public enum DegreeName { BS, MS, PhD }

    [System.Serializable]
    public class Engineer : Employee
    {
        #region Data members
        public DegreeName HighestDegree { get; set; } = DegreeName.BS;
        #endregion

        #region Constructors 
        public Engineer() { }

		public Engineer(string firstName, string lastName, DateTime age, float currPay, string ssn, 
                        DegreeName degree)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the Engineer class.
            HighestDegree = degree;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Highest Degree: {0}", HighestDegree);
        }

        // Spare prop for degree
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Highest Degree:";
            propValue = HighestDegree.ToString();
        }

        #endregion
    }
}
