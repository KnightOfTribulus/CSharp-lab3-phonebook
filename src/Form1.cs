using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace Csharp__3
{
    public partial class Form1 : Form
    { 
        List<tovarishey_kortegi> people = new List<tovarishey_kortegi>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
    if (File.Exists("Resourses/tovarishey_list.json") == true) //требуется полный путь!!!! (lol, net, Stas)
            {
                tovarishey_kortegi p = new tovarishey_kortegi();
                string stringList = File.ReadAllText("Resourses/tovarishey_list.json");
                tovarishey_list TOVARISHCHLIST = JsonConvert.DeserializeObject<tovarishey_list>(File.ReadAllText("D:\\бэкап\\С#\\Csharp  3\\tovarishey_list.json"));
                foreach (var tovarishey_kortegi in TOVARISHCHLIST.tuneyadci)
                {
                    people[listView1.SelectedItems[0].Index].FirstName = tovarishey_kortegi.FirstName; 
                    people[listView1.SelectedItems[0].Index].Address = tovarishey_kortegi.Address; 
                    people[listView1.SelectedItems[0].Index].Email = tovarishey_kortegi.Email;
                    people[listView1.SelectedItems[0].Index].Note = tovarishey_kortegi.Note;
                    people[listView1.SelectedItems[0].Index].PhoneNumber = tovarishey_kortegi.PhoneNumber;
                   // people[listView1.SelectedItems[0].Index].FirstName = listView1.SelectedItems[0].Text;

                    p.FirstName = people[listView1.SelectedItems[0].Index].FirstName;
                    p.Address = people[listView1.SelectedItems[0].Index].Address;
                    p.Email = people[listView1.SelectedItems[0].Index].Email;
                    p.Note = people[listView1.SelectedItems[0].Index].Note;
                    p.PhoneNumber = people[listView1.SelectedItems[0].Index].PhoneNumber;
                    people.Add(p);
                    listView1.Items.Add(p.FirstName);
                };
            }
            else
            {
                MessageBox.Show("Resourses/tovarishey_list.json не найден.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tovarishey_kortegi p = new tovarishey_kortegi();
            p.FirstName = textBox1.Text;
            p.Address = textBox3.Text;
            p.Email = textBox2.Text;
            p.Note = textBox4.Text;
            p.Birthday = dateTimePicker1.Value;
            people.Add(p);
            listView1.Items.Add(p.FirstName);
            textBox1.Text = String.Empty;
            textBox3.Text = String.Empty; 
            textBox2.Text = String.Empty; 
            textBox4.Text = String.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
            else
            {
                textBox1.Text = people[listView1.SelectedItems[0].Index].FirstName;
                textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
                textBox3.Text = people[listView1.SelectedItems[0].Index].Address;
                textBox4.Text = people[listView1.SelectedItems[0].Index].Note;
                textBox5.Text = people[listView1.SelectedItems[0].Index].PhoneNumber;
                dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;
            }

 }

        private void button3_Click(object sender, EventArgs e)
        {
           Remove();
        }
        void Remove() 
        {
            try
            {
                people.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);



            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                people[listView1.SelectedItems[0].Index].FirstName = textBox1.Text;
                people[listView1.SelectedItems[0].Index].Email = textBox2.Text;
                people[listView1.SelectedItems[0].Index].Address = textBox3.Text;
                people[listView1.SelectedItems[0].Index].Note = textBox4.Text;
                people[listView1.SelectedItems[0].Index].PhoneNumber = textBox5.Text;
                people[listView1.SelectedItems[0].Index].Birthday = dateTimePicker1.Value;
                listView1.SelectedItems[0].Text = textBox1.Text;

            }

        }


    }
}