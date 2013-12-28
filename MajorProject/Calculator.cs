using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using PolyLib;
namespace MajorProject
{
    public partial class Calculator : Form
    {
        Settings1 settings = new Settings1();       
        string mode = "h";
        public Calculator()
        {
            // FormSplash splash = new FormSplash();
            // splash.Show();
            InitializeComponent();
            Polynomial P = new Polynomial(5,-4,0,1);
            Polynomial p1 = Polynomial.Derivative(P);
            //MessageBox.Show(p1.ToString());
            //MessageBox.Show(P.Roots().ToString());
            listBox1.Width = 148;
            settings.Reload();
            //settings.TextSize = 0;
            changeTextSize(settings.TextSize);
            this.Size = settings.Size;
            //this.Region = settings.Position;
            //splash.Hide();
            UpdateFromSettings();
        }
        public void saveSettings(/*Settings1 newSettings*/)
        {
          //  settings = newSettings;
           // settings.Save();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exit
            settings.Save();
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Are You Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InputBox.Clear(); // Clear the inputbox
            }
        }
        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                string input = InputBox.Text;
                Scanner scanner = new Scanner(input + "\n\n");
                Parser parser = new Parser(scanner);
                Worksheet worksheet = parser.ReadWorksheet();

                String[] solutions = new String[worksheet.NumLines()];

                bool progress;
                do
                {
                    progress = false;
                    for (int index = 0; index < worksheet.NumLines(); index++)
                    {
                        Line currentLine = worksheet.GetLine(index);
                        if (currentLine is EquationLine)
                        {
                            EquationLine equation = (EquationLine)currentLine;
                            try
                            {
                                String solution = equation.Solve();
                                solutions[index] = solution;
                                progress = true;
                            }
                            catch (SolvedException)
                            {
                            }
                            catch (UnknownVariableException)
                            {
                            }
                        }
                    }
                } while (progress);

                // OutputBox.Text = worksheet.ToString();
                //string[] variables = new string[parser.lengthOfDictionary()];

                //variables = parser.returnValues();

