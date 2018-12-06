using System;
using UnityEngine;

public class JSONParser
{
    public T[] Parse<T>(string json)
    {
        return FromJson<T>(json);
    }

    public string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>{data = array};
        return JsonUtility.ToJson(wrapper, true);
    }

    private T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.data;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] data;
    }
}