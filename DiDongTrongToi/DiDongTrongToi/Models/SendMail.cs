using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DiDongTrongToi.Models
{
    public static class SendMail
    {
        public static bool SendEmail(string to_address, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hainam1507x@gmail.com");
                mail.To.Add(to_address);
                mail.Subject = "DIDONGTRONGTOI"; 
                mail.Body = "Mật Khẩu mới của Bạn , lời khuyên bạn nên thay đổi mật khẩu để cho tiện những lần đăng nhập sau. Mật Khẩu Đó là : "+body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hainam1507x@gmail.com", "hainam9xtb");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}