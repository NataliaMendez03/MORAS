﻿using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ISystemLoginRepository
    {
        Task<List<SystemLogin>> GetAll();
        Task<SystemLogin> GetSystemLogin(int idSystemLogin);
        Task<SystemLogin> CreateSystemLogin(string username, string password, int idPerson);
        Task<SystemLogin> UpdateSystemLogin(SystemLogin SystemLogin);
        Task<SystemLogin> DeleteSystemLogin(SystemLogin SystemLogin);
        Task<Login> AuthUser(string userName);

    }
    public class SystemLoginRepository : ISystemLoginRepository
    {
        private readonly berriesdbContext _db;
        public SystemLoginRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<SystemLogin> CreateSystemLogin(string username, string password, int idPerson)
        {
            Person? person = _db.Person.FirstOrDefault(ut => ut.IdPerson == idPerson);

            SystemLogin newSystemLogin = new SystemLogin
            {
                Username = username,
                Password = password,
                IdPerson = idPerson,
                RegisterDate = DateTime.Now,
                StateDelete = false,
                ModifyDate = null,
                Verified = null
            };

            await _db.SystemLogin.AddAsync(newSystemLogin);
            _db.SaveChanges();

            return newSystemLogin;
        }

        public async Task<SystemLogin> DeleteSystemLogin(SystemLogin SystemLogin)
        {
            _db.SystemLogin.Attach(SystemLogin); //Llamamos la actualizacion
            _db.Entry(SystemLogin).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return SystemLogin;
        }

        public async Task<List<SystemLogin>> GetAll()
        {
            return await _db.SystemLogin.ToListAsync();
        }

        public async Task<SystemLogin> GetSystemLogin(int idSystemLogin)
        {
            return await _db.SystemLogin.FirstOrDefaultAsync(u => u.IdSystemLogin == idSystemLogin);
        }


        // AUTENTICACION------------------------------------------------------------------------------
        public async Task<Login> AuthUser(string userName)
        {
            return await _db.Login.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<SystemLogin> UpdateSystemLogin(SystemLogin SystemLogin)
        {
            SystemLogin SystemLoginUpdate = await _db.SystemLogin.FindAsync(SystemLogin.IdSystemLogin);
            if (SystemLoginUpdate != null)
            {
                SystemLoginUpdate.Username = SystemLogin.Username;
                SystemLoginUpdate.Password = SystemLogin.Password;
                SystemLoginUpdate.IdPerson = SystemLogin.IdPerson;

                await _db.SaveChangesAsync();
            }
            return SystemLoginUpdate;
        }
    }
}