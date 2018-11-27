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
    private Vector3 _offset = new Vector3(0, 0, 100);

    private List<GameObject> items; 

    public void OnEnable()
    {
        _corridor = Resources.Load<GameObject>("Prefabs/Environment/Corridor");
        items = new List<GameObject>();
    }

    public List<GameObject> CreateRoomAndExtensions(ClassObject classObject)
    {
        var room = GetRoom(classObject);
        var newRoom = Instantiate(room.RoomGO);
        newRoom.gameObject.name = room.Info.name;
        //CreateExtensions(classObject);
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

    private void CreateExtensions(ClassObject classObject)
    {
        if (classObject.associations.Length > 0) { CreateAssociationsCorridor(); }
        if (classObject.components.Length > 0) { CreateComponentsCorridor(); }
        if (classObject.subclasses.Length > 0 || !String.IsNullOrEmpty(classObject.superclass)) { CreateInheritenceStairs(); }
    }

    private void CreateAssociationsCorridor()
    {
        InstantiateEnvironmentItem(_corridor);
    }

    private GameObject CreateComponentsCorridor()
    {
        Debug.Log("CreateComponentsCorridor");
        return null;
    }

    private GameObject CreateInheritenceStairs()
    {
        Debug.Log("CreateInheritenceStairs");
        return null;
    }

    //Centralize logic required for each addition
    private void InstantiateEnvironmentItem(GameObject go)
    {
        var newGameObject = Instantiate(go);
        newGameObject.transform.position = NextItemPosition;
        items.Add(newGameObject);
    }
}