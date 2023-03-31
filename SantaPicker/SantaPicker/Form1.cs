using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaPicker
{
    public partial class Form1 : Form
    {
        List<string> possibleParticipants = new List<string> { "Bob", "Sarah", "Noah", "Elf", "Rudolph" };
        List<string> chosenRecievers = new List<string>();
        List<string> chosenGivers = new List<string>();
        bool selectionChanged = false;
        RadioButton sRB;
        RadioButton sRB2;
        public Form1()
        {
            InitializeComponent();
            label2.Text = (possibleParticipants.Count.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selectionChanged && possibleParticipants.Count > 0 && !chosenGivers.Contains(sRB2.Text))
            {
                possibleParticipants.Remove(sRB2.Text);

                Random rnd = new Random();
                int d = rnd.Next(possibleParticipants.Count);

                MessageBox.Show("You will give a gift to: " + possibleParticipants[d]);

                chosenGivers.Add(sRB2.Text);
                chosenRecievers.Add(possibleParticipants[d]);
                possibleParticipants.Remove(possibleParticipants[d]);

                if (!chosenRecievers.Contains(sRB2.Text))
                {
                    possibleParticipants.Add(sRB2.Text);
                }

                label2.Text = (possibleParticipants.Count.ToString());
                selectionChanged = false;
            }
            else
            {
                MessageBox.Show("Please select your name from the list.");
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selectionChanged = true;
            sRB = sender as RadioButton;
            if(sRB.Checked == true)
            {
                sRB2 = sRB;
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetParticicpants();
        }

        private void ResetParticicpants()
        {
            chosenGivers.Clear();
            chosenRecievers.Clear();
            possibleParticipants.Clear();
            possibleParticipants = new List<string> { "Bob", "Sarah", "Noah", "Elf", "Rudolph" };
            label2.Text = (possibleParticipants.Count.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
