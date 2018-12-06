using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An example of an interactable object.
/// </summary>
namespace Project
{
		public class TestInteractable : MonoBehaviour, IInteractable {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void Interact()
		{
			Debug.Log("Interaction complete!");
		}
	}
}
