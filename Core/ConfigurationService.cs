using UserRegistrationAndLoginDemo.Common.Helpers;

namespace merXcoin.Services
{
    public static class ConfigurationService
    {
        public static string JwtSecretKey => ConfigurationHelper.GetValue("Jwt:Secretkey");

        public static string QBitBaseUri => ConfigurationHelper.GetValue("QBit:BaseUri");

        public static string QBitSecret => ConfigurationHelper.GetValue("QBit:Secret");

        public static string QBitOutputId => ConfigurationHelper.GetValue("QBit:OutputId");

        public static string AzureStorageTableName => ConfigurationHelper.GetValue("AzureStorage:TableName");

        public static string AzureStorageBlobName => ConfigurationHelper.GetValue("AzureStorage:BlobName");

        public static string AzureStorageConnectionString => ConfigurationHelper.GetValue("AzureStorage:ConnectionString");

        public static string AzurePaymentContainer => ConfigurationHelper.GetValue("AzureStorage:Payment");

        public static string AzureExchangeContainer => ConfigurationHelper.GetValue("AzureStorage:ExchangeContainer");

        public static string StripeSecretAPIKey => ConfigurationHelper.GetValue("Stripe:APISecretKey");

        public static string AzureStorageBuyingTableName => ConfigurationHelper.GetValue("AzureStorage:BuyingTableName");

        public static string AzureStorageSellingTableName => ConfigurationHelper.GetValue("AzureStorage:SellingTableName");

        public static string BtcExchangeRates => ConfigurationHelper.GetValue("Btc:ExchangeRates");

        public static string BtcHistoricGraph => ConfigurationHelper.GetValue("Btc:HistoricGraph");

        public static string BtcAddress => ConfigurationHelper.GetValue("Btc:Address");

        public static string BtcSecret => ConfigurationHelper.GetValue("Btc:Secret");

        public static string SmartBitBaseUri => ConfigurationHelper.GetValue("SmartBit:BaseUri");

        public static string BUYINGPROCESSQUEUE => ConfigurationHelper.GetValue("BUYINGPROCESSQUEUE");

        public static string SELLINGPROCESSQUEUE => ConfigurationHelper.GetValue("SELLINGPROCESSQUEUE");

        public static string TRANSACTIONNOTIFIERQUEUE => ConfigurationHelper.GetValue("TRANSACTIONNOTIFIERQUEUE");
    }
}
