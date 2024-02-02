using System;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;

namespace Computer_Sceince_IA
{
    class Mail
    {
		private MimeMessage message = new MimeMessage();

		/// <summary>
		/// Sends an email to validate a it exists
		/// pre: Valid email address
		/// post: Confirms email has been recived
		/// </summary>
		public void SendAuthenication(string Email_Address)
        {
			//Construct email
			message.From.Add(new MailboxAddress("Authentication", "trashspam2903@gmail.com"));

			message.To.Add(new MailboxAddress("Client", Email_Address));

			message.Subject = "Authentication";

			message.Body = new TextPart("plain") { Text = "Please reply this email to verify your account" };

			//Sends email
			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587);
				client.Authenticate("trashspam2903@gmail.com", "%TRASH2903%");
				client.Send(message);
				client.Disconnect(true);
			}
		}

		/// <summary>
		/// Searches inbox if email has been recived and matches the inputed email (Validation)
		/// pre: Valid email address
		/// post: Confirms email has been recived
		/// </summary>
		public bool CheckInbox(string email)
		{
			//Searching inbox
			using (var client = new ImapClient())
			{
				//Login information
				client.Connect("imap.gmail.com", 993, true);
				client.AuthenticationMechanisms.Remove("XOAUTH");
				client.Authenticate("trashspam2903@gmail.com", "%TRASH2903%");
				var inbox = client.Inbox;
				inbox.Open(FolderAccess.ReadWrite);

				//Runs query to search inbox
				var query = client.Inbox.Search(MailKit.Search.SearchQuery.FromContains(email).
											And(MailKit.Search.SearchQuery.NotSeen));
				inbox.SetFlags(query, MessageFlags.Deleted, true);

				if (query.ToString() != "")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// Sends an email to a selected individual
		/// pre: Valid email address
		/// post: Confirms email has been sent with appropriate body
		/// </summary>
		public void SendEmail(string Email_Address, string TeacherName, string body)
        {
			message.From.Add(new MailboxAddress("Flagged", "trashspam2903@gmail.com"));

			message.To.Add(new MailboxAddress("Client", Email_Address));

			message.Subject = "Request for meeting from: " + TeacherName;

			message.Body = new TextPart("plain") { Text = body };

			//Sending the email via spam client 
			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587);
				client.Authenticate("trashspam2903@gmail.com", "%TRASH2903%");
				client.Send(message);
				client.Disconnect(true);
			}

			MessageBox.Show("Email was successfully sent");
		}
	}
}
