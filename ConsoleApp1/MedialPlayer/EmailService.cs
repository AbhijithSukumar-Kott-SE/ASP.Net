using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    public class EmailService:IMeassageSevice
    {

        public void sendMessage(string message)
        {
            Console.WriteLine($"Email Sent: {message}");
        }
    }
}
