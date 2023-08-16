


namespace WebApplication5.BL.helper;

    public class MailSender
    {//help sending mails to any comment
        public static bool mail(MailVM mail)
        {
            try
            {

                var email = new MimeMessage()
                {
                    Sender = MailboxAddress.Parse("atiffahmykhamis@gmail.com"),
                    Subject = "message from comapny system" + ""



                };
                email.To.Add(MailboxAddress.Parse(mail.mail));
                var builder = new BodyBuilder();


                builder.HtmlBody = mail.body;
                email.Body = builder.ToMessageBody();


                email.From.Add(new MailboxAddress("Comapny system ", "atiffahmykhamis@gmail.com"));



                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);
                    smtp.Authenticate("atiffahmykhamis@gmail.com", "dxtqjlfupztfmyli");
                     smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }


            return true;

            }
            catch (Exception e)
            {
            return false;
            }

        }
    }
    

