using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using SyrianPoundService.DataObjects;
using SyrianPoundService.Models;

namespace SyrianPoundService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new SyrianPoundInitializer());
        }
    }

    public class SyrianPoundInitializer : ClearDatabaseSchemaIfModelChanges<SyrianPoundContext>
    {
        protected override void Seed(SyrianPoundContext context)
        {

            List<Currency> currencies = new List<Currency>
            {
                new Currency() { Id = Guid.NewGuid().ToString(), Country = "U.S.A", Symbol = "$", Name = "Dollar", CreatedBy = "masaad"}, 
                 new Currency() { Id = Guid.NewGuid().ToString(), Country = "European Union", Symbol = "€", Name = "Euro", CreatedBy = "masaad"}
            };

            foreach (Currency curr in currencies)
            {
                context.Set<Currency>().Add(curr);
            }

            base.Seed(context);
        }
    }
}

