using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gastos_BackEnd.Repository.DAC.Ingreso
{
    public class IngresoRepository : IIngresoRepository
    {
        private readonly ILogger<IngresoRepository> _logger;
        private  GastosDbContext _context;

        public IngresoRepository(ILogger<IngresoRepository> logger, GastosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Entity.Ingreso GetByIngresoPersonaId(Guid personald)
        {
            IngresoPorPersona ingresoPorPersona = new IngresoPorPersona();

            try
            {

                ingresoPorPersona = _context.IngresoPorPersonas
                                            .Include(x => x.IngresoldNavigation) // Incluir la entidad relacionada si es necesario
                                            .Where(x => x.Personald == personald)
                                            .OrderBy(x => x.Ingresold)
                                            .LastOrDefault()!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el ingreso por persona repository", ex.Message);
                
            }

            return ingresoPorPersona.IngresoldNavigation;



        }

        public bool SaveIngreso(Entity.Ingreso ingresoEntity)
        {
            bool saveIngreso = false;
            try
            {
                _context.Ingresos.Add(ingresoEntity);
                _context.SaveChanges();
                saveIngreso = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el ingreso repository", ex.Message);
            }
            return saveIngreso;
        }

        public bool SaveIngresoPorPersona(IngresoPorPersona ingresoPorPersona)
        {
            bool saveIngresoPorPersona = false;
            try
            {
                _context.IngresoPorPersonas.Add(ingresoPorPersona);
                _context.SaveChanges();
                saveIngresoPorPersona = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el ingreso por persona repository", ex.Message);
            }
            return saveIngresoPorPersona;
        }
    }
}
