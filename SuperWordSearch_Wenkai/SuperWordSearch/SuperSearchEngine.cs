using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWordSearch
{
	class SuperSearchEngine
	{
		public char[,] Puzzle { get; set; }
		public enum Mode {

			WRAP, NO_WRAP
		}
        bool firstTimeOrNot = false;
		public SuperSearchEngine(char[,] puzzle)
		{
			Puzzle = puzzle;
		}
		// represents the array offsets for each character surrounding the current one
		private Gridcoordinate[] directions = 
		{
			new Gridcoordinate(-1, 0), // West
			new Gridcoordinate(-1,-1), // North West
			new Gridcoordinate(0, -1), // North
			new Gridcoordinate(1, -1), // North East
			new Gridcoordinate(1, 0),  // East
			new Gridcoordinate(1, 1),  // South East
			new Gridcoordinate(0, 1),  // South
			new Gridcoordinate(-1, 1)  // South West
		};
        //search the word from the puzzle  
		public Position Search(string word, int N, int M, string mode)
		{
			// go through the Puzzle line by line
			for (int row_num = 0; row_num < Puzzle.GetLength(0); row_num++)
			{
				for (int column_num = 0; column_num < Puzzle.GetLength(1); column_num++)
				{
					if (Puzzle[row_num, column_num] == word[0])
					{
 
						// If find a character that matches the first letter of the word,  
						// search in each direction around it looking for the rest of the word
						var startPoint = new Gridcoordinate(row_num, column_num);
                        var endPoint = SearchEachDirection(word, column_num, row_num, N, M, mode, startPoint, firstTimeOrNot);

						if (endPoint != null)
						{
							return new Position(startPoint, endPoint);
						}

					}
				}
			}
			return null;
		}
        //search each direction that around the letter
        private Gridcoordinate SearchEachDirection(string word, int x, int y, int N, int M, string mode, Gridcoordinate startPoint, bool dataDuplicate)
		{
			char[] chars = word.ToCharArray();
            dataDuplicate = false;

			for (int direction = 0; direction < 8; direction++)
			{
                var reference = SearchDirection(chars, x, y, N, M, direction, mode, startPoint, dataDuplicate);

				if (reference != null)
				{
					return reference;
				}
			}
			return null;
		}
        //search the specificy direction
        private Gridcoordinate SearchDirection(char[] chars, int x, int y, int N, int M, int direction, string mode, Gridcoordinate startPoint, bool dataDuplicate)
		{
			//check which mode is using here 
			if (mode == "NO_WRAP") {
				// if in NO_WRAP Mode, check whether we have reached the boundary of the puzzle
				if (x < 0 || y < 0 || x >= Puzzle.GetLength(1) || y >= Puzzle.GetLength(0))
					return null;	
			} else if (mode == "WRAP") {
				y = (y < 0) ? (N+y) : y;
				x = (x < 0) ? (M+x) : x;
				y = (y == N) ? (N-y) : y;
				x = (x == M) ? (M-x) : x;
			}


			if (Puzzle[y, x] != chars[0])
				return null;

            //Check for the duplicated coordinates
            if (dataDuplicate && startPoint.Row_num == y && startPoint.Column_num == x)
            {
                return null;
            }
            if (startPoint.Row_num == y && startPoint.Column_num == x)
            {
                dataDuplicate = true;
            }
			// when we reach the last character in the word
			// the values of x,y represent location in the
			// puzzle where the word stops
			if (chars.Length == 1)
				return new Gridcoordinate(y, x);



			// test the next character in the current direction
			char[] copy = new char[chars.Length - 1];
			Array.Copy(chars, 1, copy, 0, chars.Length - 1);
            return SearchDirection(copy, x + directions[direction].Row_num, y + directions[direction].Column_num, N, M, direction, mode, startPoint, dataDuplicate);
		}

	}
}