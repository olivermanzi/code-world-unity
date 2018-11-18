using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser
{
    public ClassObject[] Parse(string json) => JsonHelper.FromJson<ClassObject>(json);
}
