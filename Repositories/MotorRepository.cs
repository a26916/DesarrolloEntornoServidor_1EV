using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories;

public class MotorRepository : IMotorRepository
{
    // SIMULACIÓN DE BASE DE DATOS: Lista estática para guardar los motores.
    private static List<Motor> _motores = new List<Motor>
    {
        // Atributos de tu modelo Motor: Combustible, Cilindrada, PotenciaCV, IdMotor
        new Motor(combustible: "Gasolina", cilindrada: 2000, potenciaCV: 150, idMotor: 1),
        new Motor(combustible: "Eléctrico", cilindrada: 0, potenciaCV: 200, idMotor: 2)
    };
    private static int _nextId = 3;

    public async Task<IEnumerable<Motor>> GetAllAsync()
    {
        return await Task.FromResult(_motores.AsEnumerable());
    }

    public async Task<Motor?> GetByIdAsync(int id)
    {
        return await Task.FromResult(_motores.FirstOrDefault(m => m.IdMotor == id));
    }

    public async Task<Motor> AddAsync(Motor newMotor)
    {
        newMotor.IdMotor = _nextId++;
        _motores.Add(newMotor);
        return await Task.FromResult(newMotor);
    }

    public async Task<Motor?> UpdateAsync(Motor motor)
    {
        var existingMotor = _motores.FirstOrDefault(m => m.IdMotor == motor.IdMotor);
        if (existingMotor != null)
        {
            existingMotor.Combustible = motor.Combustible;
            existingMotor.Cilindrada = motor.Cilindrada;
            existingMotor.PotenciaCV = motor.PotenciaCV;
            // No actualizamos el IdMotor
            return await Task.FromResult(existingMotor);
        }
        return await Task.FromResult<Motor?>(null);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var motorToRemove = _motores.FirstOrDefault(m => m.IdMotor == id);
        if (motorToRemove != null)
        {
            _motores.Remove(motorToRemove);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}