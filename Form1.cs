using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Projekti
{
    public partial class Form1 : Form
    {
        int counter = 0;
        int celesi = 0;
        int numeruesi = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    textBox1.Text = ofd.FileName;
                    richTextBox1.Text = File.ReadAllText(ofd.FileName);


                }
            



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            string readText = richTextBox1.Text;
            string emadhe = readText.ToUpper();



            Char mostRepeated(string s)
            {

                int[] count = new int[10000];
                int max = 0;
                Char result = Char.MinValue;
                Array.Clear(count, 0, count.Length - 1);

                foreach (char c in s)
                    if (c != ' ' && ++count[c] > max)
                    {
                        max = count[c];
                        result = c;
                    }
                return result;
            }

            string shkronjatemedha = readText.ToUpper();
           
            // MessageBox.Show("Shkronja me eperdorur eshte " + mostRepeated(shkronjatevogla));

            char meperdorura = mostRepeated(shkronjatemedha);
            int llog1(char shkronja)
            
            {
                celesi= (((meperdorura - shkronja) + 26) % 26);
                return celesi;
            }
            
            //llog1('E');
            //celesi = (((mostRepeated(shkronjatemedha) - 'E') + 26) % 26);

            // MessageBox.Show("Shkronja me eperdorur eshte " + meperdorura + ".");

            if (counter % 6 == 0)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('E'));
                textBox2.Text = llog1('E').ToString();
            }
            else if (counter % 6 == 1)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('T'));
                textBox2.Text = llog1('T').ToString();

            }
            else if (counter % 6 == 2)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('A'));
                textBox2.Text = llog1('A').ToString();

            }
            else if (counter % 6 == 3)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('O'));
                textBox2.Text = llog1('O').ToString();
            }
            else if (counter % 6 == 4)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('I'));
                textBox2.Text = llog1('I').ToString();

            }
            else if (counter % 6 == 5)
            {
                richTextBox2.Text = Decrypt(emadhe, llog1('N'));
                textBox2.Text = llog1('N').ToString();

            }
            else 
            {
                /*
                 * SI VJEN RENDI KURRRE, VEC NESE E BON PA MODUL,
                 * POR PA MODUL NUK TE LE ME I EGZ FILE-T 
                 * E NJEPASNJESHME PA E BE RUN EDHE NIHER PROGRAMIN
                */
                richTextBox2.Text = Decrypt(emadhe, llog1('S'));
                textBox2.Text = llog1('S').ToString();
                MessageBox.Show("Ju keni provuar shume!Ju lutem mbylleni programin!");

            }



            string Decrypt(string ciphertext, int key)
            {
                StringBuilder sbDecryptedtext = new StringBuilder(ciphertext);
                for (int i = 0; i < ciphertext.Length; i++)
                {
                    char ch = ciphertext[i];

                    if (Char.IsLetter(ch) == true) //((ch == ' ') || (ch == '!') || (ch == '.') || (ch == ',') || (ch == '?') || (ch == '\''))
                    // continue;

                    {
                        int posCh = ch - 'A';
                        posCh = (posCh - key + 26) % 26;
                        //A-A----0-3=-3+26=23%26=23-------15-3=12+26=38%26=12
                        ch = (char)(posCh + 'A');
                        sbDecryptedtext[i] = ch;
                    }
                }
                return sbDecryptedtext.ToString();
            }
            
            
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            counter++;
             
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            numeruesi++;// SE KE PERDOR, U MENDUA PER PJESEN E FILE-T SA HERE KLIKON
        }
    }
}
     











