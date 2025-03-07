﻿using Microsoft.EntityFrameworkCore;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DataAccessLayer.Repositories
{
    public class GenericRepository<T> :IGenericDal<T> where T : class
    {
        private readonly MySchoolDbContext _context;

        public GenericRepository(MySchoolDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var values = await _context.Set<T>().FindAsync(id);            
            _context.Set<T>().Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values= await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var values =await _context.Set<T>().FindAsync(id);
            return values;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
