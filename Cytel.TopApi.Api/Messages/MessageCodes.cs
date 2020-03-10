using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cytel.Top.Api.Messages
{
    public class MessageCodes
    {
        public enum Message
        {
            DivideByZeroException = 1200,
            PasswordNotMaching = 1500
        }
    }
}
