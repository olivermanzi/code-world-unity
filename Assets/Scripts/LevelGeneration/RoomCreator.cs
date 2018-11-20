using UnityEngine;
using System.Collections;

public class RoomCreator : ScriptableObject
{
    public Room CreateRoom(ClassObject classObject)
    {
        return GetRoom(classObject);
    }

    //Determine room prefab
    private Room GetRoom(ClassObject classObject)
    {
        int rels = GameObjectCreator.CountRels(classObject);

        //Path to prefab file
        string path = "Prefabs/Environment/" + (rels > 4 ? 4 : rels) + "DoorRoom";

        return new Room(classObject,Resources.Load<GameObject>(path));
    }
}
