﻿using System;

namespace Project{
    [Serializable]
    public class ClassObject
    {
        public string name;
        public NPCObject[] attributes;
        public MethodObject[] methods;
        public string[] subclasses;
        public string superclass;
        public string[] associations;

        [Serializable]
        public class Method
        {
            public string name;
            public string returnType;
        }
    }    
}
