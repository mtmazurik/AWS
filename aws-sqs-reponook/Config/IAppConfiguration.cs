namespace AWSQueueReponook.Config
{
    public interface IAppConfiguration
    {
        string AtlasMongoConnection { get; }
        string AWSQueueURI { get; }
        string AWSRegion { get; }
        string AWSAccessKey { get; }
        string AWSSecretKey { get; }
    }
}