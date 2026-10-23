namespace LocalDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtGrade = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnAddStudent = new Button();
            lstStudents = new ListBox();
            btnLoadStudents = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(114, 107);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(114, 148);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(100, 23);
            txtGrade.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 107);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 154);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Grade:";
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(71, 194);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(138, 44);
            btnAddStudent.TabIndex = 4;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.ItemHeight = 15;
            lstStudents.Location = new Point(342, 113);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(107, 124);
            lstStudents.TabIndex = 5;
            // 
            // btnLoadStudents
            // 
            btnLoadStudents.Location = new Point(342, 67);
            btnLoadStudents.Name = "btnLoadStudents";
            btnLoadStudents.Size = new Size(107, 23);
            btnLoadStudents.TabIndex = 6;
            btnLoadStudents.Text = "Load Students";
            btnLoadStudents.UseVisualStyleBackColor = true;
            btnLoadStudents.Click += btnLoadStudents_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoadStudents);
            Controls.Add(lstStudents);
            Controls.Add(btnAddStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtGrade);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtGrade;
        private Label label1;
        private Label label2;
        private Button btnAddStudent;
        private ListBox lstStudents;
        private Button btnLoadStudents;
    }
}
