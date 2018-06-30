using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.cs_like_lua
{
  public  class class_def
    {


    }

 

    /// <summary>
    /// 伪造抽象类，要伪造就继承这个
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public  class CLL_fake<T1, T2>
    {
     public   T1 x { get; set; }
    public    T2 y { get; set; }
        public CLL_fake(T1 x)
        {
            this.x = x;
        }
        public CLL_fake(T2 y)
        {
            this.y = y;
           
        }
        public static implicit operator T1(CLL_fake<T1, T2> m)
        {
            if (m == null) return default(T1);

            return m.x;
        }
        public static implicit operator T2(CLL_fake<T1, T2> m)
        {
            if (m == null) return default(T2);
            
            return m.y;
        }
       public static Dictionary<T1, CLL_fake<T1, T2>> xs = new Dictionary<T1, CLL_fake<T1, T2>>();
        public static Dictionary<T2, CLL_fake<T1, T2>> ys = new Dictionary<T2, CLL_fake<T1, T2>>();
        public static implicit operator CLL_fake<T1, T2>(T1 type)
        {
            if (xs.ContainsKey(type)) return xs[type];
            else
            {
                var ct = new CLL_fake<T1, T2>(type);
                xs[type] = ct;
                return ct;
            }
        }
        public static implicit operator CLL_fake<T1, T2>(T2 type)
        {
            if (ys.ContainsKey(type)) return ys[type];
            else
            {
                var ct = new CLL_fake<T1, T2>(type);
                ys[type] = ct;
                return ct;
            }
        }


    }

   public class CLL_Assemby:CLL_fake<string,long>
    {
        public CLL_Assemby(string a):base(a)
        {

        }
        public CLL_Assemby(long b) : base(b)
        {
        
        }
    }
    /// <summary>
    /// 伪造类型，并与原生类型通用
    /// </summary>
    public class CLL_Type
    {
        Type type;
        Spec_Type spec_Type;
        public CLL_Type(Type type) { this.type = type;       }
        public CLL_Type(Spec_Type type) { this.spec_Type = type; }
        public static implicit operator Type(CLL_Type m)
        {
            if (m == null) return null;

            return m.type;
        }
        public static implicit operator Spec_Type(CLL_Type m)
        {
            if (m == null) return null;

            return m.spec_Type;
        }
        static Dictionary<Type, CLL_Type> types = new Dictionary<Type, CLL_Type>();
        static Dictionary<Spec_Type, CLL_Type> stypes = new Dictionary<Spec_Type, CLL_Type>();


        public static implicit operator CLL_Type(Type type)
        {
            if (types.ContainsKey(type)) return types[type];
            else
            {
                var ct = new CLL_Type(type);
                types[type] = ct;
                return ct;
            }
        }
        public static implicit operator CLL_Type(Spec_Type type)
        {
            if (stypes.ContainsKey(type)) return stypes[type];
            else
            {
                var ct = new CLL_Type(type);
                stypes[type] = ct;
                return ct;
            }
        }
        //public 

    }
    /// <summary>
    /// 伪造特性，并与原生特性通用
    /// </summary>
    public class CLL_Attr//伪特性:Attribute
    {

        public CLL_Attr(Attribute attribute)
        {
            this.attribute = attribute;
        }
        public CLL_Attr(Attr attr)
        {
            this.attr = attr;
        }
       public abstract class Attr
        {
            public Dictionary<string, Value> valuePairs = new Dictionary<string, Value>();
          public Value GetValue(string name)
            {
                valuePairs.TryGetValue(name, out var value);
                return value;
            }
            public Attr(Dictionary<string,Value> v) { valuePairs = v; }
        }


        Attr attr;
        Attribute attribute;

        public static implicit operator Attribute(CLL_Attr m)
        {
            if (m == null) return null;

            return m.attribute;
        }
        public static implicit operator Attr(CLL_Attr m)
        {
            if (m == null) return null;

            return m.attr;
        }
        static Dictionary<Attribute, CLL_Attr> attrs = new Dictionary<Attribute, CLL_Attr>();
        static Dictionary<Attr, CLL_Attr> attrs2 = new Dictionary<Attr, CLL_Attr>();

        public static implicit operator CLL_Attr(Attribute type)
        {
            if (attrs.ContainsKey(type)) return attrs[type];
            else
            {
                var ct = new CLL_Attr(type);
                attrs.Add(type,ct);
                return ct;
            }
        }
        public static implicit operator CLL_Attr(Attr type)
        {
            if (attrs2.ContainsKey(type)) return attrs2[type];
            else
            {
                var ct = new CLL_Attr(type);
                attrs2.Add(type,ct);
                return ct;
            }
        }
        public override string ToString()
        {
            if (attribute != null) return attribute.ToString();
            return attr.ToString();
        }

    }
    public class Spec_Type
    {
        public enum Access
        {

            @private,
            @public,
            @protected,
            @internal
        }


        public CLL_Type BaseType { get; private set; }
        public CLL_Type DeclaringType { get; private set; }
        public void SetBaseType(CLL_Type type)
        {

            BaseType = type;
        }
        /// <summary>
        /// 类上属性
        /// </summary>
        public IEnumerable<CLL_Attr> CustomAttributes { get; private set; }


        public string Namespace { get; private set; }
        public string Name { get; private set; }
        public string FullName { get { return Namespace + "." + Name; } }
        public void Get()
        {
         
         //.GetInterfaces
        }
        public Dictionary<string, System.Reflection.MemberInfo> methods;


    }
}
