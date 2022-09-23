using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace FirstRealApp.Models
{
    //template pagination
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public Pagination(List<T> poodles, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(poodles);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage()
        {
            return (PageIndex < TotalPages);
        }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }


    }
}
