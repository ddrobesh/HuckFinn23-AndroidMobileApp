using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

/**
 * These code and artifact files are intended for demo, learning,
 * discussion, training, and non-commercial purposes ONLY. They
 * may not be intended for Production use while in partial
 * form, but production use for non-commercial demo/learning
 * purposes are encouraged and not disallowed.
 * Without the explicit, written concept of both author and owner,
 * any modifications and/or re-distributions of the framework,
 * code, or file systems is explicitly forbidden. Modifications
 * are allowed for local, learning purposes.
 * Re-distributions or reuse for commercial for-profit
 * purposes are explicitly forbidden.
 *
 * Copyright 2019-2023 All Rights Reserved, David D Drobesh,
 * and 8814 Bothell Properties LLC, and Level8 Partnerships,
 * respectively.
 */

namespace HuckFinn23AndroidMobileAppAWSSDKdotNet
{
	// Dependency Library "MvvmLight" simplifies MVC data bindings for AWS.NET
	//		Purpose: this is the Model for our view, uses pub/sub dynamic
	//			data bindings for expediency of POC create, not mature design.
	public class MainPageViewModel : GalaSoft.MvvmLight.ViewModelBase
	{
		public MainPageViewModel()
		{
            RetrieveCloudRemoteAWSData();
		}

		public IEnumerable<object> Data { private set; get; }
        public object AWSMyEnvironmentSecretsAndSettings { get; private set; }

		private async Task RetrieveCloudRemoteAWSData()
		{
			// ... AWS: Configure your specific settings/region
			var credentials = new Amazon.CognitoIdentity.CognitoAWSCredentials(
				"", //AWSMyEnvironmentSecretsAndSettings.IdentityPoolId,
				Amazon.RegionEndpoint.USEast1
				);

			// ... AWS: Setup client to read/write to remote cloud AWS DynamoDB (noSQL)
			var dynamoDBClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);

			// ... AWS: Call remote async promise/future, Read AWS DynamoDB table attributes
			var result = await dynamoDBClient.ScanAsync(new ScanRequest
			{
				TableName = "DemoAppData",
				AttributesToGet = new List<string> { "id", "name", "description" }
			});

			// ... AWS: Callback future proceed and parse results once returned
			//		Foreach item i, .S string value of given attribute in result.
			Data = result.Items.Select(i => new
			{
				id = i["id"].S,
				name = i["name"].S,
				description = i["description"].S
			}).OrderBy(i => i.name);

			// ... MVVLight: pub Event propertyChange in MVC for 'Data' (down-n-dirty expediency
			//		of data binding for quick exposure of remote AWS DynamoDB into my App View UI/sub)
			//	  Yo - 'Data' has changed! You got that View?? See also: MainPage.xaml
			RaisePropertyChanged(nameof(Data));

		}
	}
}

