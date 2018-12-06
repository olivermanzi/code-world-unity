using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class NPC : MonoBehaviour, IInteractable {

		NPCObject npcInfo;
		public string npcText;
		// Use this for initialization
		void Start () {
			//DEBUG STATEMENTS
			//NPCObject testInfo = new NPCObject("integer", "ExampleName");
			//Populate(testInfo);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		public void Interact()
		{
			Debug.Log("Interaction method run");
			Debug.Log(this.npcText);
			gameObject.GetComponent<TextMesh>().text = this.npcText;
			StartCoroutine(InteractionTimeout());
		}

		IEnumerator InteractionTimeout()
		{
			yield return new WaitForSeconds(7);
			this.gameObject.GetComponent<TextMesh>().text = "";
		}

		public void Populate(NPCObject info)
		{
			Debug.Log("Populated: " + info.ToString());
			this.npcText = info.ToString();
			Debug.Log("DoubleCheck: " + this.npcText);
		}
	}

}