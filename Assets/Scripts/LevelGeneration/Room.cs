using UnityEngine;

public class Room
{
    public ClassObject Info { get; private set; }
    public GameObject RoomGO { get; private set; }
    private int _doorsNum;
    private int _entryCounter;

    public Room(ClassObject classObject, GameObject roomGO)
    {
        this._entryCounter = 0;
        this.RoomGO = roomGO;
        this.Info= classObject;

        this.RoomGO.transform.position = new Vector3(0,0,0);
        this.RoomGO.name = Info.name;
        int rels = GameObjectCreator.CountRels(classObject);
        _doorsNum = rels > 4 ? 4 : rels;
    }

    public GameObject GetNextEntryPoint()
    {
        string targetTag = "DoorEntry";

        switch (_entryCounter)
        {
            case 0:
                targetTag = "Front" + targetTag;
                break;
            case 1:
                targetTag = "Left" + targetTag;
                break;
            case 2:
                targetTag = "Back" + targetTag;
                break;
            case 3:
                targetTag = "Right" + targetTag;
                break;
        }

        if (/*morethanthat*/false)
        {
            //do smth
        }
        
        for (int i = 0; i < RoomGO.transform.childCount; i++)
        {
            var child = RoomGO.transform.GetChild(i);
            //If child is a doorway
            if (child.childCount > 0)
            {
                for (int j = 0; j < child.childCount; j++)
                {
                    if (child.GetChild(j).tag.Equals(targetTag))
                    {
                        return child.GetChild(j).gameObject;
                    }
                }
            }
        }
        return new GameObject();
    }
}