using System;

[Serializable]
public class ClassObject
{
    public string name;
    public Attribute[] attributes;
    public Method[] methods;
    public string[] interfaces;
    public string[] subclasses;
    public string superclass;
    public string[] associations;

    [Serializable]
    public class Attribute
    {
        public string name;
        public string type;
    }

    [Serializable]
    public class Method
    {
        public string name;
        public string returnType;
    }
}