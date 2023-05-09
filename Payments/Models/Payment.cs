using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Azure.Cosmos.Table;

namespace Payments.Models;

internal class Payment : TableEntity
{
    public Payment()
    {
        Timestamp = DateTime.UtcNow;
        PartitionKey = Timestamp.DayOfYear.ToString();
    }
    internal string Authorisation { get; set; } = string.Empty;
    internal bool IsSuccessful { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}