
namespace Мебель
{
    partial class DBConnectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.serverNameCB = new System.Windows.Forms.ComboBox();
            this.testConnectionBTN = new System.Windows.Forms.Button();
            this.saveConnectionBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя сервера:";
            // 
            // serverNameCB
            // 
            this.serverNameCB.FormattingEnabled = true;
            this.serverNameCB.Location = new System.Drawing.Point(95, 12);
            this.serverNameCB.Name = "serverNameCB";
            this.serverNameCB.Size = new System.Drawing.Size(238, 21);
            this.serverNameCB.TabIndex = 1;
            // 
            // testConnectionBTN
            // 
            this.testConnectionBTN.Location = new System.Drawing.Point(15, 39);
            this.testConnectionBTN.Name = "testConnectionBTN";
            this.testConnectionBTN.Size = new System.Drawing.Size(154, 31);
            this.testConnectionBTN.TabIndex = 2;
            this.testConnectionBTN.Text = "Проверить подключение";
            this.testConnectionBTN.UseVisualStyleBackColor = true;
            this.testConnectionBTN.Click += new System.EventHandler(this.testConnectionBTN_Click);
            // 
            // saveConnectionBTN
            // 
            this.saveConnectionBTN.Location = new System.Drawing.Point(179, 39);
            this.saveConnectionBTN.Name = "saveConnectionBTN";
            this.saveConnectionBTN.Size = new System.Drawing.Size(154, 31);
            this.saveConnectionBTN.TabIndex = 3;
            this.saveConnectionBTN.Text = "Сохранить подключение";
            this.saveConnectionBTN.UseVisualStyleBackColor = true;
            this.saveConnectionBTN.Click += new System.EventHandler(this.saveConnectionBTN_Click);
            // 
            // DBConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 82);
            this.Controls.Add(this.saveConnectionBTN);
            this.Controls.Add(this.testConnectionBTN);
            this.Controls.Add(this.serverNameCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DBConnectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подкулючение к серверу";
            this.Load += new System.EventHandler(this.DBConnectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serverNameCB;
        private System.Windows.Forms.Button testConnectionBTN;
        private System.Windows.Forms.Button saveConnectionBTN;
    }
}