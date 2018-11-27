using UnityEngine;
using System.Collections.Generic;

public class ConnectionGenerator : ScriptableObject
{
    public void CreateConnections(List<GameObject> items)
    {
        items.ForEach( i =>
        {
            
        });
    }

    //Connects superclasses to subclasses
    private void ConnectInheritence(Room room)
    {
        //TODO Create this
    }

    //Connects associated rooms with bridges 
    private void ConnectAssociation(Room room)
    {
        
    }
}