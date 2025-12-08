using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using Models;

namespace Services;

// Interfaz para la lógica de negocio de Motores
public interface IMotorService
{
    Task<IEnumerable<Motor>> GetAllAsync();
    Task<Motor?> GetByIdAsync(int id);
    Task<Motor> CreateAsync(MotorCreateDTO dto);
    Task<Motor?> UpdateAsync(int id, MotorCreateDTO dto);
    Task<bool> DeleteAsync(int id);
}