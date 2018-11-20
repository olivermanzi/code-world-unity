using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master script for handling user input.
/// For now, handles user movement and switching cameras.
/// </summary>
namespace Project{
	public class ControlHandler : MonoBehaviour {
	
		/// <value>
		/// Reference to state controller for switching perspective
		/// </value>
		private StateController sController;

		/// <value>
		/// Reference to player gameobject
		/// </value>
		private GameObject player;

		/// <value>
		/// Amount of units by which the player moves per frame.
		/// Set to public so we can edit it in editor.
		/// </value>
		public float MovementFactor = 0.75f;

		Rigidbody playerRb;
		// Use this for initialization
		void Start () {
            player = this.gameObject;
            sController = this.gameObject.GetComponent<StateController>();
		}
		
		// Update is called once per frame
		void Update () {
			CameraListener();
			InteractionListener();
		}

		/// <summary>
		/// Listens whether the M key is pressed and switches the two cameras' active state around if it is.
		/// e.g. If FP.active == true and BE.active == false, it changes the respective values to false and true.
		/// This switches which camera is active for the user.
		/// </summary>
		public void CameraListener(){
			if (Input.GetKeyDown(KeyCode.M)){
				switch (sController.GetState()){
					case StateController.State.FirstPerson:
					sController.ChangeState(StateController.State.BirdsEye);
					break;
					case StateController.State.BirdsEye:
					sController.ChangeState(StateController.State.FirstPerson);
					break;
				}
			}
		}

		/// <summary>
		/// Listens for movement input and moves the player accordingly
		/// </summary>
		public void InteractionListener(){
			if(Input.GetKeyDown(KeyCode.E))
			{
				gameObject.GetComponent<ObjectInteraction>().StartInteraction();
			}
		}
	}
}