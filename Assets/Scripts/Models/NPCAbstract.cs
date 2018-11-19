using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
		public abstract class NPCAbstract : MonoBehaviour, IInteractable {
		public enum npcType {
			Integer,
			Double,
			Float,
			Boolean,
			Char,
			Short,
			Long

		}
		
		npcType type;
		public abstract void Interact();


	}
}
