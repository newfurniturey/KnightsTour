using System;

namespace com.newfurniturey.KnightsTour.exceptions {
	public class TourIncompleteException : Exception {

		public TourIncompleteException() {
		}

		public TourIncompleteException(string message) : base(message) {
		}
	}
}
