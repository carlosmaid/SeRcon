﻿namespace SeRconClient
{
	partial class ClientGui
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnu_file = new System.Windows.Forms.ToolStripMenuItem();
			this.mnu_file_exit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnu_server = new System.Windows.Forms.ToolStripMenuItem();
			this.mnu_server_connect = new System.Windows.Forms.ToolStripMenuItem();
			this.mnu_server_disconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ss_progress = new System.Windows.Forms.ToolStripProgressBar();
			this.ss_Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tab_console = new System.Windows.Forms.TabPage();
			this.lgvConsole = new SeRconCore.Control.LogViewer();
			this.tab_player = new System.Windows.Forms.TabPage();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tab_console.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_file,
            this.mnu_server});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(736, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnu_file
			// 
			this.mnu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_file_exit});
			this.mnu_file.Name = "mnu_file";
			this.mnu_file.Size = new System.Drawing.Size(37, 20);
			this.mnu_file.Text = "File";
			// 
			// mnu_file_exit
			// 
			this.mnu_file_exit.Name = "mnu_file_exit";
			this.mnu_file_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.mnu_file_exit.Size = new System.Drawing.Size(134, 22);
			this.mnu_file_exit.Text = "Exit";
			this.mnu_file_exit.Click += new System.EventHandler(this.mnu_file_exit_Click);
			// 
			// mnu_server
			// 
			this.mnu_server.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_server_connect,
            this.mnu_server_disconnect});
			this.mnu_server.Name = "mnu_server";
			this.mnu_server.Size = new System.Drawing.Size(51, 20);
			this.mnu_server.Text = "Server";
			// 
			// mnu_server_connect
			// 
			this.mnu_server_connect.Name = "mnu_server_connect";
			this.mnu_server_connect.Size = new System.Drawing.Size(133, 22);
			this.mnu_server_connect.Text = "Connect...";
			this.mnu_server_connect.Click += new System.EventHandler(this.mnu_server_connect_Click);
			// 
			// mnu_server_disconnect
			// 
			this.mnu_server_disconnect.Enabled = false;
			this.mnu_server_disconnect.Name = "mnu_server_disconnect";
			this.mnu_server_disconnect.Size = new System.Drawing.Size(133, 22);
			this.mnu_server_disconnect.Text = "Disconnect";
			this.mnu_server_disconnect.Click += new System.EventHandler(this.mnu_server_disconnect_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ss_Status,
            this.ss_progress});
			this.statusStrip1.Location = new System.Drawing.Point(0, 357);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(736, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ss_progress
			// 
			this.ss_progress.MarqueeAnimationSpeed = 60;
			this.ss_progress.Name = "ss_progress";
			this.ss_progress.Size = new System.Drawing.Size(100, 16);
			this.ss_progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.ss_progress.Visible = false;
			// 
			// ss_Status
			// 
			this.ss_Status.Name = "ss_Status";
			this.ss_Status.Size = new System.Drawing.Size(89, 17);
			this.ss_Status.Text = "Not connected.";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tab_console);
			this.tabControl1.Controls.Add(this.tab_player);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(736, 333);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControl1.TabIndex = 2;
			// 
			// tab_console
			// 
			this.tab_console.Controls.Add(this.lgvConsole);
			this.tab_console.Location = new System.Drawing.Point(4, 22);
			this.tab_console.Name = "tab_console";
			this.tab_console.Padding = new System.Windows.Forms.Padding(3);
			this.tab_console.Size = new System.Drawing.Size(728, 307);
			this.tab_console.TabIndex = 1;
			this.tab_console.Text = "Console";
			this.tab_console.UseVisualStyleBackColor = true;
			// 
			// lgvConsole
			// 
			this.lgvConsole.AllowNavigation = false;
			this.lgvConsole.AllowWebBrowserDrop = false;
			this.lgvConsole.DateFormat = "yyyy/MM/dd | HH:mm:ss";
			this.lgvConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lgvConsole.Location = new System.Drawing.Point(3, 3);
			this.lgvConsole.MinimumSize = new System.Drawing.Size(20, 20);
			this.lgvConsole.Name = "lgvConsole";
			this.lgvConsole.Size = new System.Drawing.Size(722, 301);
			this.lgvConsole.StyleSheet = "/Style/log.css";
			this.lgvConsole.TabIndex = 0;
			this.lgvConsole.WebBrowserShortcutsEnabled = false;
			// 
			// tab_player
			// 
			this.tab_player.Location = new System.Drawing.Point(4, 22);
			this.tab_player.Name = "tab_player";
			this.tab_player.Padding = new System.Windows.Forms.Padding(3);
			this.tab_player.Size = new System.Drawing.Size(728, 307);
			this.tab_player.TabIndex = 0;
			this.tab_player.Text = "Players";
			this.tab_player.UseVisualStyleBackColor = true;
			// 
			// ClientGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 379);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ClientGui";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " ";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tab_console.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnu_file;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel ss_Status;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tab_player;
		private System.Windows.Forms.TabPage tab_console;
		private SeRconCore.Control.LogViewer lgvConsole;
		private System.Windows.Forms.ToolStripMenuItem mnu_file_exit;
		private System.Windows.Forms.ToolStripMenuItem mnu_server;
		private System.Windows.Forms.ToolStripMenuItem mnu_server_connect;
		private System.Windows.Forms.ToolStripMenuItem mnu_server_disconnect;
		private System.Windows.Forms.ToolStripProgressBar ss_progress;
	}
}

