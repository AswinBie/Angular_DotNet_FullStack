using System;
using Domain.Interface;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity>(BlogDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    internal readonly DbSet<TEntity> DbSet = context.Set<TEntity>();
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await DbSet.AddAsync(entity);
        return entry.Entity;
        // throw new NotImplementedException();
    }

    public void DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        // throw new NotImplementedException();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
        // throw new NotImplementedException();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
        // throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        var entry =  DbSet.Update(entity);
        return entry.Entity;
        // throw new NotImplementedException();
    }
}
