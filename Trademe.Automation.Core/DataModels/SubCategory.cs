namespace Trademe.Automation.Core.DataModels
{
	public class Subcategory
	{
		public string Name { get; set; }
		public string Number { get; set; }
		public string Path { get; set; }
		public int Count { get; set; }
		public bool HasClassifieds { get; set; }
		public int AreaOfBusiness { get; set; }
		public bool IsLeaf { get; set; }
	}
}
