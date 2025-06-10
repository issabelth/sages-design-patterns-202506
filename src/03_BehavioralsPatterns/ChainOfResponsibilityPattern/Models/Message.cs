using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models
{
    public class Message
    {
        public string From { get; set; }
        public string Title { get; set; }   
        public string Body { get; set; }
    }

    public class MessageProcessor
    {
        private string[] whiteList;

        public MessageProcessor(string[] whiteList)
        {
            this.whiteList = whiteList;
        }

        public string Process(Message message)
        {            
            if (!whiteList.Contains(message.From))
            {
                throw new Exception();
            }

            if (!message.Title.Contains("Order"))
            {
                throw new Exception();
            }

            string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;

                return taxNumber;
            }
            else
            {
                throw new FormatException();
            }

            
        }
    }
}
