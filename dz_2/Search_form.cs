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

namespace dz_2
{
    public partial class Search_form : Form
    {
        RichTextBox richTextBox1;
        public Search_form(RichTextBox rich)
        {
            InitializeComponent();
            richTextBox1 = rich;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите текст!");
                return;

            }
            string find = textBox1.Text;
            string pattern = @"\b" + Regex.Escape(find) + @"\b";

            MatchCollection matches = Regex.Matches(richTextBox1.Text, pattern, RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                MessageBox.Show($"Найдено {matches.Count} совпадений!");
                foreach (Match match in matches)
                {
                    richTextBox1.Select(match.Index, match.Length);
                    richTextBox1.SelectionBackColor = Color.LightBlue;
                }
            }
            else
            {
                MessageBox.Show("Не найдено ни одного совпадения!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string find = textBox1.Text;
            string replace = textBox2.Text;
            string pattern = @"\b" + Regex.Escape(find) + @"\b";

            string newText = Regex.Replace(richTextBox1.Text, pattern, replace, RegexOptions.IgnoreCase);

            if (newText != richTextBox1.Text)
            {
                richTextBox1.Text = newText;
                MessageBox.Show("Замена выполнена успешно");
            }
            else
            {
                MessageBox.Show("Не найдено ни одного совпадения!");
            }
        }
    }
}
