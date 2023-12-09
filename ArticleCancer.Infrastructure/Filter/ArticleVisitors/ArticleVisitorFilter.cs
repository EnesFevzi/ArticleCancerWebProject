using ArticleCancer.Domain.Entities;
using ArticleCancer.Persistence.UnıtOfWorks;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Filter.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnıtOfWork _unitOfWork;

        public ArticleVisitorFilter(IUnıtOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public bool Disable { get;set; }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result;


            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new(getIp, getUserAgent);



            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))
                return next();
            else
            {
                _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                _unitOfWork.Save();
            }
            return next();


        }
    }
}
