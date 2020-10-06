using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Perestanovka
{
    public partial class Form1 : Form
    {
        Transposition t;
        public Form1()
        {
            InitializeComponent();
            t = new Transposition();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Проверьте введённые данные", "Ошибка:");
            }
            else
            {
               
                string text = textBox1.Text;
                string key = textBox2.Text;
                string[] words = new string[key.Length];
                int pos = 0;
                int key_length = textBox2.Text.Length;
                int text_length = textBox1.Text.Length;
                string key_s = "";
                if (key_length > text_length)
                {
                    int raz = key_length - text_length;
                    for (int i = 0; i < key.Length - raz; i++)
                    {
                        key_s += key[i];
                    }
                }
                else
                {
                    key_s = key;
                }

                for (int i = 0; i < key_s.Length; i++)
                {
                    words[i] = Convert.ToString(key_s[i]);
                }
                var al_words = words.OrderBy(item => item, StringComparer.Ordinal);
                string alp = "";
                int k = 0;
                foreach (string v in al_words)
                {
                    alp += v;
                    k++;
                }
                /*textBox3.Text += alp;*/
                int[] ke = new int[alp.Length];

                for (int i = 0; i < key_s.Length; i++)
                {
                    pos = alp.IndexOf(key_s[i]);
                    ke[i] = pos + 1;


                }
                for (int i = 0; i < ke.Length; i++)
                {
                    for (int j = i + 1; j < ke.Length; j++)
                    {
                        if (ke[i] == ke[j])
                            ke[j] = ke[i] + 1;
                    }

                }

               /* for(int i=0;i<ke.Length;i++)
                {
                    textBox3.Text += ke[i] + " ";
                }*/


                textBox3.Text = t.Encrypt(text, ke)
                ;
            }

        }

        private void дешифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void строкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            textBox1.Text = filetext;
            MessageBox.Show("Файл открыт!");
        }

        private void расшифроватьСКлючомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(textBox3.Text);
                sw.Close();
            }
        }
    }
}
