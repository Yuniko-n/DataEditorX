/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 2014-10-23
 * 时间: 23:14
 * 
 */
using System.Drawing;

namespace FastColoredTextBoxNS
{
	/// <summary>
	/// ygocore的lua高亮，夜间
	/// </summary>
	public class MySyntaxHighlighter : SyntaxHighlighter
	{
		readonly TextStyle mNumberStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
		readonly TextStyle mStrStyle = new TextStyle(Brushes.Gold, null, FontStyle.Regular);
		readonly TextStyle conStyle = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
		readonly TextStyle mKeywordStyle = new TextStyle(Brushes.DeepSkyBlue, null, FontStyle.Regular);
		readonly TextStyle mGrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
		readonly TextStyle mFunStyle = new TextStyle(Brushes.LightGray, null, FontStyle.Bold);


		/// <summary>
		/// Highlights Lua code
		/// </summary>
		/// <param name="range"></param>
		public override void LuaSyntaxHighlight(Range range)
		{
			range.tb.CommentPrefix = "--";
			range.tb.LeftBracket = '(';
			range.tb.RightBracket = ')';
			range.tb.LeftBracket2 = '{';
			range.tb.RightBracket2 = '}';
			range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

			range.tb.AutoIndentCharsPatterns
				= @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>.+)";

			//clear style of changed range
			range.ClearStyle(this.mStrStyle, this.mGrayStyle, this.conStyle, this.mNumberStyle, this.mKeywordStyle, this.mFunStyle);
			//
			if (this.LuaStringRegex == null)
			{
				this.InitLuaRegex();
			}
			//string highlighting
			range.SetStyle(this.mStrStyle, this.LuaStringRegex);
			//comment highlighting
			range.SetStyle(this.mGrayStyle, this.LuaCommentRegex1);
			range.SetStyle(this.mGrayStyle, this.LuaCommentRegex2);
			range.SetStyle(this.mGrayStyle, this.LuaCommentRegex3);
			//number highlighting
			range.SetStyle(this.mNumberStyle, this.LuaNumberRegex);

			//keyword highlighting
			range.SetStyle(this.mKeywordStyle, this.LuaKeywordRegex);
			//functions highlighting
			range.SetStyle(this.mFunStyle, this.LuaFunctionsRegex);
			range.SetStyle(this.mNumberStyle, @"\bc\d+\b");

			range.SetStyle(this.conStyle, @"[\s|\(|+|,]{0,1}(?<range>[A-Z_]+?)[\)|+|\s|,|;]");
			//range.SetStyle(mFunStyle, @"[:|\.|\s](?<range>[a-zA-Z0-9_]*?)[\(|\)|\s]");

			//clear folding markers
			range.ClearFoldingMarkers();
			//set folding markers
			range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
			range.SetFoldingMarkers(@"--\[\[", @"\]\]"); //allow to collapse comment block
		}
	}
}
