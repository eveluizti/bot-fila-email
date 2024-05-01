using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_fila_email.Objects
{
    public class Email
    {
        public int? cdEmail { get; set; }
        public SenderEmail sender { get; set; }
        public string dsSubject { get; set; }
        public string dsBody { get; set; }
        public List<string> recipients = new List<string>();
        public List<string> recipientsCopy = new List<string>();
        public List<string> recipientsBlindCopy = new List<string>();
        public List<string> recipientsReplyToList = new List<string>();
        public List<string> attachment = new List<string>();
        public bool idSendReady { get; set; }
        public bool idBodyHtml { get; set; }

    }
}
