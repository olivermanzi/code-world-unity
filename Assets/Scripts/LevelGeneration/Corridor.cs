using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour {

    public string IsExtensionOf { get; set; }
    public string[] Connections { get; set; }

    private GameObject[] _doors;

    public void SetupConnections()
    {
        InitializeDoors();
        foreach (var item in Connections)
        {

        }
    }

    private void InitializeDoors()
    {
        var portals = transform.GetComponentsInChildren<Portal>();
        Debug.Log(portals.Length);
    }

    private GameObject GetNextEmptyDoor()
    {
        //
        return new GameObject();
    }

    private void Connect(GameObject door, Transform destination)
    {

    }
}