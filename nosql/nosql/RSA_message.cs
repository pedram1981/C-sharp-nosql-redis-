using ServiceStack.Redis;
using System;
using System.Collections.Concurrent;
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
    public partial class RSA_message : Form
    {
        public RSA_message()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtsecond.Text = "";
            using (IRedisNativeClient client1 = new RedisClient())
            {

                try
                {

                    DateTime d1 = DateTime.Now;
                    client1.Set(RSA.encrypt(textBox2.Text, 13,7), Encoding.UTF8.GetBytes(RSA.encrypt(textBox1.Text, 13,7)));
                    DateTime d2 = DateTime.Now;
                    TimeSpan diff = d2 - d1;
                    txtsecond.Text = time_.diff_time(diff);
                     
                    MessageBox.Show("<<<< INSERT is sucessful >>>>");
                }
                catch 
                {
                    MessageBox.Show("error:key is exist");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConcurrentDictionary<Type, HashSet<object>> _cache = new ConcurrentDictionary<Type, HashSet<object>>();
            try
            {
                using (IRedisNativeClient client = new RedisClient())
                {
                    string key = textBox2.Text;
                    using (IRedisNativeClient client1 = new RedisClient())
                    {
                        key = RSA.encrypt(key,50,47);
                        client1.Del(key);
                    }
                    MessageBox.Show("<<<< REMOVE is sucessful >>>>");
                }
                
            }
            catch { MessageBox.Show("this data is not exist........."); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (IRedisNativeClient client = new RedisClient())
            {
                 string key = textBox2.Text;
                 key = RSA.encrypt(key, 50,47);
                string info = textBox1.Text;
                info = RSA.encrypt(info, 50,47);
                using (IRedisNativeClient client1 = new RedisClient())
                {
                    client1.Del(key);
                    client1.Set(key, Encoding.UTF8.GetBytes(info));
                }
                MessageBox.Show("<<<< UPDATE is sucessful >>>>");
            }
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtsecond.Text = "";
            this.Cursor = Cursors.WaitCursor;
            using (IRedisNativeClient client = new RedisClient())
            {
                try
                {
                    string key = textBox2.Text;
                    textBox1.Text = "";
                    DateTime d1 = DateTime.Now;
                    key = RSA.encrypt(key, 50, 47);
                    var result = Encoding.UTF8.GetString(client.Get(key));
                    textBox1.Text = RSA.decrypt(result, 13, 7);
                    DateTime d2 = DateTime.Now;
                    TimeSpan diff = d2 - d1;
                    txtsecond.Text = time_.diff_time(diff);
                }
                catch 
                {
                    MessageBox.Show("THIS KEY IS NOT EXIST");
                }
                
                
            }
            this.Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (IRedisNativeClient client1 = new RedisClient("localhost"))
            {
                client1.Save();
                HashSet<string> ha = new HashSet<string>();

            }

            MessageBox.Show("<<<< SAVE DB FILE is sucessful >>>>");
        }

        private void RNS_message_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtsecond.Text = "";
            if (string.IsNullOrEmpty(textBox2.Text) == false)
            {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.openFileDialog1.Filter = "Text|*.txt|All|*.*";

                string path = openFileDialog1.FileName;
                string s = System.IO.Path.GetFileName(path);
                string sourceFile = path;
                this.Cursor = Cursors.WaitCursor;
                StreamReader r1 = new StreamReader(sourceFile);
                string s1 = "";
                int counter_1 = 0;
                while (!r1.EndOfStream)
                {
                    string s2 = r1.ReadLine();
                    counter_1 = counter_1 + s2.Length; 
                    s1 = s1 +s2;
                }
                r1.Close();
              



                    using (IRedisNativeClient client1 = new RedisClient())
                    {

                        try
                        {
                            l_second.Text = "second:";
                            DateTime d1 = DateTime.Now;
                            client1.Set(RSA.encrypt(textBox2.Text, 50, 47), Encoding.UTF8.GetBytes(RSA.encrypt(s1, 50, 47)));
                            DateTime d2 = DateTime.Now;
                            TimeSpan diff = d2 - d1;
                            txtsecond.Text = time_.diff_time(diff);

                        }
                        catch
                        {
                            MessageBox.Show("error:key is exist");
                        }

                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("<<<< INSERT text file is sucessful >>>>");
                }
               

            }
            else
            {
                MessageBox.Show("enter key");
            }
        }
    }
}
