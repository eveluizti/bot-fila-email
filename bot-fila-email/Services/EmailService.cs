using bot_fila_email.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace bot_fila_email.emailService
{
    public static class EmailService
    {
        public static void Teste(string teste)
        {
            Console.WriteLine(teste);

            Email email = new Email()
            { 
                sender = new SenderEmail
                {
                    dsEmail = "[EMAIL]",
                    dsHost = "smtp.gmail.com",
                    dsSenha = "[PASSWORD]",
                    nrPort = 587,
                    idSsl = true
                },
                dsSubject = "Teste assunto",
                dsBody = @"<p style=""color:red"">Teste corpo</p>",
                recipients =  new List<string> { "[RECIPIENT1]","[RECIPIENT2]" },
                idBodyHtml = true
            };

            Send(email);
        }


        public static string Send(Email email)
        {
            try
            {
                using (var mensagemDeEmail = new MailMessage())
                {
                    mensagemDeEmail.From = new MailAddress(email.sender.dsEmail);

                    mensagemDeEmail.Subject = email.dsSubject;

                    foreach(string dsRecipient in email.recipients) 
                        mensagemDeEmail.To.Add(dsRecipient);
                    foreach (string dsRecipientCopy in email.recipientsCopy) 
                        mensagemDeEmail.CC.Add(dsRecipientCopy);
                    foreach (string dsRecipientCopy in email.recipientsBlindCopy) 
                        mensagemDeEmail.Bcc.Add(dsRecipientCopy);
                    foreach (string dsRecipientReplyToList in email.recipientsReplyToList)
                        mensagemDeEmail.ReplyToList.Add(dsRecipientReplyToList);

                    mensagemDeEmail.Body = email.dsBody;
                    mensagemDeEmail.IsBodyHtml = email.idBodyHtml;

                    foreach (string anexo in email.attachment)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        mensagemDeEmail.Attachments.Add(anexado);
                    }


                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new System.Net.NetworkCredential(email.sender.dsEmail, email.sender.dsSenha);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Host = email.sender.dsHost;
                        smtpClient.Port = email.sender.nrPort;
                        smtpClient.EnableSsl = email.sender.idSsl;

                        smtpClient.Send(mensagemDeEmail);
                    }

                    return "ok";

                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
