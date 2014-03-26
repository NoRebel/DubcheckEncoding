using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	public class TargetFieldElement: ConfigurationElement
	{
		#region Constructors
        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
		static TargetFieldElement()
        {
            // Predefine properties here
            s_propName = new ConfigurationProperty(
                "name",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_propValue = new ConfigurationProperty(
                "value",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_properties = new ConfigurationPropertyCollection();
            
            s_properties.Add(s_propName);
            s_properties.Add(s_propValue);         
        }
        #endregion

        #region Static Fields
        private static ConfigurationProperty s_propName;
        private static ConfigurationProperty s_propValue;        

        private static ConfigurationPropertyCollection s_properties;
        #endregion

         
        #region Properties
        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("Name", IsRequired=true)]
        public string Name
        {
            get { return (string)base[s_propName]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("Value")]
        public string Value
        {
            get { return (string)base[s_propValue]; }
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
