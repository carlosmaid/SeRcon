﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using AltarNet;
using SeRconCore;
using SeRconCore.Control;

namespace SeRconClient
{
	public partial class ClientGui : Form
	{
		#region Attributes

		ClientManager m_clientManager;

		#endregion

		#region Constructor

		public ClientGui()
		{
			InitializeComponent();

			m_clientManager = new ClientManager();
			m_clientManager.OnDisconnected += m_clientManager_OnDisconnected;
			m_clientManager.OnLoggingFeedback += m_clientManager_OnLoggingFeedback;
			m_clientManager.OnNotificationReceived += m_clientManager_OnNotificationReceived;
		}

		#endregion

		#region Form update

		/// <summary>
		/// Update the form depending if the user is connected or not
		/// </summary>
		private void UpdateElementConnected()
		{
			Application.UseWaitCursor = false;

			mnu_server_connect.Enabled = !m_clientManager.IsConnected;
			mnu_server_disconnect.Enabled = m_clientManager.IsConnected;

			ss_progress.Visible = false;
		}

		#endregion

		#region Client event handler

		void m_clientManager_OnDisconnected(object sender, TcpEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnDisconnected(e);
				});
			}
			else
			{
				OnDisconnected(e);
			}
		}

		private void OnDisconnected(TcpEventArgs e)
		{
			ss_Status.Text = "Connexion to " + m_clientManager.Ip + ":" + m_clientManager.Port + " was lost";
			lgvConsole.WriteLine("Connexion to " + m_clientManager.Ip + ":" + m_clientManager.Port + " was lost");
			UpdateElementConnected();
		}

		#endregion

		#region MNU

		#region File

		private void mnu_file_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region Server

		#region Connection

		private void mnu_server_connect_Click(object sender, EventArgs e)
		{
			new Connect(this).ShowDialog();
		}

		private void mnu_server_disconnect_Click(object sender, EventArgs e)
		{
			m_clientManager.Disconnect();
			UpdateElementConnected();
		}

		#endregion

		#endregion

		#endregion

		#region Connection to server

		private async Task<bool> tryConnect(string pAddress, string pPort)
		{
			IPAddress serverIp;
			if (!IPAddress.TryParse(pAddress, out serverIp))
			{
				try
				{
					IPAddress[] ipArr = Dns.GetHostAddresses(pAddress);
					foreach (IPAddress currIp in ipArr)
					{
						if (currIp.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
						{
							serverIp = currIp;
							break;
						}
					}
				}
				catch (Exception)
				{

					lgvConsole.WriteLine("Could not resolve " + pAddress + " to an Ip address.", MessageType.Error);
					ss_Status.Text = "Could not resolve " + pAddress + " to an Ip address.";

					UpdateElementConnected();

					return false;
				}
			}

			m_clientManager.Ip = serverIp;
			m_clientManager.Port = int.Parse(pPort);
			return await m_clientManager.ConnectAsync();
		}

		/// <summary>
		/// Connect this client to a server anonymously
		/// </summary>
		/// <param name="pAddress">Address of the server</param>
		/// <param name="pPort">Port of the server</param>
		public async void ConnectToServer(string pAddress, string pPort)
		{
			ss_Status.Text = "Connecting to " + pAddress + ":" + pPort + "...";
			lgvConsole.WriteLine("Connecting to " + pAddress + ":" + pPort + "...");
			ss_progress.Visible = true;

			Application.UseWaitCursor = true;

			mnu_server_connect.Enabled = false;

			bool isSuccessful = await tryConnect(pAddress, pPort);

			if (isSuccessful)
			{
				ss_Status.Text = "Connected to " + pAddress + ":" + pPort;
				lgvConsole.WriteLine("Connected to " + pAddress + ":" + pPort);
			}
			else
			{
				ss_Status.Text = "Failed to connect to " + pAddress + ":" + pPort;
				lgvConsole.WriteLine("Failed to connect to " + pAddress + ":" + pPort, MessageType.Error);
				lgvConsole.Write(m_clientManager.LastConnectionError.Message);
			}

			UpdateElementConnected();
		}

		public async void ConnectToServer(string pAddress, string pPort, string pPassword)
		{
			ss_Status.Text = "Connecting to " + pAddress + ":" + pPort + "...";
			lgvConsole.WriteLine("Connecting to " + pAddress + ":" + pPort + "...");
			ss_progress.Visible = true;

			Application.UseWaitCursor = true;

			mnu_server_connect.Enabled = false;

			bool isSuccessful = await tryConnect(pAddress, pPort);

			if (isSuccessful)
			{
				ss_Status.Text = "Connected to " + pAddress + ":" + pPort;
				lgvConsole.WriteLine("Connected to " + pAddress + ":" + pPort);

				RequestLogging(pPassword);
			}
			else
			{
				ss_Status.Text = "Failed to connect to " + pAddress + ":" + pPort;
				lgvConsole.WriteLine("Failed to connect to " + pAddress + ":" + pPort, MessageType.Error);
				lgvConsole.Write(m_clientManager.LastConnectionError.Message);
				UpdateElementConnected();
			}
		}

		#endregion

		#region Logging into the server

		public void RequestLogging(string pPassword)
		{
			Application.UseWaitCursor = true;
			ss_Status.Text = "Logging in...";
			lgvConsole.WriteLine("Logging in...");

			m_clientManager.SendLoggingRequest(pPassword);
		}

		void m_clientManager_OnLoggingFeedback(object sender, AuthenticationFeedbackArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnLoggingFeedback(e);
				});
			}
			else
			{
				OnLoggingFeedback(e);
			}
		}

		private void OnLoggingFeedback(AuthenticationFeedbackArgs e)
		{
			if(e.Result == AuthenticationResult.Success)
			{
				ss_Status.Text = "Logged in successfully to " + m_clientManager.Ip + ":" + m_clientManager.Port;
				lgvConsole.WriteLine("Logged in successfully");
			}
			else
			{
				m_clientManager.Disconnect();
				ss_Status.Text = "Logging attempt failed at " + m_clientManager.Ip + ":" + m_clientManager.Port;

				if (e.Result == AuthenticationResult.Failed)
				{
					lgvConsole.WriteLine("Logging attempt failed: Invalid username/password combination", MessageType.Error);
				}
				else if(e.Result == AuthenticationResult.RequestExpired)
				{
					lgvConsole.WriteLine("Logging attempt failed: The request took too much time for the server. Please try again.", MessageType.Error);
				}
			}

			UpdateElementConnected();
		}

		#endregion

		#region Notification Received

		void m_clientManager_OnNotificationReceived(object sender, NotificationReceivedArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnNotificationReceived(e);
				});
			}
			else
			{
				OnNotificationReceived(e);
			}
		}

		private void OnNotificationReceived(NotificationReceivedArgs e)
		{
			lgvConsole.WriteLine(e.Message, MessageType.Notification);
		}

		#endregion

	}
}

