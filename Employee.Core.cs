﻿using System;
using System.Runtime.Serialization;

namespace Employees
{
    [Serializable]
    public partial class Employee
    {
        #region Data members and Properties
        private string empFirstName;
        private string empLastName;
        private int empID;
        private float currPay;
        private DateTime empDOB;
        private string empSSN;
        static int NextId = 1;   // Used to generate unique Ids

        public string Name { get { return string.Format($"{empFirstName} {empLastName}"); } }
        public string FirstName { get { return empFirstName; } }
        public string LastName { get { return empLastName; } }
        public int Id { get { return empID; } }
        public float Pay { get { return currPay; } }
        public int Age { get { return (DateTime.Now.Year - empDOB.Year); } }
        public DateTime DateOfBirth { get { return empDOB; } }
        public string SocialSecurityNumber { get { return empSSN; } }
        public virtual string Role { get { return GetType().ToString().Substring(10); } }
        #endregion

        #region Constructors
        public Employee() { }

        public Employee(string firstName, string lastName, DateTime birthday, float pay, string ssn)
        {
            empFirstName = firstName;
            empLastName = lastName;
            empDOB = birthday;
            empID = NextId++;
            currPay = pay;
            empSSN = ssn;
        }
        #endregion

        #region Serialization customization for MaxId
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Called when the deserialization process is complete.
            if (empID > NextId) NextId = empID + 1;
        }
        #endregion
    }
}