using Models;
using DTO;

namespace Services;

public interface IRuedaService
{
    Task<Rueda?> GetByIdAsync(int id);
    Task<IEnumerable<Rueda>> GetAllAsync();
    Task<Rueda> CreateAsync(RuedaCreateDTO dto);
    Task<Rueda?> UpdateAsync(int id, RuedaCreateDTO dto);
    Task<bool> DeleteAsync(int id);
}