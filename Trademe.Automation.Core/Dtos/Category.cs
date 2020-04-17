using System.Collections.Generic;

namespace Trademe.Automation.Core.Dtos
{
	public class Category
	{
		public string Name { get; set; }
		public string Number { get; set; }
		public string Path { get; set; }
		public IEnumerable<Subcategory> Subcategories { get; set; }
		public bool HasClassifieds { get; set; }
		public int AreaOfBusiness { get; set; }
		public bool IsLeaf { get; set; }
	}
}
