using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour {

	public Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform);
		transform.Rotate(0, 180, 0, Space.Self);
	}
}
