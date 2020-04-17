using System.Collections.Generic;

namespace Trademe.Automation.Web.Tests.ContextObjects
{
	public class ContextObjectInitializer
	{
		private readonly IDictionary<string, object> _context;

		public ContextObjectInitializer()
		{
			_context = new Dictionary<string, object>();
		}
		public T Get<T>()
		{
			var key = typeof(T).Name;

			if (!_context.ContainsKey(key))
			{
				_context[key] = typeof(T).GetConstructors()[0].Invoke(null);
			}
			return (T)_context[key];
		}
	}
}
