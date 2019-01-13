using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class RoomNameDisplay : MonoBehaviour {

		public PortalCameraManager cameraManager;
		private Transform _location;

		// Use this for initialization
		void Start () {
			_location = cameraManager.FindPlayer();
			Debug.Log(_location);
			UpdateText();
			
		}
		
		// Update is called once per frame
		void Update () {
			_location = cameraManager.FindPlayer();
			UpdateText();
		}

		private void UpdateText()
		{
			if(_location != null && _location.gameObject.GetComponent<RoomBehaviour>() != null)
			{
				this.gameObject.GetComponent<Text>().text = "Current Class: " + _location.gameObject.name;
			}
		}
	}
}
