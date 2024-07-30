using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SimServer.Net
{
    public class ServerSocket : Singleton<ServerSocket>
    {
        //公钥
        public static string PublicKey = "OceanServer";
        //密钥，后续随时可能会变
        public static string SecretKey = "Ocean_Up&&NB!!";
#if DEBUG
        private string m_IpStr = "127.0.0.1";
#else
        //对应阿里云或腾讯云的 本地IP地址（不是公共IP地址）
        private string m_IpStr = "172.45.756.54";
#endif
        private const int m_Port = 8011;
        //服务器监听Socket
        private static Socket m_ListenSocket;

        //客户端Socket集合
        private static List<Socket> m_CheckReadList = new List<Socket>();

        public void Init()
        {
            IPAddress ip = IPAddress.Parse(m_IpStr);
            IPEndPoint ipEndPoint = new IPEndPoint(ip, m_Port);
            m_ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_ListenSocket.Bind(ipEndPoint);
        }
    }
}
