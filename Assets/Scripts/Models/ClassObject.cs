using System;
using System.Collections;

[Serializable]
public class ClassObject
{
    public Hashtable Attributes{ get; set; }
    public Hashtable Methods { get; set; }
    public string[] Interfaces { get; set; }
    public string[] Subclasses { get; set; }
    public string Superclass { get; set; }
}