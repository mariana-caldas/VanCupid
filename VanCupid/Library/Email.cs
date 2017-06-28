using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace VanCupid.Library
{
    public class Email
    {
        private string To { get; set; }
        private string Message { get; set; }
        private string Subject { get; set; }
        public  string Filename { get; set; }

        public Email(string to)
        {
            To = to;
        }

        public void SetSubject(string subject)
        {
            Subject = subject;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public async Task<bool> Send()
        {
            
            var message = new MailMessage();
            message.To.Add(new MailAddress(To));  // replace with valid value 
            message.From = new MailAddress("vancupid@hotmail.com");  // replace with valid value
            message.Subject = Subject;
            message.Body = Message;
            message.IsBodyHtml = true;
            //if (Filename != null)
            //{
                
            //    var file = Path.GetFileName(Filename);
            //    var filePath = Path.Combine(Server.MapPath("~/Uploads/"), file);

            //    Attachment attachment = new Attachment(filePath, MediaTypeNames.Application.Octet);
            //    ContentDisposition disposition = attachment.ContentDisposition;
            //    disposition.FileName = Filename;
            //    disposition.Size = new FileInfo(filePath).Length;
            //    disposition.DispositionType = DispositionTypeNames.Attachment;

            //    message.Attachments.Add(attachment);
            //}

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "vancupid@hotmail.com",  // replace with valid value
                    Password = "777777Vc"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
            return true;
        }
            
    }

}