// Person.cs
// Author:  Riya
// Date:    March 23, 2022
// Description:
//  A class designed to as a record of an individual person,
//  including a little information that describes their importance.


using System;

namespace Lab4
{
    class Person
    {
        // Static private variable to hold the number of persons.
        private static int personCount = 0;
        // Private variable to hold the person's identification number.
        private int personId = 0;
        // Private variable to hold the person's first name.
        private string personFirstName = String.Empty;
        // Private variable to hold the person's last name.
        private string personLastName = String.Empty;
        // Private variable to hold the person's email name.
        private string personEmail = String.Empty;
        // Private variable to hold the person's phone name.
        private string personPhone = String.Empty;
        // Private variable to hold the person's status.
        private bool contactStatus = false;

        /// <summary>
        /// Constructor - Default - creates a new person object.
        /// </summary>
        public Person()
        {
            personCount += 1;
            personId = personCount;
        }

        public Person(string firstName, string lastName, string email, string phone, bool contactedStatus) : this()
        {
            // The ": this()" part above calls the default constructor, setting the Id.

            // Set all of the instance variables within this class using the values
            // passed into this constructor.
            personFirstName = firstName;
            personLastName = lastName;
            personEmail = email;
            personPhone = phone;
            contactStatus = contactedStatus;
        }

        /// <summary>
        /// Count ReadOnly Property - Gets the number of persons that have been instantiated/created
        /// </summary>
        public int Count
        {
            get
            {
                return personCount;
            }
        }

        /// <summary>
        /// IdentificationNumber ReadOnly Property - Gets a specific persons' identification number
        /// </summary>
        public int Id
        {
            get
            {
                return personId;
            }
        }

        /// <summary>
        /// VeryImportantPersonStatus Property - >Gets and Sets the Very Important Person status of a person
        /// </summary>
        public bool ContactedStatus
        {
            get
            {
                return contactStatus;
            }
            set
            {
                // The value passed in is always called "value" by default.
                contactStatus = value;
            }
        }


        /// <summary>
        /// FirstName property - Gets and Sets the first name of a person
        /// </summary>
        public string FirstName
        {
            get
            {
                return personFirstName;
            }
            set
            {
                personFirstName = value;
            }
        }

        /// <summary>
        /// LastName property - Gets and Sets the last name of a person
        /// </summary>
        public string LastName
        {
            get
            {
                return personLastName;
            }
            set
            {
                personLastName = value;
            }
        }


        /// <summary>
        /// LastName property - Gets and Sets the email of a person
        /// </summary>
        public string Email
        {
            get
            {
                return personEmail;
            }
            set
            {
                personEmail = value;
            }
        }


        /// <summary>
        /// LastName property - Gets and Sets the last name of a person
        /// </summary>
        public string Phone
        {
            get
            {
                return personPhone;
            }
            set
            {
                personPhone = value;
            }
        }

    }
}