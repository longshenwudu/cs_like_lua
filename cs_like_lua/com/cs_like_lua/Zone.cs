using com.calitha.commons;
using com.calitha.goldparser;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.cs_like_lua
{
  public  class Zone
    {
        public enum Target
        {
            net_core_2_0
        }
        /// <summary>
        /// 目标框架
        /// </summary>
        public Target targetFramework = Target.net_core_2_0;
        
        public ICLL_Logger logger { get; set; }

        public Zone()
        {

        }
        public Zone(ICLL_Logger logger)
        {
            this.logger = logger;
        }


        public Dictionary<string, ICLL_Function> calls = new Dictionary<string, ICLL_Function>();



        private com.calitha.goldparser.LALRParser parser;

        private bool is_init;
        public Action<calitha.goldparser.NonterminalToken> action;
        public void Parser_Token(string code, Action<calitha.goldparser.NonterminalToken> callback)
        {
            if(!is_init)
            {
                parser.OnAccept += Parser_OnAccept;
                parser.OnShift += Parser_OnShift;
                is_init = true;
                

            }
         //   action += callback;

            parser.Parse(code);
        }

      public  class Token
        {
           public string type;
            public calitha.goldparser.Location location;
        }
        public List<calitha.goldparser.NonterminalToken> tokens = new List<calitha.goldparser.NonterminalToken>();

        private static void Reg_Int_Pa(int id,Pa pa)
        {
            cs.TryAdd(id, pa);
        }
        public delegate void Pa(Token last, calitha.goldparser.TerminalToken current);
        public static Dictionary<int, Pa> cs = new Dictionary<int, Pa>();
        private void Parser_OnShift(calitha.goldparser.LALRParser parser, calitha.goldparser.ShiftEventArgs args)
        {
            //         switch(args.Token.Symbol.Id)
            //            {
            //default
            //            }
         if(cs.Count==0)
            {
                var token = new Token();
                token.type = args.Token.Symbol.Id.ToString();
                //tokens.Add(args.Token);
                return;
            }

            var tok = tokens[tokens.Count - 1];
            //cs.TryGetValue(tok.type.GetHashCode(), out var r);
            //r.Invoke(tok, args.Token);
        }

        private calitha.goldparser.NonterminalToken token;
        private void Parser_OnAccept(calitha.goldparser.LALRParser parser, calitha.goldparser.AcceptEventArgs args)
        {
            CompilerToken(token);
       
        //    action.Invoke(args.Token);
        }
        void Getusing(calitha.goldparser.Token token)
        {
            if (token is TerminalToken)
            {
                TerminalToken t = (TerminalToken)token;
              var n=  StringUtil.ShowEscapeChars(t.Text);
               
            }
            else if (token is NonterminalToken)
            {
                NonterminalToken t = (NonterminalToken)token;
                var n=(t.Rule.ToString(), 1, 1);
               
                foreach (calitha.goldparser.Token childToken in t.Tokens)
                {


                    Getusing(childToken);
                }
            }
        }


        ICLL_Expression_Compiler compiler = null;
        /// <summary>
        /// 编译成表达式
        /// </summary>
        /// <param name="token"></param>
       private void CompilerToken(calitha.goldparser.NonterminalToken token)
        {
          var @using=  token.Tokens[0];
       
            //for(int i=0;i<token.Tokens.Length;i++)
          //  {
          //      var t = (calitha.goldparser.TerminalToken)token.Tokens[i];
             
          //  }
        }
    }
}
