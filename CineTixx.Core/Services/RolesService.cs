using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Services
{
    public enum UserRoles
    {
        User,
        Admin
    }
    public class RolesService : IRoleService
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RolesService(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task CreateRoles()
        {
            string[] roles = { UserRoles.User.ToString(), UserRoles.Admin.ToString() };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }
    }
}
