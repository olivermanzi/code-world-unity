using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script used to allow player interaction with objects in first person
/// Done by sending a raycast from the middle of the screen and checking for
/// interactable objects.
/// </summary>

namespace Project{
	public class ObjectInteraction : MonoBehaviour {

		StateController stateController;
		//TODO: Find better way to find the camera, this is fucking stupid since we are in the same GO
		public Camera FPCamera;
		
		/// <value>
		/// Stores the periodic check for objects in the center of the screen
		/// </value>
		Ray ray;

		/// <value>
		/// Stores positive results for a raycast
		/// </value>
		RaycastHit hit;

		/// <value>
		/// Reference for text field in HUD
		/// </value>
		public Text fpText;

		/// <value>
		/// Remembers whether an Interactable is moused over or not
		/// </value>
		private bool _mousedOver;

		// Use this for initialization
		void Start () {
			stateController = gameObject.GetComponent<StateController>();
		}
		
		// Update is called once per frame
		void Update () {
			if(stateController.GetState() == StateController.State.FirstPerson)
			{
				ray = FPCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.gameObject.tag == "Interactable") {
						fpText.text = "Press E to view info";
						_mousedOver = true;
					} else {
						fpText.text = "";
						_mousedOver = false;
					}
				} 
				else 
				{
					fpText.text = "";
					_mousedOver = false;
				}
			}
		}

		public void StartInteraction()
		{
			if(_mousedOver)
			{
				Debug.Log("Initiated interaction!");
				hit.transform.gameObject.GetComponent<IInteractable>().Interact();
			}
		}
	}
}

