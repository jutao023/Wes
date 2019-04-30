using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    class MyRandom
    {
        public static int getRandom(int min, int max)
        {
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int rand = BitConverter.ToInt32(bytes, 0);
            if (rand < 0)
                rand *= -1;
            int rtn = rand % max;
            if (rtn >= min)
            {
                return rtn;
            }
            return getRandom(min, max);
        }
    }
}
