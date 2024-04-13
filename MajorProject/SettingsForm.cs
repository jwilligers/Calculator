using System;
using System.Windows.Forms;

namespace MajorProject
{
    public partial class SettingsForm : Form
    {
//        public static Settings1 preferences = new Settings1();
//        Calculator main = new Calculator();
        Settings1 preferences;
        Calculator main;
        public SettingsForm(Settings1 set, Calculator calc)
        {
            InitializeComponent();
            preferences = set;
            main = calc;
            setOptions();            
        }
        private void setOptions()
        {
            this.TopMost = preferences.AlwaysOnTop;
            checkBoxAlwaysOnTop.Checked = preferences.AlwaysOnTop;
            if (preferences.Horizontal)
            { radioButtonHorizontal.Checked = true; }
            else
            { radioButtonVertical.Checked = true; }
            checkBoxShowVariables.Checked = preferences.DisplayVariables;
            checkBoxShowFunctions.Checked = preferences.DisplayFunctions;
        }
        private void checkBoxShowVariables_CheckedChanged(object sender, EventArgs e)
        {
            preferences.DisplayVariables = checkBoxShowVariables.Checked;
            preferences.Save();
        }
        private void checkBoxShowFunctions_CheckedChanged(object sender, EventArgs e)
        {
            preferences.DisplayFunctions = checkBoxShowFunctions.Checked;
            preferences.Save();
        }
        private void radioButtonHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            preferences.Horizontal = true;
            preferences.Save();
        }
        private void radioButtonVertical_CheckedChanged(object sender, EventArgs e)
        {
            preferences.Horizontal = false;
            preferences.Save();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            preferences.Reset();
            this.Refresh();
            setOptions();
            this.Close();
            main.UpdateFromSettings();
        }
        private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            preferences.AlwaysOnTop = checkBoxAlwaysOnTop.Checked;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            preferences.Save();
            this.Close();
            main.UpdateFromSettings();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonDegrees_CheckedChanged(object sender, EventArgs e)
        {
            preferences.Radians = false;
            preferences.Save();
        }

        private void radioButtonRadians_CheckedChanged(object sender, EventArgs e)
        {
            preferences.Radians = true;
            preferences.Save();
        }
    }
}