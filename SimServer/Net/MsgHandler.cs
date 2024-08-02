using System;
using System.Collections.Generic;

namespace SimServer.Net
{
    public partial class MsgHandler
    {
        public static void MsgSecret(ClientSocket c, MsgBase msgBase)
        {
            MsgSecret msgSecret = (MsgSecret)msgBase;
            msgSecret.Secret = ServerSocket.SecretKey;
            ServerSocket.Send(c, msgSecret);
        }
    }
}
