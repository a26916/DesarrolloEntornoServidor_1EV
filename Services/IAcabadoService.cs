using Models;
using DTO;

namespace Services;

public interface IAcabadoService
{
    Task<Acabado?> GetByIdAsync(int id);
    Task<IEnumerable<Acabado>> GetAllAsync();
    
    Task<Acabado> CreateAsync(AcabadoCreateDTO dto);
    
    Task<Acabado?> UpdateAsync(int id, AcabadoCreateDTO dto);
    Task<bool> DeleteAsync(int id);
}