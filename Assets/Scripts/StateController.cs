using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project{
	/// <summary>
	/// Switches between BirdsEye and FirstPerson states
	/// Delegates behavior relevant to switching states
	/// </summary>
	public class StateController : MonoBehaviour {


		/// <value>
		/// Reference to First Person Camera gameobject
		/// Found from the player object
		/// </value>
		private GameObject _FPCamera;

		//Reference to birdsEye camera
		public GameObject BECamera;

		/// References to UI canvases
		public GameObject firstPersonUI;
		public GameObject birdsEyeUI;

		/// Reference to image that represents the player in the BirdsEyeView
		public Image birdsEyeSprite;


		/// <value>
		/// Enumerator denoting different states
		/// </value>

		public enum State
		{
			BirdsEye,
			FirstPerson
		}

		// Use this for initialization
		void Start () {
            _FPCamera = gameObject.transform.GetChild(0).gameObject;
		}
		
		// Update is called once per frame
		void Update () {
		}

		/// <summary>
		/// Changes state and initiates relevant behavior
		/// </summary>
		/// <param name="state"> State to change to</param>
		public void ChangeState(State state)
		{
			switch(state)
			{
				//TODO: Future behavior that will depend on changed states
				case State.BirdsEye:
					firstPersonUI.SetActive(false);
					birdsEyeUI.SetActive(true);
				break;

				case State.FirstPerson:
					firstPersonUI.SetActive(true);
					birdsEyeUI.SetActive(false);
				break;

				default:
				break;
			}
			_FPCamera.SetActive(!_FPCamera.activeSelf);
			BECamera.SetActive(!BECamera.activeSelf);
		}

		/// <summary>
		/// Function to check the camera state of the system.
		/// </summary>
		/// <returns>The current state.</returns>
		public State GetState()
		{
			if(_FPCamera.activeSelf)
			{
				return State.FirstPerson;
			}

			else if(BECamera.activeSelf)
			{
				return State.BirdsEye;
			}
			else
			{
				Debug.LogWarning("StateController: No cameras active. What the fuck? Defaulting to FirstPerson");
				return State.FirstPerson;	
			}
		}

	}
}

