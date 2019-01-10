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
			gameObject.transform.Find("Text").GetComponent<TextMesh>().text = this.npcText;
			StartCoroutine(InteractionTimeout());
		}

		IEnumerator InteractionTimeout()
		{
			yield return new WaitForSeconds(7);
			this.gameObject.transform.Find("Text").GetComponent<TextMesh>().text = "";
		}

		public void Populate(NPCObject info)
		{
			this.npcText = info.ToString();
		}
	}

}