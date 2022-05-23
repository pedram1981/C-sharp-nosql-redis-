using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nosql
{
    class time_
    {
        public static string diff_time(  TimeSpan diff)
        {
            
            int h=diff.Hours*60*60*1000;
            int m=diff.Minutes*60*1000;
            int s=diff.Seconds*1000;
            int mili = diff.Milliseconds;
            mili = h + m + s + mili;
            return mili.ToString();
        }
    }
}
