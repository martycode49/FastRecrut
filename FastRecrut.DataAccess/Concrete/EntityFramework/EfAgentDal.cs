﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfAgentDal : EfEntityRepositoryBase<EfAgentDal,FastRecrutDbContext>, IAgentDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfAgentDal(FastRecrutDbContext dbContext) : base(dbContext)
        {
        }


        public Agent Get(Expression<Func<Agent, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Agent> GetAll(Expression<Func<Agent, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Agent entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Agent entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Agent entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Agent> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _FastRecrutDbContext.Agents
                .SingleOrDefaultAsync(x => x.Email == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<Agent> Create(Agent agent, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");
            var resultUser = await _FastRecrutDbContext.Agents.AnyAsync(x => x.Email == agent.Email);
            if (resultUser)
                throw new Exception("Email \"" + agent.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            agent.PasswordHash = passwordHash;
            agent.PasswordSalt = passwordSalt;

            await _FastRecrutDbContext.Agents.AddAsync(agent);

            return agent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentAsync()
        {
            return await _FastRecrutDbContext.Agents
             .ToListAsync();
        }

        public async Task<Agent> GetWithAgentsByIdAsync(int id)
        {
            return await _FastRecrutDbContext.Agents
                    .Where(user => user.Id == id)
                    .FirstOrDefaultAsync();
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void Update(Agent agentParam, string password = null)
        {
            var user = _FastRecrutDbContext.Agents.Find(agentParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (agentParam.Email != user.Email)
            {
                // username has changed so check if the new username is already taken
                if (_FastRecrutDbContext.Agents.Any(x => x.Email == agentParam.Email))
                    throw new Exception("Username " + agentParam.Email + " is already taken");
            }

            // update user properties
            user.Firstname = agentParam.Firstname;
            user.Lastname = agentParam.Lastname;
            user.Email = agentParam.Email;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _FastRecrutDbContext.Agents.Update(user);
        }
    }
}
