using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
		[Serializable]
		public class MethodObject {

		public string type;
		public string name;

			public MethodObject(string type, string name)
			{
				this.name = name;
				this.type = type;
			}
			public override string ToString()
			{
				string txt = "Name: " + this.name + "\nType: " + this.type + "\n";
				return txt;
			}


	}
}
