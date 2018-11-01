﻿using System;

namespace zgcwkj
{
    public static class Hash
    {
        //哈希类 36进制
        //有效哈希[10000000,11679615]

        #region 只支持4位 By MXWXZ

        public static string HashTo4Str(int hash)
        {
            string ret = "";
            hash -= 10000000;
            while (hash > 0)
            {
                ret += Hash2Char(hash % 36);
                hash /= 36;
            }
            if (ret.Length == 3) ret += "0";//前导零
            if (ret.Length == 2) ret += "00";
            if (ret.Length == 1) ret += "000";
            if (ret.Length == 0) ret += "0000";
            return reverse(ret);
        }

        public static int StrTo4Hash(string str)
        {
            int ret = 0;
            ret += Char2Hash(str[0]) * 46656;
            ret += Char2Hash(str[1]) * 1296;
            ret += Char2Hash(str[2]) * 36;
            ret += Char2Hash(str[3]);
            ret += 10000000;//防止前导零
            return ret;
        }

        #endregion 只支持4位 By MXWXZ

        #region 只支持6位 By zgcwkj

        public static string HashTo6Str(int hash)
        {
            string ret = "";
            hash -= 100000;
            while (hash > 0)
            {
                ret += Hash2Char(hash % 36);
                hash /= 36;
            }
            if (ret.Length == 5) ret += "0";//前导零
            if (ret.Length == 4) ret += "00";
            if (ret.Length == 3) ret += "000";
            if (ret.Length == 2) ret += "0000";
            if (ret.Length == 1) ret += "00000";
            if (ret.Length == 0) ret += "000000";
            return reverse(ret);
        }

        public static int StrTo6Hash(string str)
        {
            int ret = 0;
            ret += Char2Hash(str[0]) * 60466176;
            ret += Char2Hash(str[1]) * 1679616;
            ret += Char2Hash(str[2]) * 46656;
            ret += Char2Hash(str[3]) * 1296;
            ret += Char2Hash(str[4]) * 36;
            ret += Char2Hash(str[5]);
            ret += 100000;//防止前导零
            return ret;
        }

        #endregion 只支持6位 By zgcwkj

        private static int Char2Hash(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            else return c - 'a' + 10;
        }

        private static char Hash2Char(int hash)
        {
            if (hash >= 0 && hash <= 9) return (char)('0' + hash);
            else return (char)('a' + hash - 10);
        }

        private static string reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}