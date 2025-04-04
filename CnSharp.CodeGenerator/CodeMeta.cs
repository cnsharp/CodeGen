using System.Collections.Generic;
using System.Data.Common;

namespace CnSharp.CodeGenerator
{
	public class CodeMeta<T>
	{
		#region Constants and Fields

		private List<OutputOption> _options;

		#endregion

		#region Constructors and Destructors

		public CodeMeta()
		{
		}

		public CodeMeta(T t)
		{
			this.Meta = t;
		}

		#endregion

		#region Public Properties

		public DbProviderFactory DbProvider { get; set; }

		public T Meta { get; set; }

		public List<OutputOption> Options
		{
			get => this._options ?? new List<OutputOption>();
			set => this._options = value;
		}

		#endregion
	}
}