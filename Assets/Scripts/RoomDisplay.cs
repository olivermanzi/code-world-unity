using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDisplay : MonoBehaviour {

	public PortalCameraManager cameraManager;
	public GameObject player;
	private Transform playerLocation;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		foreach (var item in cameraManager.environmentObjects)
        {
			//Find which room the player is in
            if (player.transform.position.y - item.transform.position.y < 15f && player.transform.position.y - item.transform.position.y > 10f)
            {
                playerLocation = item.transform;
            }
        }
        if(playerLocation != null)
        {
            if(playerLocation.GetComponent<RoomBehaviour>() != null)
            {
                gameObject.GetComponent<Text>().text = playerLocation.name;
            }
            else if(playerLocation.GetComponent<Corridor>() != null)
            {
                gameObject.GetComponent<Text>().text = playerLocation.GetComponent<Corridor>().IsExtensionOf;
            }
        }
    }
}
