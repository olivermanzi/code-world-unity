using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project{
	/// <summary>
	/// Switches between BirdsEye and FirstPerson states
	/// Delegates behavior relevant to switching states
	/// </summary>
	public class StateController : MonoBehaviour {

		/// <value>
		/// Enumerator denoting different states
		/// </value>

		/// <value>
		/// Reference to First Person Camera gameobject
		/// Found from the player object
		/// </value>
		public GameObject FPCamera;

		/// <value>
		/// Reference to Birds Eye Camera gameobject
		/// </value>
		public GameObject BECamera;

		public enum State
		{
			BirdsEye,
			FirstPerson
		}

		// Use this for initialization
		void Start () {
			
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
				break;

				case State.FirstPerson:
				break;

				default:
				break;
			}
			FPCamera.SetActive(!FPCamera.activeSelf);
			BECamera.SetActive(!BECamera.activeSelf);
		}

		/// <summary>
		/// Function to check the camera state of the system.
		/// </summary>
		/// <returns>The current state.</returns>
		public State GetState()
		{
			if(FPCamera.activeSelf)
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

