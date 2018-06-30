using com.calitha.commons;
using com.calitha.goldparser;
using CS;
using GoldParser;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
      
          
            string fileName = (Environment.CurrentDirectory + "/csharp.cgt");
           using (Stream stream = File.OpenRead(fileName))
            {
                BinaryReader reader = new BinaryReader(stream);
                m_grammar = new Grammar(reader);
            }
            ////    var pa = new com.calitha.goldparser.CGTReader(Environment.CurrentDirectory + "/c.cgt");
            ////var p=    pa.CreateNewParser();
            System.Threading.Tasks.Task.Run(() => L1());
            //    p.OnAccept += P_OnAccept;
            //    p.OnReduce += P_OnReduce;
            //    p.OnShift += P_OnShift;
            //    p.Parse(System.IO.File.ReadAllText(Environment.CurrentDirectory + "/c.cs"));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }


        public static void L1()
        {
            string fileName = (Environment.CurrentDirectory + "/csharp.cgt");

        //    var p = new Morozov.Parsing.MyParser();
      //      var com2 = new Morozov.Parsing.MyParserContext(p);
    
               // var com2 = new com.calitha.goldparser.MyParser(fileName);
                var str = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/c.cs");
            Morozov.Parsing.MyParserContext.Do_Parse(str);
             //   com2.Parse(str);
             //}

            //  Morozov.Parsing.MyParserContext.Do_Parse(str);
            //;
            //   parser.Parse(str);



        }
        private static void P_OnShift(LALRParser parser, ShiftEventArgs args)
        {

           abc2.Add(args.Token);
        }

        private static void P_OnReduce(LALRParser parser, ReduceEventArgs args)
        {
         //   Console.WriteLine(args.Token.Tokens.Length);
       //     abc2.Add(args.Token);
        }

        public static List<Token> find(Token token)
        {
            var list = new List<Token>();
            if (token is TerminalToken)
            {
                TerminalToken t = (TerminalToken)token;
                if (t.Symbol.Name== "Identifier " || t.Symbol.Name == "using" || t.Symbol.Name == ";")
                {
                   list.Add(t);
                }
            }
            else if (token is NonterminalToken)
            {
                NonterminalToken t = (NonterminalToken)token;
                foreach (Token childToken in t.Tokens)
                {
                    list.AddRange(find(childToken));
                }
                }
            return list;
            }
        public static List<TerminalToken> tokens = new List<TerminalToken>();


       
        public static void Fx()
        {
            var r = new Queue<TerminalToken>();
         foreach(var tt in tokens)
            {
                r.Enqueue(tt);
            }
            TerminalToken token = null;

            var str="";
            string current="";
            string start = "";
            string last = "";
            string class_type = "";
            System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (!r.TryDequeue(out token))
                    {
                        break;
                    }

                    current = token.Symbol.Name;
                    if (current == "using")
                    {
                        start = "using";
                        Console.Write("构建using列表:");
                    }
                    if (current == "namespace")
                    {
                        start = "ns";
                        Console.Write("构建命名空间:");
                    }
                    if(current=="public")
                    {

                        class_type = current;
                    }
                    if (current == "private")
                    {

                        class_type = current;
                    }
                    if (current == "class")
                    {
                        start = "cs";
                        Console.Write($"伪造一个{class_type}类型:");
                    }
                    if (current == "Identifier")
                    {
                        if (start == "using")
                            Console.Write(token.Text);
                        if (start == "ns")
                            Console.Write(token.Text);
                        if (start == "cs")
                            Console.Write(token.Text);
                    }
                    if (current == "MemberName")
                    {
                        if (start == "using")
                            Console.Write(token.Text);
                        if (start == "ns")
                            Console.Write(token.Text);
                    }
                    if (current == ";")
                    {

                        if (start == "using")
                        {

                            start = "";
                            Console.WriteLine("");
                           // Console.WriteLine("结束");
                        }
                      
                    }
                    if (current == "{")
                    {

                        if (start == "ns"||start=="cs")
                        {

                            start = "";

                            Console.WriteLine("");
                        }

                    }
                    last = current;



                }
            });

        }

        public static List<object> abc2 = new List<object>();// "";
        public static List<string> abc = new List<string>();// "";
        public static bool isbuild = false;
        private static Grammar m_grammar;
        private static CLL_Context m_context;

        private static void FillTreeView(NonterminalToken a, Token token)
        {
          
          
            if (token is TerminalToken)
            {
              
                TerminalToken t = (TerminalToken)token;
                if (!isbuild)
                {
                    abc.Add("");
                    isbuild = true;
                  
                }
                else
                {
                 
                 if (abc[abc.Count-1].Contains("构建"))
                    {
                       

                            abc[abc.Count - 1] += t.Text;
                         
                    }
                }

                if (t.Symbol.Name == "using")
                {
                    abc[abc.Count - 1] += "构建using:";

                }
                if (t.Symbol.Name == "MemberName")
                {
                    isbuild = true;
                    //  abc[abc.Count - 1] += "构建using";

                }
                if (t.Symbol.Name == ";")
                {
                    isbuild=false;
                  //  abc[abc.Count - 1] += "构建using";

                }
                // tokens.Add(t);

                // Console.WriteLine("t:" + StringUtil.ShowEscapeChars(t.Text));

                //   Console.WriteLine("tyie:" + t.Symbol.Name);
            }
            else if (token is NonterminalToken)
            {
                NonterminalToken t = (NonterminalToken)token;
              //  Console.WriteLine(t.Symbol.Name);
                
                foreach (Token childToken in t.Tokens)
                {


                    FillTreeView(t,childToken);
                }

            }
            }


        private static void P_OnAccept(com.calitha.goldparser.LALRParser parser, com.calitha.goldparser.AcceptEventArgs args)
        {
     
         //   Console.WriteLine(args.Token.Rule.Lhs.Name);
            foreach (var t in args.Token.Tokens)
            {
                //var s= (find(t));
                FillTreeView(null, t);
                //     FillTreeView(args.Token,t);
            }
          //  Fx();
           // throw new NotImplementedException();
        }
    }
}
