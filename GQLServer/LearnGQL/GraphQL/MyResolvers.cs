using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using LearnGQL.GraphQL.Data;
using LearnGQL.GraphQL.Models;
using System.Reflection;

namespace LearnGQL.GraphQL
{
    public class IdentityResolver : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.Resolver(ctx =>
            {
                User user = ctx.Parent<User>();
                var dbContext = ctx.Service<IdentityDbContext>();
                return dbContext.Identities.Find(user.UserId);
            });
        }
    }
}
