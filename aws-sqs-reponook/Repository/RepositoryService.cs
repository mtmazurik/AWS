using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSQueueReponook.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using AWSQueueReponook.Config;
using AWSQueueReponook.Exceptions;
using MongoDB.Bson.Serialization;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Amazon.SQS;
using Amazon;
using Amazon.Runtime;
using AWSQueueReponook.Services;
using Amazon.SQS.Model;
using Amazon.Runtime.Internal.Transform;
using MongoDB.Bson.IO;

namespace AWSQueueReponook.Services
{
    public class RepositoryService : IRepositoryService
    {
        private IAppConfiguration _appConfig;
        private AmazonSQSClient _SQSClient;


        public RepositoryService(IAppConfiguration appConfig)     // ctor
        {
            _appConfig = appConfig;
            _SQSClient = CreateClient(appConfig);
        }

        public async Task Create(string repository, string collection, Repository repoObject)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = _appConfig.AWSQueueURI,
                MessageBody = JsonSerializer.Serialize(repoObject),
                MessageAttributes = new Dictionary<string, MessageAttributeValue>
                {
                    {"Repository", new MessageAttributeValue
                        { DataType = "String", StringValue = repository }
                    },
                    {"Collection", new MessageAttributeValue
                        { DataType = "String", StringValue = collection }
                    }
                }
            };
            await _SQSClient.SendMessageAsync(request);
        }

        
        public async Task Update(string repository, string collection, Repository repoObject)
        {



        }

        public async Task Delete(string repository, string collection, string _id)
        {

        }

        private AmazonSQSClient CreateClient(IAppConfiguration appConfig)
        {
            var sqsConfig = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(appConfig.AWSRegion)
            };
            var awsCredentials = new AwsCredentials(appConfig);

            return  new AmazonSQSClient(awsCredentials, sqsConfig);
        }
    }
}