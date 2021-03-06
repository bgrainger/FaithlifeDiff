namespace Menees.Diffs
{
	#region Using Directives

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Text;

	#endregion

	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
		Justification = "Using the same name as in Myers's paper.")]
	internal sealed class EditScript : ReadOnlyCollection<Edit>
	{
		#region Private Data Members

		private int totalEditLength;

		#endregion

		#region Constructors

		internal EditScript(double similarity)
			: base(new List<Edit>())
		{
			this.Similarity = similarity;
		}

		#endregion

		#region Public Properties

		public int TotalEditLength => this.totalEditLength;

		public double Similarity { get; }

		#endregion

		#region Internal Methods

		internal void Add(Edit edit)
		{
			if (edit.EditType == EditType.Change)
			{
				this.totalEditLength += 2 * edit.Length;
			}
			else
			{
				this.totalEditLength += edit.Length;
			}

			this.Items.Add(edit);
		}

		#endregion
	}
}
