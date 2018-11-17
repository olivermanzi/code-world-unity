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
		public StateController sController;

		/// <value>
		/// Reference to player gameobject
		/// </value>
		public GameObject player;

		/// <value>
		/// Amount of units by which the player moves per frame.
		/// Set to public so we can edit it in editor.
		/// </value>
		public float MovementFactor = 0.75f;

		Rigidbody playerRb;
		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			CameraListener();
			MovementListener();
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
		public void MovementListener(){
			if (Input.GetKey(KeyCode.W))
			{
				player.transform.position += Vector3.forward * MovementFactor ;
			}
			else if(Input.GetKey(KeyCode.A))
			{
				player.transform.position -= Vector3.right * MovementFactor ;
			}
			else if(Input.GetKey(KeyCode.S))
			{
				player.transform.position -= Vector3.forward * MovementFactor ;
			}
			else if(Input.GetKey(KeyCode.D))
			{
				player.transform.position += Vector3.right * MovementFactor ;
			}
		}
	}
}