using System;
using System.ComponentModel;

namespace CnSharp.CodeGenerator
{
	[DefaultProperty("Name")]
	[Serializable]
	public class OutputOption
	{
		#region Constants and Fields

		private string _val;

		#endregion

		#region Public Properties

		public string DefaultValue { get; set; }

		public string Description { get; set; }

		public InputType InputType { get; set; }

		public string Name { get; set; } = "option";

		public bool Required { get; set; }

		[Browsable(false)]
		public string Value
		{
			get => !string.IsNullOrEmpty(_val) ? _val : DefaultValue;
			set => _val = value;
		}

		#endregion
	}
}