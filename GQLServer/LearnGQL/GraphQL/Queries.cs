using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using LearnGQL.Data;
using LearnGQL.DTO;
using LearnGQL.Entities;
using LearnGQL.GraphQL.DataLoaders;
using LearnGQL.GraphQL.ExtendType;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearnGQL.GraphQL
{
    public class Queries
    {
        public TokenInfo GetMyToken([Required, MinLength(4, ErrorMessage = "UserName must be 4 letters")] string userName, [Required] string userId, [Service] IConfiguration _configuration)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var securitytoken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddDays(14),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new TokenInfo()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securitytoken),
                ExpiresAt = DateTimeOffset.UtcNow.AddDays(14),
                IssuedAt = DateTimeOffset.UtcNow,
                UserName = userName
            };
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Group> GetGroups([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Groups;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Courses;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Implementation> GetImplementations([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Implementations;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CourseImplementation> GetCourseImplementations([ScopedService] AppDbContext dbContext)
        {
            return dbContext.CourseImplementations;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Users;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UserGroupInfo> GetUserGroupCount(int userId, UserGroupCountBatchDataLoader loader)
        {
            return await loader.LoadAsync(userId);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<IQueryable<UserWithGroupInfo>> UserWithGroupInfos([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Users.Select(x => new UserWithGroupInfo
            (x,
                new UserGroupInfo
                (
                    dbContext.UserGroups.Count(ug => ug.UserId == x.UserId),
                    dbContext.UserGroups.Where(ug => ug.UserId == x.UserId).Max(x => x.GroupId)
                )
            ));
        }

        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<School> GetSchools([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Schools;
        }

        [UseDbContext(typeof(AppDbContext))]
        [Authorize]
        public IQueryable<Identity> GetIdentities([Service] IdentityDbContext dbContext)
        {
            return dbContext.Identities;
        }
    }
}
