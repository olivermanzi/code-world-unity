using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class NPC : MonoBehaviour, IInteractable {

		private NPCObject npcInfo;
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
			this.gameObject.GetComponent<MeshRenderer>().enabled = true;
			StartCoroutine(InteractionTimeout());
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;

		}

		IEnumerator InteractionTimeout()
		{
			yield return new WaitForSeconds(7);
		}

		public void Populate(NPCObject info)
		{
			this.npcInfo.type = info.type;
			this.npcInfo.varName = info.varName;
			this.npcInfo.value = info.value;
			this.gameObject.GetComponent<TextMesh>().text = npcInfo.ToString();
		}
	}

}