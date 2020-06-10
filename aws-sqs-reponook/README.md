# aws_queue_reponook
2nd tier REST API service in pod example for wrappering the messaging from .NET Core micro service (in Docker or K8s) to AWS SQS (queue).

I refactored the shell of a REST API the writing of a Repository object to the SQS queue called 'aws_queue_reponook'.  It uses the AWS Access Key and AWS Secret Key and Region and Queue Url from launchSettings.json in Visual Studio inside of the AppConfiguration.cs, but of course those are not published into Github.

Write works pointing to localhost:8192 running the Docker container inside VS2019.

