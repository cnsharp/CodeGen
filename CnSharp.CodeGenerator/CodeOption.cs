using System.ComponentModel;

namespace CnSharp.CodeGenerator
{
	public enum InputType
	{
		[Description("TextBox")]
		Text,

		[Description("MultiLine TextBox")]
		TextArea,

		[Description("DateTimePicker")]
		Date
	}
}