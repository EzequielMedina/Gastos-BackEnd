using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Repository.DAC.TiposDeGastos
{
    public class TiposDeGastosRepository : ITiposDeGastosRepository
    {
        private  GastosDbContext _context;
        private readonly ILogger<TiposDeGastosRepository> _logger;

        public TiposDeGastosRepository(GastosDbContext context, ILogger<TiposDeGastosRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public List<TipoGasto> GetTiposDeGastos()
        {
            List<TipoGasto> listTipoGasto = null;
            try
            {
                listTipoGasto = _context.TipoGastos.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de gastos", ex.Message);
                
            }
            return listTipoGasto;
        }

        public TipoGasto GetByIdTipoGasto(string tipoGastoId)
        {
            TipoGasto? tipoGasto = new TipoGasto();
            try
            {
                tipoGasto = _context.TipoGastos.Where(x => x.TipoGastold.ToString().Equals(tipoGastoId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de gastos", ex.Message);

            }
            return tipoGasto;
        }
    }
}
