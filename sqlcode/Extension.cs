﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
	static class Extension
	{
		public static string TableName(this Type type)
		{
			return type.Name;
		}

		
	}
}
