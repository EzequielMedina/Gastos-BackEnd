using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gastos_BackEnd.Repository.DAC.Periodo
{
    public class PeriodoRepository : IPeriodoRepository
    {
        private  GastosDbContext _context;
        private readonly ILogger<PeriodoRepository> _logger;

        public PeriodoRepository(GastosDbContext context, ILogger<PeriodoRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public bool SavePeriodo(Entity.Periodo periodo)
        {
            bool save = false;
            try
            {
                _context.Periodos.Add(periodo);
                _context.SaveChanges();
                save = true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al guardar periodo", ex.Message);

            }
            return save;
        }

        public List<Entity.Periodo> GetAllPeriodo()
        {
            List<Entity.Periodo> listPeriodo = new List<Entity.Periodo>();
            try
            {
                listPeriodo = _context.Periodos.ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener periodos", ex.Message);
            }
            return listPeriodo;
        }

        public bool SavePeriodoXGasto(PeriodoPorGasto periodoPorGasto)
        {
            bool save = false;
            try
            {
                _context.PeriodoPorGastos.Add(periodoPorGasto);
                _context.SaveChanges();
                save = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar periodo por gasto", ex.Message);
            }
            return save;
        }

        public Entity.Periodo? GetByIdPeriodo(string periodoId)
        {
            Entity.Periodo? periodo = null;
            try
            {
                periodo = _context.Periodos.Where(x => x.Periodold.ToString().Equals(periodoId)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

            return periodo;
        }

        public List<PeriodoPorGasto> GetByPeriodoIdPorGasto(string periodoId)
        {
            List<PeriodoPorGasto> periodoPorGastos = new List<PeriodoPorGasto>();
            try
            {
                periodoPorGastos = _context.PeriodoPorGastos
                    .Include(x => x.Gasto)
                    .Include(x => x.Gasto.TipoGastoldNavigation)// Incluye la propiedad de navegación Gasto
                    .Include(x => x.Gasto.PersonaldNavigation)// Incluye la propiedad de navegación Persona
                    .Where(x => x.Periodold.ToString().Equals(periodoId))
                    .ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener periodo por gasto", ex.Message);
            }
            return periodoPorGastos;
        }
    }
}
