using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DupCheckEncoding.Import.Configuration
{
	public class TransformationElement: ConfigurationElement
	{
		#region Constructors
        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
		static TransformationElement()
        {
            // Predefine properties here
            s_propLength = new ConfigurationProperty(
                "length",
                typeof(byte),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_propFieldOrder = new ConfigurationProperty(
                "fieldOrder",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_properties = new ConfigurationPropertyCollection();

			s_properties.Add(s_propLength);
			s_properties.Add(s_propFieldOrder);         
        }
        #endregion

        #region Static Fields
		private static ConfigurationProperty s_propLength;
		private static ConfigurationProperty s_propFieldOrder;        

        private static ConfigurationPropertyCollection s_properties;
        #endregion

         
        #region Properties
        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("length", IsRequired=true)]
        public byte Length
        {
            get { return (byte)base[s_propLength]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("fieldOrder")]
        public string FieldOrder
        {
            get { return (string)base[s_propFieldOrder]; }
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
