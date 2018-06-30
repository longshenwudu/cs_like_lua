using System;
using System.Collections.Generic;
using System.Text;

namespace com.cs_like_lua
{
    public interface ICLL_Expression
    {
        List<ICLL_Expression> @Param { get; set; }
        Value CE_Value(CLL_Context content);

    }
}
