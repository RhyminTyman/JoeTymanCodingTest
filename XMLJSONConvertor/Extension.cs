using Newtonsoft.Json.Linq;

namespace XMLJSONConvertor
{
	public static class Extension
	{	
		/*
		 * This extension method is based off of a
		 * answer on Stack Overflow, it checks first for
		 * brackets then makes sure the JSON can be parsed
		 */ 
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
