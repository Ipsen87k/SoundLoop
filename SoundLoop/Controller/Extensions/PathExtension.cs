using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.Extensions
{
	static class PathExtension
	{
		[Pure]
		public static string GetExtensionWithoutPeriod(this string path)
		{
			if (string.IsNullOrEmpty(path))
				return string.Empty;
			var substringLength = 1;
			return Path.GetExtension(path).Substring(substringLength);
		}
	}
}
