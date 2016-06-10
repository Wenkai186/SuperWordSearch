﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWordSearch
{
	public class LoadInputPuzzleIntoGrid
	{
		List<string> list = new List<string>();
		string mode;
		int wordStartIndex;

		List<string> searchWords = new List<string>();
		public char[,] PuzzleGrid(string file){
		//string[] lines;

			//var list = new List<string>();
			List<string> inputPuzzle = new List<string> ();


			try {
				var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
				using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
				{
					string line;
					while ((line = streamReader.ReadLine()) != null)
					{
						list.Add(line);
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(ex.Message);
			}



			if (list[0] != null) {
				foreach (var item in list) {
					if (list.IndexOf(item) != 0) {
						if (item != "NO_WRAP" && item != "WRAP") {
							inputPuzzle.Add (item);
						} else {
							break;
						}						
					}

				}				
			}


			char[,] puzzle = new char[inputPuzzle.Count, inputPuzzle[0].Length];

			int row = 0;
			foreach (string line in inputPuzzle)
			{
				int column = 0;
				foreach (char character in line)
				{
					puzzle[row, column] = character;
					column++;
				}
				row++;
			}

			int rowLength = puzzle.GetLength(0);
			int colLength = puzzle.GetLength(1);

			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < colLength; j++)
				{
					Console.Write(string.Format("{0} ", puzzle[i, j]));
				}
				Console.Write(Environment.NewLine + Environment.NewLine);
			}

			return puzzle;
		}

		public string GetMode(){
			foreach (var item in list) {
				
				if (item == "NO_WRAP" || item == "WRAP") {
					mode = item;
					break;
				} else {
				continue;
					//mode = "Mode not set";
				}

			}
			if (mode != null) {
				return mode;
			} else {
				return null;
			}
		}
		public List<string> GetWords(string modeInfo){

			if (modeInfo != null) {
				wordStartIndex = list.IndexOf (modeInfo) + 1;	
			}
			foreach (var item in list) {
				if (list.IndexOf (item) > wordStartIndex) {
					searchWords.Add (item);
				}
			}
			return searchWords;
		}
	}
}

