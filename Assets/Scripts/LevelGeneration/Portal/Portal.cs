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
	private float _teleportTimer = 0.0f;
    private bool isBackwardPortal = false;

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		attachedCamera = transform.parent.parent.parent.Find("PortalCamera").transform;
        portalCameraManager = GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>();
        isBackwardPortal = transform.parent.parent.CompareTag("BackDoorEntry") ? true : false;
        if (isBackwardPortal)
        {
            gameObject.AddComponent<BackwardPortal>();
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
        var history = player.GetComponent<PortalHistory>();
        Transform destination = null;
        if (isBackwardPortal)
        {
            //Get the portal we're supposed to TP to and remove it from history
            destination = GetComponent<BackwardPortal>().attachedCamera;
            receiver = history.GetLastPortalEntered().transform;
        }
        else
        {
            destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
        }
        Vector3 destinationRot = destination.transform.rotation.eulerAngles;
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.parent.Find("Portal").up, portalToPlayer);
		//If Player entered portal through front
		if (dotProduct < 1f) {
            player.transform.forward = destination.forward;
            player.transform.up = destination.up;

            player.transform.position = destination.position;
			
            player.GetComponent<FirstPersonController>().RotateTowards(destinationRot);

            //Make sure I'm not adding to history when I'm going backwards
            if (!isBackwardPortal)
            {
                history.History.Add(gameObject);
            }

            //Set portalCamera to function as playerCamera for the room left, so perspective is not broken looking backwards
            portalCameraManager.CycleCameras();

        }
    }
}