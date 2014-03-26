using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
		[ConfigurationCollection(typeof(TargetFieldElement),
		CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
		public class TargetFieldElementCollection: ConfigurationElementCollection
		{
			#region Constructors
			static TargetFieldElementCollection()
			{
				m_properties = new ConfigurationPropertyCollection();
			}

			public TargetFieldElementCollection()
			{
			}
			#endregion

			#region Fields
			private static ConfigurationPropertyCollection m_properties;
			#endregion

			#region Properties
			protected override ConfigurationPropertyCollection Properties
			{
				get { return m_properties; }
			}
    
			public override ConfigurationElementCollectionType CollectionType
			{
				get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
			}
			#endregion

			#region Indexers
			public TargetFieldElement this[int index]
			{
				get { return (TargetFieldElement)base.BaseGet(index); }
				set
				{
					if (base.BaseGet(index) != null)
					{
						base.BaseRemoveAt(index);
					}
					base.BaseAdd(index, value);
				}
			}

			public TargetFieldElement this[string name]
			{
				get { return (TargetFieldElement)base.BaseGet(name); }
			}
			#endregion


			#region Overrides
			protected override ConfigurationElement CreateNewElement()
			{
				return new TargetFieldElement();
			}

			protected override object GetElementKey(ConfigurationElement element)
			{
				return (element as TargetFieldElement).Name;
			}
			#endregion
	}
}
