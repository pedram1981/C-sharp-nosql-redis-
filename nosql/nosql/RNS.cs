using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nosql
{
    class RNS
    {

        public static string encryption(string message, int[] p)
        {
            int m = message.Length, m1 =2;
            double u1,u2;
            int count1 = 0;
            string s1 = "",s2="";
            for (int i = 0; i < m; i++)
            {
                //for (int j = 0; j < m1; j++)
                {
                    int kk = message[i];
                    u1 = kk % p[0];
                    u2 = kk % p[1];
                    s1 = s1 + u1.ToString()+"-"+u2.ToString() + "-";
             
                    //count1++;
                    //kk = message[i];
                    //u[count1] = kk % p[1];
                    //s1 = s1 + u[count1].ToString() + "-";
                    //count1++;
                    //s1 = s1+kk.ToString();----------
                }
            }
            return s1;
        }
        static int[] key_ = new int[2];
        public static int[] prime_key(int number)
        {
            int count = 1;
            int[] d1 = new int[2];
            for (int i = number - 1; 1 < i; i--)
            {
                if (IsPrime(i))
                {
                    d1[count] = i;
                    count--;
                }
                if (count == -1)
                {
                    break;
                }
            }
            key_ = d1;
            return d1;
        }
         static bool IsPrime(int candidate)
        {

            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

       static double invmod(double x, int p)
        {
            int n = (p - 1);
            string b = Convert.ToString((n - 1), 2);
            int len = b.Length;
            double[] a = new double[1000];

            for (int i = 0; i < len; i++)
                a[i] = 1;
            a[0] = x % p;
            for (int i = 0; i < len - 1; i++)
                a[i + 1] = (a[i] * a[i]) % p;

            string b1 = "";
            for (int i = b.Length - 1; 0 <= i; i--)
            {
                b1 = b1 + b[i];
            }

            b = b1;
            double mul = 1;

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].ToString() == "0")
                    a[i] = 1;
                mul = mul * a[i];
                mul = mul % p;
            }
            return mul % p;

        }
         static double CRT(int[] r, int[] p)
        {
            int cm = 1;
            double[] M = new double[2];
            for (int i = 0; i < 2; i++)
                cm = cm * p[i];
            for (int i = 0; i < 2; i++)
                M[i] = cm / p[i];
            double[] IM = new double[2];
            double x = 0;
            for (int i = 0; i < 2; i++)
            {
                IM[i] = invmod(M[i], p[i]);
                x = x + r[i] * M[i] * IM[i];
            }
            x = x % cm;
            return x;
        }
        public static string decryption(string u)
        {
            int k, k2;
            k2 = 2;
            k = 0;
            Regex r = new Regex("-");
            string[] token = null;
            token = r.Split(u);
            int[] u1 = new int[1000];
            int[] l = new int[2];
            string decryption_message = "";
            for (int i = 0; i < token.Length; i++)
            {
                try
                {
                    l[0] = int.Parse(token[i]);
                    l[1]= int.Parse(token[i+1]);
                    char character = (char)CRT(l, key_);
                     decryption_message = decryption_message + character;
                    i++;
                    
                }
                catch
                {

                }
            }

            
            return decryption_message;
        }
    }
}
