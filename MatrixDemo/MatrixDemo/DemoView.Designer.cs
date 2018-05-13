namespace MatrixDemo
{
    partial class DemoView
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
            this.matrixTabs = new System.Windows.Forms.TabControl();
            this.uniaryTab = new System.Windows.Forms.TabPage();
            this.binaryTab = new System.Windows.Forms.TabPage();
            this.leftMatrixBox = new System.Windows.Forms.TextBox();
            this.leftMatrixLabel = new System.Windows.Forms.Label();
            this.rightMatrixBox = new System.Windows.Forms.TextBox();
            this.rightMatrixLabel = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.uniaryResultBox = new System.Windows.Forms.TextBox();
            this.uniaryMatrixBox = new System.Windows.Forms.TextBox();
            this.startMatrixLabel = new System.Windows.Forms.Label();
            this.resultMatrixLabel = new System.Windows.Forms.Label();
            this.rrefButton = new System.Windows.Forms.Button();
            this.determinantButton = new System.Windows.Forms.Button();
            this.inverseButton = new System.Windows.Forms.Button();
            this.transposeButton = new System.Windows.Forms.Button();
            this.scaleButton = new System.Windows.Forms.Button();
            this.matrixTabs.SuspendLayout();
            this.uniaryTab.SuspendLayout();
            this.binaryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // matrixTabs
            // 
            this.matrixTabs.Controls.Add(this.uniaryTab);
            this.matrixTabs.Controls.Add(this.binaryTab);
            this.matrixTabs.Location = new System.Drawing.Point(13, 13);
            this.matrixTabs.Name = "matrixTabs";
            this.matrixTabs.SelectedIndex = 0;
            this.matrixTabs.Size = new System.Drawing.Size(441, 355);
            this.matrixTabs.TabIndex = 0;
            // 
            // uniaryTab
            // 
            this.uniaryTab.Controls.Add(this.transposeButton);
            this.uniaryTab.Controls.Add(this.inverseButton);
            this.uniaryTab.Controls.Add(this.determinantButton);
            this.uniaryTab.Controls.Add(this.rrefButton);
            this.uniaryTab.Controls.Add(this.resultMatrixLabel);
            this.uniaryTab.Controls.Add(this.startMatrixLabel);
            this.uniaryTab.Controls.Add(this.uniaryMatrixBox);
            this.uniaryTab.Controls.Add(this.uniaryResultBox);
            this.uniaryTab.Location = new System.Drawing.Point(4, 22);
            this.uniaryTab.Name = "uniaryTab";
            this.uniaryTab.Size = new System.Drawing.Size(433, 329);
            this.uniaryTab.TabIndex = 0;
            this.uniaryTab.Text = "Uniary Operations";
            this.uniaryTab.UseVisualStyleBackColor = true;
            // 
            // binaryTab
            // 
            this.binaryTab.Controls.Add(this.scaleButton);
            this.binaryTab.Controls.Add(this.multiplyButton);
            this.binaryTab.Controls.Add(this.subtractButton);
            this.binaryTab.Controls.Add(this.addButton);
            this.binaryTab.Controls.Add(this.resultLabel);
            this.binaryTab.Controls.Add(this.resultBox);
            this.binaryTab.Controls.Add(this.rightMatrixLabel);
            this.binaryTab.Controls.Add(this.rightMatrixBox);
            this.binaryTab.Controls.Add(this.leftMatrixLabel);
            this.binaryTab.Controls.Add(this.leftMatrixBox);
            this.binaryTab.Location = new System.Drawing.Point(4, 22);
            this.binaryTab.Name = "binaryTab";
            this.binaryTab.Size = new System.Drawing.Size(433, 329);
            this.binaryTab.TabIndex = 1;
            this.binaryTab.Text = "Binary Operations";
            this.binaryTab.UseVisualStyleBackColor = true;
            // 
            // leftMatrixBox
            // 
            this.leftMatrixBox.Location = new System.Drawing.Point(7, 20);
            this.leftMatrixBox.Multiline = true;
            this.leftMatrixBox.Name = "leftMatrixBox";
            this.leftMatrixBox.Size = new System.Drawing.Size(200, 134);
            this.leftMatrixBox.TabIndex = 0;
            // 
            // leftMatrixLabel
            // 
            this.leftMatrixLabel.AutoSize = true;
            this.leftMatrixLabel.Location = new System.Drawing.Point(4, 4);
            this.leftMatrixLabel.Name = "leftMatrixLabel";
            this.leftMatrixLabel.Size = new System.Drawing.Size(59, 13);
            this.leftMatrixLabel.TabIndex = 1;
            this.leftMatrixLabel.Text = "Left Matrix:";
            // 
            // rightMatrixBox
            // 
            this.rightMatrixBox.Location = new System.Drawing.Point(216, 20);
            this.rightMatrixBox.Multiline = true;
            this.rightMatrixBox.Name = "rightMatrixBox";
            this.rightMatrixBox.Size = new System.Drawing.Size(200, 134);
            this.rightMatrixBox.TabIndex = 2;
            // 
            // rightMatrixLabel
            // 
            this.rightMatrixLabel.AutoSize = true;
            this.rightMatrixLabel.Location = new System.Drawing.Point(213, 4);
            this.rightMatrixLabel.Name = "rightMatrixLabel";
            this.rightMatrixLabel.Size = new System.Drawing.Size(66, 13);
            this.rightMatrixLabel.TabIndex = 3;
            this.rightMatrixLabel.Text = "Right Matrix:";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(216, 184);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(200, 134);
            this.resultBox.TabIndex = 4;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(213, 168);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Result:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(7, 168);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Location = new System.Drawing.Point(7, 198);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(75, 23);
            this.subtractButton.TabIndex = 7;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.subtractButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(7, 227);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(75, 23);
            this.multiplyButton.TabIndex = 8;
            this.multiplyButton.Text = "X";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // uniaryResultBox
            // 
            this.uniaryResultBox.Location = new System.Drawing.Point(215, 20);
            this.uniaryResultBox.Multiline = true;
            this.uniaryResultBox.Name = "uniaryResultBox";
            this.uniaryResultBox.Size = new System.Drawing.Size(200, 134);
            this.uniaryResultBox.TabIndex = 5;
            // 
            // uniaryMatrixBox
            // 
            this.uniaryMatrixBox.Location = new System.Drawing.Point(7, 20);
            this.uniaryMatrixBox.Multiline = true;
            this.uniaryMatrixBox.Name = "uniaryMatrixBox";
            this.uniaryMatrixBox.Size = new System.Drawing.Size(200, 134);
            this.uniaryMatrixBox.TabIndex = 6;
            // 
            // startMatrixLabel
            // 
            this.startMatrixLabel.AutoSize = true;
            this.startMatrixLabel.Location = new System.Drawing.Point(4, 4);
            this.startMatrixLabel.Name = "startMatrixLabel";
            this.startMatrixLabel.Size = new System.Drawing.Size(77, 13);
            this.startMatrixLabel.TabIndex = 7;
            this.startMatrixLabel.Text = "Starting Matrix:";
            // 
            // resultMatrixLabel
            // 
            this.resultMatrixLabel.AutoSize = true;
            this.resultMatrixLabel.Location = new System.Drawing.Point(212, 4);
            this.resultMatrixLabel.Name = "resultMatrixLabel";
            this.resultMatrixLabel.Size = new System.Drawing.Size(40, 13);
            this.resultMatrixLabel.TabIndex = 8;
            this.resultMatrixLabel.Text = "Result:";
            // 
            // rrefButton
            // 
            this.rrefButton.Location = new System.Drawing.Point(7, 161);
            this.rrefButton.Name = "rrefButton";
            this.rrefButton.Size = new System.Drawing.Size(75, 23);
            this.rrefButton.TabIndex = 9;
            this.rrefButton.Text = "RREF";
            this.rrefButton.UseVisualStyleBackColor = true;
            this.rrefButton.Click += new System.EventHandler(this.rrefButton_Click);
            // 
            // determinantButton
            // 
            this.determinantButton.Location = new System.Drawing.Point(7, 191);
            this.determinantButton.Name = "determinantButton";
            this.determinantButton.Size = new System.Drawing.Size(75, 23);
            this.determinantButton.TabIndex = 10;
            this.determinantButton.Text = "Determinant";
            this.determinantButton.UseVisualStyleBackColor = true;
            this.determinantButton.Click += new System.EventHandler(this.determinantButton_Click);
            // 
            // inverseButton
            // 
            this.inverseButton.Location = new System.Drawing.Point(7, 221);
            this.inverseButton.Name = "inverseButton";
            this.inverseButton.Size = new System.Drawing.Size(75, 23);
            this.inverseButton.TabIndex = 11;
            this.inverseButton.Text = "Inverse";
            this.inverseButton.UseVisualStyleBackColor = true;
            this.inverseButton.Click += new System.EventHandler(this.inverseButton_Click);
            // 
            // transposeButton
            // 
            this.transposeButton.Location = new System.Drawing.Point(7, 251);
            this.transposeButton.Name = "transposeButton";
            this.transposeButton.Size = new System.Drawing.Size(75, 23);
            this.transposeButton.TabIndex = 12;
            this.transposeButton.Text = "Transpose";
            this.transposeButton.UseVisualStyleBackColor = true;
            this.transposeButton.Click += new System.EventHandler(this.transposeButton_Click);
            // 
            // scaleButton
            // 
            this.scaleButton.Location = new System.Drawing.Point(7, 257);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(75, 23);
            this.scaleButton.TabIndex = 9;
            this.scaleButton.Text = "Scale";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // DemoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 381);
            this.Controls.Add(this.matrixTabs);
            this.Name = "DemoView";
            this.Text = "Form1";
            this.matrixTabs.ResumeLayout(false);
            this.uniaryTab.ResumeLayout(false);
            this.uniaryTab.PerformLayout();
            this.binaryTab.ResumeLayout(false);
            this.binaryTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl matrixTabs;
        private System.Windows.Forms.TabPage uniaryTab;
        private System.Windows.Forms.Label resultMatrixLabel;
        private System.Windows.Forms.Label startMatrixLabel;
        private System.Windows.Forms.TextBox uniaryMatrixBox;
        private System.Windows.Forms.TextBox uniaryResultBox;
        private System.Windows.Forms.TabPage binaryTab;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Label rightMatrixLabel;
        private System.Windows.Forms.TextBox rightMatrixBox;
        private System.Windows.Forms.Label leftMatrixLabel;
        private System.Windows.Forms.TextBox leftMatrixBox;
        private System.Windows.Forms.Button inverseButton;
        private System.Windows.Forms.Button determinantButton;
        private System.Windows.Forms.Button rrefButton;
        private System.Windows.Forms.Button transposeButton;
        private System.Windows.Forms.Button scaleButton;
    }
}

