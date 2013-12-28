namespace MajorProject
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxShowVariables = new System.Windows.Forms.CheckBox();
            this.radioButtonHorizontal = new System.Windows.Forms.RadioButton();
            this.radioButtonVertical = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonDegrees = new System.Windows.Forms.RadioButton();
            this.radioButtonRadians = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reset To Defaults";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(197, 181);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxShowVariables
            // 
            this.checkBoxShowVariables.AutoSize = true;
            this.checkBoxShowVariables.Checked = true;
            this.checkBoxShowVariables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowVariables.Location = new System.Drawing.Point(12, 12);
            this.checkBoxShowVariables.Name = "checkBoxShowVariables";
            this.checkBoxShowVariables.Size = new System.Drawing.Size(99, 17);
            this.checkBoxShowVariables.TabIndex = 2;
            this.checkBoxShowVariables.Text = "Show Variables";
            this.checkBoxShowVariables.UseVisualStyleBackColor = true;
            this.checkBoxShowVariables.CheckedChanged += new System.EventHandler(this.checkBoxShowVariables_CheckedChanged);
            // 
            // radioButtonHorizontal
            // 
            this.radioButtonHorizontal.AutoSize = true;
            this.radioButtonHorizontal.Location = new System.Drawing.Point(177, 29);
            this.radioButtonHorizontal.Name = "radioButtonHorizontal";
            this.radioButtonHorizontal.Size = new System.Drawing.Size(72, 17);
            this.radioButtonHorizontal.TabIndex = 3;
            this.radioButtonHorizontal.TabStop = true;
            this.radioButtonHorizontal.Text = "Horizontal";
            this.radioButtonHorizontal.UseVisualStyleBackColor = true;
            this.radioButtonHorizontal.CheckedChanged += new System.EventHandler(this.radioButtonHorizontal_CheckedChanged);
            // 
            // radioButtonVertical
            // 
            this.radioButtonVertical.AutoSize = true;
            this.radioButtonVertical.Location = new System.Drawing.Point(177, 52);
            this.radioButtonVertical.Name = "radioButtonVertical";
            this.radioButtonVertical.Size = new System.Drawing.Size(60, 17);
            this.radioButtonVertical.TabIndex = 4;
            this.radioButtonVertical.TabStop = true;
            this.radioButtonVertical.Text = "Vertical";
            this.radioButtonVertical.UseVisualStyleBackColor = true;
            this.radioButtonVertical.CheckedChanged += new System.EventHandler(this.radioButtonVertical_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Default Orientation";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(116, 181);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxAlwaysOnTop
            // 
            this.checkBoxAlwaysOnTop.AutoSize = true;
            this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(13, 36);
            this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
            this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAlwaysOnTop.TabIndex = 7;
            this.checkBoxAlwaysOnTop.Text = "Always on Top";
            this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkBoxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysOnTop_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Degrees or Radians";
            // 
            // radioButtonDegrees
            // 
            this.radioButtonDegrees.AutoSize = true;
            this.radioButtonDegrees.Location = new System.Drawing.Point(177, 119);
            this.radioButtonDegrees.Name = "radioButtonDegrees";
            this.radioButtonDegrees.Size = new System.Drawing.Size(65, 17);
            this.radioButtonDegrees.TabIndex = 9;
            this.radioButtonDegrees.TabStop = true;
            this.radioButtonDegrees.Text = "Degrees";
            this.radioButtonDegrees.UseVisualStyleBackColor = true;
            this.radioButtonDegrees.CheckedChanged += new System.EventHandler(this.radioButtonDegrees_CheckedChanged);
            // 
            // radioButtonRadians
            // 
            this.radioButtonRadians.AutoSize = true;
            this.radioButtonRadians.Location = new System.Drawing.Point(177, 142);
            this.radioButtonRadians.Name = "radioButtonRadians";
            this.radioButtonRadians.Size = new System.Drawing.Size(64, 17);
            this.radioButtonRadians.TabIndex = 10;
            this.radioButtonRadians.TabStop = true;
            this.radioButtonRadians.Text = "Radians";
            this.radioButtonRadians.UseVisualStyleBackColor = true;
            this.radioButtonRadians.CheckedChanged += new System.EventHandler(this.radioButtonRadians_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 216);
            this.Controls.Add(this.radioButtonRadians);
            this.Controls.Add(this.radioButtonDegrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxAlwaysOnTop);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonVertical);
            this.Controls.Add(this.radioButtonHorizontal);
            this.Controls.Add(this.checkBoxShowVariables);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.button1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxShowVariables;
        private System.Windows.Forms.RadioButton radioButtonHorizontal;
        private System.Windows.Forms.RadioButton radioButtonVertical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonDegrees;
        private System.Windows.Forms.RadioButton radioButtonRadians;
    }
}