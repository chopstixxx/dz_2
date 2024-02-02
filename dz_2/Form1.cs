using System.Windows.Forms.Design;

namespace dz_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files|*.txt";


            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = filetext;



        }

        private void save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("���� ������� ��������!");


        }

        private void font_ToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            richTextBox1.Font = fontDialog1.Font;
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
            else
            {
                MessageBox.Show("�������� �����!");
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_form form = new Search_form(richTextBox1);
            form.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] csharpKeywords = {
    "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
    "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
    "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
    "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
    "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
    "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
    "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this",
    "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort",
    "using", "virtual", "void", "volatile", "while"
};

            // ��������� ������� ������� ������� � ���������� �����, ����� ����� ��������� � ����
            int selectionStart = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;

            // ��������� ���� ������ �� ���������
            Color defaultColor = richTextBox1.ForeColor;

            // ���������� �� ������� ��������� �����
            foreach (string keyword in csharpKeywords)
            {
                int startIndex = 0;
                while (startIndex < richTextBox1.TextLength)
                {
                    // ������� ������ ������ ��������� �����
                    int wordStartIndex = richTextBox1.Find(keyword, startIndex, RichTextBoxFinds.WholeWord);
                    if (wordStartIndex != -1)
                    {
                        // ������������� ���� ��� ���� ���� ��������� �����
                        richTextBox1.Select(wordStartIndex, keyword.Length);
                        richTextBox1.SelectionColor = Color.Blue;
                        startIndex = wordStartIndex + keyword.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // ���������� ������� ������� � ��������� ������� �� ������� ��������
            richTextBox1.Select(selectionStart, selectionLength);

            // ���������� ���� ������ �� ���� �� ���������
            richTextBox1.SelectionColor = defaultColor;
        }
    }
}