using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Payments.Models;
using System.Net;
using Microsoft.Azure.Cosmos.Table;

namespace Payments.Data;
internal class TableDbContext
{
    private readonly StorageSettings _settings;

    private CloudTable _table;

    private readonly ILogger _log;


    public TableDbContext(ILogger<TableDbContext> logger, StorageSettings settings)
    {
        _log = logger;
        _settings = settings;
    }

    public async Task CreateTableAsync()
    {
        // Retrieve storage account information from connection string.
        CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString();

        // Create a table client for interacting with the table service
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

        _log.LogInformation("Create a Table for the demo");

        // Create a table client for interacting with the table service 
        _table = tableClient.GetTableReference(_settings.TableName);

        if (await _table.CreateIfNotExistsAsync())
        {
            _log.LogInformation($"Created Table named: {_settings.TableName}");
        }
        else
        {
            _log.LogInformation($"Table {_settings.TableName} already exists");
        }

    }

    public async Task<Payment> InsertOrMergeEntityAsync(Payment entity)
    {
        Payment result = null;
        try
        {
            if (_table is null)
            {
                await CreateTableAsync();
            }
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            // Create the InsertOrReplace table operation
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            TableResult tableResult = await _table.ExecuteAsync(insertOrMergeOperation);
            result = tableResult.Result as Payment;

            // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure CosmoS DB 
            if (tableResult.RequestCharge.HasValue)
            {
                _log.LogInformation($"Request Charge of InsertOrMerge Operation:{tableResult.RequestCharge}");
            }


        }
        catch (Exception e)
        {
            _log.LogInformation(e.Message);

        }
        return result;
    }

    public async Task<Payment> GetEntityAsync(Payment requestedPayment)
    {

        try
        {
            if (_table is null)
            {
                _log.LogInformation("table was null in GetEntityAsync");
                await CreateTableAsync();
            }

            TableOperation operation = TableOperation.Retrieve<Payment>(requestedPayment.PartitionKey, requestedPayment.RowKey);

            // Execute the operation.
            TableResult result = await _table.ExecuteAsync(operation);
            var payment = result.Result as Payment;

            return payment;
        }
        catch (StorageException e) when (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
        {
            _log.LogInformation(e.Message);
            return null;
        }

    }


    private CloudStorageAccount CreateStorageAccountFromConnectionString()
    {
        CloudStorageAccount storageAccount;
        try
        {
            storageAccount = CloudStorageAccount.Parse(_settings.StorageConnectionString);
        }
        catch (FormatException)
        {
            _log.LogInformation(
                "Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
            throw;
        }
        catch (ArgumentException)
        {
            _log.LogInformation(
                "Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");

            throw;
        }

        _log.LogInformation("Success!");
        return storageAccount;
    }


}