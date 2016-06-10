﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWordSearch
{
	class Position
	{
		public Position()
		{

		}
        public Position(Gridcoordinate start, Gridcoordinate end)
        {
            Start = start;
            End = end;
        }


		public Gridcoordinate Start { get; set; }
		public Gridcoordinate End { get; set; }
	}
}