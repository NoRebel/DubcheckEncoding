using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using DupCheckEncoding.Import.Configuration;

namespace DubCheckEncoding.Import
{
    public class Importer
    {
	    private char columnSeparator;
		//private readonly string[] columnsToSkip = new string[] { "urid" , "pid"};
		private const string encryptionKey1 = "9X5B";
		private const string encryptionKey2 = "3A0X";


	    //private int[] indexesToSkip;
		private Dictionary<int, string> ColumnsToSkip { get; set; } 
		private Dictionary<int, string> SourceHeaders { get; set; }

	    private readonly string _importFileName;
		private readonly string _outputFileName;

	    private List<TransformationRule> _transformationRules;

	    public Importer(string importFileName, string outputFileName)
	    {
		    _importFileName = importFileName;
		    _outputFileName = outputFileName;
		    columnSeparator = GetColumnSeparator();
	    }

		private char GetColumnSeparator()
		{
			var result = ',';
			try
			{
				result = ConfigurationManager.AppSettings["ColumnSeparator"][0];
			}
			catch
			{
				
			}
			return result;
		}

		
	    public ImportResult Import()
	    {
			if (String.IsNullOrEmpty(_importFileName))
				return ImportResult.ImportFileMissing;
			if (String.IsNullOrEmpty(_outputFileName))
				return ImportResult.OutputFileMissing;
			if (_importFileName.Substring(_importFileName.Length - 4, 4) != ".csv")
				return ImportResult.BadInputFileType;


		    string[] allRows = File.ReadAllLines(_importFileName);

			Configuration config =
ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var configSectionGroup = config.GetSectionGroup("transformationRules") as TransformationRuleGroup;
			if (configSectionGroup != null)
			{
				_transformationRules = new List<TransformationRule>();
				if (configSectionGroup.InitialsTransformation != null)
					_transformationRules.Add(configSectionGroup.InitialsTransformation);
				if (configSectionGroup.BirthDateTransformation != null)
					_transformationRules.Add(configSectionGroup.BirthDateTransformation);
			}

		    var transformedRows = TransformRows(allRows, _transformationRules);

		    SourceHeaders = GetSourceHeaders(allRows);
		    ColumnsToSkip = GetColumnsToSkip(SourceHeaders);
		    var columnCount = SourceHeaders.Count();
			if (columnCount == 0)
				return ImportResult.BadFormat;

		    var rows = GetRows(allRows);
			if (rows.Count(c => c.Count() != columnCount) > 0)
				return ImportResult.BadFormat;

		    var encryptedRows = EncryptRows(rows);

			try
			{
				var writer = new StreamWriter(_outputFileName);
				writer.WriteLine(string.Join(columnSeparator.ToString(), SourceHeaders.Select(c => c.Value)));
				encryptedRows.ForEach(writer.WriteLine);
				writer.Flush();
				writer.Close();
			}
			catch (IOException e)
			{
				return ImportResult.WriteAccessDenied;
			}
		    
			return ImportResult.Success;
		}

		private string[] TransformRows(string[] allRows, List<TransformationRule> transformationRules)
		{
			var headers = GetSourceHeaders(allRows);
			var transformedHeaders = GetTransformedHeaders(headers, transformationRules).Select(c => c.Value).ToArray();
			for (int rowIndex = 1; rowIndex < allRows.Count(); rowIndex++)
			{
				var splittedRow = allRows[rowIndex].Split(columnSeparator);
				for (int columnIndex = 0; columnIndex < splittedRow.Count(); columnIndex++)
				{
					var header = headers[columnIndex];
					var transformationRule = transformationRules.SingleOrDefault(c => c.SourceField.ToLower() == header.ToLower());
					if (transformationRule != null)
					{
						if (String.IsNullOrEmpty(transformationRule.Separator))
						{
							var length = splittedRow[columnIndex].Length;
							for (int i=0; i< transformationRule.Transformations.Count; i++)
							{
								if (transformationRule.Transformations[i].Length == length)
								{
									var format = transformationRule.Transformations[i].FieldOrder;
									if (transformationRule.TransformationType == "Char")
									{
										string[] array = new string[length];
										for (int j = 0; j < splittedRow[columnIndex].Length; j++)
										{
											//array[j] = 
										}
									}
								}
							}
							

						}
						else
						{
						}
					}
				}
			}
			return transformedHeaders;
		}


