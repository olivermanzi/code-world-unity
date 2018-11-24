using UnityEngine;
using UnityEditor;

public class ConnectionGenerator : ScriptableObject
{
    private GameObject _platform;

    public void OnEnable()
    {
        _platform = Resources.Load<GameObject>("Prefabs/Environment/Platform");
    }

    public void CreateConnections(Room room)
    {
        ConnectInheritence(room);
        ConnectAssociation(room);
    }

    //Connects superclasses to subclasses
    private void ConnectInheritence(Room room)
    {
        //TODO Create this
    }

    //Connects associated rooms with bridges 
    private void ConnectAssociation(Room room)
    {
        foreach (var item in room.Info.associations)
        {
            if (GameObject.Find(item) == null)
            {
                //If associated room doesn't exist, create open bridge
                var platform = Instantiate(_platform);

                //Set the rotation and position to the correct values
                var targetEntry = room.GetNextEntryPoint();
                platform.transform.rotation = targetEntry.transform.parent.rotation;
                platform.transform.position = targetEntry.transform.position;

                //Push the platform "outwards" so that its startpoint and the target position align
                Vector3 v1 = platform.transform.position - platform.transform.Find("Startpoint").position;
                platform.transform.position += v1;
            }
            else
            {
                //If associated room already exists connect to its open bridge
                //Algorith to connec to existing bridge
            }
        }
    }
}