using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Windows.Forms.VisualStyles;

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
        bool multisign = true;
        string a;
        string b;
        string c;
        //Change the sign for operation
        private void sign_Click(object sender, EventArgs e)
        {
            if (sign.Text == "+")
            {
                sign.Text = "-";
                multisign = false;
            }
            else
            {
                sign.Text = "+";
                multisign = true;
            }
        }
        
        private void InitializaString()
        {
            a = "";
            b = "";
            c = "";
        }

        private void InitializeButton_Click(object sender, EventArgs e)
        {
            //initialize the memory array to all +0000;
            InitializaString();
            sign.Text = "+";
            inputcheck = false;
            multisign = true;
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
            try
            {
                number = Int16.Parse(InputNumber.Text.ToString());
            }
            catch
            {

            }
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
                Operation();
            }

        }

        private void ReadText_Click(object sender, EventArgs e)
        {
            if (InitialLabel.Text != "Memory is ready to go")
            {
                MessageBox.Show("Please initialize first", "Erro");
            }
            inputcheck = true;
            for(int i = 0; i < MultiText.Lines.Count(); i++)
            {
                //Thread.Sleep(5000);
                string linestring = MultiText.Lines[i];
                if (linestring[0].ToString() == "+")
                {
                    multisign = true;
                }
                else if (linestring[0].ToString() == "-")
                {
                    multisign = false;
                }
                command = Int16.Parse(linestring[1].ToString() + linestring[2].ToString());
                targetIndex = Int16.Parse(linestring[3].ToString() + linestring[4].ToString());
                number = targetIndex;
                Operation();
                
            }

        }

        public void Operation()
        {
            InitializaString();
            if (inputcheck == false)
            {
                MessageBox.Show("The input should be 4 digits, please try again", "Erro");
                return;
            }
            //read
            if (command == 10)
            {
                //bring the number to targetIndex
                //if (sign.Text == "-")
                if (multisign == true)
                {
                    Memory[targetIndex] = number;
                }
                else
                {
                    Memory[targetIndex] = number * -1;
                }
                
                //Message printout
                MessageLabel.Text = "The operation is READ," +
                    "number " + number + " stored in Memory " + targetIndex;
                //update the index;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
            }
            //write
            else if (command == 11)
            {
                //write data from location to screen
                MessageLabel.Text = "The operation is WRITE," + 
                    "the data stored in memory: " + targetIndex + " is " + Memory[targetIndex];
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
            }
            //load
            else if (command == 20)
            {
                //bring the numebr in targetIndex to the accumulator
                //not add
                Accumulator = Memory[targetIndex];
                MessageLabel.Text = "The operation is LOAD";
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //store
            else if (command == 21)
            {
                //store number from input in accumulator
                Memory[targetIndex] = number;
                //message
                MessageLabel.Text = "The operation is STORE," +
                    "number " + number + " stored in accumulator " + targetIndex;
                Accumulator = number;
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //add
            else if (command == 30)
            {
                //add to accumulator
                a = ConvertBinary(Accumulator);       //translate accumulator and memory number to binary
                b = ConvertBinary(Memory[targetIndex]);
                c = BinaryAdd(a, b);
                MessageLabel.Text = "The operation is ADD" +
                    "\nAccumulator number in binary is :" + a + "\nMemory number in binary is :" + b
                    + "\nResult numebr in binary is :" + c;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();

            }
            //subtract
            else if (command == 31)
            {
                //subtract to accumulator
                a = ConvertBinary(Accumulator);       //translate accumulator and memory number to binary
                b = ConvertBinary(Memory[targetIndex]);
                c = BinarySub(a, b);
                MessageLabel.Text = "The operation is SUBTRACT" +
                    "\nAccumulator number in binary is " + a + "\nMemory number in binary is :" + b
                    + "\nResult numebr in binary is :" + c;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //divide
            else if (command == 32)
            {
                //divide number in accumulator by number in memory
                Accumulator = BinaryDivide(Accumulator,Memory[targetIndex]);
                MessageLabel.Text = "The operation is DIVIDE, " +
                    "the result is: " + Accumulator;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //multiply
            else if (command == 33)
            {
                //multiply number in accumulator by number in memory
                Accumulator = BinaryMulti(Accumulator, Memory[targetIndex]);
                MessageLabel.Text = "The operation is MULTIPLY, " +
                    "the result is: " + Accumulator;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //mod
            else if (command == 34)
            {
                Accumulator = BinaryMod(Accumulator, Memory[targetIndex]);
                MessageLabel.Text = "The operation is MOD, " +
                    "the result is: " + Accumulator;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //exponent
            else if (command == 35)
            {
                Accumulator = BinaryExponent(Accumulator, Memory[targetIndex]);
                MessageLabel.Text = "The operation is EXPONENT, " +
                    "the result is: " + Accumulator;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
                AccumulatorOut.Text = Accumulator.ToString();
            }
            //branch
            else if (command == 40)
            {
                MessageLabel.Text = "The operation is BRANCH, " +
                    "jump to Memory " + targetIndex;
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
            }
            //branchneg
            else if (command == 41)
            {
                //invert target number
                Memory[targetIndex] = -Memory[targetIndex];
                MessageLabel.Text = "The operation is BRANCHNEG, " +
                  "jump to Memory " + targetIndex + "invert number equals: " + Memory[targetIndex];

                Index = targetIndex;
                IndexOut.Text = Index.ToString();
            }
            //branchzero
            else if (command == 42)
            {
                //branch to memory location and zero out
                Memory[targetIndex] = 0;
                MessageLabel.Text = "The operation is BRANCHZERO, " +
                    " jump to Memory " + targetIndex + " zero out memory equals: " + Memory[targetIndex];
                Index = targetIndex;
                IndexOut.Text = Index.ToString();
            }
            //halt
            else if (command == 43)
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
            //error
            else
            {
                MessageBox.Show("Don't have this command, try again", "Erro");
            }
        }

        public string ConvertBinary(int decimalNumber)
        {
            string result = "";
            //a and b are two arrays store the binary number
            if (decimalNumber != 0)
            {
                for (int i = 0; decimalNumber > 0; i++)
                {
                    if (decimalNumber % 2 == 1)
                    {
                        result = "1" + result;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                    decimalNumber = decimalNumber / 2;
                }
            }
            else
            {
                result = "0" + result;
            }
            while (result.Length < 8)
            {
                result = "0" + a;
            }
            return result;
        }

        public int ConvertDecimal(string target)
        {
            int result = Convert.ToInt32(target, 2);
            return result;
        }

        public string BinaryAdd(string first, string second)
        {
            string result = "";
            bool carry = false;//begin with no carry
            for (int i = first.Length - 1; i >= 0; i--)
            {
                if (first[i] == '0' && second[i] == '0') //0+0=0
                {
                    //check carry
                    if (carry == true)  //0+carry = 1
                    {
                        result = "1" + result;
                        carry = false;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
                else if (first[i] == '1' && second[i] == '0')
                {
                    //check carry
                    if (carry == true)  //1+carry = 0
                    {
                        result = "0" + result;
                        carry = false;
                    }
                    else
                    {
                        result = "1" + result;
                    }
                }
                else if (first[i] == '0' && second[i] == '1')//0+1=1
                {
                    //check carry
                    if (carry == true)  //1+carry = 1
                    {
                        result = "0" + result;
                        carry = false;
                    }
                    else
                    {
                        result = "1" + result;
                    }
                }
                else if (first[i] == '1' && second[i] == '1')//1+1 = 0 and carry to 1
                {
                    //check carry
                    if (carry == true)  //0+carry = 1
                    {
                        result = "1" + result;
                        carry = false;
                    }
                    else
                    {
                        result = "0" + result;
                        carry = true;
                    }
                }
            }
            while (result.Length < 8)
            {
                result = "0" + result;
            }
            //get c array with result binary
            return result;
        }
        public string BinarySub(string first, string second)
        {
            string result = "";
            int carry = 0;//begin with no carry
            for (int i = 7; i >= 0; i--)
            {
                if (first[i] == '0' && second[i] == '0') //0-0=0
                {
                    //check carry
                    if (carry > 0)  //0-carry = 1
                    {
                        result = "1" + result;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
                else if (first[i] == '1' && second[i] == '0') //1-0 = 1
                {
                    //check carry
                    if (carry > 0)  //1 - carry = 0
                    {
                        result = "0" + result;
                        carry -= 1;
                    }
                    else
                    {
                        result = "1" + result;
                    }
                }
                else if (first[i] == '0' && second[i] == '1')//0-1=1
                {
                    //check carry
                    if (carry > 0)  // 0 - 1 - carry = 
                    {
                        c = "0" + c;
                    }
                    else
                    {
                        result = "1" + result;
                        carry += 1;
                    }
                }
                else if (first[i] == '1' && second[i] == '1')//1-1 = 0 and carry to 1
                {
                    //check carry
                    if (carry > 0)  //0+carry = 1
                    {
                        result = "1" + result;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
            }
            while (result.Length < 8)
            {
                result = "0" + result;
            }
            return result;
        }

        public int BinaryMulti(int number, int counter)
        {
            int result = 0;
            string binaryString = ConvertBinary(number);
            string resultString = binaryString;
            for (int i = 0; i < counter; i++)
            {
                resultString = BinaryAdd(resultString, binaryString);
            }
            result = ConvertDecimal(resultString);

            return result;
        }

        //divide while loop until the reminder number is >= 0
        public int BinaryDivide(int a, int b)
        {
            int result = 0;
            string first = ConvertBinary(a);
            string second = ConvertBinary(b);
            bool check = false;
            while(check == false)
            {
                first = BinarySub(first, second);
                a = a - b;
                result += 1;
                if (a == 0)
                {
                    check = true;
                }
                if (a < b)
                {
                    check = true;
                }
            }
            
            return result;
        }

        //MOD
        public int BinaryMod(int a, int b)
        {
            int result = 0;
            string first = ConvertBinary(a);
            string second = ConvertBinary(b);
            bool check = false;
            while (check == false)
            {
                first = BinarySub(first, second);
                a = a - b;
                if (a == 0)
                {
                    check = true;
                    result = 0;
                }
                if (a < b)
                {
                    check = true;
                    result = a;
                }
            }
            return result;
        }

        //x exponent
        public int BinaryExponent(int a, int counter)
        {
            int result = a;
            for (int i = 0; i < counter-1; i++)
            {
                result = BinaryMulti(result, a);
            }
            return result;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Choose A File name";
                sfd.Filter = "Text File|*.txt";
                sfd.DefaultExt = ".txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    TextWriter tw = new StreamWriter(filePath);
                    tw.Write(MultiText.Text);
                    tw.Close();
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose a file";
                ofd.Filter = "Text File|*.txt";
                ofd.DefaultExt = ".txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    TextReader tr = new StreamReader(filePath);
                    MultiText.Text = tr.ReadToEnd();
                    tr.Close();
                }
            }
        }

        private void MultipleProcess_Button_Click(object sender, EventArgs e)
        {
            var _StartApplication = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath);
            System.Diagnostics.Process.Start(_StartApplication);
        }
    }
}
