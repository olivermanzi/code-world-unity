using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project{
	public class ActorCreator : ScriptableObject {

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
                            obj = Resources.Load("Prefabs/Actors/attributeInt") as GameObject;
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

                        case ("double"):
                            obj = Resources.Load("Prefabs/Actors/attributeDouble") as GameObject;
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

                        case ("float"):
                            obj = Resources.Load("Prefabs/Actors/attributeFloat") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("boolean"):
                            obj = Resources.Load("Prefabs/Actors/attributeBoolean") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("char"):
                            obj = Resources.Load("Prefabs/Actors/attributeChar") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("short"):
                            obj = Resources.Load("Prefabs/Actors/attributeInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("long"):
                            obj = Resources.Load("Prefabs/Actors/attributeInt") as GameObject;
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

        public void CreateMethods(Room room, GameObject newRoom)
        {
            int i = 0;
            if (room.Info.methods.Length > 0)
            {
                foreach (MethodObject method in room.Info.methods)
                {
                    Vector3 position;
                    GameObject obj;
                    switch (method.returnType)
                    {
                        case ("int"):
                            obj = Resources.Load("Prefabs/Actors/methodInt") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("double"):
                            obj = Resources.Load("Prefabs/Actors/methodDouble") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("float"):
                            obj = Resources.Load("Prefabs/Actors/methodFloat") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("boolean"):
                            obj = Resources.Load("Prefabs/Actors/methodBoolean") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("char"):
                            obj = Resources.Load("Prefabs/Actors/methodChar") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("short"):
                            obj = Resources.Load("Prefabs/Actors/methodInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("long"):
                            obj = Resources.Load("Prefabs/Actors/methodInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("void"):
                            obj = Resources.Load("Prefabs/Actors/methodInt") as GameObject;
                            Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.GetComponent<Method>().Populate(method);
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
