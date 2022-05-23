using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nosql
{
    class RSA
    {
        private static int GCD(int p, int q)
        {
            if (q == 0)
            {
                return p;
            }

            int r = p % q;

            return GCD(q, r);
        }
        static int[] m = new int[4];
        static void initilize(int p, int q)
        {
            int Pk=0, Phi=0;
            Pk = p * q;
            Phi = (p - 1) * (q - 1);
            int x = 2, e = 1;
            while (x>1)
            {
                 e=e+1;
                 x=GCD(Phi,e);
            }
            int i=1;
            int r=1;
            int k = 0;
            while (r > 0)
            {
                k = (Phi * i) + 1;
                r = k%e;
                i = i + 1;
            }
            int d = k / e;
            m[0] = Pk;
            m[1] = Phi;
            m[2] = d;
            m[3] = e;
            
        }

        static string encrypt_(char M,int N,int e)
        {
            string e1 = Convert.ToString(e, 2);
            int hh = e1.Length;
            s3 = "";
            for (int i = 0; i < lenght - hh; i++)
            {
                e1 = "0" + e1;
                s3 = s3 + e1;
            }
            int k = lenght-1;
            int c = M;
            int cf = 1;
            cf =(c * cf)%N;
            for (int i = k-1; 0<i ; i--)
            {
                c = (c*c)%N;
                int j=k-i+1;
                if (e1[j]==1)
                  cf=(c*cf)*N;
             }
            return cf.ToString() ;
        }

        static string decrypt_(string M, int N, int e)
        {
            string e1 = Convert.ToString(e, 2);
            int hh = e1.Length;
            for (int i = 0; i < lenght - hh; i++)
            {
                e1 = "0" + e1;
            }
            int k = lenght-1;
            int c =int.Parse(M);
            int cf = 1;
            cf = (c * cf) % N;
            for (int i = k - 1; 0 < i; i--)
            {
                c = (c * c) % N;
                int j = k - i + 1;
                if (e1[j] == 1)
                    cf = (c * cf) * N;
            }
            char c11 =(char)cf;
            return c11.ToString();
        }
        static int lenght =256;
        static string s3 = "";
        public static string encrypt(string message,int p,int q)
        {

            string s1 = "";
            s3 = "";
            for (int i = 0; i < message.Length; i++)
            {
                initilize(p, q);
                string k1 = encrypt_(message[i], m[0], m[3]);
                s1 = s1 +k1+"-";
                s3 = s3 + k1 + "-";
            }
         
            return s1;
         
        }

        public static string decrypt(string u,int p,int q)
        {
           
            int k, k2;
            k2 = 5;
            k = 0;
            Regex r = new Regex("-");
            string[] token = null;
            token = r.Split(u);
            int[] u1 = new int[10000000];
            for (int i = 0; i < token.Length; i++)
            {
                try
                {
                    u1[i] = int.Parse(token[i]);
                    k++;
                }
                catch
                {

                }
            }
            string message = "";

            for (int i = 0; i < k; i++)
            {
                initilize(p, q);
                message=message+decrypt_(u1[i].ToString(), m[0], m[2]);
            }
            return message;
        }
    }
}
