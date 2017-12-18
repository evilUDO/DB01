namespace WindowsFormsApplicationDB1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnection = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCommand = new System.Windows.Forms.Button();
            this.buttonReader = new System.Windows.Forms.Button();
            this.listBoxAusgabe = new System.Windows.Forms.ListBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnection
            // 
            this.buttonConnection.Location = new System.Drawing.Point(37, 33);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(144, 44);
            this.buttonConnection.TabIndex = 0;
            this.buttonConnection.Text = "Connection";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(636, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel1.Text = "toolstripstatuslabel1";
            // 
            // buttonCommand
            // 
            this.buttonCommand.Location = new System.Drawing.Point(37, 83);
            this.buttonCommand.Name = "buttonCommand";
            this.buttonCommand.Size = new System.Drawing.Size(144, 39);
            this.buttonCommand.TabIndex = 2;
            this.buttonCommand.Text = "SQL- Command";
            this.buttonCommand.UseVisualStyleBackColor = true;
            this.buttonCommand.Click += new System.EventHandler(this.buttonCommand_Click);
            // 
            // buttonReader
            // 
            this.buttonReader.Location = new System.Drawing.Point(37, 128);
            this.buttonReader.Name = "buttonReader";
            this.buttonReader.Size = new System.Drawing.Size(144, 40);
            this.buttonReader.TabIndex = 3;
            this.buttonReader.Text = "auslesen";
            this.buttonReader.UseVisualStyleBackColor = true;
            this.buttonReader.Click += new System.EventHandler(this.buttonReader_Click);
            // 
            // listBoxAusgabe
            // 
            this.listBoxAusgabe.FormattingEnabled = true;
            this.listBoxAusgabe.Location = new System.Drawing.Point(39, 202);
            this.listBoxAusgabe.Name = "listBoxAusgabe";
            this.listBoxAusgabe.Size = new System.Drawing.Size(305, 225);
            this.listBoxAusgabe.TabIndex = 4;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(391, 281);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(147, 42);
            this.buttonChange.TabIndex = 5;
            this.buttonChange.Text = "Datensatz ändern";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 473);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.listBoxAusgabe);
            this.Controls.Add(this.buttonReader);
            this.Controls.Add(this.buttonCommand);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonConnection);
            this.Name = "Form1";
            this.Text = "OLEDB - Zugriff";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonCommand;
        private System.Windows.Forms.Button buttonReader;
        private System.Windows.Forms.ListBox listBoxAusgabe;
        private System.Windows.Forms.Button buttonChange;
    }
}

