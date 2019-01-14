using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
		[Serializable]
		public class MethodObject {

		public string returnType;
		public string name;

			public MethodObject(string returnType, string name)
			{
				this.name = name;
				this.returnType = returnType;
			}
			public override string ToString()
			{
				string txt = "Name: " + this.name + "\nreturnType: " + this.returnType + "\n";
				return txt;
			}


	}
}
