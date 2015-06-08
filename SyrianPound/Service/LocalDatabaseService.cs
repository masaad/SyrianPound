using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SyrianPound.Model;
using Xamarin.Forms;

namespace SyrianPound.Service
{
    public class LocalDatabaseService
    {
        public static async Task IntializeDatabase()
        {
            Debug.WriteLine("LocalDatabaseService: IntializeDatabase....Start");
            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();
            await localDbConnection.CreateTableAsync<RateTable>();
            Debug.WriteLine("LocalDatabaseService: IntializeDatabase....Completed");
        }

        public static async Task<IEnumerable<Rate>> GetRates()
        {           
            await IntializeDatabase();            
            List<Rate> result = new List<Rate>();

            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();

            var rates = localDbConnection.Table<RateTable>();

            Debug.WriteLine("LocalDatabaseService: GetRates()....Map to Rate");
            await rates.ToListAsync().ContinueWith(rt =>
            {
                foreach (var rateRow in rt.Result)
                {
                    result.Add(new Rate
                    {
                        CurrencyInfo = new Currency {Name = rateRow.CurrencyName, Symbol = rateRow.CurrencySymbol},
                        Change = new RateChange() {Amount = rateRow.ChangeAmount, Type = rateRow.ChangeAmountType},
                        ExchangePrice = rateRow.ExchangePrice,
                        Trade = rateRow.Trade,
                        StartDate = rateRow.StartDate,
                        EndDate = rateRow.EndDate,
                        LastUpdated = rateRow.LastUpdated
                    });
                }
            });

            Debug.WriteLine("LocalDatabaseService: GetRates()....Map to Rate done!!!!!");
            return result;
        }


        public static async Task SyncLocalDatabase(IEnumerable<Rate> newRates)
        {            
            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();
            await localDbConnection.ExecuteScalarAsync<int>("Delete FROM Rate").ContinueWith(rt =>
            {
                localDbConnection.Table<RateTable>().CountAsync().ContinueWith(rr =>
                    Debug.WriteLine("LocalDatabaseService: SyncLocalDatabase.... OldRate Count: {0}", rr.Result));
                                   
                foreach (var newRate in newRates)
                {
                    localDbConnection.InsertAsync(new RateTable()
                    {
                        CurrencyName = newRate.CurrencyInfo.Name,
                        CurrencySymbol = newRate.CurrencyInfo.Symbol,
                        ChangeAmount = newRate.Change.Amount,
                        ChangeAmountType = newRate.Change.Type,
                        Trade = newRate.Trade,
                        ExchangePrice = newRate.ExchangePrice,
                        StartDate = newRate.StartDate,
                        EndDate = newRate.EndDate,
                        LastUpdated = newRate.LastUpdated
                    });
                }
            });          
        }
    }
}
