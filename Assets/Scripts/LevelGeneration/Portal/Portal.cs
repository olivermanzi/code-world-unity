using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform receiver;
    public string destinationString;
    public Transform destination;
	private Transform player;
	private Transform attachedCamera;
    private PortalCameraManager portalCameraManager;
    private Transform _wallBelow;
	private bool isOverlapping = false;
	private float _teleportTimer = 0.0f;    

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		attachedCamera = transform.parent.parent.parent.Find("PortalCamera").transform;
        portalCameraManager = GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>();
        _wallBelow = this.transform.parent.parent.Find("WallBelow");
        _wallBelow.gameObject.SetActive(false);
        if(receiver != null)
        {
            destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
        }
        if(destination == null)
        {
            CloseGate();
        }
    }

    // Update is called once per frame
    void Update () 
	{
        if (isOverlapping == true && receiver != null )
        {
            player.GetComponent<FirstPersonController>().isTeleporting = true;
			TeleportPlayer ();
			isOverlapping = false;
            player.GetComponent<FirstPersonController>().isTeleporting = false;

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
        Vector3 destinationRot = destination.transform.rotation.eulerAngles;
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.parent.Find("Portal").up, portalToPlayer);
		//If Player entered portal through front
		if (dotProduct < 1f) {
            player.transform.forward = destination.forward;
            player.transform.up = destination.up;

            player.transform.position = destination.position;
			//Set portalCamera to focus on door entered
			var cam = attachedCamera.GetComponent<PortalCamera>();
			cam.portal = transform.parent.Find("Portal").transform;
			cam.OtherPortal = receiver.parent.Find("Portal").transform;
            player.GetComponent<FirstPersonController>().RotateTowards(destinationRot);

            //Set portalCamera to function as playerCamera for the room left, so perspective is not broken looking backwards
            portalCameraManager.CycleCameras();

        }
    }

    public void CloseGate()
    {
        Transform doorway = this.transform.parent.parent;
        _wallBelow.gameObject.SetActive(true);
        doorway.Find("WallAbove/Text").gameObject.SetActive(false);
    }
}