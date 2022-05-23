using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nosql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader r1 = new StreamReader("data5.txt");
            string s1 = "";
            while (!r1.EndOfStream)
            {
                s1 = s1 + r1.ReadLine();
            }
            int h = s1.Length;
            
             using (IRedisNativeClient client1 = new RedisClient())
             {
                
                     client1.Set("100", Encoding.UTF8.GetBytes(s1));   
                  
             }
                            
        }
    }
}
