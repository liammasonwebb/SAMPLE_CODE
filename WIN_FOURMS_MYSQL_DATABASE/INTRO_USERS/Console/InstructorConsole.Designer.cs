namespace INTRO_USERS
{
    partial class InstructorConsole
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
            this.listViewWeek = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerWeek = new System.Windows.Forms.DateTimePicker();
            this.buttonCancelSchedule = new System.Windows.Forms.Button();
            this.buttonSaveSchedule = new System.Windows.Forms.Button();
            this.comboBoxInstructor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewWeek
            // 
            this.listViewWeek.Location = new System.Drawing.Point(10, 58);
            this.listViewWeek.MultiSelect = false;
            this.listViewWeek.Name = "listViewWeek";
            this.listViewWeek.Size = new System.Drawing.Size(708, 309);
            this.listViewWeek.TabIndex = 3;
            this.listViewWeek.UseCompatibleStateImageBehavior = false;
            this.listViewWeek.View = System.Windows.Forms.View.Details;
            this.listViewWeek.Visible = false;
            this.listViewWeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewWeek_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Week of:";
            // 
            // dateTimePickerWeek
            // 
            this.dateTimePickerWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWeek.Location = new System.Drawing.Point(99, 32);
            this.dateTimePickerWeek.Name = "dateTimePickerWeek";
            this.dateTimePickerWeek.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerWeek.TabIndex = 14;
            this.dateTimePickerWeek.ValueChanged += new System.EventHandler(this.dateTimePickerWeek_ValueChanged);
            // 
            // buttonCancelSchedule
            // 
            this.buttonCancelSchedule.Location = new System.Drawing.Point(641, 373);
            this.buttonCancelSchedule.Name = "buttonCancelSchedule";
            this.buttonCancelSchedule.Size = new System.Drawing.Size(77, 34);
            this.buttonCancelSchedule.TabIndex = 17;
            this.buttonCancelSchedule.Text = "Cancel";
            this.buttonCancelSchedule.UseVisualStyleBackColor = true;
            this.buttonCancelSchedule.Click += new System.EventHandler(this.buttonCancelSchedule_Click);
            // 
            // buttonSaveSchedule
            // 
            this.buttonSaveSchedule.Location = new System.Drawing.Point(541, 373);
            this.buttonSaveSchedule.Name = "buttonSaveSchedule";
            this.buttonSaveSchedule.Size = new System.Drawing.Size(94, 34);
            this.buttonSaveSchedule.TabIndex = 16;
            this.buttonSaveSchedule.Text = "Save Schedule";
            this.buttonSaveSchedule.UseVisualStyleBackColor = true;
            this.buttonSaveSchedule.Click += new System.EventHandler(this.buttonSaveSchedule_Click);
            // 
            // comboBoxInstructor
            // 
            this.comboBoxInstructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxInstructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstructor.Enabled = false;
            this.comboBoxInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxInstructor.FormattingEnabled = true;
            this.comboBoxInstructor.Location = new System.Drawing.Point(99, 5);
            this.comboBoxInstructor.Name = "comboBoxInstructor";
            this.comboBoxInstructor.Size = new System.Drawing.Size(105, 21);
            this.comboBoxInstructor.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Instructor Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "LOG OUT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InstructorConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 416);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxInstructor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelSchedule);
            this.Controls.Add(this.buttonSaveSchedule);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerWeek);
            this.Controls.Add(this.listViewWeek);
            this.Name = "InstructorConsole";
            this.Text = "Instructor Schedule Planning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewWeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeek;
        private System.Windows.Forms.Button buttonCancelSchedule;
        private System.Windows.Forms.Button buttonSaveSchedule;
        private System.Windows.Forms.ComboBox comboBoxInstructor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}