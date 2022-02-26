using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using LearnGQL.Data;
using LearnGQL.Entities;
using System.Reflection;

namespace LearnGQL.GraphQL
{
    public class IdentityResolver : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {

            descriptor.Resolve(ctx =>
            {
                User user = ctx.Parent<User>();
                var dbContext = ctx.Service<IdentityDbContext>();
                return dbContext.Identities.Find(user.UserId);
            });
        }
    }
}
