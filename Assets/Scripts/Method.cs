using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class Method : MonoBehaviour, IInteractable {

			MethodObject methodInfo;
			public string methodText;
			// Use this for initialization
			void Start () {
				//DEBUG STATEMENTS
				//methodObject testInfo = new.methodObject("integer", "ExampleName");
				//Populate(testInfo);
			}
			
			// Update is called once per frame
			void Update () {
				
			}
			
			public void Interact()
			{
				Debug.Log("Interaction method run");
				Debug.Log(this.methodText);
				gameObject.transform.Find("Text").GetComponent<TextMesh>().text = this.methodText;
				StartCoroutine(InteractionTimeout());
			}

			IEnumerator InteractionTimeout()
			{
				yield return new WaitForSeconds(7);
				this.gameObject.transform.Find("Text").GetComponent<TextMesh>().text = "";
			}

			public void Populate(MethodObject info)
			{
				Debug.Log("Populated: " + info.ToString());
				this.methodText = info.ToString();
				Debug.Log("DoubleCheck: " + this.methodText);
			}
	}
}
