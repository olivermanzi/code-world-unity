using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class Portal : MonoBehaviour {

		public Transform receiver;
		public string destination;
		public Backtracker backtracker;
		private Transform player;
		private Transform attachedCamera;
		private PortalCameraManager portalCameraManager;
		private bool isOverlapping = false;
		private float _teleportTimer = 0.0f;

		private void Start()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			attachedCamera = transform.parent.parent.parent.Find("PortalCamera").transform;
			portalCameraManager = GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>();
			backtracker = GameObject.Find("Backtracker").GetComponent<Backtracker>();
		}

		// Update is called once per frame
		void Update () 
		{
			if (isOverlapping == true && receiver != null )
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
				player.transform.Rotate(0,TranslateRotation(player),0,Space.World);
				player.transform.position = destination.position;
				Debug.Log("Rotation: " + destination.rotation);
				
				//Set portalCamera to focus on door entered
				var cam = attachedCamera.GetComponent<PortalCamera>();
				cam.portal = transform.parent.Find("Portal").transform;
				cam.OtherPortal = receiver.parent.Find("Portal").transform;

				//Set portalCamera to function as playerCamera for the room left, so perspective is not broken looking backwards
				portalCameraManager.CycleCameras();
				backtracker.EnterRoom();
			}
		}

		private bool IsExitPortal()
		{
			if(this.gameObject.transform.parent.parent.gameObject.name == "DoorwayWall Back")
			{
				return true;
			}
			return false;
		}

		private float TranslateRotation(Transform player)
		{
			int rotation = (int) transform.parent.parent.rotation.y;
			int res = 0;
			switch(rotation){
				case 90:
					res=90;
					break;
				case 180:

					break;
				case 270:
					res=-90;
					break;
			}
			return player.rotation.y + res;
		}
	}
}