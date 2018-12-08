using UnityEngine;
using System.Collections.Generic;

namespace Project{
    public class ConnectionGenerator : ScriptableObject
    {
        public void CreateConnections(List<GameObject> items)
        {
            items.ForEach( i =>
            {
                var item = i.GetComponent<Corridor>();
                //Check if item is corridor
                if (item != null)
                {
                    //TODO Connect its doors to the associations specified in their attached script
                }
            });
        }
    }
}