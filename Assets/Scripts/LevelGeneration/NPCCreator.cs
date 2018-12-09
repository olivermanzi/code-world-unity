using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project{
	public class NPCCreator : ScriptableObject {

		System.Random rnd = new System.Random();
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void CreateAttributes(Room room, GameObject newRoom)
        {
            int i = 0;
            if (room.Info.attributes.Length > 0)
            {
                foreach (NPCObject npc in room.Info.attributes)
                {
                    Vector3 position;
                    GameObject obj;
                    switch (npc.type)
                    {
                        case ("int"):
                            obj = Resources.Load("Prefabs/Actors/modelInt") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Double"):
                            obj = Resources.Load("Prefabs/Actors/modelDouble") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Float"):
                            obj = Resources.Load("Prefabs/Actors/modelFloat") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Boolean"):
                            obj = Resources.Load("Prefabs/Actors/modelBoolean") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Char"):
                            obj = Resources.Load("Prefabs/Actors/modelChar") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Short"):
                            obj = Resources.Load("Prefabs/Actors/modelInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("Long"):
                            obj = Resources.Load("Prefabs/Actors/modelInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        default:
                            Debug.Log("No");
                            break;
                    }
                    Debug.Log("Created objects: " + i++);
                }
            }
        }

		private bool checkIfPosEmpty(Vector3 pos)
        {
            GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
            foreach (GameObject current in interactables)
            {
                if (current.transform.position == pos)
                    return false;
            }
            return true;
        }
	}
}
