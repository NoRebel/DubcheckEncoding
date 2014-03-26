using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	[ConfigurationCollection(typeof(TransformationElement),
		CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
	public class TransformationElementCollection: ConfigurationElementCollection
	{
			#region Constructors
			static TransformationElementCollection()
			{
				m_properties = new ConfigurationPropertyCollection();
			}

			public TransformationElementCollection()
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
			public TransformationElement this[int index]
			{
				get { return (TransformationElement)base.BaseGet(index); }
				set
				{
					if (base.BaseGet(index) != null)
					{
						base.BaseRemoveAt(index);
					}
					base.BaseAdd(index, value);
				}
			}

			public TransformationElement this[string name]
			{
				get { return (TransformationElement)base.BaseGet(name); }
			}
			#endregion


			#region Overrides
			protected override ConfigurationElement CreateNewElement()
			{
				return new TransformationElement();
			}

			protected override object GetElementKey(ConfigurationElement element)
			{
				return (element as TransformationElement).Length;
			}
			#endregion

	}
}
