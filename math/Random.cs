using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace com.newfurniturey.KnightsTour.math {
	public static class Random {

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, System.Random rng) {
			T[] arr = source.ToArray();

			int n = arr.Length;
			while (n > 1) {
				int k = rng.Next(n--);
				yield return arr[k];
				arr[k] = arr[n];
			}
		}
		
		public static IEnumerable<T> ShuffleSecure<T>(this IEnumerable<T> source, RNGCryptoServiceProvider rng) {
			T[] arr = source.ToArray();

			byte[] randInt = new byte[4];
			int n = arr.Length;
			while (n > 1) {
				rng.GetBytes(randInt);
				int k = Convert.ToInt32(randInt);
				yield return arr[k];
				arr[k] = arr[n];
			}
		}
		
	}
}
