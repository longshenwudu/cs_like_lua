using System;
using System.Collections.Generic;
using System.Text;

namespace com.cs_like_lua
{
  public  interface ICLL_Function
    {
        string keyword { get; set; }
        Value Call(CLL_Context context, IList<Value> @params);

    }
    public interface ICLL_Function_Member
    {
        string keyword { get; set; }
        Value Call(CLL_Context context, object obj, IList<Value> @params);
    }
}
