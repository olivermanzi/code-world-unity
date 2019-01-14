using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes sure the text above actors faces the player
/// </summary>
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
