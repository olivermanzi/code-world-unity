using System;

namespace Project{
    [Serializable]
    public class ClassObject
    {
        public string name;
        public NPCObject[] attributes;
        public Method[] methods;
        public string[] interfaces;
        public string[] subclasses;
        public string superclass;
        public string[] associations;
        public string[] components;

        [Serializable]
        public class Method
        {
            public string name;
            public string returnType;
        }
    }    
}
