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
                var targetEntry = room.GetNextEntryPoint();

                Vector3 v1 = platform.transform.position - platform.transform.Find("Startpoint").position;
                platform.transform.rotation = Quaternion.FromToRotation(v1, targetEntry) * platform.transform.rotation;
                platform.transform.position = targetEntry + targetEntry.normalized * v1.magnitude;
            }
            else
            {
                //If associated room already exists connect to its open bridge
                //Algorith to connec to existing bridge
            }
        }
    }

   
}