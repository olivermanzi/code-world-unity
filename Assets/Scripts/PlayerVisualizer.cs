using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class PlayerVisualizer : MonoBehaviour {

		public GameObject player;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			playerPositionHandler();
		}
		/// <summary>
		/// Draws player position on the birds eye view
		/// </summary>
		public void playerPositionHandler()
		{
			Vector3 pos = Camera.main.WorldToScreenPoint(player.transform.position);
			this.transform.position = pos;
		}
		
	}
}

