using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
		[Serializable]
		public class NPCObject{
			public enum npcType {
				Integer,
				Double,
				Float,
				Boolean,
				Char,
				Short,
				Long

			}
			
			public string type;
			public string name;

			/* public NPCObject(npcType type, string name)
			{
				this.type = type;
				this.name = name;
			}*/

			public NPCObject(string type, string name)
			{
				this.name = name;
				this.type = type;
				/* switch(type)
				{
					case("int"):
					this.type = npcType.Integer;
					break;

					case("Double"):
					this.type = npcType.Integer;
					break;

					case("Float"):
					this.type = npcType.Float;
					break;

					case("Boolean"):
					this.type = npcType.Boolean;
					break;

					case("Char"):
					this.type = npcType.Char;
					break;

					case("Short"):
					this.type = npcType.Short;
					break;

					case("Long"):
					this.type = npcType.Long;
					break;

					default:
					Debug.Log("NPCOBJECT: Undefined string type");
					this.type = npcType.Integer;
					break;

				}*/
			}
			public override string ToString()
			{
				//todo
				/*switch(this.type)
				{
					case(npcType.Integer):
					sType = "Integer";
					break;
					case(npcType.Double):
					sType = "Double";
					break;
					case(npcType.Float):
					sType = "Float";
					break;
					case(npcType.Boolean):
					sType = "Boolean";
					break;
					case(npcType.Char):
					sType = "Char";
					break;
					case(npcType.Short):
					sType = "Short";
					break;
					case(npcType.Long):
					sType = "Long";
					break;
					default:
					sType = "Undefined";
					break;
				} */
				string txt = "Name: " + this.name + "\nType: " + this.type + "\n";
				return txt;
			}

	}
}
