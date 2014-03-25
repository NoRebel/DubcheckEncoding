using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	public class TransformationRuleSection: ConfigurationSection
	{
		#region Constructors
        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
		static TransformationRuleSection()
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
                ConfigurationPropertyOptions.None
            );

			s_separator = new ConfigurationProperty(
				"separator",
				typeof(string),
				null,
				ConfigurationPropertyOptions.None
			);


            s_properties = new ConfigurationPropertyCollection();
            
            s_properties.Add(s_sourceField);
            s_properties.Add(s_transformationType);            
        }
        #endregion

        #region Static Fields
		private static ConfigurationProperty s_sourceField;
		private static ConfigurationProperty s_transformationType;
		private static ConfigurationProperty s_separator;

        private static ConfigurationPropertyCollection s_properties;
        #endregion

         
        #region Properties
        /// <summary>
        /// Gets the StringValue setting.
        /// </summary>
		[ConfigurationProperty("sourcefield", IsRequired = true)]
        public string SourceField
        {
            get { return (string)base[s_sourceField]; }
        }

        /// <summary>
        /// Gets the BooleanValue setting.
        /// </summary>
        [ConfigurationProperty("transformationType")]
        public bool TransformationType
        {
            get { return (bool)base[s_transformationType]; }
        }

        /// <summary>
        /// Gets the TimeSpanValue setting.
        /// </summary>
        [ConfigurationProperty("separator")]
        public string Separator
        {
            get { return (string)base[s_separator]; }
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
