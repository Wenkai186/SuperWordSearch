﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWordSearch
{
	class Gridcoordinate
	{
		public Gridcoordinate(int row_num, int column_num)
		{
			Row_num = row_num;
			Column_num = column_num;
		}

		public int Row_num { get; set; }
		public int Column_num { get; set; }
	}
}