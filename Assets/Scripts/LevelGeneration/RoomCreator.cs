using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreator : ScriptableObject
{
    private Vector3 NextItemPosition
    {
        get
        {
            var pos = _nextItemPosition;
            _nextItemPosition += _offset;
            return pos;
        }
    }

    private GameObject _corridor;
    private string _room;
    private Vector3 _nextItemPosition = new Vector3(0, 0, 0);
    private Vector3 _offset = new Vector3(0, 0, 150);

    private List<GameObject> items; 

    public void OnEnable()
    {
        _corridor = Resources.Load<GameObject>("Prefabs/Environment/Corridor");
        items = new List<GameObject>();
    }

    public List<GameObject> CreateRoomAndExtensions(ClassObject classObject)
    {
        var room = GetRoom(classObject);
        var newRoom = InstantiateEnvironmentItem(room.RoomGO);
        
        newRoom.gameObject.name = room.Info.name;
        newRoom.AddComponent<RoomBehaviour>();
        CreateExtensions(room, newRoom);
        return items;
    }

    //Determine room prefab
    private Room GetRoom(ClassObject classObject)
    {
        int rels = GameObjectCreator.CountRels(classObject);

        //Path to prefab file
        string _room = "Prefabs/Environment/" + (rels > 4 ? 4 : rels) + "DoorRoom";

        return new Room(classObject,Resources.Load<GameObject>(_room));       
    }

    private void CreateExtensions(Room room, GameObject newRoom)
    {
        var classObject = room.Info;
        if (classObject.associations.Length > 0) { CreateAssociationsCorridor(room, newRoom); }
        if (classObject.components.Length > 0) { CreateComponentsCorridor(room, newRoom); }
        if (classObject.subclasses.Length > 0 || !String.IsNullOrEmpty(classObject.superclass)) { CreateInheritenceStairs(room, newRoom); }
    }

    private void CreateAssociationsCorridor(Room room, GameObject newRoom)
    {
       var corridor = InstantiateEnvironmentItem(_corridor);
        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("BackDoorEntry"))
            {
                Debug.Log("yeet");
               var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                newRoom.GetComponent<RoomBehaviour>().AssociationsRoomTeleporter = portal;
                portal.GetComponent<Portal>().receiver = newRoom.GetComponent<RoomBehaviour>().LeftTeleporter;
            }
           
        }
        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("PortalCam"))
            {
                Debug.Log("asdadasd");

                corridor.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal = newRoom.GetComponent<RoomBehaviour>().LeftTeleporter.transform.parent.Find("Portal");
            }
        }
       
    }

    private void CreateComponentsCorridor(Room room, GameObject newRoom)
    {
        var corridor = InstantiateEnvironmentItem(_corridor);
        var roomBH = newRoom.GetComponent<RoomBehaviour>();

        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("BackDoorEntry"))
            {
                Debug.Log("yeet");
                var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                roomBH.ComponentsRoomTeleporter = portal;
                portal.GetComponent<Portal>().receiver =roomBH.RightTeleporter;
                Debug.Log(roomBH.RightTeleporter);

            }

        }
        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("PortalCam"))
            {
                corridor.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal =roomBH.RightTeleporter.transform.parent.Find("Portal").transform;
            }
        }
    }

    private void CreateInheritenceStairs(Room room, GameObject newRoom)
    {
        var corridor = InstantiateEnvironmentItem(_corridor);
        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("BackDoorEntry"))
            {
                Debug.Log("yeet");
                var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                newRoom.GetComponent<RoomBehaviour>().InheritenceRoomTeleporter = portal;
                portal.GetComponent<Portal>().receiver = newRoom.GetComponent<RoomBehaviour>().FrontTeleporter;
            }
        }
        for (int i = 0; i < corridor.transform.childCount; i++)
        {
            if (corridor.transform.GetChild(i).CompareTag("PortalCam"))
            {
                corridor.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal = newRoom.GetComponent<RoomBehaviour>().FrontTeleporter.transform.parent.Find("Portal");
            }
        }
    }

    //Centralize logic required for each addition
    private GameObject InstantiateEnvironmentItem(GameObject go)
    {
        var newGameObject = Instantiate(go);
        newGameObject.transform.position = NextItemPosition;
        items.Add(newGameObject); //what is this for? i dont remember
        return newGameObject;
    }
}