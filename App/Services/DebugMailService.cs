using App.Services;
using System;
using System.Diagnostics;

namespace App.Services
{
    public class DebugMailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string message)
        {
            Debug.WriteLine("Sending Mail \nTo:{to} \nFrom:{from} \nSubject:{subject} \nMessage:{message}");
            return true;
        }
    }
}
