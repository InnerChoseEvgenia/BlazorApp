﻿using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.CategorySet.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.CategorySet.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.CategorySet.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.CategorySet.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.CategorySet.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _db.CategorySet.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                _db.CategorySet.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
