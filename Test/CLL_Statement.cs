namespace CS
{
    /// <summary>
    /// 编译状态行
    /// </summary>
    public class CLL_Statement : Morozov.Parsing.ASTNode
    {
        public override bool IsTerminal => throw new System.NotImplementedException();
        public Morozov.Parsing.MyParserContext context { get; set; }
        public CLL_Statement(Morozov.Parsing.MyParserContext context)
        {
            this.context = context;
        }
        public virtual void Execute()
        {
        }
    }
}