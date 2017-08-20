using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.newfurniturey.KnightsTour {
	class KnightsTour {

		private uint boardWidth = 8;
		private uint boardHeight = 8;
		private int[,] board;

		public uint BoardWidth {
			get { return boardWidth; }
		}

		public uint BoardHeight {
			get { return boardHeight; }
		}

		public KnightsTour(uint width = 8, uint height = 8) {
			boardWidth = width;
			boardHeight = height;
			initializeBoard();
		}

		public void PrintBoard() {
			int columnWidth = (BoardWidth * BoardHeight).ToString().Length + 1;
			string columnFormat = "{0,-" + columnWidth + "}";

			for (int row = 0; row < BoardHeight; row++) {
				for (int col = 0; col < BoardWidth; col++) {
					Console.Write(columnFormat, board[row, col]);
				}
				Console.Write("\n");
			}
		}

		private void initializeBoard() {
			board = new int[BoardWidth,BoardHeight];
		}
	}
}
