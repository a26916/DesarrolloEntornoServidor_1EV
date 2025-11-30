using Models;
using DTO;

namespace Services;

public interface IMotorService
{
    // READ
    Task<Motor?> GetByIdAsync(int id);
    Task<IEnumerable<Motor>> GetAllAsync();

    // CREATE
    Task<Motor> CreateAsync(MotorCreateDTO dto);
    
    // UPDATE
    Task<Motor?> UpdateAsync(int id, MotorCreateDTO dto);

    // DELETE
    Task<bool> DeleteAsync(int id);
}