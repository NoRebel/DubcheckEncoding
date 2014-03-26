using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	public class TransformationRuleGroup : ConfigurationSectionGroup
	{
		#region Constructors

		public TransformationRuleGroup()
		{
		}

		#endregion

		#region Properties

		[ConfigurationProperty("InitialsTransformationRule")]
		public TransformationRule InitialsTransformation
		{
			get { return (TransformationRule)base.Sections["InitialsTransformationRule"]; }
		}

		[ConfigurationProperty("BirthDateTransformationRule")]
		public TransformationRule BirthDateTransformation
		{
			get { return (TransformationRule)base.Sections["BirthDateTransformationRule"]; }
		}
		#endregion
	}
}
