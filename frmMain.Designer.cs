namespace SerialToKeyboard
{
    partial class FrmMain
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall) return;

            this.Hide();
            e.Cancel = true;
            base.OnFormClosing(e);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            btnTransfer = new Button();
            cmbPort = new ComboBox();
            cmbBaud = new ComboBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            checkBoxStartWithWindows = new CheckBox();
            btnSave = new Button();
            btnReloadPorts = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(15, 53);
            btnTransfer.Margin = new Padding(4, 3, 4, 3);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(264, 27);
            btnTransfer.TabIndex = 0;
            btnTransfer.Text = "Iniciar Leitura";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += BtnTransferClick;
            // 
            // cmbPort
            // 
            cmbPort.FormattingEnabled = true;
            cmbPort.Location = new Point(14, 14);
            cmbPort.Margin = new Padding(4, 3, 4, 3);
            cmbPort.Name = "cmbPort";
            cmbPort.Size = new Size(140, 23);
            cmbPort.TabIndex = 1;
            // 
            // cmbBaud
            // 
            cmbBaud.FormattingEnabled = true;
            cmbBaud.Location = new Point(162, 14);
            cmbBaud.Margin = new Padding(4, 3, 4, 3);
            cmbBaud.Name = "cmbBaud";
            cmbBaud.Size = new Size(116, 23);
            cmbBaud.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Serial to Keyboard";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(101, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(100, 22);
            toolStripMenuItem1.Text = "Abrir";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(100, 22);
            toolStripMenuItem2.Text = "Sair";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // checkBoxStartWithWindows
            // 
            checkBoxStartWithWindows.AutoSize = true;
            checkBoxStartWithWindows.Location = new Point(14, 130);
            checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            checkBoxStartWithWindows.Size = new Size(147, 19);
            checkBoxStartWithWindows.TabIndex = 2;
            checkBoxStartWithWindows.Text = "Iniciar com o Windows";
            checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(190, 125);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 3;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReloadPorts
            // 
            btnReloadPorts.Location = new Point(14, 86);
            btnReloadPorts.Margin = new Padding(4, 3, 4, 3);
            btnReloadPorts.Name = "btnReloadPorts";
            btnReloadPorts.Size = new Size(264, 27);
            btnReloadPorts.TabIndex = 4;
            btnReloadPorts.Text = "Recarregar Portas";
            btnReloadPorts.UseVisualStyleBackColor = true;
            btnReloadPorts.Click += btnReloadPorts_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 161);
            Controls.Add(btnReloadPorts);
            Controls.Add(btnSave);
            Controls.Add(checkBoxStartWithWindows);
            Controls.Add(cmbBaud);
            Controls.Add(cmbPort);
            Controls.Add(btnTransfer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(308, 200);
            MinimumSize = new Size(308, 200);
            Name = "FrmMain";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Serial to Keyboard";
            Activated += FrmMainActivated;
            Load += FrmMainLoad;
            Resize += FrmMain_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private CheckBox checkBoxStartWithWindows;
        private Button btnReloadPorts;
        private Button btnSave;
    }
}

