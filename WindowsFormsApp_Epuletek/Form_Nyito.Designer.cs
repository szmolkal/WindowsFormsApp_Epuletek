
namespace WindowsFormsApp_Epuletek
{
    partial class Form_Nyito
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
            this.listBox_Epuletek = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_uj_tombhaz = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.label_Kalkulacio_Label = new System.Windows.Forms.Label();
            this.textBox_Arkalkulacio = new System.Windows.Forms.TextBox();
            this.listBox_Esedekes_Epuletek = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_Epuletek
            // 
            this.listBox_Epuletek.FormattingEnabled = true;
            this.listBox_Epuletek.Location = new System.Drawing.Point(12, 12);
            this.listBox_Epuletek.Name = "listBox_Epuletek";
            this.listBox_Epuletek.Size = new System.Drawing.Size(210, 212);
            this.listBox_Epuletek.Sorted = true;
            this.listBox_Epuletek.TabIndex = 0;
            this.listBox_Epuletek.SelectedIndexChanged += new System.EventHandler(this.listBox_Epuletek_SelectedIndexChanged);
            this.listBox_Epuletek.DoubleClick += new System.EventHandler(this.listBox_Epuletek_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Új családiház";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_uj_csaladi_Click);
            // 
            // button_uj_tombhaz
            // 
            this.button_uj_tombhaz.Location = new System.Drawing.Point(228, 69);
            this.button_uj_tombhaz.Name = "button_uj_tombhaz";
            this.button_uj_tombhaz.Size = new System.Drawing.Size(130, 26);
            this.button_uj_tombhaz.TabIndex = 2;
            this.button_uj_tombhaz.Text = "Új tömbház";
            this.button_uj_tombhaz.UseVisualStyleBackColor = true;
            this.button_uj_tombhaz.Click += new System.EventHandler(this.button_uj_tombhaz_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(228, 126);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(130, 32);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "Épület törlése";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(228, 189);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(130, 34);
            this.button_Update.TabIndex = 4;
            this.button_Update.Text = "Módosítás";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // label_Kalkulacio_Label
            // 
            this.label_Kalkulacio_Label.AutoSize = true;
            this.label_Kalkulacio_Label.Location = new System.Drawing.Point(88, 239);
            this.label_Kalkulacio_Label.Name = "label_Kalkulacio_Label";
            this.label_Kalkulacio_Label.Size = new System.Drawing.Size(191, 13);
            this.label_Kalkulacio_Label.TabIndex = 6;
            this.label_Kalkulacio_Label.Text = "A kijelölt épület előzetes árkalkulációja:";
            // 
            // textBox_Arkalkulacio
            // 
            this.textBox_Arkalkulacio.Location = new System.Drawing.Point(91, 256);
            this.textBox_Arkalkulacio.Name = "textBox_Arkalkulacio";
            this.textBox_Arkalkulacio.ReadOnly = true;
            this.textBox_Arkalkulacio.Size = new System.Drawing.Size(192, 20);
            this.textBox_Arkalkulacio.TabIndex = 5;
            this.textBox_Arkalkulacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // listBox_Esedekes_Epuletek
            // 
            this.listBox_Esedekes_Epuletek.FormattingEnabled = true;
            this.listBox_Esedekes_Epuletek.Location = new System.Drawing.Point(12, 298);
            this.listBox_Esedekes_Epuletek.Name = "listBox_Esedekes_Epuletek";
            this.listBox_Esedekes_Epuletek.Size = new System.Drawing.Size(346, 238);
            this.listBox_Esedekes_Epuletek.Sorted = true;
            this.listBox_Esedekes_Epuletek.TabIndex = 7;
            // 
            // Form_Nyito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 552);
            this.Controls.Add(this.listBox_Esedekes_Epuletek);
            this.Controls.Add(this.textBox_Arkalkulacio);
            this.Controls.Add(this.label_Kalkulacio_Label);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_uj_tombhaz);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_Epuletek);
            this.MaximizeBox = false;
            this.Name = "Form_Nyito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Nyito_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox listBox_Epuletek;
        private System.Windows.Forms.Button button_uj_tombhaz;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Label label_Kalkulacio_Label;
        private System.Windows.Forms.TextBox textBox_Arkalkulacio;
        public System.Windows.Forms.ListBox listBox_Esedekes_Epuletek;
    }
}

