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
            Transform destination = FindDestination(item);
            Connect(GetNextEmptyDoor(), destination);
        }
    }

    private Transform FindDestination(string item)
    {
        return GameObject.Find(item).GetComponent<RoomBehaviour>().BackTeleporter.transform;
    }

    private void InitializeDoors()
    {
        var portals = transform.GetComponentsInChildren<Portal>();
        foreach (var item in portals)
        {
            GameObject gate = item.gameObject.transform.parent.gameObject;
            _doors.Add(gate);
        }
    }

    private GameObject GetNextEmptyDoor()
    {
        var door = _doors.Find(x => _doors.IndexOf(x) == _doors.Count - 1);
        _doors.Remove(door);
        return door;
    }

    private void Connect(GameObject door, Transform destination)
    {
        door.GetComponentInChildren<Portal>().receiver = destination;
    }
}