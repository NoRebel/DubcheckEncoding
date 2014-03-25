using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DubCheckEncoding.Import
{
    public class Importer
    {
	    private char columnSeparator;
		//private readonly string[] columnsToSkip = new string[] { "urid" , "pid"};
		private const string encryptionKey1 = "9X5B";
		private const string encryptionKey2 = "3A0X";


	    private int[] indexesToSkip;

	    private readonly string _importFileName;
		private readonly string _outputFileName;

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
		    var headers = GetHeaders(allRows);
		    indexesToSkip = GetIndexColumnToSkip(headers).ToArray();
		    var columnCount = headers.Count();
			if (columnCount == 0)
				return ImportResult.BadFormat;
		    
			var rows = GetRows(allRows);
			if (rows.Count(c => c.Count() != columnCount) > 0)
				return ImportResult.BadFormat;

		    var encryptedRows = EncryptRows(rows);

			try
			{
				var writer = new StreamWriter(_outputFileName);
				writer.WriteLine(string.Join(columnSeparator.ToString(), headers));
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

		private IEnumerable<int> GetIndexColumnToSkip(string[] headers)
		{
			var columnsToSkip = GetColumnsToSkip();
			foreach (string columnToSkip in columnsToSkip)
			{
				int result = -1;
				for (int i = 0; i < headers.Count(); i++)
				{
					if (headers[i].Trim().Replace("\"", "").ToLower() == columnToSkip.ToLower())
					{
						result = i;
						break;
					}
				}
				yield return result;
			}
			
		}

		private List<string> GetColumnsToSkip()
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
					if (!indexesToSkip.Any(c => c == cellIndex))
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

	    private string[] GetHeaders(string[] fileContent)
	    {
		    return fileContent[0].Split(columnSeparator).Select(c => c.ToLower()).ToArray();
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
