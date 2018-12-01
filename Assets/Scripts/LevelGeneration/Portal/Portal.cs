using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform receiver;

	private Transform player;
	private bool isOverlapping = false;

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () 
	{
        if (isOverlapping == true && receiver != null)
        {
			TeleportPlayer ();
			isOverlapping = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            isOverlapping = true;
        }
    }

	private void TeleportPlayer()
	{
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.parent.Find("Portal").up, portalToPlayer);
		//If Player entered portal through front
		if (dotProduct < 1f) {
			var destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
			var direction = destination.transform.InverseTransformDirection(Vector3.forward);
			player.LookAt (direction);
			Debug.Log (player.rotation.eulerAngles);
			player.transform.position = destination.position;
		}
	}
}