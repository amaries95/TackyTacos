namespace Payments.Data;
internal class StorageSettings
{
    public string StorageConnectionString { get; set; }
    public string BlobContainerName { get; set; }
    public string TableName { get; set; }
}