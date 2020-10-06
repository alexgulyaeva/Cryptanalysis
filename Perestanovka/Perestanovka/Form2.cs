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
    public partial class Form2 : Form
    {
        int k = 2;
        int d = 2; Transposition t;
        public Form2()
        {
            InitializeComponent();
            t = new Transposition();
            textBox3.Text = Convert.ToString(d);
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Проверьте введённые данные!", "Ошибка:");
            }
            else
            {

                string text = textBox1.Text;

                button1.Text = "Продолжить";


                string k = GeneratorKey(d);



                string[] mass = k.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < mass.Length; j++)
                {
                    string pr = mass[j];
                    int[] c = new int[pr.Length];
                    textBox2.Text += "Ключ: ";
                    for (int i = 0; i < pr.Length; i++)
                    {

                        c[i] = Convert.ToInt32(pr[i]) - 48;
                        textBox2.Text += Convert.ToString(c[i]) + " ";
                    }
                    textBox2.Text += "Результат: " + t.Decrypt(text, c) + "; " + "\r\n\r\n";


                }
                MessageBox.Show("Для продолжения криптоанализа нажмите кнопку <<Продолжить>>", "Хотите продолжить?");
                d++;
                textBox3.Text = Convert.ToString(d);
            }


        }

    
        static int fact(int num)
        {
            return (num == 0) ? 1 : num * fact(num - 1);
        }
        static string GeneratorKey(int d)
        {
            string k = "";
            if (d == 2)
            {
                for (int i = 1; i < d + 1; i++)
                {

                    for (int j = 1; j < d + 1; j++)
                    {
                        if (i != j)
                        {
                            k += Convert.ToString(i) + Convert.ToString(j) + " ";
                        }
                    }
                }
            }
            if(d==3)
            {
                for (int i = 1; i < d + 1; i++)
                {

                    for (int j = 1; j < d + 1; j++)
                    {
                        for(int z=1;z<d+1;z++)

                        if (i != j && i!=z && z!=j)
                        {
                            k += Convert.ToString(i) + Convert.ToString(j)+ Convert.ToString(z) + " ";
                        }
                    }
                }
            }
            if (d == 4)
            {
                for (int i = 1; i < d + 1; i++)
                {

                    for (int j = 1; j < d + 1; j++)
                    {
                        for (int z = 1; z < d + 1; z++)
                        {
                            for (int q = 1; q < d + 1; q++)
                                if (i != j && i != z && z != j && q!=i &&q!=j && q!=z)
                            {
                                k += Convert.ToString(i) + Convert.ToString(j) + Convert.ToString(z)+ Convert.ToString(q) + " ";
                            }
                        }
                    }
                }
            }
            if (d == 5)
            {
                for (int i = 1; i < d + 1; i++)
                {

                    for (int j = 1; j < d + 1; j++)
                    {
                        for (int z = 1; z < d + 1; z++)
                        {
                            for (int q = 1; q < d + 1; q++)
                            {
                                for (int a = 1; a < d + 1; a++)
                                    if (i != j && i != z && z != j && q != i && q != j && q != z && a != i && a != j && a != z &&a!=q)
                                {
                                    k += Convert.ToString(i) + Convert.ToString(j) + Convert.ToString(z) + Convert.ToString(q)+ Convert.ToString(a) + " ";
                                }
                            }
                        }
                    }
                }
                if (d == 5)
                {
                    for (int i = 1; i < d + 1; i++)
                    {

                        for (int j = 1; j < d + 1; j++)
                        {
                            for (int z = 1; z < d + 1; z++)
                            {
                                for (int q = 1; q < d + 1; q++)
                                {
                                    for (int a = 1; a < d + 1; a++)
                                    {
                                        for (int l = 1; l < d + 1; l++)
                                            if (i != j && i != z && z != j && q != i && q != j && q != z && a != i && a != j && a != z
                                                && a != q && l != i && l != j && l != z && q != l && a != l)
                                            {
                                                k += Convert.ToString(i) + Convert.ToString(j) + Convert.ToString(z) + Convert.ToString(q) + Convert.ToString(a) + Convert.ToString(l) + " ";
                                            }
                                    }
                                }
                            }
                        }
                    }
                    }
                }
            return k;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            textBox1.Text = filetext;
            MessageBox.Show("Файл открыт!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(textBox3.Text);
                sw.Close();
            }
            MessageBox.Show("Текст сохранён!");
        }
    }
}
