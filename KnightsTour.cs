using System;
using com.newfurniturey.KnightsTour.exceptions;

namespace com.newfurniturey.KnightsTour {
	class KnightsTour {

		private uint boardWidth = 8;
		private uint boardHeight = 8;
		private uint[,] board;
		private uint currentMove = 1;

		private int[,] possibleMoves = new int[,] {
			{ 2, 1 },   // up 2, right 1
			{ 2, -1 },  // up 2, left 1
			{ 1, 2 },   // up 1, right 2
			{ 1, -2 },  // up 1, left 2
			{ -2, 1 },  // down 2, right 1
			{ -2, -1 }, // down 2, left 1
			{ -1, 2 },  // down 1, right 2
			{ -1, -2 }  // down 1, left 2
		};

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

		public uint[] GetTour() {
			if (!IsBoardComplete()) {
				throw new TourIncompleteException();
			}

			uint[] tour = new uint[board.Length];
			for (uint row = 0; row < BoardHeight; row++) {
				for (uint col = 0; col < BoardWidth; col++) {
					tour[(row * BoardWidth) + col] = board[row, col];
				}
			}
			return tour;
		}

		public bool BruteForce(uint startRow = 0, uint startColumn = 0) {
			if (!bruteForceMove(startRow, startColumn)) {
				return false;
			}

			return IsBoardComplete();
		}

		private bool bruteForceMove(uint row, uint column) {
			if (!isValidPosition(row, column) || isTaken(row, column)) {
				return false;
			}
			move(row, column);

			if (IsBoardComplete()) {
				return true;
			}

			uint nextRow;
			uint nextCol;
			for (int i = 0; i < possibleMoves.GetLength(0); i++) {
				nextRow = row + (uint)possibleMoves[i, 0];
				nextCol = column + (uint)possibleMoves[i, 1];

				if (isValidPosition(nextRow, nextCol) && !isTaken(nextRow, nextCol)) {
					if (bruteForceMove(nextRow, nextCol)) {
						return true;
					}
				}
			}

			return false;
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