	    private Dictionary<int, string> GetTransformedHeaders(Dictionary<int, string> sourceHeaders,
		    List<TransformationRule> transformationRules)
	    {
		    return GetTransformedHeaders(sourceHeaders.Select(c => c.Value).ToArray(), transformationRules);
	    }


	    private Dictionary<int, string> GetTransformedHeaders(string[] sourceHeaders, 
			List<TransformationRule> transformationRules)
		{
			var result = new Dictionary<int, string>();
			int index = 0;
			foreach (var sourceHeader in sourceHeaders)
			{
				var transformationRule = transformationRules.SingleOrDefault(c => c.SourceField.ToLower() == sourceHeader.ToLower());
				if (transformationRule != null)
				{
					for (int i = 0; i < transformationRule.TargetFields.Count; i++)
					{
						result.Add(index, transformationRule.TargetFields[i].Value);
						index++;
					}

				}
				else
				{
					result.Add(index, sourceHeader.ToLower());
					index++;
				}
				
			}
		    return result;
		}

		private Dictionary<int, string> GetColumnsToSkip(Dictionary<int, string> headers)
		{
			var columnsToSkip = GetNonEncryptedFields();
			var result = new Dictionary<int, string>();
			foreach (string columnToSkip in columnsToSkip)
			{
				var columnName = columnToSkip.ToLower();
				for (int i = 0; i < headers.Count(); i++)
				{					
					if (headers[i].Trim().Replace("\"", "").ToLower() == columnName)
					{
						result.Add(i, columnName);						
					}
				}				
			}
			return result;
		}

		private List<string> GetNonEncryptedFields()
		{
			var strColumnsToSkip = ConfigurationManager.AppSettings["NonEncryptedFields"];
			return strColumnsToSkip.Split(',').Select(c => c.Trim()).ToList();
		}

		private List<string> EncryptRows(List<List<string>> rows)
		{
			var result = new List<string>();

			foreach (var row in rows)
			{
				var newRow = new List<string>();
				for(int cellIndex = 0; cellIndex < row.Count; cellIndex++)
				{
					var newString = row[cellIndex].ToLower();
					if (ColumnsToSkip.All(c => c.Key != cellIndex))
					{
						var finalString = EncryptCell(newString);
						newRow.Add("\"" + finalString + "\"");
					}
					
					else
						newRow.Add(newString);
				}
				result.Add(string.Join(columnSeparator.ToString(), newRow));
			}

			return result;
		}

		private string EncryptCell(string cell)
		{
			return GetMd5Hash( GetMd5Hash(GetMd5Hash(cell + encryptionKey1) + cell) +
				GetMd5Hash(GetMd5Hash(cell + encryptionKey2) + cell) );
		}

		private string GetMd5Hash(string cell)
		{
			//Declarations
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			//Instantiate MD5CryptoServiceProvider, get bytes for original string and compute hash (encoded string)
			md5 = new MD5CryptoServiceProvider();
			originalBytes = UTF8Encoding.Default.GetBytes(cell);
			encodedBytes = md5.ComputeHash(originalBytes);

			StringBuilder sBuilder = new StringBuilder();
			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < encodedBytes.Length; i++)
			{
				sBuilder.Append(encodedBytes[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}

	    private Dictionary<int, string> GetSourceHeaders(string[] fileContent)
	    {
		    var result = new Dictionary<int, string>();
		    var headerNames = fileContent[0].Split(columnSeparator).Select(c => c.ToLower()).ToArray();
		    for (int i = 0; i < headerNames.Count(); i++)
		    {
				result.Add(i, headerNames[i]);
		    }

		    return result;
	    }

	    private List<List<string>> GetRows(string[] fileContent)
		{
			var result = new List<List<string>>();
			fileContent = fileContent.Where(c => c.Trim().Length > 0).ToArray();
			for (int i = 1; i < fileContent.Count(); i++)
			{
				result.Add(fileContent[i].Split(columnSeparator).ToList());
			}
			return result;
		}
    } 
}
