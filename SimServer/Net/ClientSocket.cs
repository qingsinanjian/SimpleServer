using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SimServer.Net
{
    public class ClientSocket
    {
        public Socket Socket { get; set; }

        public long LastPingTime { get; set; } = 0;
    }
}
