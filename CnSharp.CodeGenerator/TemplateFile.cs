using System;

namespace CnSharp.CodeGenerator
{
	[Serializable]
	public class TemplateFile
	{
		#region Constants and Fields

		private const string DefaultExt = ".txt";

		private const string OutputFileDefaultNameFormat = "{0}.{1}";

		private string _extension;

		private string _outputFileNameFormat = OutputFileDefaultNameFormat;

		#endregion

		#region Public Properties

		public string Extension
		{
			get
			{
				if (_extension == null || _extension.Trim().Length == 0)
				{
					return DefaultExt;
				}
				if (!_extension.StartsWith("."))
				{
					_extension = "." + _extension;
				}
				return _extension;
			}
			set => _extension = value;
		}

		public string Name { get; set; }

		/// <summary>
		/// like Table.TemplateName.cs
		/// </summary>
		public string OutputFileNameFormat
		{
			get
			{
				if (_outputFileNameFormat == null || _outputFileNameFormat.Trim().Length == 0)
				{
					return OutputFileDefaultNameFormat;
				}
				return _outputFileNameFormat;
			}
			set => _outputFileNameFormat = value;
		}

		public string Path { get; set; }

		#endregion
	}
}