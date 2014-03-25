using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DubCheckEncoding.Import
{
	public enum ImportResult
	{
		Success,
		ImportFileMissing,
		OutputFileMissing,
		BadFormat,
		WriteAccessDenied,
		BadInputFileType
	}
}
