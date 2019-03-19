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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] row1 = new string[] { "ㄱ", "g" };
            string[] row2 = new string[] { "ㄴ", "n" };
            string[] row3 = new string[] { "ㄷ", "d" };
            string[] row4 = new string[] { "ㄹ", "l" };
            string[] row5 = new string[] { "ㅁ", "m" };
            string[] row6 = new string[] { "ㅂ", "b" };
            string[] row7 = new string[] { "ㅅ", "s" };
            string[] row8 = new string[] { "ㅇ", "silent / ng" };
            string[] row9 = new string[] { "ㅈ", "j" };
            string[] row10 = new string[] { "ㅊ", "ch" };
            string[] row11 = new string[] { "ㅋ", "k" };
            string[] row12 = new string[] { "ㅌ", "t" };
            string[] row13 = new string[] { "ㅍ", "p" };
            string[] row14 = new string[] { "ㅎ", "h" };

            object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7,
                row8, row9, row10, row11, row12, row13, row14 };

            foreach (string[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }

            string[] row15 = new string[] { "ㅏ", "a" };
            string[] row16 = new string[] { "ㅑ", "ya" };
            string[] row17 = new string[] { "ㅓ", "eo" };
            string[] row18 = new string[] { "ㅕ", "yeo" };
            string[] row19 = new string[] { "ㅗ", "o" };
            string[] row20 = new string[] { "ㅛ", "yo" };
            string[] row21 = new string[] { "ㅜ", "oo" };
            string[] row22 = new string[] { "ㅠ", "yu" };
            string[] row23 = new string[] { "ㅡ", "uh" };
            string[] row24 = new string[] { "ㅣ", "i" };

            // COMPLEX VOWELS
            string[] row25 = new string[] { "ㅐ", "ae" };
            string[] row26 = new string[] { "ㅒ", "yae" };
            string[] row27 = new string[] { "ㅔ", "e" };
            string[] row28 = new string[] { "ㅖ ", "ye" };
            string[] row29 = new string[] { "ㅘ", "wa" };
            string[] row30 = new string[] { "ㅚ", "oe" };
            string[] row31 = new string[] { "ㅙ", "wae" };
            string[] row32 = new string[] { "ㅟ", "wi" };
            string[] row33 = new string[] { "ㅞ", "we" };
            string[] row34 = new string[] { "ㅢ", "ui" };
            string[] row35 = new string[] { "ㅝ", "wo" };

            object[] rowVowels = new object[] { row15, row16, row17, row18, row19,
                row20, row21, row22, row23, row24,
                row25, row26, row27, row28, row29,
                row30, row31, row32, row33, row34, row35};

            foreach (string[] rowArray in rowVowels)
            {
                dataGridView2.Rows.Add(rowArray);
            }

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            f1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoice("Microsoft Heami Desktop");

            Regex reg = new Regex("^[a-zA-Z0-9]*$");

            if (reg.IsMatch(textBox1.Text))
            {
                MessageBox.Show("ERROR: Enter a korean word.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            synth.Speak(textBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
