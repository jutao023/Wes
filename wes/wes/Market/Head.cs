using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    [Serializable]
    class Head
    {
        /// <summary>
        /// 包头总长度
        /// </summary>
        public static int LENGTH = 24;

        /// <summary>
        /// 数据总长度
        /// </summary>
        public Int32 length;

        /// <summary>
        /// 
        /// </summary>
        public Int64 sequencedId;

        /// <summary>
        /// 
        /// </summary>
        public Int16 code;

        /// <summary>
        /// 
        /// </summary>
        public Int32 version;

        /// <summary>
        ///
        /// </summary>
        public string terminal;

        /// <summary>
        /// 
        /// </summary>
        public Int32 requestId;

        public static Head ByteToHead(byte[] byt)
        {
            if (byt.Length != LENGTH)
                return null;

            Head head = new Head();
            int i = 0, j = 0;

            byte[] len = new byte[4];
            len[i++] = byt[j++];
            len[i++] = byt[j++];
            len[i++] = byt[j++];
            len[i++] = byt[j++];
            Array.Reverse(len);
            head.length = BitConverter.ToInt32(len, 0);

            i = 0;
            byte[] seqeId = new byte[8];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            seqeId[i++] = byt[j++];
            Array.Reverse(seqeId);
            head.sequencedId = BitConverter.ToInt64(seqeId, 0);

            i = 0;
            byte[] cod = new byte[2];
            cod[i++] = byt[j++];
            cod[i++] = byt[j++];
            Array.Reverse(cod);
            head.code = BitConverter.ToInt16(cod, 0);

            i = 0;
            byte[] ver = new byte[4];
            ver[i++] = byt[j++];
            ver[i++] = byt[j++];
            ver[i++] = byt[j++];
            ver[i++] = byt[j++];
            Array.Reverse(ver);
            head.version = BitConverter.ToInt32(ver, 0);

            i = 0;
            byte[] term = new byte[4];
            term[i++] = byt[j++];
            term[i++] = byt[j++];
            term[i++] = byt[j++];
            term[i++] = byt[j++];
            head.terminal = Encoding.UTF8.GetString(term);
/*
            i = 0;
            byte[] req = new byte[4];
            req[i++] = byt[j++];
            req[i++] = byt[j++];
            req[i++] = byt[j++];
            req[i++] = byt[j++];
            Array.Reverse(req);
            head.requestId = BitConverter.ToInt32(req, 0);
*/
            return head;
        }

        public byte[] headToByteArray()
        {
    
            byte[] hd = new byte[26];
            int j = 0;
            //1
            hd[j++] = (byte)((length & 0xFF000000) >> 24);
            hd[j++] = (byte)((length & 0x00FF0000) >> 16);
            hd[j++] = (byte)((length & 0x0000FF00) >> 8);
            hd[j++] = (byte)((length & 0x000000FF));
            //2
            MemoryStream stream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(stream);
            bw.Write(sequencedId);
            bw.Flush();
            byte[] seq = stream.ToArray();
            Array.Reverse(seq);
            for (int i = 0; i < 8; i++)
            {
                hd[j++] = seq[i];
            }
            //3
            hd[j++] = (byte)((code & 0x0000FF00) >> 8);
            hd[j++] = (byte)((code & 0x000000FF));
            //4
            hd[j++] = (byte)((version & 0xFF000000) >> 24);
            hd[j++] = (byte)((version & 0x00FF0000) >> 16);
            hd[j++] = (byte)((version & 0x0000FF00) >> 8);
            hd[j++] = (byte)((version & 0x000000FF));

            //5
            byte[] term = Encoding.UTF8.GetBytes(terminal);
            for (int i = 0; i < 4; i++)
            {
                hd[j++] = term[i];
            }

            hd[j++] = (byte)((requestId & 0xFF000000) >> 24);
            hd[j++] = (byte)((requestId & 0x00FF0000) >> 16);
            hd[j++] = (byte)((requestId & 0x0000FF00) >> 8);
            hd[j++] = (byte)((requestId & 0x000000FF));

            return hd;
        }
    }
}
