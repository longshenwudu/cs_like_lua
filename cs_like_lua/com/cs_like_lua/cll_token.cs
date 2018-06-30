using com.calitha.goldparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cll
{
    public enum Token_Type
    {
        none,
        keyword,
        id,
        pc,
        type,
        block,
        value,
        other
    }

    public class cll_TokenParser
    {

        List<string> types = new List<string>();
        List<string> keywords = new List<string>();
       CLL_token current;
        LALRParser parser;
        public System.IO.Stream cgt;
        public void Start(string input)
        {
            CGTReader reader = new CGTReader(cgt);
            parser = reader.CreateNewParser();
            
            parser.OnTokenRead += OnRead;
            parser.OnShift += OnSF;
            parser.OnAccept += Parser_OnAccept;
            if (parser != null)
            {
                parser.Parse(input);
            }
        }

        private void Parser_OnAccept(LALRParser parser, AcceptEventArgs args)
        {
            throw new NotImplementedException();
        }

        public int current_;
        public void OnSF(LALRParser parser, ShiftEventArgs args)
        {

            current = new CLL_token();
            current.location = args.Token.Location;
          
            switch (args.Token.Symbol.Id)
            {
                case 3:
                    current_ = 3;
                    //current.type = Token_Type.id;
                    break;

            }
          

            current.text = args.Token.Text;
        }

        public void OnRead(LALRParser parser, TokenReadEventArgs args)
        {
           
            current = new CLL_token();
            current.location = args.Token.Location;
         
            switch (args.Token.Symbol.Name)
            {
                case "class id":
                    current.type = Token_Type.id;
                    break;

            }
        
            current.text = args.Token.Text;
        }
    }

        public class CLL_token
    {
        public string text;
        public com.calitha.goldparser.Location location;
        public Token_Type type;
        public override string ToString()
        {
            return type.ToString() + "|" + text + "|" + location.ToString();
        }
    }
}

