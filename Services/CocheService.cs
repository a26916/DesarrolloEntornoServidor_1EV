using DTO;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services;

// La clase MotorService implementa todos los métodos de IMotorService
public class MotorService : IMotorService
{
    // Datos de prueba para simular la base de datos (MOCK DATA)
    private readonly List<Motor> _motores = new List<Motor>
    {
        new Motor { IdMotor = 1, Tipo = "V8", Potencia = 450, Combustible = "Gasolina" },
        new Motor { IdMotor = 2, Tipo = "E1", Potencia = 150, Combustible = "Eléctrico" }
    };
    
    private int _nextId = 3;

    public async Task<IEnumerable<Motor>> GetAllAsync()
    {
        // En una aplicación real, aquí iría la llamada al Repositorio.
        // Por ahora, devolvemos los datos simulados.
        return await Task.FromResult(_motores);
    }

    public async Task<Motor> GetByIdAsync(int id)
    {
        // Buscamos el motor por ID en la lista simulada.
        var motor = _motores.FirstOrDefault(m => m.IdMotor == id);
        return await Task.FromResult(motor);
    }

    public async Task<Motor> CreateAsync(MotorCreateDTO dto)
    {
        var nuevoMotor = new Motor
        {
            IdMotor = _nextId++,
            Tipo = dto.Tipo,
            Potencia = dto.Potencia,
            Combustible = dto.Combustible // Asumiendo que el DTO tiene un campo Combustible
        };

        _motores.Add(nuevoMotor);
        return await Task.FromResult(nuevoMotor);
    }
    
    // **NOTA:** Tendrías que implementar también UpdateAsync y DeleteAsync
    public Task<Motor> UpdateAsync(int id, MotorCreateDTO dto)
    {
        // Implementación pendiente
        return Task.FromResult<Motor>(null);
    }
    
    public Task<bool> DeleteAsync(int id)
    {
        // Implementación pendiente
        return Task.FromResult(false);
    }
}