using System;
using System.Collections;
using System.Runtime.Serialization;

namespace ServiceContract
{
    [Serializable]
    public class MyISerClass : ISerializable
    {
        static readonly string Value = "hello";
        public MyISerClass() { }

        public MyISerClass(SerializationInfo info, StreamingContext context)
        {
            string s = info.GetString("SomeKey");
            if (s == null || s.Equals(Value) == false)
            {
                throw new Exception("MyISer1: Got bad value = " + s);
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SomeKey", Value);
        }
    }

    [Serializable]
    public struct MyISerStruct : ISerializable
    {
        static readonly string Value = "hello";

        public MyISerStruct(SerializationInfo info, StreamingContext context)
        {
            string s = info.GetString("SomeKey");
            if (s == null || s.Equals(Value) == false)
            {
                throw new Exception("MyISer1: Got bad value = " + s);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SomeKey", Value);
        }
    }

    [Serializable]
    public class MyISerClassFromClass : MyISerClass, ISerializable
    {
        static readonly string Value = "there";
        public MyISerClassFromClass() { }

        public MyISerClassFromClass(SerializationInfo info, StreamingContext context)
        {
            string s = info.GetString("SomeKey");
            if (s == null || s.Equals(Value) == false)
            {
                throw new Exception("MyISer1: Got bad value = " + s);
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SomeKey", Value);
        }
    }

    [Serializable]
    public class BaseSerializable
    {

    }

    [Serializable]
    public class MyISerClassFromSerializable : BaseSerializable, ISerializable
    {
        static readonly string Value = "there";
        public MyISerClassFromSerializable() { }

        public MyISerClassFromSerializable(SerializationInfo info, StreamingContext context)
        {
            string s = info.GetString("SomeKey");
            if (s == null || s.Equals(Value) == false)
            {
                throw new Exception("MyISer1: Got bad value = " + s);
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SomeKey", Value);
        }
    }

    [Serializable]
    public class ArrayHolder
    {
        public ArrayHolder()
        {
            this.o = new object[] { "hello", (object)9, new H() };
        }
        object[] o;
    }

    [Serializable]
    public class ArrayListHolder
    {
        public ArrayListHolder()
        {
            this.o = new ArrayList(new object[] { "hello", (object)9, new H() });
        }
        ArrayList o;
    }

    [DataContract(Name = "HP")]
    public class H
    {
        [DataMember]
        private int i = 99;
    }

    [Serializable]
    public class BoxedStructHolder
    {
        object o = (object)9;
        object o2 = (object)new mYStruct();
        ICloneable clone = (ICloneable)new mYStruct();
    }

    [DataContract]
    public struct mYStruct : ICloneable
    {
        [DataMember]
        private int i;

        public object Clone()
        {
            // TODO:  Add mYStruct.Clone implementation
            return null;
        }
    }
}