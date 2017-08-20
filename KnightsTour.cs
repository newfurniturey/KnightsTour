using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.newfurniturey.KnightsTour {
	class KnightsTour {

		private uint boardWidth = 8;
		private uint boardHeight = 8;
		private uint[,] board;
		private uint currentMove = 1;

		public uint BoardWidth {
			get { return boardWidth; }
		}

		public uint BoardHeight {
			get { return boardHeight; }
		}

		public KnightsTour(uint rows = 8, uint columns = 8) {
			boardWidth = columns;
			boardHeight = rows;
			initializeBoard();
		}

		public bool IsBoardComplete() => (currentMove == (BoardWidth * BoardHeight) + 1);

		public bool IsBoardReallyComplete() {
			for (uint row = 0; row < BoardHeight; row++) {
				for (uint col = 0; col < BoardWidth; col++) {
					if (!isTaken(row, col)) {
						return false;
					}
				}
			}

			return true;
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
			board = new uint[BoardWidth,BoardHeight];
		}

		private bool isTaken(uint row, uint column) {
			return (board[row, column] != 0);
		}

		private bool isValidPosition(uint row, uint column) {
			return (row < BoardHeight) && (column < BoardWidth);
		}

		private void move(uint row, uint column) {
			board[row, column] = currentMove++;
		}
	}
}
