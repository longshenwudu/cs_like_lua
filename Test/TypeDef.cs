using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class TypeDef : Morozov.Parsing.ASTNode
    {
        public Dictionary<string, object> vs = new Dictionary<string, object>();
        public string name;
        public LinkedList<string> ts;
        public override bool IsTerminal => throw new NotImplementedException();
        public TypeDef(string n):base()
        {
            name = n;
        }
        public TypeDef(LinkedList<string> n) : base()
        {
           ts = n;
        }
    }
    //public class TypeDef2 : Morozov.Parsing.ASTNode
    //{
    //    public Dictionary<string, object> vs = new Dictionary<string, object>();
    //    public string name;
    //    public LinkedList<string> ts;
    //    public override bool IsTerminal => throw new NotImplementedException();
    //    public TypeDef(string n) : base()
    //    {
    //        name = n;
    //    }
    //    public TypeDef(LinkedList<string> n) : base()
    //    {
    //        ts = n;
    //    }
    //}
}
