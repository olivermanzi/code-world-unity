using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for interactable objects
/// The Interact method should contain whatever behavior occurs
/// when the Interact key is pressed.
/// </summary>
namespace Project
{
	public interface IInteractable {
		void Interact();
	}
}

