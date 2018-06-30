using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class HyHelper
    {
    public static string UnicodeToString(string srcText)
    {
        string dst = "";
        string src = srcText;
        int len = srcText.Length / 6;
        for (int i = 0; i <= len - 1; i++)
        {
            string str = "";
            str = src.Substring(0, 6).Substring(2);
            src = src.Substring(6);
            byte[] bytes = new byte[2];
            bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
            bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
            dst += Encoding.Unicode.GetString(bytes);
        }
        return dst;
    }
    public class th_
    {
        public string first;
        public string last;
    }
   
    public static string Hy(string input)
    {
        try
        {
            var sp = input.Split('天');
            List<th_> new_p = new List<th_>();
            
            foreach (var sp2 in sp)
            {
                if(sp2.Contains("神")&&sp2.Contains("灵"))
                {
                    var sp3 = sp2.Replace("神", "").Replace("灵","");
                  var str=  UnicodeToString(sp3);

                    new_p.Add(new th_ { first=sp2,last=str});
                    //
                }
            }
            input = input.Replace("天", "");
            foreach(var r in new_p)
            {
                input = input.Replace(r.first, r.last);
            }

        }
      catch
        {
          
        }
        return input;
    }
    }

