using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	public class TransformationRule: ConfigurationSection
	{

		#region Constructors
		/// <summary>
		/// Predefines the valid properties and prepares
		/// the property collection.
		/// </summary>
		static TransformationRule()
		{
			// Predefine properties here
			s_sourceField = new ConfigurationProperty(
				"sourceField",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
			);

			s_transformationType = new ConfigurationProperty(
				"transformationType",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
			);

			s_separator = new ConfigurationProperty(
				"separator",
				typeof(string),
				null,
				ConfigurationPropertyOptions.None
			);

			s_propTargetFields = new ConfigurationProperty(
				"targetFields",
				typeof(TargetFieldElementCollection),
				null,
				ConfigurationPropertyOptions.None
			);

			s_propTransformations = new ConfigurationProperty(
				"transformations",
				typeof(TransformationElementCollection),
				null,
				ConfigurationPropertyOptions.None
			);

			s_properties = new ConfigurationPropertyCollection();

			s_properties.Add(s_sourceField);
			s_properties.Add(s_transformationType);
			s_properties.Add(s_separator);
			s_properties.Add(s_propTargetFields);
			s_properties.Add(s_propTransformations);
		}
		#endregion

		#region Static Fields
		private static ConfigurationProperty s_sourceField;
		private static ConfigurationProperty s_transformationType;
		private static ConfigurationProperty s_separator;
		private static ConfigurationProperty s_propTargetFields;
		private static ConfigurationProperty s_propTransformations;

		private static ConfigurationPropertyCollection s_properties;
		#endregion

         
        #region Properties
        /// <summary>
        /// Gets the StringValue setting.
        /// </summary>
		[ConfigurationProperty("sourceField", IsRequired = true)]
        public string SourceField
        {
			get { return (string)base[s_sourceField]; }
        }

        /// <summary>
        /// Gets the TransformationType setting.
        /// </summary>
        [ConfigurationProperty("transformationType")]
        public string TransformationType
        {
			get { return (string)base[s_transformationType]; }
        }

        /// <summary>
        /// Gets the Separator setting.
        /// </summary>
        [ConfigurationProperty("separator")]
        public string Separator
        {
			get { return (string)base[s_separator]; }
        }

		/// <summary>
		/// Gets the Separator setting.
		/// </summary>
		[ConfigurationProperty("targetFields")]
		public TargetFieldElementCollection TargetFields
		{
			get { return (TargetFieldElementCollection)base[s_propTargetFields]; }
		}

		/// <summary>
		/// Gets the Separator setting.
		/// </summary>
		[ConfigurationProperty("transformations")]
		public TransformationElementCollection Transformations
		{
			get { return (TransformationElementCollection)base[s_propTransformations]; }
		}

		
        /// <summary>
        /// Override the Properties collection and return our custom one.
        /// </summary>
		protected override ConfigurationPropertyCollection Properties
		{
			get { return s_properties; }
		}
        #endregion
	}
}
