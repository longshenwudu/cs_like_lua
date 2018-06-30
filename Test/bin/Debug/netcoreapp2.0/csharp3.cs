
using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;

using GoldParser;

namespace Morozov.Parsing
{
        
    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                        =   0, // (EOF)
        SYMBOL_ERROR                      =   1, // (Error)
        SYMBOL_COMMENT                    =   2, // Comment
        SYMBOL_NEWLINE                    =   3, // NewLine
        SYMBOL_WHITESPACE                 =   4, // Whitespace
        SYMBOL_TIMESDIV                   =   5, // '*/'
        SYMBOL_DIVTIMES                   =   6, // '/*'
        SYMBOL_DIVDIV                     =   7, // '//'
        SYMBOL_MINUS                      =   8, // '-'
        SYMBOL_MINUSMINUS                 =   9, // '--'
        SYMBOL_EXCLAM                     =  10, // '!'
        SYMBOL_EXCLAMEQ                   =  11, // '!='
        SYMBOL_PERCENT                    =  12, // '%'
        SYMBOL_PERCENTEQ                  =  13, // '%='
        SYMBOL_AMP                        =  14, // '&'
        SYMBOL_AMPAMP                     =  15, // '&&'
        SYMBOL_AMPEQ                      =  16, // '&='
        SYMBOL_LPAREN                     =  17, // '('
        SYMBOL_RPAREN                     =  18, // ')'
        SYMBOL_TIMES                      =  19, // '*'
        SYMBOL_TIMESEQ                    =  20, // '*='
        SYMBOL_COMMA                      =  21, // ','
        SYMBOL_DIV                        =  22, // '/'
        SYMBOL_DIVEQ                      =  23, // '/='
        SYMBOL_COLON                      =  24, // ':'
        SYMBOL_SEMI                       =  25, // ';'
        SYMBOL_QUESTION                   =  26, // '?'
        SYMBOL_LBRACKET                   =  27, // '['
        SYMBOL_RBRACKET                   =  28, // ']'
        SYMBOL_CARET                      =  29, // '^'
        SYMBOL_CARETEQ                    =  30, // '^='
        SYMBOL_LBRACE                     =  31, // '{'
        SYMBOL_PIPE                       =  32, // '|'
        SYMBOL_PIPEPIPE                   =  33, // '||'
        SYMBOL_PIPEEQ                     =  34, // '|='
        SYMBOL_RBRACE                     =  35, // '}'
        SYMBOL_TILDE                      =  36, // '~'
        SYMBOL_PLUS                       =  37, // '+'
        SYMBOL_PLUSPLUS                   =  38, // '++'
        SYMBOL_PLUSEQ                     =  39, // '+='
        SYMBOL_LT                         =  40, // '<'
        SYMBOL_LTLT                       =  41, // '<<'
        SYMBOL_LTLTEQ                     =  42, // '<<='
        SYMBOL_LTEQ                       =  43, // '<='
        SYMBOL_EQ                         =  44, // '='
        SYMBOL_MINUSEQ                    =  45, // '-='
        SYMBOL_EQEQ                       =  46, // '=='
        SYMBOL_GT                         =  47, // '>'
        SYMBOL_MINUSGT                    =  48, // '->'
        SYMBOL_GTEQ                       =  49, // '>='
        SYMBOL_GTGT                       =  50, // '>>'
        SYMBOL_GTGTEQ                     =  51, // '>>='
        SYMBOL_ABSTRACT                   =  52, // abstract
        SYMBOL_ADD                        =  53, // add
        SYMBOL_AS                         =  54, // as
        SYMBOL_ASSEMBLY                   =  55, // assembly
        SYMBOL_BASE                       =  56, // base
        SYMBOL_BOOL                       =  57, // bool
        SYMBOL_BREAK                      =  58, // break
        SYMBOL_BYTE                       =  59, // byte
        SYMBOL_CASE                       =  60, // case
        SYMBOL_CATCH                      =  61, // catch
        SYMBOL_CHAR                       =  62, // char
        SYMBOL_CHARLITERAL                =  63, // CharLiteral
        SYMBOL_CHECKED                    =  64, // checked
        SYMBOL_CLASS                      =  65, // class
        SYMBOL_CONST                      =  66, // const
        SYMBOL_CONTINUE                   =  67, // continue
        SYMBOL_DECIMAL                    =  68, // decimal
        SYMBOL_DECLITERAL                 =  69, // DecLiteral
        SYMBOL_DEFAULT                    =  70, // default
        SYMBOL_DELEGATE                   =  71, // delegate
        SYMBOL_DO                         =  72, // do
        SYMBOL_DOUBLE                     =  73, // double
        SYMBOL_DYNAMIC                    =  74, // dynamic
        SYMBOL_ELSE                       =  75, // else
        SYMBOL_ENUM                       =  76, // enum
        SYMBOL_EVENT                      =  77, // event
        SYMBOL_EXPLICIT                   =  78, // explicit
        SYMBOL_EXTERN                     =  79, // extern
        SYMBOL_FALSE                      =  80, // false
        SYMBOL_FIELD                      =  81, // field
        SYMBOL_FINALLY                    =  82, // finally
        SYMBOL_FIXED                      =  83, // fixed
        SYMBOL_FLOAT                      =  84, // float
        SYMBOL_FOR                        =  85, // for
        SYMBOL_FOREACH                    =  86, // foreach
        SYMBOL_GET                        =  87, // get
        SYMBOL_GLOBAL                     =  88, // global
        SYMBOL_GOTO                       =  89, // goto
        SYMBOL_HEXLITERAL                 =  90, // HexLiteral
        SYMBOL_IDENTIFIER                 =  91, // Identifier
        SYMBOL_IF                         =  92, // if
        SYMBOL_IMPLICIT                   =  93, // implicit
        SYMBOL_IN                         =  94, // in
        SYMBOL_INT                        =  95, // int
        SYMBOL_INTERFACE                  =  96, // interface
        SYMBOL_INTERNAL                   =  97, // internal
        SYMBOL_IS                         =  98, // is
        SYMBOL_LOCK                       =  99, // lock
        SYMBOL_LONG                       = 100, // long
        SYMBOL_MEMBERNAME                 = 101, // MemberName
        SYMBOL_METHOD                     = 102, // method
        SYMBOL_MODULE                     = 103, // module
        SYMBOL_NAMESPACE                  = 104, // namespace
        SYMBOL_NEW                        = 105, // new
        SYMBOL_NULL                       = 106, // null
        SYMBOL_OBJECT                     = 107, // object
        SYMBOL_OPERATOR                   = 108, // operator
        SYMBOL_OUT                        = 109, // out
        SYMBOL_OVERRIDE                   = 110, // override
        SYMBOL_PARAM                      = 111, // param
        SYMBOL_PARAMS                     = 112, // params
        SYMBOL_PARTIAL                    = 113, // partial
        SYMBOL_PRIVATE                    = 114, // private
        SYMBOL_PROPERTY                   = 115, // property
        SYMBOL_PROTECTED                  = 116, // protected
        SYMBOL_PUBLIC                     = 117, // public
        SYMBOL_READONLY                   = 118, // readonly
        SYMBOL_REALLITERAL                = 119, // RealLiteral
        SYMBOL_REF                        = 120, // ref
        SYMBOL_REMOVE                     = 121, // remove
        SYMBOL_RETURN                     = 122, // return
        SYMBOL_SBYTE                      = 123, // sbyte
        SYMBOL_SEALED                     = 124, // sealed
        SYMBOL_SET                        = 125, // set
        SYMBOL_SHORT                      = 126, // short
        SYMBOL_SIZEOF                     = 127, // sizeof
        SYMBOL_STACKALLOC                 = 128, // stackalloc
        SYMBOL_STATIC                     = 129, // static
        SYMBOL_STRING                     = 130, // string
        SYMBOL_STRINGLITERAL              = 131, // StringLiteral
        SYMBOL_STRUCT                     = 132, // struct
        SYMBOL_SWITCH                     = 133, // switch
        SYMBOL_THIS                       = 134, // this
        SYMBOL_THROW                      = 135, // throw
        SYMBOL_TRUE                       = 136, // true
        SYMBOL_TRY                        = 137, // try
        SYMBOL_TYPE                       = 138, // type
        SYMBOL_TYPEOF                     = 139, // typeof
        SYMBOL_UINT                       = 140, // uint
        SYMBOL_ULONG                      = 141, // ulong
        SYMBOL_UNCHECKED                  = 142, // unchecked
        SYMBOL_UNSAFE                     = 143, // unsafe
        SYMBOL_USHORT                     = 144, // ushort
        SYMBOL_USING                      = 145, // using
        SYMBOL_VAR                        = 146, // var
        SYMBOL_VIRTUAL                    = 147, // virtual
        SYMBOL_VOID                       = 148, // void
        SYMBOL_VOLATILE                   = 149, // volatile
        SYMBOL_WHILE                      = 150, // while
        SYMBOL_ACCESSOPT                  = 151, // <Access Opt>
        SYMBOL_ACCESSORDEC                = 152, // <Accessor Dec>
        SYMBOL_ADDEXP                     = 153, // <Add Exp>
        SYMBOL_ANDEXP                     = 154, // <And Exp>
        SYMBOL_ARGLIST                    = 155, // <Arg List>
        SYMBOL_ARGLISTOPT                 = 156, // <Arg List Opt>
        SYMBOL_ARGUMENT                   = 157, // <Argument>
        SYMBOL_ARRAYINITIALIZER           = 158, // <Array Initializer>
        SYMBOL_ARRAYINITIALIZEROPT        = 159, // <Array Initializer Opt>
        SYMBOL_ASSIGNTAIL                 = 160, // <Assign Tail>
        SYMBOL_ATTRIBLIST                 = 161, // <Attrib List>
        SYMBOL_ATTRIBOPT                  = 162, // <Attrib Opt>
        SYMBOL_ATTRIBSECTION              = 163, // <Attrib Section>
        SYMBOL_ATTRIBTARGETSPECOPT        = 164, // <Attrib Target Spec Opt>
        SYMBOL_ATTRIBUTE                  = 165, // <Attribute>
        SYMBOL_BASETYPE                   = 166, // <Base Type>
        SYMBOL_BLOCK                      = 167, // <Block>
        SYMBOL_BLOCKORSEMI                = 168, // <Block or Semi>
        SYMBOL_CATCHCLAUSE                = 169, // <Catch Clause>
        SYMBOL_CATCHCLAUSES               = 170, // <Catch Clauses>
        SYMBOL_CLASSBASELIST              = 171, // <Class Base List>
        SYMBOL_CLASSBASEOPT               = 172, // <Class Base Opt>
        SYMBOL_CLASSDECL                  = 173, // <Class Decl>
        SYMBOL_CLASSITEM                  = 174, // <Class Item>
        SYMBOL_CLASSITEMDECSOPT           = 175, // <Class Item Decs Opt>
        SYMBOL_COMPAREEXP                 = 176, // <Compare Exp>
        SYMBOL_COMPILATIONITEM            = 177, // <Compilation Item>
        SYMBOL_COMPILATIONITEMS           = 178, // <Compilation Items>
        SYMBOL_COMPILATIONUNIT            = 179, // <Compilation Unit>
        SYMBOL_CONDITIONALEXP             = 180, // <Conditional Exp>
        SYMBOL_CONSTANTDEC                = 181, // <Constant Dec>
        SYMBOL_CONSTANTDECLARATOR         = 182, // <Constant Declarator>
        SYMBOL_CONSTANTDECLARATORS        = 183, // <Constant Declarators>
        SYMBOL_CONSTRUCTORDEC             = 184, // <Constructor Dec>
        SYMBOL_CONSTRUCTORDECLARATOR      = 185, // <Constructor Declarator>
        SYMBOL_CONSTRUCTORINIT            = 186, // <Constructor Init>
        SYMBOL_CONSTRUCTORINITOPT         = 187, // <Constructor Init Opt>
        SYMBOL_CONVERSIONOPERATORDECL     = 188, // <Conversion Operator Decl>
        SYMBOL_DELEGATEDECL               = 189, // <Delegate Decl>
        SYMBOL_DESTRUCTORDEC              = 190, // <Destructor Dec>
        SYMBOL_DIMSEPARATORS              = 191, // <Dim Separators>
        SYMBOL_ENUMBASEOPT                = 192, // <Enum Base Opt>
        SYMBOL_ENUMBODY                   = 193, // <Enum Body>
        SYMBOL_ENUMDECL                   = 194, // <Enum Decl>
        SYMBOL_ENUMITEMDEC                = 195, // <Enum Item Dec>
        SYMBOL_ENUMITEMDECS               = 196, // <Enum Item Decs>
        SYMBOL_ENUMITEMDECSOPT            = 197, // <Enum Item Decs Opt>
        SYMBOL_EQUALITYEXP                = 198, // <Equality Exp>
        SYMBOL_EVALITEM                   = 199, // <eval item>
        SYMBOL_EVENTACCESSORDECS          = 200, // <Event Accessor Decs>
        SYMBOL_EVENTDEC                   = 201, // <Event Dec>
        SYMBOL_EXPRESSION                 = 202, // <Expression>
        SYMBOL_EXPRESSIONLIST             = 203, // <Expression List>
        SYMBOL_EXPRESSIONOPT              = 204, // <Expression Opt>
        SYMBOL_FIELDDEC                   = 205, // <Field Dec>
        SYMBOL_FINALLYCLAUSEOPT           = 206, // <Finally Clause Opt>
        SYMBOL_FIXEDPTRDEC                = 207, // <Fixed Ptr Dec>
        SYMBOL_FIXEDPTRDECS               = 208, // <Fixed Ptr Decs>
        SYMBOL_FORCONDITIONOPT            = 209, // <For Condition Opt>
        SYMBOL_FORINITOPT                 = 210, // <For Init Opt>
        SYMBOL_FORITERATOROPT             = 211, // <For Iterator Opt>
        SYMBOL_FORMALPARAM                = 212, // <Formal Param>
        SYMBOL_FORMALPARAMLIST            = 213, // <Formal Param List>
        SYMBOL_FORMALPARAMLISTOPT         = 214, // <Formal Param List Opt>
        SYMBOL_HEADER                     = 215, // <Header>
        SYMBOL_INDEXERDEC                 = 216, // <Indexer Dec>
        SYMBOL_INTEGRALTYPE               = 217, // <Integral Type>
        SYMBOL_INTERFACEACCESSORS         = 218, // <Interface Accessors>
        SYMBOL_INTERFACEBASEOPT           = 219, // <Interface Base Opt>
        SYMBOL_INTERFACEDECL              = 220, // <Interface Decl>
        SYMBOL_INTERFACEEMPTYBODY         = 221, // <Interface Empty Body>
        SYMBOL_INTERFACEEVENTDEC          = 222, // <Interface Event Dec>
        SYMBOL_INTERFACEINDEXERDEC        = 223, // <Interface Indexer Dec>
        SYMBOL_INTERFACEITEMDEC           = 224, // <Interface Item Dec>
        SYMBOL_INTERFACEITEMDECSOPT       = 225, // <Interface Item Decs Opt>
        SYMBOL_INTERFACEMETHODDEC         = 226, // <Interface Method Dec>
        SYMBOL_INTERFACEPROPERTYDEC       = 227, // <Interface Property Dec>
        SYMBOL_LITERAL                    = 228, // <Literal>
        SYMBOL_LOCALVARDECL               = 229, // <Local Var Decl>
        SYMBOL_LOGICALANDEXP              = 230, // <Logical And Exp>
        SYMBOL_LOGICALOREXP               = 231, // <Logical Or Exp>
        SYMBOL_LOGICALXOREXP              = 232, // <Logical Xor Exp>
        SYMBOL_MEMBERLIST                 = 233, // <Member List>
        SYMBOL_METHOD2                    = 234, // <Method>
        SYMBOL_METHODDEC                  = 235, // <Method Dec>
        SYMBOL_METHODEXP                  = 236, // <Method Exp>
        SYMBOL_METHODCALL                 = 237, // <methodcall>
        SYMBOL_METHODSOPT                 = 238, // <Methods Opt>
        SYMBOL_MODIFIER                   = 239, // <Modifier>
        SYMBOL_MODIFIERLISTOPT            = 240, // <Modifier List Opt>
        SYMBOL_MULTEXP                    = 241, // <Mult Exp>
        SYMBOL_NAMESPACEDEC               = 242, // <Namespace Dec>
        SYMBOL_NAMESPACEITEM              = 243, // <Namespace Item>
        SYMBOL_NAMESPACEITEMS             = 244, // <Namespace Items>
        SYMBOL_NEWOPT                     = 245, // <New Opt>
        SYMBOL_NONARRAYTYPE               = 246, // <Non Array Type>
        SYMBOL_NORMALSTM                  = 247, // <Normal Stm>
        SYMBOL_OBJECTEXP                  = 248, // <Object Exp>
        SYMBOL_OPERATORDEC                = 249, // <Operator Dec>
        SYMBOL_OREXP                      = 250, // <Or Exp>
        SYMBOL_OTHERTYPE                  = 251, // <Other Type>
        SYMBOL_OVERLOADOP                 = 252, // <Overload Op>
        SYMBOL_OVERLOADOPERATORDECL       = 253, // <Overload Operator Decl>
        SYMBOL_POINTEROPT                 = 254, // <Pointer Opt>
        SYMBOL_PRIMARY                    = 255, // <Primary>
        SYMBOL_PRIMARYARRAYCREATIONEXP    = 256, // <Primary Array Creation Exp>
        SYMBOL_PRIMARYEXP                 = 257, // <Primary Exp>
        SYMBOL_PROPERTYDEC                = 258, // <Property Dec>
        SYMBOL_QUALIFIEDID                = 259, // <Qualified ID>
        SYMBOL_RANKSPECIFIER              = 260, // <Rank Specifier>
        SYMBOL_RANKSPECIFIERS             = 261, // <Rank Specifiers>
        SYMBOL_RANKSPECIFIERSOPT          = 262, // <Rank Specifiers Opt>
        SYMBOL_RESOURCE                   = 263, // <Resource>
        SYMBOL_SEMICOLONOPT               = 264, // <Semicolon Opt>
        SYMBOL_SHIFTEXP                   = 265, // <Shift Exp>
        SYMBOL_STATEMENT                  = 266, // <Statement>
        SYMBOL_STATEMENTEXP               = 267, // <Statement Exp>
        SYMBOL_STATEMENTEXPLIST           = 268, // <Statement Exp List>
        SYMBOL_STMLIST                    = 269, // <Stm List>
        SYMBOL_STRUCTDECL                 = 270, // <Struct Decl>
        SYMBOL_SWITCHLABEL                = 271, // <Switch Label>
        SYMBOL_SWITCHLABELS               = 272, // <Switch Labels>
        SYMBOL_SWITCHSECTION              = 273, // <Switch Section>
        SYMBOL_SWITCHSECTIONSOPT          = 274, // <Switch Sections Opt>
        SYMBOL_THENSTM                    = 275, // <Then Stm>
        SYMBOL_TYPE2                      = 276, // <Type>
        SYMBOL_TYPEDECL                   = 277, // <Type Decl>
        SYMBOL_UNARYEXP                   = 278, // <Unary Exp>
        SYMBOL_USINGDIRECTIVE             = 279, // <Using Directive>
        SYMBOL_USINGLIST                  = 280, // <Using List>
        SYMBOL_VALIDID                    = 281, // <Valid ID>
        SYMBOL_VAR2                       = 282, // <var>
        SYMBOL_VAR_VAR                    = 283, // <var_var>
        SYMBOL_VARIABLEDECLARATOR         = 284, // <Variable Declarator>
        SYMBOL_VARIABLEDECS               = 285, // <Variable Decs>
        SYMBOL_VARIABLEINITIALIZER        = 286, // <Variable Initializer>
        SYMBOL_VARIABLEINITIALIZERLIST    = 287, // <Variable Initializer List>
        SYMBOL_VARIABLEINITIALIZERLISTOPT = 288  // <Variable Initializer List Opt>
    };

    enum RuleConstants : int
    {
        RULE_BLOCKORSEMI                                                             =   0, // <Block or Semi> ::= <Block>
        RULE_BLOCKORSEMI_SEMI                                                        =   1, // <Block or Semi> ::= ';'
        RULE_VALIDID_IDENTIFIER                                                      =   2, // <Valid ID> ::= Identifier
        RULE_VALIDID_THIS                                                            =   3, // <Valid ID> ::= this
        RULE_VALIDID_BASE                                                            =   4, // <Valid ID> ::= base
        RULE_VALIDID                                                                 =   5, // <Valid ID> ::= <Base Type>
        RULE_QUALIFIEDID                                                             =   6, // <Qualified ID> ::= <Valid ID> <Member List>
        RULE_MEMBERLIST_MEMBERNAME                                                   =   7, // <Member List> ::= <Member List> MemberName
        RULE_MEMBERLIST                                                              =   8, // <Member List> ::= 
        RULE_SEMICOLONOPT_SEMI                                                       =   9, // <Semicolon Opt> ::= ';'
        RULE_SEMICOLONOPT                                                            =  10, // <Semicolon Opt> ::= 
        RULE_LITERAL_TRUE                                                            =  11, // <Literal> ::= true
        RULE_LITERAL_FALSE                                                           =  12, // <Literal> ::= false
        RULE_LITERAL_DECLITERAL                                                      =  13, // <Literal> ::= DecLiteral
        RULE_LITERAL_HEXLITERAL                                                      =  14, // <Literal> ::= HexLiteral
        RULE_LITERAL_REALLITERAL                                                     =  15, // <Literal> ::= RealLiteral
        RULE_LITERAL_CHARLITERAL                                                     =  16, // <Literal> ::= CharLiteral
        RULE_LITERAL_STRINGLITERAL                                                   =  17, // <Literal> ::= StringLiteral
        RULE_LITERAL_NULL                                                            =  18, // <Literal> ::= null
        RULE_TYPE                                                                    =  19, // <Type> ::= <Non Array Type>
        RULE_TYPE_TIMES                                                              =  20, // <Type> ::= <Non Array Type> '*'
        RULE_TYPE2                                                                   =  21, // <Type> ::= <Non Array Type> <Rank Specifiers>
        RULE_TYPE_TIMES2                                                             =  22, // <Type> ::= <Non Array Type> <Rank Specifiers> '*'
        RULE_POINTEROPT_TIMES                                                        =  23, // <Pointer Opt> ::= '*'
        RULE_POINTEROPT                                                              =  24, // <Pointer Opt> ::= 
        RULE_NONARRAYTYPE                                                            =  25, // <Non Array Type> ::= <Qualified ID>
        RULE_BASETYPE                                                                =  26, // <Base Type> ::= <Other Type>
        RULE_BASETYPE2                                                               =  27, // <Base Type> ::= <Integral Type>
        RULE_OTHERTYPE_FLOAT                                                         =  28, // <Other Type> ::= float
        RULE_OTHERTYPE_DOUBLE                                                        =  29, // <Other Type> ::= double
        RULE_OTHERTYPE_DECIMAL                                                       =  30, // <Other Type> ::= decimal
        RULE_OTHERTYPE_BOOL                                                          =  31, // <Other Type> ::= bool
        RULE_OTHERTYPE_VOID                                                          =  32, // <Other Type> ::= void
        RULE_OTHERTYPE_OBJECT                                                        =  33, // <Other Type> ::= object
        RULE_OTHERTYPE_STRING                                                        =  34, // <Other Type> ::= string
        RULE_OTHERTYPE_DYNAMIC                                                       =  35, // <Other Type> ::= dynamic
        RULE_INTEGRALTYPE_SBYTE                                                      =  36, // <Integral Type> ::= sbyte
        RULE_INTEGRALTYPE_BYTE                                                       =  37, // <Integral Type> ::= byte
        RULE_INTEGRALTYPE_SHORT                                                      =  38, // <Integral Type> ::= short
        RULE_INTEGRALTYPE_USHORT                                                     =  39, // <Integral Type> ::= ushort
        RULE_INTEGRALTYPE_INT                                                        =  40, // <Integral Type> ::= int
        RULE_INTEGRALTYPE_UINT                                                       =  41, // <Integral Type> ::= uint
        RULE_INTEGRALTYPE_LONG                                                       =  42, // <Integral Type> ::= long
        RULE_INTEGRALTYPE_ULONG                                                      =  43, // <Integral Type> ::= ulong
        RULE_INTEGRALTYPE_CHAR                                                       =  44, // <Integral Type> ::= char
        RULE_RANKSPECIFIERSOPT                                                       =  45, // <Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
        RULE_RANKSPECIFIERSOPT2                                                      =  46, // <Rank Specifiers Opt> ::= 
        RULE_RANKSPECIFIERS                                                          =  47, // <Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
        RULE_RANKSPECIFIERS2                                                         =  48, // <Rank Specifiers> ::= <Rank Specifier>
        RULE_RANKSPECIFIER_LBRACKET_RBRACKET                                         =  49, // <Rank Specifier> ::= '[' <Dim Separators> ']'
        RULE_DIMSEPARATORS_COMMA                                                     =  50, // <Dim Separators> ::= <Dim Separators> ','
        RULE_DIMSEPARATORS                                                           =  51, // <Dim Separators> ::= 
        RULE_EXPRESSIONOPT                                                           =  52, // <Expression Opt> ::= <Expression>
        RULE_EXPRESSIONOPT2                                                          =  53, // <Expression Opt> ::= 
        RULE_EXPRESSIONLIST                                                          =  54, // <Expression List> ::= <Expression>
        RULE_EXPRESSIONLIST_COMMA                                                    =  55, // <Expression List> ::= <Expression> ',' <Expression List>
        RULE_EXPRESSION_EQ                                                           =  56, // <Expression> ::= <Conditional Exp> '=' <Expression>
        RULE_EXPRESSION_PLUSEQ                                                       =  57, // <Expression> ::= <Conditional Exp> '+=' <Expression>
        RULE_EXPRESSION_MINUSEQ                                                      =  58, // <Expression> ::= <Conditional Exp> '-=' <Expression>
        RULE_EXPRESSION_TIMESEQ                                                      =  59, // <Expression> ::= <Conditional Exp> '*=' <Expression>
        RULE_EXPRESSION_DIVEQ                                                        =  60, // <Expression> ::= <Conditional Exp> '/=' <Expression>
        RULE_EXPRESSION_CARETEQ                                                      =  61, // <Expression> ::= <Conditional Exp> '^=' <Expression>
        RULE_EXPRESSION_AMPEQ                                                        =  62, // <Expression> ::= <Conditional Exp> '&=' <Expression>
        RULE_EXPRESSION_PIPEEQ                                                       =  63, // <Expression> ::= <Conditional Exp> '|=' <Expression>
        RULE_EXPRESSION_PERCENTEQ                                                    =  64, // <Expression> ::= <Conditional Exp> '%=' <Expression>
        RULE_EXPRESSION_LTLTEQ                                                       =  65, // <Expression> ::= <Conditional Exp> '<<=' <Expression>
        RULE_EXPRESSION_GTGTEQ                                                       =  66, // <Expression> ::= <Conditional Exp> '>>=' <Expression>
        RULE_EXPRESSION                                                              =  67, // <Expression> ::= <Conditional Exp>
        RULE_CONDITIONALEXP_QUESTION_COLON                                           =  68, // <Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
        RULE_CONDITIONALEXP                                                          =  69, // <Conditional Exp> ::= <Or Exp>
        RULE_OREXP_PIPEPIPE                                                          =  70, // <Or Exp> ::= <Or Exp> '||' <And Exp>
        RULE_OREXP                                                                   =  71, // <Or Exp> ::= <And Exp>
        RULE_ANDEXP_AMPAMP                                                           =  72, // <And Exp> ::= <And Exp> '&&' <Logical Or Exp>
        RULE_ANDEXP                                                                  =  73, // <And Exp> ::= <Logical Or Exp>
        RULE_LOGICALOREXP_PIPE                                                       =  74, // <Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
        RULE_LOGICALOREXP                                                            =  75, // <Logical Or Exp> ::= <Logical Xor Exp>
        RULE_LOGICALXOREXP_CARET                                                     =  76, // <Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
        RULE_LOGICALXOREXP                                                           =  77, // <Logical Xor Exp> ::= <Logical And Exp>
        RULE_LOGICALANDEXP_AMP                                                       =  78, // <Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
        RULE_LOGICALANDEXP                                                           =  79, // <Logical And Exp> ::= <Equality Exp>
        RULE_EQUALITYEXP_EQEQ                                                        =  80, // <Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
        RULE_EQUALITYEXP_EXCLAMEQ                                                    =  81, // <Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
        RULE_EQUALITYEXP                                                             =  82, // <Equality Exp> ::= <Compare Exp>
        RULE_COMPAREEXP_LT                                                           =  83, // <Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
        RULE_COMPAREEXP_GT                                                           =  84, // <Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
        RULE_COMPAREEXP_LTEQ                                                         =  85, // <Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
        RULE_COMPAREEXP_GTEQ                                                         =  86, // <Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
        RULE_COMPAREEXP_IS                                                           =  87, // <Compare Exp> ::= <Compare Exp> is <Type>
        RULE_COMPAREEXP_AS                                                           =  88, // <Compare Exp> ::= <Compare Exp> as <Type>
        RULE_COMPAREEXP                                                              =  89, // <Compare Exp> ::= <Shift Exp>
        RULE_SHIFTEXP_LTLT                                                           =  90, // <Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
        RULE_SHIFTEXP_GTGT                                                           =  91, // <Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
        RULE_SHIFTEXP                                                                =  92, // <Shift Exp> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                             =  93, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                            =  94, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                                  =  95, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                           =  96, // <Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
        RULE_MULTEXP_DIV                                                             =  97, // <Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
        RULE_MULTEXP_PERCENT                                                         =  98, // <Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
        RULE_MULTEXP                                                                 =  99, // <Mult Exp> ::= <Unary Exp>
        RULE_UNARYEXP_EXCLAM                                                         = 100, // <Unary Exp> ::= '!' <Unary Exp>
        RULE_UNARYEXP_TILDE                                                          = 101, // <Unary Exp> ::= '~' <Unary Exp>
        RULE_UNARYEXP_MINUS                                                          = 102, // <Unary Exp> ::= '-' <Unary Exp>
        RULE_UNARYEXP_PLUSPLUS                                                       = 103, // <Unary Exp> ::= '++' <Unary Exp>
        RULE_UNARYEXP_MINUSMINUS                                                     = 104, // <Unary Exp> ::= '--' <Unary Exp>
        RULE_UNARYEXP_LPAREN_RPAREN                                                  = 105, // <Unary Exp> ::= '(' <Expression> ')' <Object Exp>
        RULE_UNARYEXP                                                                = 106, // <Unary Exp> ::= <Object Exp>
        RULE_OBJECTEXP_DELEGATE_LPAREN_RPAREN                                        = 107, // <Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
        RULE_OBJECTEXP                                                               = 108, // <Object Exp> ::= <Primary Array Creation Exp>
        RULE_OBJECTEXP2                                                              = 109, // <Object Exp> ::= <Method Exp>
        RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET                           = 110, // <Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
        RULE_PRIMARYARRAYCREATIONEXP_NEW                                             = 111, // <Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
        RULE_METHODEXP                                                               = 112, // <Method Exp> ::= <Method Exp> <Method>
        RULE_METHODEXP2                                                              = 113, // <Method Exp> ::= <Primary Exp>
        RULE_PRIMARYEXP_TYPEOF_LPAREN_RPAREN                                         = 114, // <Primary Exp> ::= typeof '(' <Type> ')'
        RULE_PRIMARYEXP_SIZEOF_LPAREN_RPAREN                                         = 115, // <Primary Exp> ::= sizeof '(' <Type> ')'
        RULE_PRIMARYEXP_CHECKED_LPAREN_RPAREN                                        = 116, // <Primary Exp> ::= checked '(' <Expression> ')'
        RULE_PRIMARYEXP_UNCHECKED_LPAREN_RPAREN                                      = 117, // <Primary Exp> ::= unchecked '(' <Expression> ')'
        RULE_PRIMARYEXP_NEW_LPAREN_RPAREN                                            = 118, // <Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
        RULE_PRIMARYEXP                                                              = 119, // <Primary Exp> ::= <Primary>
        RULE_PRIMARYEXP_LPAREN_RPAREN                                                = 120, // <Primary Exp> ::= '(' <Expression> ')'
        RULE_PRIMARY                                                                 = 121, // <Primary> ::= <Valid ID>
        RULE_PRIMARY_LPAREN_RPAREN                                                   = 122, // <Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
        RULE_PRIMARY2                                                                = 123, // <Primary> ::= <Literal>
        RULE_ARGLISTOPT                                                              = 124, // <Arg List Opt> ::= <Arg List>
        RULE_ARGLISTOPT2                                                             = 125, // <Arg List Opt> ::= 
        RULE_ARGLIST_COMMA                                                           = 126, // <Arg List> ::= <Arg List> ',' <Argument>
        RULE_ARGLIST                                                                 = 127, // <Arg List> ::= <Argument>
        RULE_ARGUMENT                                                                = 128, // <Argument> ::= <Expression>
        RULE_ARGUMENT_REF                                                            = 129, // <Argument> ::= ref <Expression>
        RULE_ARGUMENT_OUT                                                            = 130, // <Argument> ::= out <Expression>
        RULE_STMLIST                                                                 = 131, // <Stm List> ::= <Stm List> <Statement>
        RULE_STMLIST2                                                                = 132, // <Stm List> ::= <Statement>
        RULE_STATEMENT_IDENTIFIER_COLON                                              = 133, // <Statement> ::= Identifier ':'
        RULE_STATEMENT_SEMI                                                          = 134, // <Statement> ::= <Local Var Decl> ';'
        RULE_STATEMENT_IF_LPAREN_RPAREN                                              = 135, // <Statement> ::= if '(' <Expression> ')' <Statement>
        RULE_STATEMENT_IF_LPAREN_RPAREN_ELSE                                         = 136, // <Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
        RULE_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN                                   = 137, // <Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
        RULE_STATEMENT_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN                           = 138, // <Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
        RULE_STATEMENT_WHILE_LPAREN_RPAREN                                           = 139, // <Statement> ::= while '(' <Expression> ')' <Statement>
        RULE_STATEMENT_LOCK_LPAREN_RPAREN                                            = 140, // <Statement> ::= lock '(' <Expression> ')' <Statement>
        RULE_STATEMENT_USING_LPAREN_RPAREN                                           = 141, // <Statement> ::= using '(' <Resource> ')' <Statement>
        RULE_STATEMENT_FIXED_LPAREN_RPAREN                                           = 142, // <Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
        RULE_STATEMENT_DELEGATE_LPAREN_RPAREN                                        = 143, // <Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
        RULE_STATEMENT                                                               = 144, // <Statement> ::= <Normal Stm>
        RULE_THENSTM_IF_LPAREN_RPAREN_ELSE                                           = 145, // <Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
        RULE_THENSTM_FOR_LPAREN_SEMI_SEMI_RPAREN                                     = 146, // <Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
        RULE_THENSTM_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN                             = 147, // <Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
        RULE_THENSTM_WHILE_LPAREN_RPAREN                                             = 148, // <Then Stm> ::= while '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_LOCK_LPAREN_RPAREN                                              = 149, // <Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_USING_LPAREN_RPAREN                                             = 150, // <Then Stm> ::= using '(' <Resource> ')' <Then Stm>
        RULE_THENSTM_FIXED_LPAREN_RPAREN                                             = 151, // <Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
        RULE_THENSTM_DELEGATE_LPAREN_RPAREN                                          = 152, // <Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
        RULE_THENSTM                                                                 = 153, // <Then Stm> ::= <Normal Stm>
        RULE_NORMALSTM_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE                            = 154, // <Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
        RULE_NORMALSTM_DO_WHILE_LPAREN_RPAREN_SEMI                                   = 155, // <Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
        RULE_NORMALSTM_TRY                                                           = 156, // <Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
        RULE_NORMALSTM_CHECKED                                                       = 157, // <Normal Stm> ::= checked <Block>
        RULE_NORMALSTM_UNCHECKED                                                     = 158, // <Normal Stm> ::= unchecked <Block>
        RULE_NORMALSTM_UNSAFE                                                        = 159, // <Normal Stm> ::= unsafe <Block>
        RULE_NORMALSTM_BREAK_SEMI                                                    = 160, // <Normal Stm> ::= break ';'
        RULE_NORMALSTM_CONTINUE_SEMI                                                 = 161, // <Normal Stm> ::= continue ';'
        RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI                                          = 162, // <Normal Stm> ::= goto Identifier ';'
        RULE_NORMALSTM_GOTO_CASE_SEMI                                                = 163, // <Normal Stm> ::= goto case <Expression> ';'
        RULE_NORMALSTM_GOTO_DEFAULT_SEMI                                             = 164, // <Normal Stm> ::= goto default ';'
        RULE_NORMALSTM_RETURN_SEMI                                                   = 165, // <Normal Stm> ::= return <Expression Opt> ';'
        RULE_NORMALSTM_THROW_SEMI                                                    = 166, // <Normal Stm> ::= throw <Expression Opt> ';'
        RULE_NORMALSTM_SEMI                                                          = 167, // <Normal Stm> ::= <Statement Exp> ';'
        RULE_NORMALSTM_SEMI2                                                         = 168, // <Normal Stm> ::= ';'
        RULE_NORMALSTM                                                               = 169, // <Normal Stm> ::= <Block>
        RULE_BLOCK_LBRACE_RBRACE                                                     = 170, // <Block> ::= '{' <Stm List> '}'
        RULE_BLOCK_LBRACE_RBRACE2                                                    = 171, // <Block> ::= '{' '}'
        RULE_VARIABLEDECS                                                            = 172, // <Variable Decs> ::= <Variable Declarator>
        RULE_VARIABLEDECS_COMMA                                                      = 173, // <Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
        RULE_VARIABLEDECLARATOR_IDENTIFIER                                           = 174, // <Variable Declarator> ::= Identifier
        RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ                                        = 175, // <Variable Declarator> ::= Identifier '=' <Variable Initializer>
        RULE_VARIABLEINITIALIZER                                                     = 176, // <Variable Initializer> ::= <Expression>
        RULE_VARIABLEINITIALIZER2                                                    = 177, // <Variable Initializer> ::= <Array Initializer>
        RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET                        = 178, // <Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
        RULE_CONSTANTDECLARATORS                                                     = 179, // <Constant Declarators> ::= <Constant Declarator>
        RULE_CONSTANTDECLARATORS_COMMA                                               = 180, // <Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
        RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ                                        = 181, // <Constant Declarator> ::= Identifier '=' <Expression>
        RULE_SWITCHSECTIONSOPT                                                       = 182, // <Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
        RULE_SWITCHSECTIONSOPT2                                                      = 183, // <Switch Sections Opt> ::= 
        RULE_SWITCHSECTION                                                           = 184, // <Switch Section> ::= <Switch Labels> <Stm List>
        RULE_SWITCHLABELS                                                            = 185, // <Switch Labels> ::= <Switch Label>
        RULE_SWITCHLABELS2                                                           = 186, // <Switch Labels> ::= <Switch Labels> <Switch Label>
        RULE_SWITCHLABEL_CASE_COLON                                                  = 187, // <Switch Label> ::= case <Expression> ':'
        RULE_SWITCHLABEL_DEFAULT_COLON                                               = 188, // <Switch Label> ::= default ':'
        RULE_FORINITOPT                                                              = 189, // <For Init Opt> ::= <Local Var Decl>
        RULE_FORINITOPT2                                                             = 190, // <For Init Opt> ::= <Statement Exp List>
        RULE_FORINITOPT3                                                             = 191, // <For Init Opt> ::= 
        RULE_FORITERATOROPT                                                          = 192, // <For Iterator Opt> ::= <Statement Exp List>
        RULE_FORITERATOROPT2                                                         = 193, // <For Iterator Opt> ::= 
        RULE_FORCONDITIONOPT                                                         = 194, // <For Condition Opt> ::= <Expression>
        RULE_FORCONDITIONOPT2                                                        = 195, // <For Condition Opt> ::= 
        RULE_STATEMENTEXPLIST_COMMA                                                  = 196, // <Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
        RULE_STATEMENTEXPLIST                                                        = 197, // <Statement Exp List> ::= <Statement Exp>
        RULE_CATCHCLAUSES                                                            = 198, // <Catch Clauses> ::= <Catch Clause> <Catch Clauses>
        RULE_CATCHCLAUSES2                                                           = 199, // <Catch Clauses> ::= 
        RULE_CATCHCLAUSE_CATCH_LPAREN_IDENTIFIER_RPAREN                              = 200, // <Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
        RULE_CATCHCLAUSE_CATCH_LPAREN_RPAREN                                         = 201, // <Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
        RULE_CATCHCLAUSE_CATCH                                                       = 202, // <Catch Clause> ::= catch <Block>
        RULE_FINALLYCLAUSEOPT_FINALLY                                                = 203, // <Finally Clause Opt> ::= finally <Block>
        RULE_FINALLYCLAUSEOPT                                                        = 204, // <Finally Clause Opt> ::= 
        RULE_RESOURCE                                                                = 205, // <Resource> ::= <Local Var Decl>
        RULE_RESOURCE2                                                               = 206, // <Resource> ::= <Statement Exp>
        RULE_FIXEDPTRDECS                                                            = 207, // <Fixed Ptr Decs> ::= <Fixed Ptr Dec>
        RULE_FIXEDPTRDECS_COMMA                                                      = 208, // <Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
        RULE_FIXEDPTRDEC_IDENTIFIER_EQ                                               = 209, // <Fixed Ptr Dec> ::= Identifier '=' <Expression>
        RULE_LOCALVARDECL                                                            = 210, // <Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
        RULE_LOCALVARDECL2                                                           = 211, // <Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
        RULE_STATEMENTEXP_LPAREN_RPAREN                                              = 212, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
        RULE_STATEMENTEXP_LPAREN_RPAREN2                                             = 213, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_LBRACKET_RBRACKET                                          = 214, // <Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSGT_IDENTIFIER                                         = 215, // <Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_PLUSPLUS                                                   = 216, // <Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSMINUS                                                 = 217, // <Statement Exp> ::= <Qualified ID> '--' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP                                                            = 218, // <Statement Exp> ::= <Qualified ID> <Assign Tail>
        RULE_ASSIGNTAIL_PLUSPLUS                                                     = 219, // <Assign Tail> ::= '++'
        RULE_ASSIGNTAIL_MINUSMINUS                                                   = 220, // <Assign Tail> ::= '--'
        RULE_ASSIGNTAIL_EQ                                                           = 221, // <Assign Tail> ::= '=' <Expression>
        RULE_ASSIGNTAIL_PLUSEQ                                                       = 222, // <Assign Tail> ::= '+=' <Expression>
        RULE_ASSIGNTAIL_MINUSEQ                                                      = 223, // <Assign Tail> ::= '-=' <Expression>
        RULE_ASSIGNTAIL_TIMESEQ                                                      = 224, // <Assign Tail> ::= '*=' <Expression>
        RULE_ASSIGNTAIL_DIVEQ                                                        = 225, // <Assign Tail> ::= '/=' <Expression>
        RULE_ASSIGNTAIL_CARETEQ                                                      = 226, // <Assign Tail> ::= '^=' <Expression>
        RULE_ASSIGNTAIL_AMPEQ                                                        = 227, // <Assign Tail> ::= '&=' <Expression>
        RULE_ASSIGNTAIL_PIPEEQ                                                       = 228, // <Assign Tail> ::= '|=' <Expression>
        RULE_ASSIGNTAIL_PERCENTEQ                                                    = 229, // <Assign Tail> ::= '%=' <Expression>
        RULE_ASSIGNTAIL_LTLTEQ                                                       = 230, // <Assign Tail> ::= '<<=' <Expression>
        RULE_ASSIGNTAIL_GTGTEQ                                                       = 231, // <Assign Tail> ::= '>>=' <Expression>
        RULE_METHODSOPT                                                              = 232, // <Methods Opt> ::= <Methods Opt> <Method>
        RULE_METHODSOPT2                                                             = 233, // <Methods Opt> ::= 
        RULE_METHOD_MEMBERNAME                                                       = 234, // <Method> ::= MemberName
        RULE_METHOD_MEMBERNAME_LPAREN_RPAREN                                         = 235, // <Method> ::= MemberName '(' <Arg List Opt> ')'
        RULE_METHOD_LBRACKET_RBRACKET                                                = 236, // <Method> ::= '[' <Expression List> ']'
        RULE_METHOD_MINUSGT_IDENTIFIER                                               = 237, // <Method> ::= '->' Identifier
        RULE_METHOD_PLUSPLUS                                                         = 238, // <Method> ::= '++'
        RULE_METHOD_MINUSMINUS                                                       = 239, // <Method> ::= '--'
        RULE_VAR_VAR                                                                 = 240, // <var> ::= var
        RULE_VAR_GLOBAL                                                              = 241, // <var> ::= global
        RULE_VAR_VAR_IDENTIFIER                                                      = 242, // <var_var> ::= <var> Identifier
        RULE_VAR_VAR_IDENTIFIER_EQ                                                   = 243, // <var_var> ::= <var> Identifier '=' <Variable Initializer>
        RULE_METHODCALL                                                              = 244, // <methodcall> ::= <Formal Param List Opt>
        RULE_EVALITEM                                                                = 245, // <eval item> ::= <Stm List>
        RULE_EVALITEM2                                                               = 246, // <eval item> ::= 
        RULE_COMPILATIONUNIT                                                         = 247, // <Compilation Unit> ::= <Using List> <Compilation Items> <eval item>
        RULE_USINGLIST                                                               = 248, // <Using List> ::= <Using List> <Using Directive>
        RULE_USINGLIST2                                                              = 249, // <Using List> ::= 
        RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI                                 = 250, // <Using Directive> ::= using Identifier '=' <Qualified ID> ';'
        RULE_USINGDIRECTIVE_USING_SEMI                                               = 251, // <Using Directive> ::= using <Qualified ID> ';'
        RULE_COMPILATIONITEMS                                                        = 252, // <Compilation Items> ::= <Compilation Items> <Compilation Item>
        RULE_COMPILATIONITEMS2                                                       = 253, // <Compilation Items> ::= 
        RULE_COMPILATIONITEM                                                         = 254, // <Compilation Item> ::= <Namespace Dec>
        RULE_COMPILATIONITEM2                                                        = 255, // <Compilation Item> ::= <Namespace Item>
        RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE                                    = 256, // <Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
        RULE_NAMESPACEITEMS                                                          = 257, // <Namespace Items> ::= <Namespace Items> <Namespace Item>
        RULE_NAMESPACEITEMS2                                                         = 258, // <Namespace Items> ::= 
        RULE_NAMESPACEITEM                                                           = 259, // <Namespace Item> ::= <Constant Dec>
        RULE_NAMESPACEITEM2                                                          = 260, // <Namespace Item> ::= <Field Dec>
        RULE_NAMESPACEITEM3                                                          = 261, // <Namespace Item> ::= <Method Dec>
        RULE_NAMESPACEITEM4                                                          = 262, // <Namespace Item> ::= <Property Dec>
        RULE_NAMESPACEITEM5                                                          = 263, // <Namespace Item> ::= <Type Decl>
        RULE_TYPEDECL                                                                = 264, // <Type Decl> ::= <Class Decl>
        RULE_TYPEDECL2                                                               = 265, // <Type Decl> ::= <Struct Decl>
        RULE_TYPEDECL3                                                               = 266, // <Type Decl> ::= <Interface Decl>
        RULE_TYPEDECL4                                                               = 267, // <Type Decl> ::= <Enum Decl>
        RULE_TYPEDECL5                                                               = 268, // <Type Decl> ::= <Delegate Decl>
        RULE_HEADER                                                                  = 269, // <Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
        RULE_ACCESSOPT_PRIVATE                                                       = 270, // <Access Opt> ::= private
        RULE_ACCESSOPT_PROTECTED                                                     = 271, // <Access Opt> ::= protected
        RULE_ACCESSOPT_PUBLIC                                                        = 272, // <Access Opt> ::= public
        RULE_ACCESSOPT_INTERNAL                                                      = 273, // <Access Opt> ::= internal
        RULE_ACCESSOPT                                                               = 274, // <Access Opt> ::= 
        RULE_MODIFIERLISTOPT                                                         = 275, // <Modifier List Opt> ::= <Modifier List Opt> <Modifier>
        RULE_MODIFIERLISTOPT2                                                        = 276, // <Modifier List Opt> ::= 
        RULE_MODIFIER_ABSTRACT                                                       = 277, // <Modifier> ::= abstract
        RULE_MODIFIER_EXTERN                                                         = 278, // <Modifier> ::= extern
        RULE_MODIFIER_NEW                                                            = 279, // <Modifier> ::= new
        RULE_MODIFIER_OVERRIDE                                                       = 280, // <Modifier> ::= override
        RULE_MODIFIER_PARTIAL                                                        = 281, // <Modifier> ::= partial
        RULE_MODIFIER_READONLY                                                       = 282, // <Modifier> ::= readonly
        RULE_MODIFIER_SEALED                                                         = 283, // <Modifier> ::= sealed
        RULE_MODIFIER_STATIC                                                         = 284, // <Modifier> ::= static
        RULE_MODIFIER_UNSAFE                                                         = 285, // <Modifier> ::= unsafe
        RULE_MODIFIER_VIRTUAL                                                        = 286, // <Modifier> ::= virtual
        RULE_MODIFIER_VOLATILE                                                       = 287, // <Modifier> ::= volatile
        RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE                                = 288, // <Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_CLASSBASEOPT_COLON                                                      = 289, // <Class Base Opt> ::= ':' <Class Base List>
        RULE_CLASSBASEOPT                                                            = 290, // <Class Base Opt> ::= 
        RULE_CLASSBASELIST_COMMA                                                     = 291, // <Class Base List> ::= <Class Base List> ',' <Non Array Type>
        RULE_CLASSBASELIST                                                           = 292, // <Class Base List> ::= <Non Array Type>
        RULE_CLASSITEMDECSOPT                                                        = 293, // <Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
        RULE_CLASSITEMDECSOPT2                                                       = 294, // <Class Item Decs Opt> ::= 
        RULE_CLASSITEM                                                               = 295, // <Class Item> ::= <Constant Dec>
        RULE_CLASSITEM2                                                              = 296, // <Class Item> ::= <Field Dec>
        RULE_CLASSITEM3                                                              = 297, // <Class Item> ::= <Method Dec>
        RULE_CLASSITEM4                                                              = 298, // <Class Item> ::= <Property Dec>
        RULE_CLASSITEM5                                                              = 299, // <Class Item> ::= <Event Dec>
        RULE_CLASSITEM6                                                              = 300, // <Class Item> ::= <Indexer Dec>
        RULE_CLASSITEM7                                                              = 301, // <Class Item> ::= <Operator Dec>
        RULE_CLASSITEM8                                                              = 302, // <Class Item> ::= <Constructor Dec>
        RULE_CLASSITEM9                                                              = 303, // <Class Item> ::= <Destructor Dec>
        RULE_CLASSITEM10                                                             = 304, // <Class Item> ::= <Type Decl>
        RULE_CONSTANTDEC_CONST_SEMI                                                  = 305, // <Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
        RULE_FIELDDEC_SEMI                                                           = 306, // <Field Dec> ::= <Header> <Type> <Variable Decs> ';'
        RULE_METHODDEC_LPAREN_RPAREN                                                 = 307, // <Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
        RULE_FORMALPARAMLISTOPT                                                      = 308, // <Formal Param List Opt> ::= <Formal Param List>
        RULE_FORMALPARAMLISTOPT2                                                     = 309, // <Formal Param List Opt> ::= 
        RULE_FORMALPARAMLIST                                                         = 310, // <Formal Param List> ::= <Formal Param>
        RULE_FORMALPARAMLIST_COMMA                                                   = 311, // <Formal Param List> ::= <Formal Param List> ',' <Formal Param>
        RULE_FORMALPARAM_IDENTIFIER                                                  = 312, // <Formal Param> ::= <Attrib Opt> <Type> Identifier
        RULE_FORMALPARAM_REF_IDENTIFIER                                              = 313, // <Formal Param> ::= <Attrib Opt> ref <Type> Identifier
        RULE_FORMALPARAM_OUT_IDENTIFIER                                              = 314, // <Formal Param> ::= <Attrib Opt> out <Type> Identifier
        RULE_FORMALPARAM_PARAMS_IDENTIFIER                                           = 315, // <Formal Param> ::= <Attrib Opt> params <Type> Identifier
        RULE_PROPERTYDEC_LBRACE_RBRACE                                               = 316, // <Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
        RULE_ACCESSORDEC_GET                                                         = 317, // <Accessor Dec> ::= <Access Opt> get <Block or Semi>
        RULE_ACCESSORDEC_GET_SET                                                     = 318, // <Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET                                                         = 319, // <Accessor Dec> ::= <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET_GET                                                     = 320, // <Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
        RULE_EVENTDEC_EVENT_SEMI                                                     = 321, // <Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
        RULE_EVENTDEC_EVENT_LBRACE_RBRACE                                            = 322, // <Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
        RULE_EVENTACCESSORDECS_ADD                                                   = 323, // <Event Accessor Decs> ::= add <Block or Semi>
        RULE_EVENTACCESSORDECS_ADD_REMOVE                                            = 324, // <Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE                                                = 325, // <Event Accessor Decs> ::= remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE_ADD                                            = 326, // <Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
        RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE                              = 327, // <Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
        RULE_OPERATORDEC                                                             = 328, // <Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
        RULE_OPERATORDEC2                                                            = 329, // <Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_RPAREN                  = 330, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_COMMA_IDENTIFIER_RPAREN = 331, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN       = 332, // <Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN       = 333, // <Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
        RULE_OVERLOADOP_PLUS                                                         = 334, // <Overload Op> ::= '+'
        RULE_OVERLOADOP_MINUS                                                        = 335, // <Overload Op> ::= '-'
        RULE_OVERLOADOP_EXCLAM                                                       = 336, // <Overload Op> ::= '!'
        RULE_OVERLOADOP_TILDE                                                        = 337, // <Overload Op> ::= '~'
        RULE_OVERLOADOP_PLUSPLUS                                                     = 338, // <Overload Op> ::= '++'
        RULE_OVERLOADOP_MINUSMINUS                                                   = 339, // <Overload Op> ::= '--'
        RULE_OVERLOADOP_TRUE                                                         = 340, // <Overload Op> ::= true
        RULE_OVERLOADOP_FALSE                                                        = 341, // <Overload Op> ::= false
        RULE_OVERLOADOP_TIMES                                                        = 342, // <Overload Op> ::= '*'
        RULE_OVERLOADOP_DIV                                                          = 343, // <Overload Op> ::= '/'
        RULE_OVERLOADOP_PERCENT                                                      = 344, // <Overload Op> ::= '%'
        RULE_OVERLOADOP_AMP                                                          = 345, // <Overload Op> ::= '&'
        RULE_OVERLOADOP_PIPE                                                         = 346, // <Overload Op> ::= '|'
        RULE_OVERLOADOP_CARET                                                        = 347, // <Overload Op> ::= '^'
        RULE_OVERLOADOP_LTLT                                                         = 348, // <Overload Op> ::= '<<'
        RULE_OVERLOADOP_GTGT                                                         = 349, // <Overload Op> ::= '>>'
        RULE_OVERLOADOP_EQEQ                                                         = 350, // <Overload Op> ::= '=='
        RULE_OVERLOADOP_EXCLAMEQ                                                     = 351, // <Overload Op> ::= '!='
        RULE_OVERLOADOP_GT                                                           = 352, // <Overload Op> ::= '>'
        RULE_OVERLOADOP_LT                                                           = 353, // <Overload Op> ::= '<'
        RULE_OVERLOADOP_GTEQ                                                         = 354, // <Overload Op> ::= '>='
        RULE_OVERLOADOP_LTEQ                                                         = 355, // <Overload Op> ::= '<='
        RULE_CONSTRUCTORDEC                                                          = 356, // <Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
        RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPAREN_RPAREN                          = 357, // <Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
        RULE_CONSTRUCTORINITOPT                                                      = 358, // <Constructor Init Opt> ::= <Constructor Init>
        RULE_CONSTRUCTORINITOPT2                                                     = 359, // <Constructor Init Opt> ::= 
        RULE_CONSTRUCTORINIT_COLON_BASE_LPAREN_RPAREN                                = 360, // <Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
        RULE_CONSTRUCTORINIT_COLON_THIS_LPAREN_RPAREN                                = 361, // <Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
        RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPAREN_RPAREN                            = 362, // <Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
        RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE                              = 363, // <Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_ARRAYINITIALIZEROPT                                                     = 364, // <Array Initializer Opt> ::= <Array Initializer>
        RULE_ARRAYINITIALIZEROPT2                                                    = 365, // <Array Initializer Opt> ::= 
        RULE_ARRAYINITIALIZER_LBRACE_RBRACE                                          = 366, // <Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
        RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE                                    = 367, // <Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
        RULE_VARIABLEINITIALIZERLISTOPT                                              = 368, // <Variable Initializer List Opt> ::= <Variable Initializer List>
        RULE_VARIABLEINITIALIZERLISTOPT2                                             = 369, // <Variable Initializer List Opt> ::= 
        RULE_VARIABLEINITIALIZERLIST                                                 = 370, // <Variable Initializer List> ::= <Variable Initializer>
        RULE_VARIABLEINITIALIZERLIST_COMMA                                           = 371, // <Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
        RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE                        = 372, // <Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
        RULE_INTERFACEBASEOPT_COLON                                                  = 373, // <Interface Base Opt> ::= ':' <Class Base List>
        RULE_INTERFACEBASEOPT                                                        = 374, // <Interface Base Opt> ::= 
        RULE_INTERFACEITEMDECSOPT                                                    = 375, // <Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
        RULE_INTERFACEITEMDECSOPT2                                                   = 376, // <Interface Item Decs Opt> ::= 
        RULE_INTERFACEITEMDEC                                                        = 377, // <Interface Item Dec> ::= <Interface Method Dec>
        RULE_INTERFACEITEMDEC2                                                       = 378, // <Interface Item Dec> ::= <Interface Property Dec>
        RULE_INTERFACEITEMDEC3                                                       = 379, // <Interface Item Dec> ::= <Interface Event Dec>
        RULE_INTERFACEITEMDEC4                                                       = 380, // <Interface Item Dec> ::= <Interface Indexer Dec>
        RULE_INTERFACEMETHODDEC_IDENTIFIER_LPAREN_RPAREN                             = 381, // <Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
        RULE_NEWOPT_NEW                                                              = 382, // <New Opt> ::= new
        RULE_NEWOPT                                                                  = 383, // <New Opt> ::= 
        RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE                           = 384, // <Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
        RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE                = 385, // <Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
        RULE_INTERFACEACCESSORS_GET                                                  = 386, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET                                                  = 387, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_GET_SET                                              = 388, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET_GET                                              = 389, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER                                      = 390, // <Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
        RULE_INTERFACEEMPTYBODY_SEMI                                                 = 391, // <Interface Empty Body> ::= ';'
        RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE                                        = 392, // <Interface Empty Body> ::= '{' '}'
        RULE_ENUMDECL_ENUM_IDENTIFIER                                                = 393, // <Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
        RULE_ENUMBASEOPT_COLON                                                       = 394, // <Enum Base Opt> ::= ':' <Integral Type>
        RULE_ENUMBASEOPT                                                             = 395, // <Enum Base Opt> ::= 
        RULE_ENUMBODY_LBRACE_RBRACE                                                  = 396, // <Enum Body> ::= '{' <Enum Item Decs Opt> '}'
        RULE_ENUMBODY_LBRACE_COMMA_RBRACE                                            = 397, // <Enum Body> ::= '{' <Enum Item Decs> ',' '}'
        RULE_ENUMITEMDECSOPT                                                         = 398, // <Enum Item Decs Opt> ::= <Enum Item Decs>
        RULE_ENUMITEMDECSOPT2                                                        = 399, // <Enum Item Decs Opt> ::= 
        RULE_ENUMITEMDECS                                                            = 400, // <Enum Item Decs> ::= <Enum Item Dec>
        RULE_ENUMITEMDECS_COMMA                                                      = 401, // <Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
        RULE_ENUMITEMDEC_IDENTIFIER                                                  = 402, // <Enum Item Dec> ::= <Attrib Opt> Identifier
        RULE_ENUMITEMDEC_IDENTIFIER_EQ                                               = 403, // <Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
        RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPAREN_RPAREN_SEMI                     = 404, // <Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
        RULE_ATTRIBOPT                                                               = 405, // <Attrib Opt> ::= <Attrib Opt> <Attrib Section>
        RULE_ATTRIBOPT2                                                              = 406, // <Attrib Opt> ::= 
        RULE_ATTRIBSECTION_LBRACKET_RBRACKET                                         = 407, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
        RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET                                   = 408, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
        RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON                                      = 409, // <Attrib Target Spec Opt> ::= assembly ':'
        RULE_ATTRIBTARGETSPECOPT_FIELD_COLON                                         = 410, // <Attrib Target Spec Opt> ::= field ':'
        RULE_ATTRIBTARGETSPECOPT_EVENT_COLON                                         = 411, // <Attrib Target Spec Opt> ::= event ':'
        RULE_ATTRIBTARGETSPECOPT_METHOD_COLON                                        = 412, // <Attrib Target Spec Opt> ::= method ':'
        RULE_ATTRIBTARGETSPECOPT_MODULE_COLON                                        = 413, // <Attrib Target Spec Opt> ::= module ':'
        RULE_ATTRIBTARGETSPECOPT_PARAM_COLON                                         = 414, // <Attrib Target Spec Opt> ::= param ':'
        RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON                                      = 415, // <Attrib Target Spec Opt> ::= property ':'
        RULE_ATTRIBTARGETSPECOPT_RETURN_COLON                                        = 416, // <Attrib Target Spec Opt> ::= return ':'
        RULE_ATTRIBTARGETSPECOPT_TYPE_COLON                                          = 417, // <Attrib Target Spec Opt> ::= type ':'
        RULE_ATTRIBTARGETSPECOPT                                                     = 418, // <Attrib Target Spec Opt> ::= 
        RULE_ATTRIBLIST                                                              = 419, // <Attrib List> ::= <Attribute>
        RULE_ATTRIBLIST_COMMA                                                        = 420, // <Attrib List> ::= <Attrib List> ',' <Attribute>
        RULE_ATTRIBUTE_LPAREN_RPAREN                                                 = 421, // <Attribute> ::= <Qualified ID> '(' <Expression List> ')'
        RULE_ATTRIBUTE_LPAREN_RPAREN2                                                = 422, // <Attribute> ::= <Qualified ID> '(' ')'
        RULE_ATTRIBUTE                                                               = 423  // <Attribute> ::= <Qualified ID>
    };

        // this class will construct a parser without having to process
        //  the CGT tables with each creation.  It must be initialized
        //  before you can call CreateParser()
    public sealed class ParserFactory
    {
        static Grammar m_grammar;
        static bool _init;
        
        private ParserFactory()
        {
        }
        
        private static BinaryReader GetResourceReader(string resourceName)
        {  
            Assembly assembly = Assembly.GetExecutingAssembly();   
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            return new BinaryReader(stream);
        }
        
        public static void InitializeFactoryFromFile(string FullCGTFilePath)
        {
            if (!_init)
            {
               BinaryReader reader = new BinaryReader(new FileStream(FullCGTFilePath,FileMode.Open));
               m_grammar = new Grammar( reader );
               _init = true;
            }
        }
        
        public static void InitializeFactoryFromResource(string resourceName)
        {
            if (!_init)
            {
                BinaryReader reader = GetResourceReader(resourceName);
                m_grammar = new Grammar( reader );
                _init = true;
            }
        }
        
        public static Parser CreateParser(TextReader reader)
        {
           if (_init)
           {
                return new Parser(reader, m_grammar);
           }
           throw new Exception("You must first Initialize the Factory before creating a parser!");
        }
    }
        
    public abstract partial class ASTNode
    {
        public abstract bool IsTerminal
        {
            get;
        }
    }
    
    /// <summary>
    /// Derive this class for Terminal AST Nodes
    /// </summary>
    public partial class TerminalNode : ASTNode
    {
        private Symbol m_symbol;
        private string m_text;
        private int m_lineNumber;
        private int m_linePosition;

        public TerminalNode(Parser theParser)
        {
            m_symbol = theParser.TokenSymbol;
            m_text = theParser.TokenSymbol.ToString();
            m_lineNumber = theParser.LineNumber;
            m_linePosition = theParser.LinePosition;
        }

        public override bool IsTerminal
        {
            get
            {
                return true;
            }
        }
        
        public Symbol Symbol
        {
            get { return m_symbol; }
        }

        public string Text
        {
            get { return m_text; }
        }

        public override string ToString()
        {
            return m_text;
        }

        public int LineNumber 
        {
            get { return m_lineNumber; }
        }

        public int LinePosition
        {
            get { return m_linePosition; }
        }
    }
    
    /// <summary>
    /// Derive this class for NonTerminal AST Nodes
    /// </summary>
    public partial class NonTerminalNode : ASTNode
    {
        private int m_reductionNumber;
        private Rule m_rule;
        private List<ASTNode> m_array = new List<ASTNode>();

        public NonTerminalNode(Parser theParser)
        {
            m_rule = theParser.ReductionRule;
        }
        
        public override bool IsTerminal
        {
            get
            {
                return false;
            }
        }

        public int ReductionNumber 
        {
            get { return m_reductionNumber; }
            set { m_reductionNumber = value; }
        }

        public int Count 
        {
            get { return m_array.Count; }
        }

        public ASTNode this[int index]
        {
            get { return m_array[index]; }
        }

        public void AppendChildNode(ASTNode node)
        {
            if (node == null)
            {
                return ; 
            }
            m_array.Add(node);
        }

        public Rule Rule
        {
            get { return m_rule; }
        }

    }

    public partial class MyParser
    {
        MyParserContext m_context;
        ASTNode m_AST;
        string m_errorString;
        Parser m_parser;
        
        public int LineNumber
        {
            get
            {
                return m_parser.LineNumber;
            }
        }

        public int LinePosition
        {
            get
            {
                return m_parser.LinePosition;
            }
        }

        public string ErrorString
        {
            get
            {
                return m_errorString;
            }
        }

        public string ErrorLine
        {
            get
            {
                return m_parser.LineText;
            }
        }

        public ASTNode SyntaxTree
        {
            get
            {
                return m_AST;
            }
        }

        public bool Parse(string source)
        {
            return Parse(new StringReader(source));
        }

        public bool Parse(StringReader sourceReader)
        {
            m_parser = ParserFactory.CreateParser(sourceReader);
            m_parser.TrimReductions = true;
            m_context = new MyParserContext(m_parser);
            
            while (true)
            {
                switch (m_parser.Parse())
                {
                    case ParseMessage.LexicalError:
                        m_errorString = string.Format("Lexical Error. Line {0}. Token {1} was not expected.", m_parser.LineNumber, m_parser.TokenText);
                        return false;

                    case ParseMessage.SyntaxError:
                        StringBuilder text = new StringBuilder();
                        foreach (Symbol tokenSymbol in m_parser.GetExpectedTokens())
                        {
                            text.Append(' ');
                            text.Append(tokenSymbol.ToString());
                        }
                        m_errorString = string.Format("Syntax Error. Line {0}. Expecting: {1}.", m_parser.LineNumber, text.ToString());
                        
                        return false;
                    case ParseMessage.Reduction:
                        m_parser.TokenSyntaxNode = m_context.CreateASTNode();
                        break;

                    case ParseMessage.Accept:
                        m_AST = m_parser.TokenSyntaxNode as ASTNode;
                        m_errorString = null;
                        return true;

                    case ParseMessage.InternalError:
                        m_errorString = "Internal Error. Something is horribly wrong.";
                        return false;

                    case ParseMessage.NotLoadedError:
                        m_errorString = "Grammar Table is not loaded.";
                        return false;

                    case ParseMessage.CommentError:
                        m_errorString = "Comment Error. Unexpected end of input.";
                        
                        return false;

                    case ParseMessage.CommentBlockRead:
                    case ParseMessage.CommentLineRead:
                        // don't do anything 
                        break;
                }
            }
         }

    }

    public partial class MyParserContext
    {

        // instance fields
        private Parser m_parser;
        
        private TextReader m_inputReader;
        

        
        // constructor
        public MyParserContext(Parser prser)
        {
            m_parser = prser;   
        }
       

        private string GetTokenText()
        {
            // delete any of these that are non-terminals.

            switch (m_parser.TokenSymbol.Index)
            {

                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //Token Kind: 3
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //Token Kind: 7
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //Token Kind: 2
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //Token Kind: 2
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //Token Kind: 2
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESDIV :
                //'*/'
                //Token Kind: 5
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIVTIMES :
                //'/*'
                //Token Kind: 4
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIVDIV :
                //'//'
                //Token Kind: 6
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_AMPEQ :
                //'&='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CARETEQ :
                //'^='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEEQ :
                //'|='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TILDE :
                //'~'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LTLTEQ :
                //'<<='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTEQ :
                //'>>='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ABSTRACT :
                //abstract
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ADD :
                //add
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //as
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ASSEMBLY :
                //assembly
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BASE :
                //base
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BYTE :
                //byte
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CHECKED :
                //checked
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DECIMAL :
                //decimal
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DECLITERAL :
                //DecLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATE :
                //delegate
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DYNAMIC :
                //dynamic
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUM :
                //enum
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EVENT :
                //event
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPLICIT :
                //explicit
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXTERN :
                //extern
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIELD :
                //field
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIXED :
                //fixed
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FOREACH :
                //foreach
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GET :
                //get
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GLOBAL :
                //global
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GOTO :
                //goto
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_HEXLITERAL :
                //HexLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IMPLICIT :
                //implicit
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACE :
                //interface
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERNAL :
                //internal
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IS :
                //is
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LOCK :
                //lock
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERNAME :
                //MemberName
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //method
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MODULE :
                //module
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACE :
                //namespace
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NULL :
                //null
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECT :
                //object
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR :
                //operator
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OUT :
                //out
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OVERRIDE :
                //override
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //param
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //params
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PARTIAL :
                //partial
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTY :
                //property
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_READONLY :
                //readonly
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_REALLITERAL :
                //RealLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_REF :
                //ref
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_REMOVE :
                //remove
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SBYTE :
                //sbyte
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SEALED :
                //sealed
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SET :
                //set
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SHORT :
                //short
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SIZEOF :
                //sizeof
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STACKALLOC :
                //stackalloc
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCT :
                //struct
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_THROW :
                //throw
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //type
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEOF :
                //typeof
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_UINT :
                //uint
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ULONG :
                //ulong
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_UNCHECKED :
                //unchecked
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_UNSAFE :
                //unsafe
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_USHORT :
                //ushort
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_USING :
                //using
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VIRTUAL :
                //virtual
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VOLATILE :
                //volatile
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSOPT :
                //<Access Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSORDEC :
                //<Accessor Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ANDEXP :
                //<And Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLIST :
                //<Arg List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLISTOPT :
                //<Arg List Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT :
                //<Argument>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZER :
                //<Array Initializer>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNTAIL :
                //<Assign Tail>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBLIST :
                //<Attrib List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBOPT :
                //<Attrib Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBSECTION :
                //<Attrib Section>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBUTE :
                //<Attribute>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BASETYPE :
                //<Base Type>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCKORSEMI :
                //<Block or Semi>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSE :
                //<Catch Clause>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSES :
                //<Catch Clauses>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASELIST :
                //<Class Base List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASEOPT :
                //<Class Base Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDECL :
                //<Class Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEM :
                //<Class Item>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEMDECSOPT :
                //<Class Item Decs Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMPAREEXP :
                //<Compare Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEM :
                //<Compilation Item>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEMS :
                //<Compilation Items>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONUNIT :
                //<Compilation Unit>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONALEXP :
                //<Conditional Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEC :
                //<Constant Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATOR :
                //<Constant Declarator>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATORS :
                //<Constant Declarators>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDEC :
                //<Constructor Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDECLARATOR :
                //<Constructor Declarator>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINIT :
                //<Constructor Init>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINITOPT :
                //<Constructor Init Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONVERSIONOPERATORDECL :
                //<Conversion Operator Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATEDECL :
                //<Delegate Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DESTRUCTORDEC :
                //<Destructor Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIMSEPARATORS :
                //<Dim Separators>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBASEOPT :
                //<Enum Base Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBODY :
                //<Enum Body>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMDECL :
                //<Enum Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDEC :
                //<Enum Item Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECS :
                //<Enum Item Decs>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXP :
                //<Equality Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EVALITEM :
                //<eval item>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTACCESSORDECS :
                //<Event Accessor Decs>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTDEC :
                //<Event Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
                //<Expression List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONOPT :
                //<Expression Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIELDDEC :
                //<Field Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLYCLAUSEOPT :
                //<Finally Clause Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDEC :
                //<Fixed Ptr Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDECS :
                //<Fixed Ptr Decs>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORCONDITIONOPT :
                //<For Condition Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORINITOPT :
                //<For Init Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORITERATOROPT :
                //<For Iterator Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAM :
                //<Formal Param>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLIST :
                //<Formal Param List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLISTOPT :
                //<Formal Param List Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_HEADER :
                //<Header>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INDEXERDEC :
                //<Indexer Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGRALTYPE :
                //<Integral Type>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEACCESSORS :
                //<Interface Accessors>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEBASEOPT :
                //<Interface Base Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEDECL :
                //<Interface Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEMPTYBODY :
                //<Interface Empty Body>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEVENTDEC :
                //<Interface Event Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEINDEXERDEC :
                //<Interface Indexer Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDEC :
                //<Interface Item Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEMETHODDEC :
                //<Interface Method Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEPROPERTYDEC :
                //<Interface Property Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LOCALVARDECL :
                //<Local Var Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXP :
                //<Logical And Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXP :
                //<Logical Or Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALXOREXP :
                //<Logical Xor Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERLIST :
                //<Member List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD2 :
                //<Method>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDEC :
                //<Method Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHODEXP :
                //<Method Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<methodcall>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_METHODSOPT :
                //<Methods Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIER :
                //<Modifier>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIERLISTOPT :
                //<Modifier List Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEDEC :
                //<Namespace Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEM :
                //<Namespace Item>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEMS :
                //<Namespace Items>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NEWOPT :
                //<New Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NONARRAYTYPE :
                //<Non Array Type>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NORMALSTM :
                //<Normal Stm>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECTEXP :
                //<Object Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATORDEC :
                //<Operator Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OREXP :
                //<Or Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERTYPE :
                //<Other Type>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOP :
                //<Overload Op>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOPERATORDECL :
                //<Overload Operator Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_POINTEROPT :
                //<Pointer Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<Primary>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYARRAYCREATIONEXP :
                //<Primary Array Creation Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYEXP :
                //<Primary Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTYDEC :
                //<Property Dec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_QUALIFIEDID :
                //<Qualified ID>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIER :
                //<Rank Specifier>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERS :
                //<Rank Specifiers>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RESOURCE :
                //<Resource>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SEMICOLONOPT :
                //<Semicolon Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SHIFTEXP :
                //<Shift Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXP :
                //<Statement Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXPLIST :
                //<Statement Exp List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STMLIST :
                //<Stm List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCTDECL :
                //<Struct Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABEL :
                //<Switch Label>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABELS :
                //<Switch Labels>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTION :
                //<Switch Section>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTIONSOPT :
                //<Switch Sections Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_THENSTM :
                //<Then Stm>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE2 :
                //<Type>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDECL :
                //<Type Decl>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXP :
                //<Unary Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_USINGDIRECTIVE :
                //<Using Directive>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_USINGLIST :
                //<Using List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VALIDID :
                //<Valid ID>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VAR2 :
                //<var>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VAR_VAR :
                //<var_var>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATOR :
                //<Variable Declarator>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECS :
                //<Variable Decs>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZER :
                //<Variable Initializer>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                default:
                    throw new SymbolException("You don't want the text of a non-terminal symbol");

            }
            
        }

        public ASTNode CreateASTNode()
        {
            switch (m_parser.ReductionRule.Index)
            {
                case (int)RuleConstants.RULE_BLOCKORSEMI :
                //<Block or Semi> ::= <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_BLOCKORSEMI_SEMI :
                //<Block or Semi> ::= ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALIDID_IDENTIFIER :
                //<Valid ID> ::= Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALIDID_THIS :
                //<Valid ID> ::= this
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALIDID_BASE :
                //<Valid ID> ::= base
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALIDID :
                //<Valid ID> ::= <Base Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_QUALIFIEDID :
                //<Qualified ID> ::= <Valid ID> <Member List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST_MEMBERNAME :
                //<Member List> ::= <Member List> MemberName
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST :
                //<Member List> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT_SEMI :
                //<Semicolon Opt> ::= ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT :
                //<Semicolon Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_TRUE :
                //<Literal> ::= true
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_FALSE :
                //<Literal> ::= false
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_DECLITERAL :
                //<Literal> ::= DecLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_HEXLITERAL :
                //<Literal> ::= HexLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_REALLITERAL :
                //<Literal> ::= RealLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_CHARLITERAL :
                //<Literal> ::= CharLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_STRINGLITERAL :
                //<Literal> ::= StringLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LITERAL_NULL :
                //<Literal> ::= null
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<Type> ::= <Non Array Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES :
                //<Type> ::= <Non Array Type> '*'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPE2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers> '*'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT_TIMES :
                //<Pointer Opt> ::= '*'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT :
                //<Pointer Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NONARRAYTYPE :
                //<Non Array Type> ::= <Qualified ID>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_BASETYPE :
                //<Base Type> ::= <Other Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_BASETYPE2 :
                //<Base Type> ::= <Integral Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_FLOAT :
                //<Other Type> ::= float
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DOUBLE :
                //<Other Type> ::= double
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DECIMAL :
                //<Other Type> ::= decimal
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_BOOL :
                //<Other Type> ::= bool
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_VOID :
                //<Other Type> ::= void
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_OBJECT :
                //<Other Type> ::= object
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_STRING :
                //<Other Type> ::= string
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DYNAMIC :
                //<Other Type> ::= dynamic
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SBYTE :
                //<Integral Type> ::= sbyte
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_BYTE :
                //<Integral Type> ::= byte
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SHORT :
                //<Integral Type> ::= short
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_USHORT :
                //<Integral Type> ::= ushort
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_INT :
                //<Integral Type> ::= int
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_UINT :
                //<Integral Type> ::= uint
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_LONG :
                //<Integral Type> ::= long
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_ULONG :
                //<Integral Type> ::= ulong
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_CHAR :
                //<Integral Type> ::= char
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT2 :
                //<Rank Specifiers Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS :
                //<Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS2 :
                //<Rank Specifiers> ::= <Rank Specifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIER_LBRACKET_RBRACKET :
                //<Rank Specifier> ::= '[' <Dim Separators> ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS_COMMA :
                //<Dim Separators> ::= <Dim Separators> ','
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS :
                //<Dim Separators> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT :
                //<Expression Opt> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT2 :
                //<Expression Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST :
                //<Expression List> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
                //<Expression List> ::= <Expression> ',' <Expression List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Conditional Exp> '=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUSEQ :
                //<Expression> ::= <Conditional Exp> '+=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUSEQ :
                //<Expression> ::= <Conditional Exp> '-=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_TIMESEQ :
                //<Expression> ::= <Conditional Exp> '*=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_DIVEQ :
                //<Expression> ::= <Conditional Exp> '/=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_CARETEQ :
                //<Expression> ::= <Conditional Exp> '^=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AMPEQ :
                //<Expression> ::= <Conditional Exp> '&=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PIPEEQ :
                //<Expression> ::= <Conditional Exp> '|=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PERCENTEQ :
                //<Expression> ::= <Conditional Exp> '%=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTLTEQ :
                //<Expression> ::= <Conditional Exp> '<<=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTGTEQ :
                //<Expression> ::= <Conditional Exp> '>>=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Conditional Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP_QUESTION_COLON :
                //<Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP :
                //<Conditional Exp> ::= <Or Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OREXP_PIPEPIPE :
                //<Or Exp> ::= <Or Exp> '||' <And Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OREXP :
                //<Or Exp> ::= <And Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ANDEXP_AMPAMP :
                //<And Exp> ::= <And Exp> '&&' <Logical Or Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ANDEXP :
                //<And Exp> ::= <Logical Or Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP_PIPE :
                //<Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP :
                //<Logical Or Exp> ::= <Logical Xor Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP_CARET :
                //<Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP :
                //<Logical Xor Exp> ::= <Logical And Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP_AMP :
                //<Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP :
                //<Logical And Exp> ::= <Equality Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EQEQ :
                //<Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EXCLAMEQ :
                //<Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP :
                //<Equality Exp> ::= <Compare Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LT :
                //<Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GT :
                //<Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LTEQ :
                //<Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GTEQ :
                //<Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_IS :
                //<Compare Exp> ::= <Compare Exp> is <Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_AS :
                //<Compare Exp> ::= <Compare Exp> as <Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP :
                //<Compare Exp> ::= <Shift Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_LTLT :
                //<Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_GTGT :
                //<Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP :
                //<Shift Exp> ::= <Add Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_EXCLAM :
                //<Unary Exp> ::= '!' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_TILDE :
                //<Unary Exp> ::= '~' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUS :
                //<Unary Exp> ::= '-' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_PLUSPLUS :
                //<Unary Exp> ::= '++' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUSMINUS :
                //<Unary Exp> ::= '--' <Unary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_LPAREN_RPAREN :
                //<Unary Exp> ::= '(' <Expression> ')' <Object Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP :
                //<Unary Exp> ::= <Object Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP_DELEGATE_LPAREN_RPAREN :
                //<Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP :
                //<Object Exp> ::= <Primary Array Creation Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP2 :
                //<Object Exp> ::= <Method Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET :
                //<Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW :
                //<Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODEXP :
                //<Method Exp> ::= <Method Exp> <Method>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODEXP2 :
                //<Method Exp> ::= <Primary Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_TYPEOF_LPAREN_RPAREN :
                //<Primary Exp> ::= typeof '(' <Type> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_SIZEOF_LPAREN_RPAREN :
                //<Primary Exp> ::= sizeof '(' <Type> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_CHECKED_LPAREN_RPAREN :
                //<Primary Exp> ::= checked '(' <Expression> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_UNCHECKED_LPAREN_RPAREN :
                //<Primary Exp> ::= unchecked '(' <Expression> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_NEW_LPAREN_RPAREN :
                //<Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP :
                //<Primary Exp> ::= <Primary>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_LPAREN_RPAREN :
                //<Primary Exp> ::= '(' <Expression> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<Primary> ::= <Valid ID>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_LPAREN_RPAREN :
                //<Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<Primary> ::= <Literal>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT :
                //<Arg List Opt> ::= <Arg List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT2 :
                //<Arg List Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGLIST_COMMA :
                //<Arg List> ::= <Arg List> ',' <Argument>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGLIST :
                //<Arg List> ::= <Argument>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT :
                //<Argument> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_REF :
                //<Argument> ::= ref <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_OUT :
                //<Argument> ::= out <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STMLIST :
                //<Stm List> ::= <Stm List> <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STMLIST2 :
                //<Stm List> ::= <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IDENTIFIER_COLON :
                //<Statement> ::= Identifier ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<Statement> ::= <Local Var Decl> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPAREN_RPAREN :
                //<Statement> ::= if '(' <Expression> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPAREN_RPAREN_ELSE :
                //<Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN :
                //<Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_WHILE_LPAREN_RPAREN :
                //<Statement> ::= while '(' <Expression> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LOCK_LPAREN_RPAREN :
                //<Statement> ::= lock '(' <Expression> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_USING_LPAREN_RPAREN :
                //<Statement> ::= using '(' <Resource> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FIXED_LPAREN_RPAREN :
                //<Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DELEGATE_LPAREN_RPAREN :
                //<Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Normal Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_IF_LPAREN_RPAREN_ELSE :
                //<Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN :
                //<Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_WHILE_LPAREN_RPAREN :
                //<Then Stm> ::= while '(' <Expression> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_LOCK_LPAREN_RPAREN :
                //<Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_USING_LPAREN_RPAREN :
                //<Then Stm> ::= using '(' <Resource> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FIXED_LPAREN_RPAREN :
                //<Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM_DELEGATE_LPAREN_RPAREN :
                //<Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_THENSTM :
                //<Then Stm> ::= <Normal Stm>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_DO_WHILE_LPAREN_RPAREN_SEMI :
                //<Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_TRY :
                //<Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CHECKED :
                //<Normal Stm> ::= checked <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNCHECKED :
                //<Normal Stm> ::= unchecked <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNSAFE :
                //<Normal Stm> ::= unsafe <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_BREAK_SEMI :
                //<Normal Stm> ::= break ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CONTINUE_SEMI :
                //<Normal Stm> ::= continue ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI :
                //<Normal Stm> ::= goto Identifier ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_CASE_SEMI :
                //<Normal Stm> ::= goto case <Expression> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_DEFAULT_SEMI :
                //<Normal Stm> ::= goto default ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_RETURN_SEMI :
                //<Normal Stm> ::= return <Expression Opt> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_THROW_SEMI :
                //<Normal Stm> ::= throw <Expression Opt> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI :
                //<Normal Stm> ::= <Statement Exp> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI2 :
                //<Normal Stm> ::= ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM :
                //<Normal Stm> ::= <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <Stm List> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS :
                //<Variable Decs> ::= <Variable Declarator>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS_COMMA :
                //<Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER :
                //<Variable Declarator> ::= Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ :
                //<Variable Declarator> ::= Identifier '=' <Variable Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER :
                //<Variable Initializer> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER2 :
                //<Variable Initializer> ::= <Array Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET :
                //<Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS :
                //<Constant Declarators> ::= <Constant Declarator>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS_COMMA :
                //<Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ :
                //<Constant Declarator> ::= Identifier '=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT :
                //<Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT2 :
                //<Switch Sections Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTION :
                //<Switch Section> ::= <Switch Labels> <Stm List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS :
                //<Switch Labels> ::= <Switch Label>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS2 :
                //<Switch Labels> ::= <Switch Labels> <Switch Label>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_CASE_COLON :
                //<Switch Label> ::= case <Expression> ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_DEFAULT_COLON :
                //<Switch Label> ::= default ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT :
                //<For Init Opt> ::= <Local Var Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT2 :
                //<For Init Opt> ::= <Statement Exp List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT3 :
                //<For Init Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT :
                //<For Iterator Opt> ::= <Statement Exp List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT2 :
                //<For Iterator Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT :
                //<For Condition Opt> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT2 :
                //<For Condition Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST_COMMA :
                //<Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST :
                //<Statement Exp List> ::= <Statement Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES :
                //<Catch Clauses> ::= <Catch Clause> <Catch Clauses>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES2 :
                //<Catch Clauses> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPAREN_IDENTIFIER_RPAREN :
                //<Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPAREN_RPAREN :
                //<Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH :
                //<Catch Clause> ::= catch <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT_FINALLY :
                //<Finally Clause Opt> ::= finally <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT :
                //<Finally Clause Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RESOURCE :
                //<Resource> ::= <Local Var Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_RESOURCE2 :
                //<Resource> ::= <Statement Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS_COMMA :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDEC_IDENTIFIER_EQ :
                //<Fixed Ptr Dec> ::= Identifier '=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL :
                //<Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL2 :
                //<Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPAREN_RPAREN :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPAREN_RPAREN2 :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LBRACKET_RBRACKET :
                //<Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSGT_IDENTIFIER :
                //<Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_PLUSPLUS :
                //<Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSMINUS :
                //<Statement Exp> ::= <Qualified ID> '--' <Methods Opt> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP :
                //<Statement Exp> ::= <Qualified ID> <Assign Tail>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSPLUS :
                //<Assign Tail> ::= '++'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSMINUS :
                //<Assign Tail> ::= '--'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_EQ :
                //<Assign Tail> ::= '=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSEQ :
                //<Assign Tail> ::= '+=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSEQ :
                //<Assign Tail> ::= '-=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_TIMESEQ :
                //<Assign Tail> ::= '*=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_DIVEQ :
                //<Assign Tail> ::= '/=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_CARETEQ :
                //<Assign Tail> ::= '^=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_AMPEQ :
                //<Assign Tail> ::= '&=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PIPEEQ :
                //<Assign Tail> ::= '|=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PERCENTEQ :
                //<Assign Tail> ::= '%=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_LTLTEQ :
                //<Assign Tail> ::= '<<=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_GTGTEQ :
                //<Assign Tail> ::= '>>=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT :
                //<Methods Opt> ::= <Methods Opt> <Method>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT2 :
                //<Methods Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME :
                //<Method> ::= MemberName
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME_LPAREN_RPAREN :
                //<Method> ::= MemberName '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_LBRACKET_RBRACKET :
                //<Method> ::= '[' <Expression List> ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSGT_IDENTIFIER :
                //<Method> ::= '->' Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_PLUSPLUS :
                //<Method> ::= '++'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSMINUS :
                //<Method> ::= '--'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VAR_VAR :
                //<var> ::= var
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VAR_GLOBAL :
                //<var> ::= global
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VAR_VAR_IDENTIFIER :
                //<var_var> ::= <var> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VAR_VAR_IDENTIFIER_EQ :
                //<var_var> ::= <var> Identifier '=' <Variable Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODCALL :
                //<methodcall> ::= <Formal Param List Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVALITEM :
                //<eval item> ::= <Stm List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVALITEM2 :
                //<eval item> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONUNIT :
                //<Compilation Unit> ::= <Using List> <Compilation Items> <eval item>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_USINGLIST :
                //<Using List> ::= <Using List> <Using Directive>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_USINGLIST2 :
                //<Using List> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI :
                //<Using Directive> ::= using Identifier '=' <Qualified ID> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_SEMI :
                //<Using Directive> ::= using <Qualified ID> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS :
                //<Compilation Items> ::= <Compilation Items> <Compilation Item>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS2 :
                //<Compilation Items> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM :
                //<Compilation Item> ::= <Namespace Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM2 :
                //<Compilation Item> ::= <Namespace Item>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE :
                //<Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS :
                //<Namespace Items> ::= <Namespace Items> <Namespace Item>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS2 :
                //<Namespace Items> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM :
                //<Namespace Item> ::= <Constant Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM2 :
                //<Namespace Item> ::= <Field Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM3 :
                //<Namespace Item> ::= <Method Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM4 :
                //<Namespace Item> ::= <Property Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM5 :
                //<Namespace Item> ::= <Type Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL :
                //<Type Decl> ::= <Class Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL2 :
                //<Type Decl> ::= <Struct Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL3 :
                //<Type Decl> ::= <Interface Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL4 :
                //<Type Decl> ::= <Enum Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL5 :
                //<Type Decl> ::= <Delegate Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_HEADER :
                //<Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PRIVATE :
                //<Access Opt> ::= private
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PROTECTED :
                //<Access Opt> ::= protected
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PUBLIC :
                //<Access Opt> ::= public
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_INTERNAL :
                //<Access Opt> ::= internal
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT :
                //<Access Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT :
                //<Modifier List Opt> ::= <Modifier List Opt> <Modifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT2 :
                //<Modifier List Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_ABSTRACT :
                //<Modifier> ::= abstract
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_EXTERN :
                //<Modifier> ::= extern
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_NEW :
                //<Modifier> ::= new
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_OVERRIDE :
                //<Modifier> ::= override
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_PARTIAL :
                //<Modifier> ::= partial
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_READONLY :
                //<Modifier> ::= readonly
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_SEALED :
                //<Modifier> ::= sealed
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_STATIC :
                //<Modifier> ::= static
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_UNSAFE :
                //<Modifier> ::= unsafe
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VIRTUAL :
                //<Modifier> ::= virtual
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VOLATILE :
                //<Modifier> ::= volatile
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE :
                //<Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT_COLON :
                //<Class Base Opt> ::= ':' <Class Base List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT :
                //<Class Base Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST_COMMA :
                //<Class Base List> ::= <Class Base List> ',' <Non Array Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST :
                //<Class Base List> ::= <Non Array Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT :
                //<Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT2 :
                //<Class Item Decs Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM :
                //<Class Item> ::= <Constant Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM2 :
                //<Class Item> ::= <Field Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM3 :
                //<Class Item> ::= <Method Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM4 :
                //<Class Item> ::= <Property Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM5 :
                //<Class Item> ::= <Event Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM6 :
                //<Class Item> ::= <Indexer Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM7 :
                //<Class Item> ::= <Operator Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM8 :
                //<Class Item> ::= <Constructor Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM9 :
                //<Class Item> ::= <Destructor Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM10 :
                //<Class Item> ::= <Type Decl>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEC_CONST_SEMI :
                //<Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIELDDEC_SEMI :
                //<Field Dec> ::= <Header> <Type> <Variable Decs> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_METHODDEC_LPAREN_RPAREN :
                //<Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT :
                //<Formal Param List Opt> ::= <Formal Param List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT2 :
                //<Formal Param List Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST :
                //<Formal Param List> ::= <Formal Param>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST_COMMA :
                //<Formal Param List> ::= <Formal Param List> ',' <Formal Param>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> <Type> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_REF_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> ref <Type> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_OUT_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> out <Type> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_PARAMS_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> params <Type> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROPERTYDEC_LBRACE_RBRACE :
                //<Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET_SET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET_GET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_SEMI :
                //<Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_LBRACE_RBRACE :
                //<Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD :
                //<Event Accessor Decs> ::= add <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD_REMOVE :
                //<Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE :
                //<Event Accessor Decs> ::= remove <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE_ADD :
                //<Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC :
                //<Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC2 :
                //<Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_COMMA_IDENTIFIER_RPAREN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUS :
                //<Overload Op> ::= '+'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUS :
                //<Overload Op> ::= '-'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAM :
                //<Overload Op> ::= '!'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TILDE :
                //<Overload Op> ::= '~'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUSPLUS :
                //<Overload Op> ::= '++'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUSMINUS :
                //<Overload Op> ::= '--'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TRUE :
                //<Overload Op> ::= true
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_FALSE :
                //<Overload Op> ::= false
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TIMES :
                //<Overload Op> ::= '*'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_DIV :
                //<Overload Op> ::= '/'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PERCENT :
                //<Overload Op> ::= '%'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_AMP :
                //<Overload Op> ::= '&'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PIPE :
                //<Overload Op> ::= '|'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_CARET :
                //<Overload Op> ::= '^'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTLT :
                //<Overload Op> ::= '<<'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTGT :
                //<Overload Op> ::= '>>'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EQEQ :
                //<Overload Op> ::= '=='
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAMEQ :
                //<Overload Op> ::= '!='
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GT :
                //<Overload Op> ::= '>'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LT :
                //<Overload Op> ::= '<'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTEQ :
                //<Overload Op> ::= '>='
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTEQ :
                //<Overload Op> ::= '<='
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDEC :
                //<Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPAREN_RPAREN :
                //<Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT :
                //<Constructor Init Opt> ::= <Constructor Init>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT2 :
                //<Constructor Init Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_BASE_LPAREN_RPAREN :
                //<Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_THIS_LPAREN_RPAREN :
                //<Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPAREN_RPAREN :
                //<Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE :
                //<Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt> ::= <Array Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT2 :
                //<Array Initializer Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt> ::= <Variable Initializer List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT2 :
                //<Variable Initializer List Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List> ::= <Variable Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST_COMMA :
                //<Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT_COLON :
                //<Interface Base Opt> ::= ':' <Class Base List>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT :
                //<Interface Base Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT2 :
                //<Interface Item Decs Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC :
                //<Interface Item Dec> ::= <Interface Method Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC2 :
                //<Interface Item Dec> ::= <Interface Property Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC3 :
                //<Interface Item Dec> ::= <Interface Event Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC4 :
                //<Interface Item Dec> ::= <Interface Indexer Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEMETHODDEC_IDENTIFIER_LPAREN_RPAREN :
                //<Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NEWOPT_NEW :
                //<New Opt> ::= new
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NEWOPT :
                //<New Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER :
                //<Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_SEMI :
                //<Interface Empty Body> ::= ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE :
                //<Interface Empty Body> ::= '{' '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMDECL_ENUM_IDENTIFIER :
                //<Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT_COLON :
                //<Enum Base Opt> ::= ':' <Integral Type>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT :
                //<Enum Base Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs Opt> '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_COMMA_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs> ',' '}'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt> ::= <Enum Item Decs>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT2 :
                //<Enum Item Decs Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS :
                //<Enum Item Decs> ::= <Enum Item Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS_COMMA :
                //<Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER_EQ :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPAREN_RPAREN_SEMI :
                //<Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT :
                //<Attrib Opt> ::= <Attrib Opt> <Attrib Section>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT2 :
                //<Attrib Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON :
                //<Attrib Target Spec Opt> ::= assembly ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_FIELD_COLON :
                //<Attrib Target Spec Opt> ::= field ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_EVENT_COLON :
                //<Attrib Target Spec Opt> ::= event ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_METHOD_COLON :
                //<Attrib Target Spec Opt> ::= method ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_MODULE_COLON :
                //<Attrib Target Spec Opt> ::= module ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PARAM_COLON :
                //<Attrib Target Spec Opt> ::= param ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON :
                //<Attrib Target Spec Opt> ::= property ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_RETURN_COLON :
                //<Attrib Target Spec Opt> ::= return ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_TYPE_COLON :
                //<Attrib Target Spec Opt> ::= type ':'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST :
                //<Attrib List> ::= <Attribute>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST_COMMA :
                //<Attrib List> ::= <Attrib List> ',' <Attribute>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPAREN_RPAREN :
                //<Attribute> ::= <Qualified ID> '(' <Expression List> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPAREN_RPAREN2 :
                //<Attribute> ::= <Qualified ID> '(' ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE :
                //<Attribute> ::= <Qualified ID>
                //todo: Perhaps create an object in the AST.
                return null;

                default:
                    throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }
            
        }

    }
    
}
