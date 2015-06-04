using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using System.Web.UI.WebControls;
using AutoMapper;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using SyrianPoundService.DataObjects;
using SyrianPoundService.Models;

namespace SyrianPoundService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class RatesController : TableController<Rate>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SyrianPoundContext context = new SyrianPoundContext();
            DomainManager = new EntityDomainManager<Rate>(context, Request, Services);
        }

        // GET tables/Rates
        public IQueryable<RateDTO> GetActiveRates()
        {
            var rates = Query().Where(rate => rate.StartDate <= DateTime.Now &&
                                              (!rate.EndDate.HasValue || rate.EndDate > DateTime.Now))
                .Include(x => x.CurrencyInfo)
                .Include(x => x.Change); 
          
            Mapper.CreateMap<Currency, CurrencyDTO>();
            Mapper.CreateMap<RateChange, RateChangeDTO>(); 
            var map = Mapper.CreateMap<Rate, RateDTO>();
           
            map.ForAllMembers(opt => opt.Ignore());
            map.ForMember(des => des.CurrencyInfo, src => src.MapFrom(m => m.CurrencyInfo));
            map.ForMember(des => des.Change, src => src.MapFrom(m => m.Change));
            map.ForMember(des => des.LastUpdated, src => src.MapFrom(m => m.UpdatedAt));
            map.ForMember(des => des.ExchangePrice, src => src.MapFrom(m => m.ExchangePrice));
            map.ForMember(des => des.StartDate, src => src.MapFrom(m => m.StartDate));
            map.ForMember(des => des.EndDate, src => src.MapFrom(m => m.EndDate));
            map.ForMember(des => des.Trade, src => src.MapFrom(m => m.Trade));       
            return Mapper.Map(rates, new List<RateDTO>()).AsQueryable();
        }     

        //// GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public SingleResult<TodoItem> GetTodoItem(string id)
        //{
        //    return Lookup(id);
        //}

        //// PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        //{
        //    return UpdateAsync(id, patch);
        //}

        //// POST tables/TodoItem
        //public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        //{
        //    TodoItem current = await InsertAsync(item);
        //    return CreatedAtRoute("Tables", new { id = current.Id }, current);
        //}

        //// DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        //public Task DeleteTodoItem(string id)
        //{
        //    return DeleteAsync(id);
        //}
    }
}