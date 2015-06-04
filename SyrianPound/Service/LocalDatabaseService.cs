﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SyrianPound.Model;
using Xamarin.Forms;

namespace SyrianPound.Service
{
    public class LocalDatabaseService
    {
        public static async Task IntializeDatabase()
        {           
            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();
            await localDbConnection.CreateTableAsync<RateTable>();           
        }

        public static async Task<IEnumerable<Rate>> GetRates()
        {           
            await IntializeDatabase();            
            List<Rate> result = new List<Rate>();

            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();

            var rates = localDbConnection.Table<RateTable>();
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
       
            return result;
        }


        public static async Task SyncLocalDatabase(IEnumerable<Rate> newRates)
        {            
            var localDbConnection = DependencyService.Get<ISQLite>().GetConnection();
            await localDbConnection.ExecuteAsync("Delete FROM RateTable", null).ContinueWith(rt =>
            {
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