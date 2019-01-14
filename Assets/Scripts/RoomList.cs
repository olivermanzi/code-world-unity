using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class RoomList : MonoBehaviour {

		public PortalCameraManager cameraManager;
		public Transform player;
		private List<string> _rooms;
		// Use this for initialization
		void Start () {
			_rooms = new List<string>();
			foreach(GameObject item in cameraManager.environmentObjects)
			{
				if(item.gameObject.GetComponent<RoomBehaviour>() != null )
				{
					_rooms.Add(item.name);
				}
			}

			this.gameObject.GetComponent<Dropdown>().AddOptions(_rooms);
		}

		public void FastTravel()
		{
			string roomName = this.gameObject.GetComponent<Dropdown>().captionText.text;
			Transform destination = GameObject.Find(roomName).transform;
			Transform current = FindPlayerLocation();

			Vector3 portalToPlayer = player.position - current.transform.position;
			player.transform.forward = destination.forward;
			player.transform.up = destination.up;

			player.transform.position = destination.position + new Vector3 (20, 11, 0);

			cameraManager.CycleCameras();
			current.Find("DoorwayWall Back/Doorway/PortalTeleporter").GetComponent<Portal>().CloseGate();
            destination.Find("DoorwayWall Back/Doorway/PortalTeleporter").GetComponent<Portal>().CloseGate();
        }

		public Transform FindPlayerLocation()
		{
			Transform playerLocation = null;
			foreach (GameObject item in cameraManager.environmentObjects)
			{
				//Find which room the player is in
				if (player.transform.position.y - item.transform.position.y < 15f && player.transform.position.y - item.transform.position.y > 10f)
				{
					playerLocation = item.transform;
					return playerLocation;
				}
			}
			return playerLocation;
		}
	}
}