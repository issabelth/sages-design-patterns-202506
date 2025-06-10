using MediatorPatternWebApp.IServices;
using System;

namespace MediatorPatternWebApp.Services
{
    public class EmailMessageService : IMessageService
    {
        public void Send(string number, string message)
        {
            Console.WriteLine($"Send sms {message} to {number}");
        }
    }
}