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
                Debug.Log(targetEntry.transform.parent.transform.rotation);
                platform.transform.Rotate(targetEntry.transform.parent.position);
                platform.transform.position = targetEntry.transform.position + v1;
            }
            else
            {
                //If associated room already exists connect to its open bridge
                //Algorith to connec to existing bridge
            }
        }
    }

   
}