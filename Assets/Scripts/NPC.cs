using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class NPC : MonoBehaviour, IInteractable {

		NPCObject npcInfo;
		string npcText;
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
			this.gameObject.GetComponent<TextMesh>().text = npcText;
			StartCoroutine(InteractionTimeout());
		}

		IEnumerator InteractionTimeout()
		{
			yield return new WaitForSeconds(7);
			this.gameObject.GetComponent<TextMesh>().text = "";
		}

		public void Populate(NPCObject info)
		{
			npcInfo = new NPCObject(info.type, info.name);
			npcText = npcInfo.ToString();
		}
	}

}