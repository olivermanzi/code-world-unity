using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Corridor : MonoBehaviour {

    public string IsExtensionOf { get; set; }
    public string[] Connections { get; set; }

    private List<Transform> _doors;
    private List<Transform> _openDoors;

    public void SetupConnections()
    {
        InitializeDoors();
        foreach (var item in Connections)
        {
            Debug.Log("hue");
            Connect(GetNextEmptyDoor(), FindDestination(item));
        }
    }

    private void InitializeDoors()
    {
        _doors = new List<Transform>();
        _openDoors = new List<Transform>();
        var portalTps = transform.GetComponentsInChildren<Portal>();
        foreach (var item in portalTps)
        {
           _doors.Add(item.transform.parent);
           _openDoors.Add(item.transform.parent);
        }
    }

    private Transform GetNextEmptyDoor()
    {
        //
        var last = _openDoors.ElementAt(_openDoors.Count-1);
        _openDoors.Remove(last);
        return last;
    }

    private void Connect(Transform door, Transform destination)
    {
        var destRoom = destination.GetComponent<RoomBehaviour>();
        door.GetComponentInChildren<Portal>().receiver = destRoom.BackTeleporter;
        destRoom.GetComponentInChildren<PortalCamera>().OtherPortal = door.Find("Portal");
        Debug.Log("asd");
    }

    private Transform FindDestination(string destination)
    {
        var dest = GameObject.Find(destination).transform;
        return dest;
    }
}