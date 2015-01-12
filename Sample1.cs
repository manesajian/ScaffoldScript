using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScaffoldScript
{
    public partial class Sample1 : Form
    {
        string [] GuyNames = { "Adam", "Alex", "Alvin",
                                     "Bartholomew", "Billy", "Bob",
                                     "Charles", "Chet", "Chuck",
                                     "Daniel", "Dennis", "David",
                                     "Eduardo", "Edward",
                                     "Frank",
                                     "George", "Guy",
                                     "Hansel", "Harry",
                                     "Isaac",
                                     "Jay", "James", "Jim", "John", "Joseph",
                                     "Karl", "Kevin", "Kyle",
                                     "Larry", "Lars", "Lenny",
                                     "Mark", "Max",
                                     "Norm",
                                     "Oliver",
                                     "Paul", "Peter",
                                     "Quinn",
                                     "Roger", "Ryan",
                                     "Sam", "Samuel", "Sean", "Shawn",
                                     "Theodore", "Thomas", "Tim", "Timothy", "Tom",
                                     "Ulysses", "Uwe",
                                     "Victor",
                                     "Will",
                                     "Xavier",
                                     "Yoseph", "Yuri", "Yuseph",
                                     "Zane"};

        string [] GirlNames = { "Angela",
                                      "Betsy", "Betty",
                                      "Candy", "Carla", "Carol", "Cindy",
                                      "Danielle", "Darcy", "Doris",
                                      "Edith", "Elayne",
                                      "Faith", "Felicity", "Fiona",
                                      "Gladys", "Gwynn",
                                      "Hannah", "Harriet", "Heidi", "Helen",
                                      "Ingrid", "Isabel", "Ivy",
                                      "Jane", "Janet", "Joan", "Judy", "Julia", "Julie",
                                      "Karen", "Karla",
                                      "Lacey", "Leanne", "Linda",
                                      "Martha", "Marjory", "Mary",
                                      "Nancy", "Nora",
                                      "Olga", "Olivia",
                                      "Paula", "Peggy",
                                      "Rachel", "Roberta", "Rose",
                                      "Sadhvi", "Santayani", "Sara", "Sarah", "Shakeela",
                                      "Tammy", "Theresa", "Tiffany",
                                      "Ursula",
                                      "Vivian",
                                      "Wendy" };

        string [] LastNames = { "Smith",
                                      "Johnson",
                                      "Williams",
                                      "Brown",
                                      "Jones",
                                      "Miller",
                                      "Davis",
                                      "Garcia",
                                      "Rodriguez",
                                      "Wilson",
                                      "Martinez",
                                      "Anderson",
                                      "Taylor",
                                      "Thomas",
                                      "Hernandez",
                                      "Moore",
                                      "Martin",
                                      "Jackson",
                                      "Thompson",
                                      "White",
                                      "Lopez",
                                      "Lee",
                                      "Gonzalez",
                                      "Harris",
                                      "Clark",
                                      "Lewis",
                                      "Robinson",
                                      "Walker",
                                      "Perez",
                                      "Hall",
                                      "Young",
                                      "Allen",
                                      "Sanchez" };

        private int patients = 0;

        public Sample1()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            string newPatient = txtFirstName.Text + " " + txtMiddleName.Text + " " + txtLastName.Text + ", " +
                                txtDateOfBirth.Text + ", " + txtPatientID.Text;

            txtOutput.Text = newPatient + System.Environment.NewLine + txtOutput.Text;

            patients += 1;

            txtTotalPatients.Text = patients.ToString();
        }

        private void btnRandomPatient_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int sex = random.Next(0, 2);

            if (sex == 1)
            {
                txtFirstName.Text = GuyNames[random.Next(0, GuyNames.Length)];

                int middle_type = random.Next(0, 3);

                if (middle_type == 1)
                    txtMiddleName.Text = GuyNames[random.Next(0, GuyNames.Length)];
                else if (middle_type == 2)
                    txtMiddleName.Text = LastNames[random.Next(0, LastNames.Length)];
                else
                    txtMiddleName.Text = GuyNames[random.Next(0, GuyNames.Length)][0] + ".";
            }
            else
            {
                txtFirstName.Text = GirlNames[random.Next(0, GirlNames.Length)];

                int middle_type = random.Next(0, 3);

                if (middle_type == 1)
                    txtMiddleName.Text = GirlNames[random.Next(0, GuyNames.Length)];
                else if (middle_type == 2)
                    txtMiddleName.Text = LastNames[random.Next(0, LastNames.Length)];
                else
                    txtMiddleName.Text = GirlNames[random.Next(0, GuyNames.Length)][0] + ".";
            }

            txtLastName.Text = LastNames[random.Next(0, LastNames.Length)];

            txtDateOfBirth.Text = (2011 - random.Next(0, 102)).ToString() + "-" +
                                  random.Next(1, 13).ToString() + "-" +
                                  random.Next(1, 29).ToString();

            txtPatientID.Text = (1000000 + random.Next(1000000, 9999999)).ToString();
        }

        private void btnClearPatients_Click(object sender, EventArgs e)
        {
            patients = 0;

            txtOutput.Text = "";
            txtTotalPatients.Text = "";
        }
    }
}