                String output = "";
                for (int index = 0; index < worksheet.NumLines(); index++)
                {
                    Line currentLine = worksheet.GetLine(index);
                    if (currentLine is ExpressionLine)
                    {
                        output += ((ExpressionLine)currentLine).Result().Value().ToString() + "\r\n";
                    }
                    else if (currentLine is EquationLine)
                    {
                        // ((EquationLine)currentLine).Solve();
                        output += solutions[index] + "\r\n"; //  currentLine.ToString();
                    }
                    else if (currentLine is CommentLine)
                    {
                        output += currentLine.ToString();
                    }
                    else
                    {
                        output += "\r\n";
                    }
                }
                OutputBox.Text = output;
                string[] variables = parser.returnValues();
                listBox1.Items.AddRange(variables);
                listBox1.Sorted = true;

            }
            catch (InputException)
            {
                OutputBox.Text = "";
            }
            catch (Exception error)
            {
                OutputBox.Text = error.Message;
            }

        }
        private void increaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.settings.TextSize += 1;
            changeTextSize(1);
            settings.Save();
        }
        private void changeTextSize(int number)
        {
            if (number > 0)
            {
                for (int i = 0; i <= number; i++)
                {
                    InputBox.Font = new Font("newfont", (InputBox.Font.SizeInPoints + 1));
                    OutputBox.Font = new Font("newfont", (OutputBox.Font.SizeInPoints + 1));
                    listBox1.Font = new Font("newfont", (listBox1.Font.SizeInPoints + 1));
                }
            }
            if (number == 0) { }
            else
            {
                number = -number;
                for (int i = 0; i <= number; i++)
                {
                    InputBox.Font = new Font("newfont", (InputBox.Font.SizeInPoints - 1));
                    OutputBox.Font = new Font("newfont", (OutputBox.Font.SizeInPoints - 1));
                    listBox1.Font = new Font("newfont", (listBox1.Font.SizeInPoints - 1));
                }
            }
            Resizing();
        }
        private void decreaseTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeTextSize(-1);
            this.settings.TextSize -= 1;
            settings.Save();
            Resizing();
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "v";
            Resizing();
            settings.Horizontal = false;
            settings.Save();
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "h";
            Resizing();
            settings.Horizontal = true;
            settings.Save();
        }
        private void InputBox_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "Click here and type. Examples include 'x = 4' or '1+2*4sin(pi/2)'")
            {
                InputBox.Text = "";
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://dl.dropbox.com/u/15531426/User%20Manual.pdf");
        }
        private void referenceManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://dl.dropbox.com/u/15531426/Reference%20Manual.pdf");
        }
        private void Resizing()
        {
            if (settings.DisplayVariables)
            {
                listBox1.Visible = true;
                if (mode == "h")
                {
                    int boxWidth = (this.Size.Width - 54 - listBox1.Width);
                    int boxHeight = (this.Size.Height - 112) / 2;
                    InputBox.Width = boxWidth;
                    InputBox.Height = boxHeight;
                    InputBox.Location = new Point(12, 27);
                    OutputBox.Width = boxWidth;
                    OutputBox.Height = boxHeight;
                    OutputBox.Location = new Point(12, this.Size.Height - 63 - boxHeight);
                    listBox1.Location = new Point(this.Width - 30 - listBox1.Width, 27);
                    listBox1.Height = this.Size.Height - 27-63;
                    listBox1.Size = listBox1.Size;

                    //listBoxVariables.Width = 148;
                    OutputBox.Width = boxWidth;
                    OutputBox.Height = boxHeight;
                }
                else
                {
                    int boxHeight = (this.Size.Height - 94);
                    int boxWidth = (this.Size.Width - 54 - listBox1.Width) / 2;
                    InputBox.Height = boxHeight;
                    InputBox.Width = boxWidth;
                    InputBox.Location = new Point(12, 27);
                    OutputBox.Location = new Point(20 + InputBox.Size.Width, 27);
                    listBox1.Location = new Point(this.Width - 30 - listBox1.Width, 27);
                    listBox1.Height = this.Size.Height - 94;

                    OutputBox.Height = boxHeight;
                    OutputBox.Width = boxWidth;
                }
            }
            else
            {
                listBox1.Visible = false;
                if (mode == "h")
                {
                    int boxHeight = (this.Size.Height - 112) / 2;
                    int boxWidth = (this.Size.Width - 54);
                    InputBox.Height = boxHeight;
                    InputBox.Width = boxWidth;
                    InputBox.Location = new Point(12, 27);
                    OutputBox.Location = new Point(12, 50 + InputBox.Size.Height);
                    OutputBox.Height = boxHeight;
                    OutputBox.Width = boxWidth;
                }
                else
                {
                    int boxHeight = (this.Size.Height - 94);
                    int boxWidth = (this.Size.Width - 54) / 2;
                    InputBox.Height = boxHeight;
                    InputBox.Width = boxWidth;
                    InputBox.Location = new Point(12, 27);
                    OutputBox.Location = new Point(20 + InputBox.Size.Width, 27);
                    OutputBox.Height = boxHeight;
                    OutputBox.Width = boxWidth;
                }
            }
        }
        private void Calculator_Resize(object sender, EventArgs e)
        {
            Resizing();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsform = new SettingsForm(settings, this);
            settingsform.Show();
        }
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator newWindow = new Calculator();
            newWindow.Show();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Calc files (*.calc)|*.calc|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Calc files (*.calc)|*.calc|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenFile(@openFileDialog1.FileName);
        }

        public void OpenFile(string FileName)
        {
            InputBox.Text = "";
            StreamReader reader = new StreamReader(FileName, true);
            try
            {
                InputBox.Text = reader.ReadToEnd();
            }
            finally
            {
                reader.Close();
            }
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            if (File.Exists(@saveFileDialog1.FileName))
            {
                if (new FileInfo(@saveFileDialog1.FileName).Length == 0)
                {
                    SaveFile(@saveFileDialog1.FileName, InputBox.Text);
                }
                else
                {
                    File.Delete(@saveFileDialog1.FileName);
                    SaveFile(@saveFileDialog1.FileName, InputBox.Text);
                }
            }
            else
            {
                SaveFile(@saveFileDialog1.FileName, InputBox.Text);
            }
        }
        private void SaveFile(string filename, string text)
        {
            StreamWriter writer = new StreamWriter(filename, true);
            try
            {
                writer.Write(text);
                writer.Flush();
            }
            finally
            {
                writer.Close();
            }
        }
        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Size = this.Size;
           // settings.Position = this.Region;

            settings.Save();
           
        }
        public void UpdateFromSettings()
        {
            this.TopMost = settings.AlwaysOnTop;
            if (settings.Horizontal)
            {
                mode = "h";
            }
            else
            {
                mode = "v";
            }
            Resizing();

            
          
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
              if (listBox1.SelectedItem != null) {
                 if (listBox1.SelectedItem.ToString().Length != 0)  {
                         InputBox.AppendText(listBox1.SelectedItem.ToString());
                } 
              }
        }
        
    }
}