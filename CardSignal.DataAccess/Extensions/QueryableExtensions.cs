using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> WithTracking<T>(this IQueryable<T> queryable, bool track)
        where T : class
    {
        return track ? queryable.AsTracking() : queryable.AsNoTracking();
    }
}