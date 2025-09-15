using System.Text;

namespace Custom
{
    public static class Base64
    {
        private static char[] base64 =
        {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z',
        '0','1','2','3','4','5','6','7','8','9',
        '+','/'
        };

        private static byte[] base64Reverse = new byte[128];

        static Base64()
        {
            for (int i = 0; i < base64.Length; i++)
                base64Reverse[base64[i]] = (byte)i;
        }


        public static string Encode(string str)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var sb = new StringBuilder();

            int extraCharLength = 0, extraCharBits = 0;
            foreach (var c in bytes)
            {
                if (extraCharLength == 6)
                {
                    sb.Append(base64[extraCharBits]);
                    (extraCharBits, extraCharLength) = (0, 0);
                }

                int shifts = 6 - extraCharLength;
                extraCharBits = extraCharBits << shifts;
                extraCharLength = 8 - shifts;

                sb.Append(base64[(c >> extraCharLength) | extraCharBits]);
                extraCharBits = c & ((1 << extraCharLength) - 1);
            }

            if (extraCharLength != 0)
            {
                int shift = 6 - extraCharLength;
                sb.Append(base64[extraCharBits << shift]);
                sb.Append(new[] { "", "==", "=" }[extraCharLength % 3]);
            }

            return sb.ToString();
        }


        public static string Decode(string input)
        {

            var result = new List<Byte>();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            int extraChar = 0;
            int shift = 2;
            for (int i = 0, z = 0; i < bytes.Length - 1; i++)
            {

                if (bytes[i + 1] == '=') break;

                int toBase8 = base64Reverse[bytes[i]] << shift;

                extraChar = base64Reverse[bytes[i + 1]] >> (6 - shift);

                if (shift == 6) i++;
                else
                {
                    int remaining = base64Reverse[bytes[i + 1]] & ((1 << (6 - shift)) - 1);
                    bytes[i + 1] = (byte)base64[remaining];
                }

                result.Add((byte)(toBase8 | extraChar));

                shift = shift == 6 ? 2 : shift + 2;

            }

            return Encoding.UTF8.GetString(result.ToArray());
        }


        public static class MultiString
        {

            public static string Encode(IList<string> strs)
            {
                var sb = new StringBuilder();
                foreach (var str in strs)
                {
                    sb.Append(Base64.Encode(str) + "===");
                }
                return sb.ToString();
            }

            public static List<string> Decode(string s)
            {
                var list = new List<string>();
                int start = 0; int end = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '=')
                    {
                        end = i;
                        while (i < s.Length && s[i] == '=') i++;
                        list.Add(Base64.Decode(s[start..(end + (i - end) - 3)]));
                        start = i;
                    }
                }

                return list;
            }
        }

    }
}


