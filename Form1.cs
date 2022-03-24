// Author:          Riya 
// Created:         March 23, 2022
// Last Modified:   March 23, 2022
// Description:     This is the fourth lab. Where a Windows form can display a list of contacts and allow the user to add
//                  new contacts to the list as well as edit existing contacts selected from a ListView.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab4
{
    public partial class Form1 : Form
    {


        private List<Person> PersonList = new List<Person>();
        // This flag is used to indicate whether the program is checking boxes as opposed to a human.
        private bool isAutomated = false;
        // Variable representing the current selected index in the ListView.
        // This is being used to simplify a few reference to indexes.
        private int selectedIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validate all input fields, and if they are valid create the person object, add the entered person to the list, and add them to the ListView.
        /// </summary>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Empty the error label; it will fill with NEW errors if anything is wrong.
            textErrorBox.Text = String.Empty;

            // Check if the person is valid.
            if (IsPesronValid(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPhone.Text))
            {
                // person details are valid; create a person object.
                Person newPersonToAdd = new Person(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPhone.Text, checkBoxContacted.Checked);

                ListViewItem personItem = new ListViewItem();





                MessageBox.Show(selectedIndex.ToString());
                
                // If a person is currently selected...
                if (selectedIndex >= 0)
                {
                    // Replace the old version of that person with the new one!

                    personItem.Checked = newPersonToAdd.ContactedStatus;

                    personItem.SubItems.Add(newPersonToAdd.FirstName);
                    personItem.SubItems.Add(newPersonToAdd.LastName);
                    personItem.SubItems.Add(newPersonToAdd.Email);
                    personItem.SubItems.Add(DateTime.Now.ToString("M-d-yyyy"));
                    personItem.SubItems.Add(newPersonToAdd.Phone);

                    listViewPerson.Items[selectedIndex] = personItem;

                   
                }
                else
                {
                    // Otherwise, add a person with the entered details to the end of the list.
                    PersonList.Add(newPersonToAdd);

                    ListViewItem personItem2 = new ListViewItem();

                    personItem2.Checked = newPersonToAdd.ContactedStatus;

                    personItem2.SubItems.Add(newPersonToAdd.FirstName);
                    personItem2.SubItems.Add(newPersonToAdd.LastName);
                    personItem2.SubItems.Add(newPersonToAdd.Email);
                    personItem2.SubItems.Add(DateTime.Now.ToString("M-d-yyyy"));
                    personItem2.SubItems.Add(newPersonToAdd.Phone);

                    listViewPerson.Items.Add(personItem2);

                }


                
                // Allow the program to modify the ListView's checkboxes.
                isAutomated = true;
               
                // Reset the form to allow new entries.
                SetDefaults();
            }
        }

        /// <summary>
        /// Reset the form to its default state.
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// Me close form.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Reset the form's input fields to their default states.
        /// </summary>
        private void SetDefaults()
        {
            // Resets fields to default state.
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxPhone.Clear();
            checkBoxContacted.Checked = false;
            listViewPerson.SelectedItems.Clear();
            textErrorBox.Text = String.Empty;
            selectedIndex = -1;

           
        }

        /// <summary>
        /// When a checkbox in the ListView is checked, say no and don't let the user change it.
        /// </summary>
        private void PreventCheck(object sender, ItemCheckEventArgs e)
        {
            // Only prevent checking if it's being done by the user.
            if (!isAutomated)
            {
                // Change the new value of the checkbox equal to the old state of the checkbox.
                e.NewValue = e.CurrentValue;
            }
        }





        /// <summary>
        /// When a person in the ListView is selected, write that person's properties into the input controls.
        /// </summary>
        private void PersonSelected(object sender, EventArgs e)
        {
            // If the list is populated and something is selected...
            if (listViewPerson.Items.Count > 0 && listViewPerson.FocusedItem != null)
            {
                // ...fill in the entry fields with values based on the selected person.
                textBoxFirstName.Text = listViewPerson.FocusedItem.SubItems[1].Text;
                textBoxLastName.Text = listViewPerson.FocusedItem.SubItems[2].Text;
                textBoxEmail.Text = listViewPerson.FocusedItem.SubItems[3].Text;
                textBoxPhone.Text = listViewPerson.FocusedItem.SubItems[5].Text;
                checkBoxContacted.Checked = listViewPerson.FocusedItem.Checked;

                // Set the selectedIndex to match the listView.
                selectedIndex = listViewPerson.FocusedItem.Index;
            }
            else
            {
                // If nothing is selected, set the selectedIndex to -1.
                selectedIndex = -1;
            }
        }



        /// <summary>
        /// Checks whether the input related to a person is valid
        /// </summary>

        private bool IsPesronValid( string firstName, string lastName, string email, string phone)
        {

            string newLine = Environment.NewLine;

            // Assume the worker is valid.
            bool isValid = true;

            // Check the first input.
            if (firstName == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textErrorBox.Text += "*You must enter a first name."+newLine;
            }
            // Check the third input.
            if (lastName == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textErrorBox.Text += "*You must enter a last name."+newLine;
            }
            // Check the third input.
            if (email == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textErrorBox.Text += "*You must enter a email address" + newLine;
            }
            // Check the third input.
            if (phone == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textErrorBox.Text += "*You must enter a phone number." + newLine;
            }
            else if (!Regex.IsMatch(phone.ToString(), "[0-9()-]{10,11}"))
            {

                //If it's not valid, set error = true and write an error message.
                textErrorBox.Text += "*Invalid value! value must be between 10 - 11 characters."+newLine;
                isValid &= false;

            }

            return isValid;
        }


    }
}
