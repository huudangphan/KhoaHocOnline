using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class CaesarClass
    {
        public string PlaintText { get; set; }
        public int Key { get; set; }
        public string CipherText { get; set; }
        
        public CaesarClass(string text="",int k=0)
        {
            PlaintText = text;
            Key = k;
            CipherText = "";
        }
        public string Encrypt()
        {
            foreach (var c in PlaintText)
            {
                if (c != 32)
                {
                    int so = c - 'A';
                    so = (so + Key) % 26;
                    CipherText = CipherText + (char)(so + 'A');
                }
                else
                    CipherText = CipherText + c;
                 
            }
            return CipherText;
        }
        public string DeEncypt()
        {
            string s = "";
            foreach (var c in CipherText)
            {
                if (c != 32)
                {
                    int so = c - 'A';
                    so = (so - Key + 26) % 26;
                    s = s + (char)(so + 'A');
                }
                else
                    s = s + c;
               
            }
            return s;

        }
    }
}
