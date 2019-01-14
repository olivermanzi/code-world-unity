using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// Deletes json file after application exits
/// </summary>
public class FileDeleter : MonoBehaviour {

	
	// Use this for initialization
	string path = "/Resources/Project.json";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnApplicationQuit()
	{
		if(File.Exists(path))
		{
			File.Delete(path);
		}
	}
}
