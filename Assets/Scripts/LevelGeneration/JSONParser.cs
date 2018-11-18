using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser
{
    public ClassObject[] Parse(string json) => FromJson(json);

    private ClassObject[] FromJson(string json)
    {
        Wrapper<ClassObject> wrapper = JsonUtility.FromJson<Wrapper<ClassObject>>(json);
        return wrapper.data;
    }

    private class Wrapper<ClassObject>
    {
        public ClassObject[] data;
    }
}
