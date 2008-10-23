using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp
{
	class EditableSong : Song 
	{
		public new string title { get { return base.title; } set { base.title = value; } }
		public new string language { get { return base.language; } set { base.language = value; } }

		public EditableSong(string fileName) : base(fileName)
		{
			
		}



	}
}
