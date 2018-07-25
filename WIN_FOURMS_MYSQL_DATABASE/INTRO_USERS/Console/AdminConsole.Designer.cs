namespace INTRO_USERS
{
    partial class AdminConsole
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
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelSchedule = new System.Windows.Forms.Button();
            this.buttonSaveSchedule = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveCar = new System.Windows.Forms.Button();
            this.comboBoxInstructor = new System.Windows.Forms.ComboBox();
            this.comboBoxCar = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.listViewDay = new System.Windows.Forms.ListView();
            this.listViewWeek = new System.Windows.Forms.ListView();
            this.dateTimePickerWeek = new System.Windows.Forms.DateTimePicker();
            this.listViewCarsAssigned = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(318, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Click below in the values to assign/remove slots to the Instructors:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Instructor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Car:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Please select a date to display the week on the left panel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Please select a date of the first column to see the detail of the day on the righ" +
    "t:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Assign Car:";
            // 
            // buttonCancelSchedule
            // 
            this.buttonCancelSchedule.Location = new System.Drawing.Point(710, 334);
            this.buttonCancelSchedule.Name = "buttonCancelSchedule";
            this.buttonCancelSchedule.Size = new System.Drawing.Size(77, 34);
            this.buttonCancelSchedule.TabIndex = 36;
            this.buttonCancelSchedule.Text = "Cancel";
            this.buttonCancelSchedule.UseVisualStyleBackColor = true;
            this.buttonCancelSchedule.Click += new System.EventHandler(this.buttonCancelSchedule_Click);
            // 
            // buttonSaveSchedule
            // 
            this.buttonSaveSchedule.Location = new System.Drawing.Point(610, 334);
            this.buttonSaveSchedule.Name = "buttonSaveSchedule";
            this.buttonSaveSchedule.Size = new System.Drawing.Size(94, 34);
            this.buttonSaveSchedule.TabIndex = 35;
            this.buttonSaveSchedule.Text = "Confirm Schedule";
            this.buttonSaveSchedule.UseVisualStyleBackColor = true;
            this.buttonSaveSchedule.Click += new System.EventHandler(this.buttonSaveSchedule_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Week of:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Date Displayed:";
            // 
            // buttonSaveCar
            // 
            this.buttonSaveCar.Location = new System.Drawing.Point(274, 332);
            this.buttonSaveCar.Name = "buttonSaveCar";
            this.buttonSaveCar.Size = new System.Drawing.Size(94, 34);
            this.buttonSaveCar.TabIndex = 32;
            this.buttonSaveCar.Text = "Assign Cars";
            this.buttonSaveCar.UseVisualStyleBackColor = true;
            this.buttonSaveCar.Click += new System.EventHandler(this.buttonSaveCar_Click);
            // 
            // comboBoxInstructor
            // 
            this.comboBoxInstructor.FormattingEnabled = true;
            this.comboBoxInstructor.Location = new System.Drawing.Point(88, 340);
            this.comboBoxInstructor.Name = "comboBoxInstructor";
            this.comboBoxInstructor.Size = new System.Drawing.Size(78, 21);
            this.comboBoxInstructor.TabIndex = 29;
            this.comboBoxInstructor.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstructor_SelectedIndexChanged);
            // 
            // comboBoxCar
            // 
            this.comboBoxCar.FormattingEnabled = true;
            this.comboBoxCar.Location = new System.Drawing.Point(172, 340);
            this.comboBoxCar.Name = "comboBoxCar";
            this.comboBoxCar.Size = new System.Drawing.Size(78, 21);
            this.comboBoxCar.TabIndex = 28;
            this.comboBoxCar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCar_SelectedIndexChanged);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(496, 12);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(30, 13);
            this.labelDate.TabIndex = 27;
            this.labelDate.Text = "Date";
            // 
            // listViewDay
            // 
            this.listViewDay.Location = new System.Drawing.Point(405, 50);
            this.listViewDay.MultiSelect = false;
            this.listViewDay.Name = "listViewDay";
            this.listViewDay.Size = new System.Drawing.Size(382, 273);
            this.listViewDay.TabIndex = 26;
            this.listViewDay.UseCompatibleStateImageBehavior = false;
            this.listViewDay.View = System.Windows.Forms.View.Details;
            this.listViewDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewDay_MouseDown);
            // 
            // listViewWeek
            // 
            this.listViewWeek.Location = new System.Drawing.Point(11, 83);
            this.listViewWeek.MultiSelect = false;
            this.listViewWeek.Name = "listViewWeek";
            this.listViewWeek.Size = new System.Drawing.Size(358, 169);
            this.listViewWeek.TabIndex = 25;
            this.listViewWeek.UseCompatibleStateImageBehavior = false;
            this.listViewWeek.View = System.Windows.Forms.View.Details;
            this.listViewWeek.SelectedIndexChanged += new System.EventHandler(this.listViewWeek_SelectedIndexChanged);
            // 
            // dateTimePickerWeek
            // 
            this.dateTimePickerWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWeek.Location = new System.Drawing.Point(73, 32);
            this.dateTimePickerWeek.Name = "dateTimePickerWeek";
            this.dateTimePickerWeek.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerWeek.TabIndex = 24;
            this.dateTimePickerWeek.ValueChanged += new System.EventHandler(this.dateTimePickerWeek_ValueChanged);
            // 
            // listViewCarsAssigned
            // 
            this.listViewCarsAssigned.Location = new System.Drawing.Point(11, 258);
            this.listViewCarsAssigned.Name = "listViewCarsAssigned";
            this.listViewCarsAssigned.Size = new System.Drawing.Size(357, 63);
            this.listViewCarsAssigned.TabIndex = 45;
            this.listViewCarsAssigned.UseCompatibleStateImageBehavior = false;
            this.listViewCarsAssigned.View = System.Windows.Forms.View.Details;
            this.listViewCarsAssigned.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 46;
            this.button1.Text = "Delete account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 34);
            this.button2.TabIndex = 46;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WeekResourcesAvailabilityPage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 378);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewCarsAssigned);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelSchedule);
            this.Controls.Add(this.buttonSaveSchedule);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSaveCar);
            this.Controls.Add(this.comboBoxInstructor);
            this.Controls.Add(this.comboBoxCar);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.listViewDay);
            this.Controls.Add(this.listViewWeek);
            this.Controls.Add(this.dateTimePickerWeek);
            this.Name = "WeekResourcesAvailabilityPage2";
            this.Text = "Week Resources Planning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelSchedule;
        private System.Windows.Forms.Button buttonSaveSchedule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveCar;
        private System.Windows.Forms.ComboBox comboBoxInstructor;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ListView listViewDay;
        private System.Windows.Forms.ListView listViewWeek;
        private System.Windows.Forms.DateTimePicker dateTimePickerWeek;
        private System.Windows.Forms.ListView listViewCarsAssigned;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}