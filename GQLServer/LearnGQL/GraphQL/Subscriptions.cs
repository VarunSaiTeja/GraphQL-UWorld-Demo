using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using LearnGQL.GraphQL.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LearnGQL.GraphQL
{
    public class Subscriptions
    {
        [Subscribe, GraphQLDeprecated("Use OnUserAddedToGroup for group level subscription")]
        public UserGroup OnUserAddedToGroups([EventMessage] UserGroup userGroup)
        {
            return userGroup;
        }

        [Subscribe(With = nameof(SubscribeToOnUserAddedToGroupAsync))]
        public UserGroup OnUserAddedToGroup(int groupId, [EventMessage] UserGroup userGroup,
            CancellationToken cancellationToken)
        {
            return userGroup;
        }

        [SubscribeAndResolve]
        [Authorize]
        public async IAsyncEnumerable<string> OnMessageAsync([GlobalState("ClaimsPrincipal")] ClaimsPrincipal User)
        {
            yield return "Hey Hello!";
            await Task.Delay(2000);
            yield return "It Changed?";
            await Task.Delay(2000);
            yield return "Your User Id is " + User.Identity.Name;
            await Task.Delay(2500);
            yield return "It Never Changes Because It Doesn't Work";
        }


        public async ValueTask<ISourceStream<UserGroup>> SubscribeToOnUserAddedToGroupAsync(
            int groupId,
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken) =>
            await eventReceiver.SubscribeAsync<string, UserGroup>(
                nameof(OnUserAddedToGroup) + "-" + groupId, cancellationToken);
    }
}
