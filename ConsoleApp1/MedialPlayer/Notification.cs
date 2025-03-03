using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    class Notification
    {
        private readonly IMeassageSevice _messageService;

        public Notification(IMeassageSevice messageService)
        {
            _messageService = messageService;
        }

        public void NotifyUser(string message)
        {
            _messageService.sendMessage(message);
        }
    }
}
