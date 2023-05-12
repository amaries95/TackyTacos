namespace Orders.Data;
internal class MongoDbSettings
{
    public string Database { get; set; }
    public string ConnectionString { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public Options Options { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string OrdersCollectionName { get; set; }
}

internal class Options
{
    public string ReplicaSet { get; set; }
}