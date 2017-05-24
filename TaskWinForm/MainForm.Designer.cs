namespace TaskWinForm
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllTask = new DevExpress.XtraEditors.SimpleButton();
            this.pnlActiveControl = new System.Windows.Forms.Panel();
            this.btnComments = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnComments);
            this.panel1.Controls.Add(this.btnAddTask);
            this.panel1.Controls.Add(this.btnAllTask);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 75);
            this.panel1.TabIndex = 0;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(292, 12);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(104, 49);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "New Task";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnAllTask
            // 
            this.btnAllTask.Location = new System.Drawing.Point(12, 12);
            this.btnAllTask.Name = "btnAllTask";
            this.btnAllTask.Size = new System.Drawing.Size(104, 49);
            this.btnAllTask.TabIndex = 2;
            this.btnAllTask.Text = "All Tasks";
            this.btnAllTask.Click += new System.EventHandler(this.btnAllTask_Click);
            // 
            // pnlActiveControl
            // 
            this.pnlActiveControl.BackColor = System.Drawing.SystemColors.Control;
            this.pnlActiveControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActiveControl.Location = new System.Drawing.Point(0, 75);
            this.pnlActiveControl.Name = "pnlActiveControl";
            this.pnlActiveControl.Size = new System.Drawing.Size(508, 411);
            this.pnlActiveControl.TabIndex = 1;
            // 
            // btnComments
            // 
            this.btnComments.Location = new System.Drawing.Point(149, 12);
            this.btnComments.Name = "btnComments";
            this.btnComments.Size = new System.Drawing.Size(104, 49);
            this.btnComments.TabIndex = 4;
            this.btnComments.Text = "Comments";
            this.btnComments.Click += new System.EventHandler(this.btnComments_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 486);
            this.Controls.Add(this.pnlActiveControl);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "MainForm";
            this.Text = "Task manager";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlActiveControl;
        private DevExpress.XtraEditors.SimpleButton btnAddTask;
        private DevExpress.XtraEditors.SimpleButton btnAllTask;
        private DevExpress.XtraEditors.SimpleButton btnComments;
    }
}

