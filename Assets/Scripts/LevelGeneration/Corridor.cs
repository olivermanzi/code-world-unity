using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour {

    public string IsExtensionOf { get; set; }
    public string[] Connections { get; set; }

    private List<GameObject> _doors;

    public void SetupConnections()
    {
        InitializeDoors();
        foreach (var item in Connections)
        {
            Connect(GetNextEmptyDoor(), item);
        }
    }

    private void InitializeDoors()
    {
        _doors = new List<GameObject>();
        var portals = transform.GetComponentsInChildren<Portal>();
        foreach (var item in portals)
        {
            if(item.receiver == null)
            {
                GameObject gate = item.transform.parent.gameObject;
                _doors.Add(gate);
            }
        }
    }

    private GameObject GetNextEmptyDoor()
    {
        var door = _doors.Find(x => _doors.IndexOf(x) == _doors.Count - 1);
        _doors.Remove(door);
        return door;
    }

    private void Connect(GameObject door, string name)
    {
        Transform destination = GameObject.Find(name).transform;
        door.GetComponentInChildren<Portal>().receiver = destination.GetComponent<RoomBehaviour>().BackTeleporter.transform;
        door.GetComponentInChildren<Portal>().destination = name;
        destination.Find("PortalCamera").GetComponent<PortalCamera>().OtherPortal = door.transform.Find("Portal").GetComponent<MeshRenderer>().transform;
    }
}