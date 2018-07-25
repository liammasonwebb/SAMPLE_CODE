namespace INTRO_USERS
{
    partial class ClientConsole
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewAppointmentSelection = new System.Windows.Forms.ListView();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAppointmentSelected = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewAppointments = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Please select one of the free slots to book a time and an Instructor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Select Date:";
            // 
            // listViewAppointmentSelection
            // 
            this.listViewAppointmentSelection.Location = new System.Drawing.Point(12, 95);
            this.listViewAppointmentSelection.MultiSelect = false;
            this.listViewAppointmentSelection.Name = "listViewAppointmentSelection";
            this.listViewAppointmentSelection.Size = new System.Drawing.Size(634, 259);
            this.listViewAppointmentSelection.TabIndex = 19;
            this.listViewAppointmentSelection.UseCompatibleStateImageBehavior = false;
            this.listViewAppointmentSelection.View = System.Windows.Forms.View.Details;
            this.listViewAppointmentSelection.Visible = false;
            this.listViewAppointmentSelection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewAppointmentSelection_MouseDown);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDate.Location = new System.Drawing.Point(78, 44);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerDate.TabIndex = 18;
            this.dateTimePickerDate.ValueChanged += new System.EventHandler(this.dateTimePickerDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Selected App:";
            // 
            // labelAppointmentSelected
            // 
            this.labelAppointmentSelected.AutoSize = true;
            this.labelAppointmentSelected.Location = new System.Drawing.Point(92, 368);
            this.labelAppointmentSelected.Name = "labelAppointmentSelected";
            this.labelAppointmentSelected.Size = new System.Drawing.Size(125, 13);
            this.labelAppointmentSelected.TabIndex = 23;
            this.labelAppointmentSelected.Text = "No appointment selected";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(586, 368);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(63, 30);
            this.buttonConfirm.TabIndex = 24;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "User Name:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(81, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(55, 13);
            this.labelUserName.TabIndex = 31;
            this.labelUserName.Text = "userName";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "LOG OUT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(483, 268);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(63, 30);
            this.buttonDelete.TabIndex = 29;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Instructor";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // listViewAppointments
            // 
            this.listViewAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewAppointments.FullRowSelect = true;
            this.listViewAppointments.Location = new System.Drawing.Point(409, 95);
            this.listViewAppointments.MultiSelect = false;
            this.listViewAppointments.Name = "listViewAppointments";
            this.listViewAppointments.Size = new System.Drawing.Size(240, 258);
            this.listViewAppointments.TabIndex = 25;
            this.listViewAppointments.UseCompatibleStateImageBehavior = false;
            this.listViewAppointments.View = System.Windows.Forms.View.Details;
            // 
            // ClientConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 400);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelAppointmentSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listViewAppointmentSelection);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.listViewAppointments);
            this.Controls.Add(this.buttonDelete);
            this.Name = "ClientConsole";
            this.Text = "CustomerAppointmentsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewAppointmentSelection;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAppointmentSelected;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewAppointments;
    }
}