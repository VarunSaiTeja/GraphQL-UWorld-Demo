using GreenDonut;
using LearnGQL.Data;
using LearnGQL.GraphQL.ExtendType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearnGQL.GraphQL.DataLoaders
{
    public class UserGroupCountBatchDataLoader : BatchDataLoader<int, UserGroupInfo>
    {
        AppDbContext dbContext;
        public UserGroupCountBatchDataLoader(IDbContextFactory<AppDbContext> appDbFactory, IBatchScheduler batchScheduler, DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            dbContext = appDbFactory.CreateDbContext();
        }

        protected override async Task<IReadOnlyDictionary<int, UserGroupInfo>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await dbContext.UserGroups.Where(x => keys.Contains(x.UserId))
                .GroupBy(x => x.UserId)
                .Select(x => new { userId = x.Key, groupInfo = new UserGroupInfo(x.Count(), x.Max(m => m.GroupId)) })
                .ToDictionaryAsync(x => x.userId, x => x.groupInfo, cancellationToken: cancellationToken);
        }
    }
}
