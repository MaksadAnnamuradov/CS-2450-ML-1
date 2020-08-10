namespace UV_Sim_Csharp
{
    partial class Form1
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
            this.UVinput = new System.Windows.Forms.TextBox();
            this.sign = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IndexOut = new System.Windows.Forms.Label();
            this.InitializeButton = new System.Windows.Forms.Button();
            this.InitialLabel = new System.Windows.Forms.Label();
            this.AccumulatorOut = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.InputNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NewApplication_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UVinput
            // 
            this.UVinput.Location = new System.Drawing.Point(636, 137);
            this.UVinput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UVinput.Name = "UVinput";
            this.UVinput.Size = new System.Drawing.Size(178, 26);
            this.UVinput.TabIndex = 0;
            // 
            // sign
            // 
            this.sign.AutoSize = true;
            this.sign.Location = new System.Drawing.Point(610, 142);
            this.sign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(18, 20);
            this.sign.TabIndex = 1;
            this.sign.Text = "+";
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click + change it to -";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(860, 137);
            this.NextButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(112, 38);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Accumulator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Location:";
            // 
            // IndexOut
            // 
            this.IndexOut.AutoSize = true;
            this.IndexOut.Location = new System.Drawing.Point(176, 198);
            this.IndexOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IndexOut.Name = "IndexOut";
            this.IndexOut.Size = new System.Drawing.Size(18, 20);
            this.IndexOut.TabIndex = 7;
            this.IndexOut.Text = "0";
            // 
            // InitializeButton
            // 
            this.InitializeButton.Location = new System.Drawing.Point(372, 42);
            this.InitializeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InitializeButton.Name = "InitializeButton";
            this.InitializeButton.Size = new System.Drawing.Size(112, 38);
            this.InitializeButton.TabIndex = 8;
            this.InitializeButton.Text = "Initialize";
            this.InitializeButton.UseVisualStyleBackColor = true;
            this.InitializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // InitialLabel
            // 
            this.InitialLabel.AutoSize = true;
            this.InitialLabel.Location = new System.Drawing.Point(50, 50);
            this.InitialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InitialLabel.Name = "InitialLabel";
            this.InitialLabel.Size = new System.Drawing.Size(235, 20);
            this.InitialLabel.TabIndex = 9;
            this.InitialLabel.Text = "Please Initialize the memory first";
            // 
            // AccumulatorOut
            // 
            this.AccumulatorOut.AutoSize = true;
            this.AccumulatorOut.Location = new System.Drawing.Point(176, 140);
            this.AccumulatorOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AccumulatorOut.Name = "AccumulatorOut";
            this.AccumulatorOut.Size = new System.Drawing.Size(18, 20);
            this.AccumulatorOut.TabIndex = 10;
            this.AccumulatorOut.Text = "0";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(254, 325);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(159, 20);
            this.MessageLabel.TabIndex = 11;
            this.MessageLabel.Text = "This is message label";
            // 
            // InputNumber
            // 
            this.InputNumber.Location = new System.Drawing.Point(636, 200);
            this.InputNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputNumber.Name = "InputNumber";
            this.InputNumber.Size = new System.Drawing.Size(148, 26);
            this.InputNumber.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Input Number:";
            // 
            // NewApplication_Button
            // 
            this.NewApplication_Button.Location = new System.Drawing.Point(472, 667);
            this.NewApplication_Button.Name = "NewApplication_Button";
            this.NewApplication_Button.Size = new System.Drawing.Size(280, 40);
            this.NewApplication_Button.TabIndex = 14;
            this.NewApplication_Button.Text = "Start New Application";
            this.NewApplication_Button.UseVisualStyleBackColor = true;
            this.NewApplication_Button.Click += new System.EventHandler(this.NewApplication_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.NewApplication_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InputNumber);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.AccumulatorOut);
            this.Controls.Add(this.InitialLabel);
            this.Controls.Add(this.InitializeButton);
            this.Controls.Add(this.IndexOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sign);
            this.Controls.Add(this.UVinput);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UVinput;
        private System.Windows.Forms.Label sign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label accumulator;
        private System.Windows.Forms.Label IndexOut;
        private System.Windows.Forms.Button InitializeButton;
        private System.Windows.Forms.Label InitialLabel;
        private System.Windows.Forms.Label AccumulatorOut;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox InputNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button NewApplication_Button;
    }
}

