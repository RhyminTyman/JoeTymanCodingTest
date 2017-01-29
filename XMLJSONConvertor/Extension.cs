using Newtonsoft.Json.Linq;

namespace XMLJSONConvertor
{
	public static class Extension
	{
		public static bool IsJson(this string input)
		{
			input = input.Trim();
			System.Predicate<string> IsWellFormed = (x) =>
			{
				try
				{
					JToken.Parse(x);
				}
				catch
				{
					return false;
				}
				return true;
			};

			return (input.StartsWith("{") && input.EndsWith("}")
					|| input.StartsWith("[") && input.EndsWith("]"))
				&& IsWellFormed(input);
		}
	}
}
