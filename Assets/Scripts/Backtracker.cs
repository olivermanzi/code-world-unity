using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class Backtracker : MonoBehaviour {

		public LevelCreator levelCreator;
		public PortalCameraManager cameraManager;
		public GameObject[] environment;
		public GameObject player;
		private Stack<GameObject> _visited = new Stack<GameObject>();
		// Use this for initialization
		void Start () {
			player = GameObject.FindGameObjectWithTag("Player");
			//environment = cameraManager.environmentObjects;
		}

		public GameObject FindPlayerLocation()
		{
			Transform playerLocation = null;
			foreach (var item in cameraManager.environmentObjects)
			{
				//Find which room the player is in
				if (player.transform.position.y - item.transform.position.y < 15f && player.transform.position.y - item.transform.position.y > 10f)
				{
					playerLocation = item.transform;
				}
			}
			Debug.Log("Backtracker - Room name: " + playerLocation.gameObject.name);
			return playerLocation.gameObject;
		}

		public void EnterRoom()
		{
			if(_visited.Count > 1)
			{
				if(FindPlayerLocation().name == _visited.Peek().name)
				{
					_visited.Pop();
				}
			}
			_visited.Push(FindPlayerLocation());
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
