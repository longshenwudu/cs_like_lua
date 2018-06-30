using System;
using System.Collections.Generic;
using System.Text;

namespace com.cs_like_lua
{
    public interface ICLL_Logger
    {
        void Log(string str);
        void Warn(string str);
        void Error(string str);
    }
}
