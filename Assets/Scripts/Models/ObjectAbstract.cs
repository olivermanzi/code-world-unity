using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
		public abstract class ObjectAbstract : MonoBehaviour, IInteractable {
		public enum objectType {	//you can totally delete these if you want, wasn't sure if you'd need them or nah
			Integer,
			Double,
			Float,
			Boolean,
			Char,
			Short,
			Long

		}

		objectType type;

		public abstract void Interact();


	}
}
