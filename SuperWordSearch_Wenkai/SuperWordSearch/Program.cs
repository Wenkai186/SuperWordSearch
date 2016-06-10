﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWordSearch
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> words = new List<string> ();
			List<string> searchResults = new List<string> ();
			LoadInputPuzzleIntoGrid puzzleGrid = new LoadInputPuzzleIntoGrid ();
			string mode;
			int N, M;
			Position searchResultsPoint = new Position();

            ///////////////////////////////////////////////////////
            //                input file name                    //
            ///////////////////////////////////////////////////////

            Console.WriteLine("Please enter file name:\n"); // Prompt
            Console.WriteLine("                 There are four files that can be choosed:");
            Console.WriteLine("                                 test1.txt");
            Console.WriteLine("                                 test2.txt");
            Console.WriteLine("                                 test3.txt");
            Console.WriteLine("                                 test4.txt");
            string fileName = Console.ReadLine(); 

			//check if the file is exits or not
			string path = Directory.GetCurrentDirectory() + "/" + fileName;

			if (File.Exists(path)) 
			{
				///////////////////////////////////////////////////////
				//        initial the puzzle layout                  //
				//            get search mode                        //
				//       get the words that need to search          //
				/////////////////////////////////////////////////////

                Console.WriteLine("\n");
				Console.WriteLine ("PUZZLE \n");
				//load the input letters into NxM grid array puzzle
				char[,] puzzle = puzzleGrid.PuzzleGrid(fileName);
				SuperSearchEngine Super = new SuperSearchEngine(puzzle);

				//get the mode info
				mode = puzzleGrid.GetMode();

				//get P words that need to be found in the grid
				words = puzzleGrid.GetWords (mode);

				N = puzzle.GetLength (0);
				M = puzzle.GetLength (1);

				Console.WriteLine ("Mode -- " + mode);
                Console.WriteLine("\n");
                Console.WriteLine("Words need to search: ");
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine("\n");
				///////////////////////////////////////////////////////
				//                search words                       //
				///////////////////////////////////////////////////////

				foreach (var word in words) {
					searchResultsPoint = Super.Search(word, N, M, mode);
					if (searchResultsPoint != null)
					{
						string startPoint = "(" + searchResultsPoint.Start.Row_num + "," + searchResultsPoint.Start.Column_num + ")";
						string endPoint = "(" + searchResultsPoint.End.Row_num + "," + searchResultsPoint.End.Column_num + ")";
						string position = startPoint + endPoint;
						searchResults.Add (position);
					}
					else
					{
						searchResults.Add ("NOT FOUND");
					}

				}

				///////////////////////////////////////////////////////
				//               print out the search results        //
				///////////////////////////////////////////////////////

				Console.WriteLine("Here is the search result: \n");
				foreach (var result in searchResults) {
					Console.WriteLine (result);
				}
			} else {
				Console.WriteLine("The current directory is {0}", path);
				Console.WriteLine ("\n");
				Console.WriteLine("Could not find file. Please check the file name!");
			} 

			Console.ReadLine();
		}
	}
}