


namespace WebApplication5.BL.helper;

    public class MailSender
    {//help sending mails to any comment
        public static async Task mail(MailVM comm)
        {
            try
            {

                var email = new MimeMessage()
                {
                    Sender = MailboxAddress.Parse("atiffahmykhamis@gmail.com"),
                    Subject = "message from College system from " + comm.mail



                };
                email.To.Add(MailboxAddress.Parse(comm.mail));
                var builder = new BodyBuilder();


                builder.HtmlBody = comm.body;
                email.Body = builder.ToMessageBody();


                email.From.Add(new MailboxAddress("Comapny system ", "atiffahmykhamis@gmail.com"));



                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);
                    smtp.Authenticate("atiffahmykhamis@gmail.com", "dxtqjlfupztfmyli");
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }




            }
            catch (Exception e)
            {

            }

        }
    }
    

