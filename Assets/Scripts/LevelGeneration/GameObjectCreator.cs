using UnityEngine;

public class GameObjectCreator : ScriptableObject
{
    private RoomCreator _roomCreator;
    private ConnectionGenerator _connectionGenerator;

    public GameObjectCreator()
    {
        _roomCreator = ScriptableObject.CreateInstance("RoomCreator") as RoomCreator;
        _connectionGenerator = ScriptableObject.CreateInstance("ConnectionGenerator") as ConnectionGenerator ;
    }

    public void Compose (ClassObject classObject)
    {
        Room room = _roomCreator.CreateRoom(classObject);
        _connectionGenerator.CreateConnections(room);

        Instantiate(room.RoomGO);
    }

    //Count number of relationships a class has
    public static int CountRels(ClassObject classObject)
    {
        int res = 0;

        foreach (string sc in classObject.subclasses) { res++; }
        foreach (string assoc in classObject.associations) { res++; }
        if (!string.IsNullOrEmpty(classObject.superclass)) { res++; }
        return res;
    }
}