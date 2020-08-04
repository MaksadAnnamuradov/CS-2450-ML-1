using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UV_Sim_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageLabel.Text = "";
        }

        public int[] Memory = new int[1000];//create array with 1000 capacity
        int Index = 0;//index begin with 0
        int Accumulator = 0;//accumulate begin with 0
        int command;
        int targetIndex;
        int number;
        bool inputcheck = false;

        //Change the sign for operation
        private void sign_Click(object sender, EventArgs e)
        {
            if (sign.Text == "+")
            {
                sign.Text = "-";
            }
            else
            {
                sign.Text = "+";
            }
        }

        private void InitializeButton_Click(object sender, EventArgs e)
        {
            //initialize the memory array to all +0000;
            Accumulator = 0;
            Index = 0;
            int n = 0;
            for (int i = 0; i < 1000; i++)
            {
                Memory[i] = n;
            }
            InitialLabel.Text = "Memory is ready to go";
        }

        //get the input from the textbox and store in operation
        public void GetInput()
        {
            string tmp = UVinput.Text;
            if (tmp.Length != 4)
            {
                inputcheck = false;
                return;
            }
            bool b = tmp.All(char.IsDigit);
            if (b == true)
            {
                inputcheck = true;
            }
            else
            {
                inputcheck = false;
                return;
            }
            command = Int16.Parse(tmp[0].ToString() + tmp[1].ToString());
            targetIndex = Int16.Parse(tmp[2].ToString() + tmp[3].ToString());
            //get input numebr if needed
            number = Int16.Parse(InputNumber.Text.ToString());
        }

        //find out which operation been called
        //operation eg:+0101
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (InitialLabel.Text != "Memory is ready to go")
            {
                MessageBox.Show("Please initialize first", "Erro");
            }
            else
            {
                GetInput();
                if (inputcheck == false)
                {
                    MessageBox.Show("The input should be 4 digits, please try again", "Erro");
                    return;
                }
                if (command == 10)//read
                {
                    //bring the number to targetIndex
                    if (sign.Text == "-")
                    {
                        number = number * -1;
                    }
                    Memory[targetIndex] = number;
                    //Message printout
                    MessageLabel.Text = "The operation is READ," +
                        "number " + number + " stored in Memory " + targetIndex;
                    //update the index;
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                }
                else if (command == 11)//write
                {
                    //put the data in the screen
                    MessageLabel.Text = "The operation is WRITE," +
                        "the number in Memory " + targetIndex + " is " + Memory[targetIndex];
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                }
                else if (command == 20)//load
                {
                    //bring the numebr in targetIndex to the accumulator
                    //not add
                    Accumulator = Memory[targetIndex];
                    MessageLabel.Text = "The operation is LOAD";
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                    AccumulatorOut.Text = Accumulator.ToString();
                }
                else if (command == 21)//store
                {
                    //
                }
                else if (command == 30)//add
                {
                    //add to accumulator
                    Accumulator += Memory[targetIndex];
                    MessageLabel.Text = "The operation is ADD, " + 
                        "add " + Memory[targetIndex] + " to Accumulator";
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                    AccumulatorOut.Text = Accumulator.ToString();
                }
                else if (command == 31)//subtract
                {
                    //subtract to accumulator
                    Accumulator -= Memory[targetIndex];
                    MessageLabel.Text = "The operation is SUBTRACT, " +
                        "subtract " + Memory[targetIndex] + " to Accumulator";
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                    AccumulatorOut.Text = Accumulator.ToString();
                }
                else if (command == 32)//divide
                {

                }
                else if (command == 33)//multiply
                {

                }
                else if (command == 40)//branch
                {
                    MessageLabel.Text = "The operation is BRANCH, " + 
                        "jump to Memory " + targetIndex;
                    Index = targetIndex;
                    IndexOut.Text = Index.ToString();
                }
                else if (command == 41)//branchneg
                {

                }
                else if (command == 42)//branchzero
                {

                }
                else if (command == 43)//halt
                {
                    MessageLabel.Text = "The operation is HALT," + 
                    " please initialize the memory again\n" +
                    "Final number in Accumulator: " + Accumulator + "\n" +
                    "Final Memory Location: " + Index;
                    InitialLabel.Text = "Please Initialize the memory first";
                    Accumulator = 0;
                    Index = 0;
                    IndexOut.Text = Index.ToString();
                    AccumulatorOut.Text = Accumulator.ToString();
                }
                else
                {
                    MessageBox.Show("Don't have this command, try again", "Erro");
                }
            }

        }
    }
}
