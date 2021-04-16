using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using LearnGQL.DTO;
using LearnGQL.GraphQL.Data;
using LearnGQL.GraphQL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Users;
        }

        [UseDbContext(typeof(AppDbContext))]
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
