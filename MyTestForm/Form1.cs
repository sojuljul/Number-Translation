using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Speech.Synthesis;
using System.Globalization;

using System.Text.RegularExpressions;

namespace MyTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string onesPlace(string numString, bool isSino)
        {
            int numTemp = Convert.ToInt32(numString);
            string numKorean = "";

            switch(numTemp)
            {
                case 0:
                    numKorean = "yeong";
                    break;
                case 1:
                    if (isSino == true)
                    {
                        numKorean = "il";
                    }
                    else
                    {
                        numKorean = "hana";
                    }
                    break;
                case 2:
                    if (isSino == true)
                    {
                        numKorean = "i";
                    }
                    else
                    {
                        numKorean = "dul";
                    }
                    break;
                case 3:
                    if (isSino == true)
                    {
                        numKorean = "sam";
                    }
                    else
                    {
                        numKorean = "set";
                    }
                    
                    break;
                case 4:
                    if (isSino == true)
                    {
                        numKorean = "sa";
                    }
                    else
                    {
                        numKorean = "net";
                    }
                    
                    break;
                case 5:
                    if (isSino == true)
                    {
                        numKorean = "o";
                    }
                    else
                    {
                        numKorean = "daseot";
                    }

                    break;
                case 6:
                    if (isSino == true)
                    {
                        numKorean = "yuk";
                    }
                    else
                    {
                        numKorean = "yeoseot";
                    }
                    
                    break;
                case 7:
                    if (isSino == true)
                    {
                        numKorean = "chil";
                    }
                    else
                    {
                        numKorean = "ilgop";
                    }
                    
                    break;
                case 8:
                    if (isSino == true)
                    {
                        numKorean = "pal";
                    }
                    else
                    {
                        numKorean = "yeodeol";
                    }
                    
                    break;
                case 9:
                    if (isSino == true)
                    {
                        numKorean = "gu";
                    }
                    else
                    {
                        numKorean = "ahop";
                    }
                    
                    break;
            }

            return numKorean;
        }

        private string tensPlace(string numString, bool isSino)
        {
            int numTemp = Convert.ToInt32(numString);
            string numKorean = "";

            switch(numTemp)
            {
                case 10:
                    if (isSino == true)
                    {
                        numKorean = "ship";
                    }
                    else
                    {
                        numKorean = "yeol";
                    }
                    break;
                case 20:
                    if (isSino == true)
                    {
                        numKorean = "eeship";
                    }
                    else
                    {
                        numKorean = "seumul";
                    }
                    break;
                case 30:
                    if (isSino == true)
                    {
                        numKorean = "samship";
                    }
                    else
                    {
                        numKorean = "seoreun";
                    }
                    
                    break;
                case 40:
                    if (isSino == true)
                    {
                        numKorean = "saship";
                    }
                    else
                    {
                        numKorean = "maheun";
                    }
                    
                    break;
                case 50:
                    if (isSino == true)
                    {
                        numKorean = "oship";
                    }
                    else
                    {
                        numKorean = "swin";
                    }
                    
                    break;
                case 60:
                    if (isSino == true)
                    {
                        numKorean = "yukship";
                    }
                    else
                    {
                        numKorean = "yesun";
                    }
                    
                    break;
                case 70:
                    if (isSino == true)
                    {
                        numKorean = "chilship";
                    }
                    else
                    {
                        numKorean = "ilheun";
                    }
                    
                    break;
                case 80:
                    if (isSino == true)
                    {
                        numKorean = "palship";
                    }
                    else
                    {
                        numKorean = "yeodeun";
                    }
                    
                    break;
                case 90:
                    if (isSino == true)
                    {
                        numKorean = "guship";
                    }
                    else
                    {
                        numKorean = "aheun";
                    }
                    
                    break;
                
                default:
                    if (numTemp > 0)
                    {
                        if (isSino == true)
                        {
                            string tensTemp = tensPlace(numString.Substring(0, 1) + "0", true);
                            string onesTemp = onesPlace(numString.Substring(1), true);
                            numKorean = tensTemp + " " + onesTemp;
                        }
                        else
                        {
                            string tensTemp = tensPlace(numString.Substring(0, 1) + "0", false);
                            string onesTemp = onesPlace(numString.Substring(1), false);
                            numKorean = tensTemp + " " + onesTemp;
                        }
                    }
                    break;
            }

            return numKorean;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("ERROR: Please enter a number.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex reg = new Regex("^[0-9]*$");

            if (!reg.IsMatch(textBox1.Text))
            {
                MessageBox.Show("ERROR: Please enter a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            button2.Enabled = true;
            button5.Enabled = true;

            string numText = textBox1.Text;
            int num = Convert.ToInt32(numText);
            string tempSino = "";
            string tempNative = "";

            

            if (num >= 0 && num < 10)
            {
                tempSino = onesPlace(numText, true);
                tempNative = onesPlace(numText, false);
            }
            else if (num >= 10 && num < 100)
            {
                tempSino = tensPlace(numText, true);
                tempNative = tensPlace(numText, false);
            }
            else if (num >= 100 || num < 0)
            {
                tempSino = "N/A";
                tempNative = "N/A";
            }

            textBox2.Text = tempSino;
            textBox3.Text = tempNative;
            textBox4.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            //foreach (InstalledVoice voice in synth.GetInstalledVoices())
            //{
            //    VoiceInfo info = voice.VoiceInfo;

            //    Console.WriteLine("Name: " + info.Name);
            //    Console.WriteLine("Cult: " + info.Culture);
            //}

            synth.SelectVoice("Microsoft Heami Desktop");
            synth.Volume = 100;

            int numTemp = Convert.ToInt32(textBox4.Text);
            string temp = "";
            string tempText = textBox4.Text;

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            myDictionary.Add(1, "일");
            myDictionary.Add(2, "이");
            myDictionary.Add(3, "삼");
            myDictionary.Add(4, "사");
            myDictionary.Add(5, "오");
            myDictionary.Add(6, "육");
            myDictionary.Add(7, "칠");
            myDictionary.Add(8, "팔");
            myDictionary.Add(9, "구");
            myDictionary.Add(10, "십");
            myDictionary.Add(20, "이십");
            myDictionary.Add(30, "삼십");
            myDictionary.Add(40, "사십");
            myDictionary.Add(50, "오십");
            myDictionary.Add(60, "육십");
            myDictionary.Add(70, "칠십");
            myDictionary.Add(80, "팔십");
            myDictionary.Add(90, "구십");


            if (numTemp >= 100)
            {
                MessageBox.Show("ERROR: Values greater than 99 are incomplete.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numTemp < 0)
            {
                MessageBox.Show("ERROR: Values less than 0 are invalid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numTemp < 10 || numTemp == 10 || numTemp == 20 || numTemp == 30 || numTemp == 40 ||
                numTemp == 50 || numTemp == 60 || numTemp == 70 || numTemp == 80 || numTemp == 90)
            {
                temp = myDictionary[numTemp];
            }
            else
            {
                string tensPlace = tempText.Substring(0, 1) + "0";
                string onesPlace = tempText.Substring(1);

                string tempTens = myDictionary[Convert.ToInt32(tensPlace)];
                string tempOnes = myDictionary[Convert.ToInt32(onesPlace)];

                temp = tempTens + " " + tempOnes;
            }

            synth.Speak(temp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Sino-Korean number system is used for dates, money, addresses, phone numbers, and numbers over 100.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Native Korean number system is used for number of items (1-99) and age.";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.SelectVoice("Microsoft Heami Desktop");
            synth.Volume = 100;

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            myDictionary.Add(0, "영");
            myDictionary.Add(1, "하나");
            myDictionary.Add(2, "둘");
            myDictionary.Add(3, "셋");
            myDictionary.Add(4, "넷");
            myDictionary.Add(5, "다섯");
            myDictionary.Add(6, "여섯");
            myDictionary.Add(7, "일곱");
            myDictionary.Add(8, "여덟");
            myDictionary.Add(9, "아홉");
            myDictionary.Add(10, "열");
            myDictionary.Add(20, "스물");
            myDictionary.Add(30, "서른");
            myDictionary.Add(40, "마흔");
            myDictionary.Add(50, "쉰");
            myDictionary.Add(60, "예순");
            myDictionary.Add(70, "일흔");
            myDictionary.Add(80, "여든");
            myDictionary.Add(90, "아흔");

            string tempText = textBox4.Text;
            int numText = Convert.ToInt32(tempText);
            string temp = "";

            if (numText >= 100)
            {
                MessageBox.Show("ERROR: Values greater than 99 are invalid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numText < 0)
            {
                MessageBox.Show("ERROR: Values less than 0 are invalid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numText < 10 || numText == 10 || numText == 20 || numText == 30 ||
                numText == 40 || numText == 50 || numText == 60 || numText == 70 ||
                numText == 80 || numText == 90)
            {
                temp = myDictionary[numText];
            }            
            else
            {
                string tensPlace = tempText.Substring(0, 1) + "0";
                string onesPlace = tempText.Substring(1);

                string tempTens = myDictionary[Convert.ToInt32(tensPlace)];
                string tempOnes = myDictionary[Convert.ToInt32(onesPlace)];

                temp = tempTens + " " + tempOnes;
            }
            
            synth.Speak(temp);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            button2.Enabled = false;
            button5.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            f2.ShowDialog();
        }
    }
}
