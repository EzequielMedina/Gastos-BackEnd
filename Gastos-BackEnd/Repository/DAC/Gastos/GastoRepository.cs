using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Repository.DAC.Gastos
{
    public class GastoRepository : IGastoRepository
    {
        private  GastosDbContext _context;
        private readonly ILogger<GastoRepository> _logger;

        public GastoRepository(GastosDbContext context, ILogger<GastoRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public bool SaveGasto(Gasto gastoRequest)
        {
            bool save = false;
            try
            {
                _context.Gastos.Add(gastoRequest);
                _context.SaveChanges();
                save = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar gasto", ex.Message);
            }

            return save;
        }

        public List<Gasto> GetByPersonaId(Guid personald)
        {
            List<Gasto> listGasto = new List<Gasto>();
            try
            {
                listGasto = _context.Gastos.Where(x => x.Personald == personald).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener gastos por persona gastoRepository ", ex.Message);
            }
            return listGasto;
        }
    }
}
