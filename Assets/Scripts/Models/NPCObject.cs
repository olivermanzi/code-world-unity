using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
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
		
		public npcType type;
		public string varName;
		public string value;

		public NPCObject(npcType type, string varName, string value)
		{
			this.type = type;
			this.varName = varName;
			this.value = value;
		}

		public override string ToString()
		{
			//todo
			string sType;
			switch(this.type)
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
			}
			string txt = "Name: " + this.varName + "\nType: " + sType + "\nValue: " + this.value + "\n";
			return txt;
		}

	}
}
