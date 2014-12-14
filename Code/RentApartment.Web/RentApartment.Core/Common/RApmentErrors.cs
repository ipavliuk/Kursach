using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Common
{
	public enum RApmentErrors
	{
		Ok = 0,
		OperationError = 1,
		NotAllMandatoryFields = 2,
		FailedProceedRequest = 3,
		IdNotFound = 4,
		FailedToUpdate = 5,
		AuthenticationError = 6,
		InitializationFailed = 7,
	}
}
