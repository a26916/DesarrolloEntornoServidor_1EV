using Models;
using DTOs;
// Asegúrate de importar el namespace donde tengas la interfaz del repositorio
// using Repositories; 

namespace Services
{
    public class MotorService : IMotorService
    {
        // Inyección de dependencia del Repositorio
        private readonly IMotorRepository _motorRepository;

        public MotorService(IMotorRepository motorRepository)
        {
            _motorRepository = motorRepository;
        }

        // 1. OBTENER TODOS
        public async Task<IEnumerable<Motor>> GetAllAsync()
        {
            return await _motorRepository.GetAllAsync();
        }

        // 2. OBTENER POR ID
        public async Task<Motor?> GetByIdAsync(int id)
        {
            return await _motorRepository.GetByIdAsync(id);
        }

        // 3. CREAR
        public async Task<Motor> CreateAsync(MotorCreateDTO dto)
        {
            // Mapeo manual de DTO a Modelo (Entidad)
            // Si usaras AutoMapper esto sería una sola línea, pero así es explícito:
            var nuevoMotor = new Motor
            {
                Combustible = dto.Combustible,
                Cilindrada = dto.Cilindrada,
                PotenciaCV = dto.PotenciaCV
                // El IdMotor normalmente lo genera la base de datos, así que no lo asignamos aquí
            };

            return await _motorRepository.CreateAsync(nuevoMotor);
        }

        // 4. ACTUALIZAR
        public async Task<Motor?> UpdateAsync(int id, MotorCreateDTO dto)
        {
            // Primero buscamos si existe
            var motorExistente = await _motorRepository.GetByIdAsync(id);

            if (motorExistente == null)
            {
                return null; // O lanzar una excepción según tu lógica
            }

            // Actualizamos los campos con los datos del DTO
            motorExistente.Combustible = dto.Combustible;
            motorExistente.Cilindrada = dto.Cilindrada;
            motorExistente.PotenciaCV = dto.PotenciaCV;

            // Llamamos al repositorio para guardar cambios
            // Asumo que tu repositorio tiene un método UpdateAsync que devuelve el motor actualizado
            return await _motorRepository.UpdateAsync(motorExistente);
        }

        // 5. BORRAR
        public async Task<bool> DeleteAsync(int id)
        {
            // Asumo que el repositorio devuelve true si borró, false si no existía
            return await _motorRepository.DeleteAsync(id);
        }
    }
}