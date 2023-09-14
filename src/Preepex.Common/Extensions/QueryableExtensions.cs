using Preepex.Common.Paging;
using System;
using System.Linq;

namespace Preepex.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {

            var pageIndex = page == 0 ? 1 : page;
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);


            var skip = (pageIndex - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}