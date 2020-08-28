using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsResultMSfTeachers
{
    public partial class registration : Form
    {

        string fname, lname, dname, tid, designation, contact, email, gender, uname, pass;

        private object errorProviderApp;

        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // text box code will be here
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
               
        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            fname = textBox1.Text;
            lname = textBox2.Text;
            dname = textBox3.Text;
            tid   = textBox4.Text;
            designation = textBox5.Text;
            contact = textBox6.Text;
            email   = textBox7.Text;
            gender  = textBox8.Text;
            uname   = textBox9.Text;
            pass    = textBox9.Text;

           
            if (string.IsNullOrEmpty(fname))
            {
                MessageBox.Show("You must enter First Name.");
                label12.Text = "You must enter First Name.";
                return;
            }
            else if (string.IsNullOrEmpty(lname))
            {
                MessageBox.Show("You must enter Last Name.");
                label12.Text = "You must enter Last Name.";
                return;
            }
            else if (string.IsNullOrEmpty(dname))
            {
                MessageBox.Show("You must enter Department Name.");
                label12.Text = "You must enter Department Name.";
                return;
            }
            else if (string.IsNullOrEmpty(tid))
            {
                MessageBox.Show("You must enter Teacher Id.");
                label12.Text = "You must enter Teacher Id.";
                return;
            }
            else if (string.IsNullOrEmpty(designation))
            {
                MessageBox.Show("You must enter Teacher Designation.");
                label12.Text = "You must enter Teacher Designation.";
                return;
            }
            else if (string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("You must enter Contact No");
                label12.Text = "You must enter Contact No";
                return;
            }
            else if (string.IsNullOrEmpty(email))
            {

                string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                try
                {

                    if (Regex.IsMatch(email, expression))
                    {

                        MessageBox.Show("email address validated");

                        label12.Text = email.ToString();
                    }
                    else
                    {
                        MessageBox.Show("You must enter Valida Email address2");
                    }
                }
                catch (RegexMatchTimeoutException)
                {
                    MessageBox.Show("You must enter Valida Email address");
                    label12.Text = "You must enter Valida Email address";
                    return;
                }
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                    label12.Text = "email validation succesfully";
                else
                    label12.Text = "Invalidet email address";

            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select at least any Gender!");
            }
            else if (radioButton1.Checked)
            {
                gender = "male";//male == 1 & female == 2;
            }
            else if (radioButton2.Checked)
            {
                gender = "frmale";//male == 1 & female == 2;
            }
            else if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("You must enter a Username");
                return;
            }
            else if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("You must enter a Password");
                return;
            }
            

            // database connection and store data in database;
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=desktop-rotb5oa;Initial Catalog=TestDB;Integrated Security = True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = " ";

                sql = "INSERT INTO registration(f_name, l_name,d_name,t_id,designation,contact,email,gender,username,password,check_in)  VALUES('"+fname+"', '"+ lname+"', '"+ dname+"', '"+ tid+"', '"+ designation+"', '"+ contact+"', '"+ email+"', '"+ gender+"', '"+ uname+"', '"+ pass+"','')";

                SqlCommand cmd = new SqlCommand(sql,cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                
                MessageBox.Show("Connection Open && send data to database completed.. !");

                cnn.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
