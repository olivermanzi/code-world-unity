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
			NPCObject testInfo = new NPCObject(NPCObject.npcType.Integer, "ExampleName", "2" );
			Populate(testInfo);
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
			npcInfo = new NPCObject(info.type, info.varName, info.value);
			npcText = npcInfo.ToString();
		}
	}

}