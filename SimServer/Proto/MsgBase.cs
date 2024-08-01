using ProtoBuf;
using SimServer.Net;
using System;
using System.Collections.Generic;
using System.IO;

public class MsgBase
{
    public virtual ProtocolEnum ProtoType { get; set; }

    /// <summary>
    /// 编码协议名
    /// </summary>
    /// <param name="msgBase"></param>
    /// <returns></returns>
    public static byte[] EncodeName(MsgBase msgBase)
    {

    }

    /// <summary>
    /// 解码协议名
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static ProtocolEnum DecodeName(byte[] bytes)
    {

    }

    /// <summary>
    /// 协议序列化及加密
    /// </summary>
    /// <param name="msgBase"></param>
    /// <returns></returns>
    public static byte[] Encond(MsgBase msgBase)
    {
        using(var memory = new MemoryStream())
        {
            //将我们的协议类进行序列化转换成数组
            Serializer.Serialize(memory, msgBase);
            byte[] bytes = memory.ToArray();
            string secret = ServerSocket.SecretKey;
            //对数组进行加密
            if(msgBase is MsgSecret)
            {
                secret = ServerSocket.PublicKey;
            }
            bytes = AES.AESEncrypt(bytes, secret);
            return bytes;
        }
    }
}

