using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHistory : MonoBehaviour {

    public List<GameObject> History;

	// Use this for initialization
	void Start () {
        History = new List<GameObject>();
	}

    public GameObject GetLastPortalEntered()
    {
        GameObject res = null;
        if(History.Count >= 1)
        {
            res = History[History.Count - 1];
        }
        return res;
    }

    public GameObject GetSecondToLastPortalEntered()
    {
        GameObject res = null;
        if (History.Count >= 2)
        {
            res = History[History.Count - 2];
        }
        return res;
    }

    public GameObject GetThirdToLastPortalEntered()
    {
        GameObject res = null;
        if (History.Count >= 3)
        {
            res = History[History.Count - 3];
        }
        return res;
    }

    public GameObject PopLastPortalEntered()
    {
        GameObject res = null;

        if (History.Count != 0)
        {
            res = History[History.Count - 1];
            History.RemoveAt(History.Count-1);
        }
        Debug.Log(res);
        return res;
    }

}
