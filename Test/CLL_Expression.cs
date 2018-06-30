namespace com.cs_like_lua
{
    /// <summary>
    /// 编译表达式
    /// </summary>
    public class CLL_Expression : Morozov.Parsing.ASTNode
    {
        public override bool IsTerminal => throw new System.NotImplementedException();
        public Morozov.Parsing.MyParserContext context { get; set; }
        public CLL_Expression(Morozov.Parsing.MyParserContext context)
        {
            this.context = context;
        }
        public virtual object Value
        {
            get { return null; }
        }
    }
}