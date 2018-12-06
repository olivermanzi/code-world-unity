using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the text of the TextMesh hovering above the Class gameobject
/// </summary>
public class NameSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetName(string name)
	{
		GameObject nameObject = this.transform.Find("Name").gameObject;
		nameObject.GetComponent<TextMesh>().text = name;
	}
}
