using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.newfurniturey.KnightsTour {
	class Program {

		static void Main(string[] args) {
			uint boardWidth = uint.Parse(args[0]);
			uint boardHeight = uint.Parse(args[1]);

			KnightsTour tour = new KnightsTour(boardWidth, boardHeight);
			tour.PrintBoard();

			Console.WriteLine("\nBrute-Force");
			bool bruteForceResult = tour.BruteForce();

			Console.WriteLine("Success: {0}", bruteForceResult);
			tour.PrintBoard();

			Console.ReadLine();

		}

	}
}
