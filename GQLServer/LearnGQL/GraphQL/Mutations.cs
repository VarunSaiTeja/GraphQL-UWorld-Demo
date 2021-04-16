using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using LearnGQL.GraphQL.Data;
using LearnGQL.GraphQL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LearnGQL.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<School> ChangeSchoolNameAsync(int schoolId, string schoolName, [ScopedService] AppDbContext dbContext)
        {
            var school = dbContext.Schools.Find(schoolId);
            school.SchoolName = schoolName;
            await dbContext.SaveChangesAsync();
            return school;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UserGroup> AddUserToGroup(int userId, int groupId, Role role,
            [ScopedService] AppDbContext dbContext, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var userGroup = new UserGroup { GroupId = groupId, UserId = userId, Role = role };
            dbContext.UserGroups.Add(userGroup);
            await dbContext.SaveChangesAsync(cancellationToken);

            await dbContext.Entry(userGroup).Reference(x => x.User).LoadAsync(cancellationToken);
            await dbContext.Entry(userGroup).Reference(x => x.Group).LoadAsync(cancellationToken);

            //await eventSender.SendAsync(nameof(Subscriptions.OnUserAddedToGroup), userGroup, cancellationToken);
            await eventSender.SendAsync(nameof(Subscriptions.OnUserAddedToGroup) + "-" + groupId, userGroup, cancellationToken);
            return userGroup;
        }
    }
}
