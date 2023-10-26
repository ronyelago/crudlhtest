using LGApi.Entities;
using LGApi.Infra;
using LGApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LGApi.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly LgApiContext context;

    public ContaRepository(LgApiContext context) => this.context = context;
    
    public async Task<Conta?> GetById(int id)
    {
        return await context.Set<Conta>().FindAsync(id);
    }

    public async Task<IEnumerable<Conta>> GetAll()
    {
        return await context.Set<Conta>().ToListAsync();
    }

    public async Task Add(Conta conta)
    {
        context.Set<Conta>().Add(conta);
        await context.SaveChangesAsync();
    }

    public async Task Update(Conta conta)
    {
        context.Entry(conta).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task Delete(Conta conta)
    {
        context.Set<Conta>().Remove(conta);
        await context.SaveChangesAsync();
    }
}