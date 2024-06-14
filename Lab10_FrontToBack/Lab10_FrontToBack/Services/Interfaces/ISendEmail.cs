using System;
using System.Net.Mail;

namespace Lab10_FrontToBack.Services.Interfaces
{
    public interface ISendEmail
    {
        public void Send(string from, string displayName, string to, string messageBody, string subject);
    }
}

