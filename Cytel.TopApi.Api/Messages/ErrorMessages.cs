using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cytel.Top.Api.Messages
{
    public static class MessageResponses
    {

        public static Dictionary<string, string> ErrorMessages
         = new Dictionary<string, string>
         {
             {
                 MessageCodes.Message.DivideByZeroException.ToString(),
                 "Divide By Zero Exception"
             },
             {
                 MessageCodes.Message.PasswordNotMaching.ToString(),
                 "Password is Manadtory"
             },
         };

    }
}
