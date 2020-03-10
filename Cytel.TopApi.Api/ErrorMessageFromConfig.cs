using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cytel.Top.Api
{
    public class ErrorMessageFromConfig
    {
        public enum Message
        {
            ParameterNotFoud = 1004,
            LengthNotMatching = 1005
        }
    }
}
