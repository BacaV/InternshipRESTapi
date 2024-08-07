﻿using Product.Datalayer.Model;
using Microsoft.EntityFrameworkCore;
using Product.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.DataLayer.Repository;

namespace DataAccessLayer.Repository
{
    public class UsersRepository :  IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UsersRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await appDbContext.Users.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await appDbContext.Users.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception(message: "User not found");
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            try
            {
                return await appDbContext.Users.FirstOrDefaultAsync(e => e.Username == name) ?? throw new DbUpdateException();
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            try
            {
                var user = appDbContext.Users.Add(newUser);
                await appDbContext.SaveChangesAsync();
                return user.Entity;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

    }
}
