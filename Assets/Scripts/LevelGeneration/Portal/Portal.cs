using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform receiver;
    public string destination;

	private Transform player;
	private Transform attachedCamera;
    private PortalCameraManager portalCameraManager;
	private bool isOverlapping = false;

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		attachedCamera = transform.parent.parent.parent.Find("PortalCamera").transform;
        portalCameraManager = GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>();
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
		var destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.parent.Find("Portal").up, portalToPlayer);
		//If Player entered portal through front
		if (dotProduct < 1f) {
			player.transform.rotation = destination.rotation;
			player.transform.position = destination.position;
			 
			//Set portalCamera to focus on door entered
			var cam = attachedCamera.GetComponent<PortalCamera>();
			cam.portal = transform.parent.Find("Portal").transform;
			cam.OtherPortal = receiver.parent.Find("Portal").transform;

            //Set portalCamera to function as playerCamera for the room left, so perspective is not broken looking backwards
            portalCameraManager.CycleCameras();
		}
	}
}