﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace checker.rnd
{
	internal static class RndUtil
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Choice<T>(params T[] array) => array[ThreadStaticRnd.Next(array.Length)];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static char Choice(string str) => str[ThreadStaticRnd.Next(str.Length)];

		public static Random ThreadStaticRnd => rnd ?? (rnd = new Random(Guid.NewGuid().GetHashCode()));

		public static Task RndDelay(int max) => Task.Delay(ThreadStaticRnd.Next(max));

		[ThreadStatic] private static Random rnd;
	}
}