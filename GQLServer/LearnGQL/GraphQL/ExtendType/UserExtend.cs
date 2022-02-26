using HotChocolate;
using HotChocolate.Types;
using LearnGQL.Entities;
using LearnGQL.GraphQL.DataLoaders;
using System.Threading.Tasks;

namespace LearnGQL.GraphQL.ExtendType
{
    [ExtendObjectType(typeof(User))]
    public class UserExtend
    {
        public async Task<UserGroupInfo> GroupInfo([Parent] User user, [Service] UserGroupCountBatchDataLoader loader)
        {
            return await loader.LoadAsync(user.UserId);
        }
    }

    public record UserGroupInfo(int count, int? lastGroupId);

#nullable enable
    public record UserWithGroupInfo(User user, UserGroupInfo? groupInfo);
#nullable disable
}
