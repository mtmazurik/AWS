using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSQueueReponook.Config;

namespace AWSQueueReponook.Services
{
	public class AwsCredentials : AWSCredentials
	{
		private readonly IAppConfiguration _appConfig;

		public AwsCredentials(IAppConfiguration appConfig)
		{
			_appConfig = appConfig;
		}

		public override ImmutableCredentials GetCredentials()
		{
			return new ImmutableCredentials( _appConfig.AWSAccessKey, _appConfig.AWSSecretKey, null);
		}
	}
}
