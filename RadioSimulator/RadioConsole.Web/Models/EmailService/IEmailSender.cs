using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioConsole.Web.Models.EmailService
{
    interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
