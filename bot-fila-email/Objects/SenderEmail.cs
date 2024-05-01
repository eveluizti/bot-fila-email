using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_fila_email.Objects
{
    public class SenderEmail
    {
        public int cdSender { get; set; }
        public string dsEmail { get; set; }
        public string dsSenha { get; set; }
        public string dsHost { get; set; }
        public int nrPort { get; set; }
        public bool idSsl { get; set; }
    }
}
