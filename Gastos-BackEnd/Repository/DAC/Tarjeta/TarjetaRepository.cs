using Gastos_BackEnd.Entity;
using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gastos_BackEnd.Repository.DAC.Tarjeta
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly ILogger<TarjetaRepository> _logger;
        private  GastosDbContext _context;

        public TarjetaRepository(ILogger<TarjetaRepository> logger, GastosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Tarjetum> GetAllTarjetaByPersonaId(Guid personald)
        {
            List<Tarjetum> listTarjeta = new List<Tarjetum>();
            try
            {
                listTarjeta = _context.PersonaPorTarjeta.Where(x => x.PersonaId == personald).Select(x => x.Tarjeta).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las tarjetas por persona repository", ex.Message);
            }
            return listTarjeta;
        }

        public Tarjetum? GetById(string tarjetaId, string personaId)
        {
            Tarjetum tarjeta = null;
            try
            {
                tarjeta = _context.PersonaPorTarjeta.Where(x => x.PersonaId.ToString() == personaId && x.TarjetaId.ToString() == tarjetaId).Select(x => x.Tarjeta).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la tarjeta por id repository", ex.Message);
            }
            return tarjeta;
        }

        public Tarjetum? GetByNombre(string nombre)
        {
            Tarjetum tarjeta = null;
            try
            {
                tarjeta = _context.Tarjeta.FirstOrDefault(x => x.Nombre == nombre);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la tarjeta por nombre repository", ex.Message);
            }
            return tarjeta;
        }

        public List<TarjetaPorPeriodo> GetByPeriodoIdAndTarjetaId(string periodoId, Guid tarjetaId)
        {
            
            List<TarjetaPorPeriodo> listTarjetaPorPeriodo = new List<TarjetaPorPeriodo>();
            try
            {
                listTarjetaPorPeriodo = _context.TarjetaPorPeriodos
                    .Include(x => x.Gasto)
                    .Include(x => x.Gasto.TipoGastoldNavigation)
                    .Where(x => x.Periodold == Guid.Parse( periodoId ) && x.TarjetaId == tarjetaId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la tarjeta por periodo repository", ex.Message);
            }
            return listTarjetaPorPeriodo;

        }

        public PersonaPorTarjetum? GetByPersonaIdAndTarjetaId(Guid personald, Guid tarjetaId)
        {
            PersonaPorTarjetum personaPorTarjeta = null;
            try
            {
                personaPorTarjeta = _context.PersonaPorTarjeta.FirstOrDefault(x => x.PersonaId == personald && x.TarjetaId == tarjetaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la persona por tarjeta repository", ex.Message);
            }
            return personaPorTarjeta;
        }

        public bool SavePersonaPorTarjeta(PersonaPorTarjetum personaPorTarjetum)
        {
            bool savePersonaPorTarjeta = false;
            try
            {
                _context.PersonaPorTarjeta.Add(personaPorTarjetum);
                _context.SaveChanges();
                savePersonaPorTarjeta = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la persona por tarjeta repository", ex.Message);
            }
            return savePersonaPorTarjeta;
        }

        public bool SaveTarjeta(Tarjetum tarjeta)
        {
            bool saveTarjeta = false;
            try
            {
                _context.Tarjeta.Add(tarjeta);
                _context.SaveChanges();
                saveTarjeta = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la tarjeta repository", ex.Message);
            }
            return saveTarjeta;
        }

        public bool SaveTarjetaPorPeriodo(TarjetaPorPeriodo tarjetaPorPeriodo)
        {
            bool saveTarjetaPorPeriodo = false;
            try
            {
                _context.TarjetaPorPeriodos.Add(tarjetaPorPeriodo);
                _context.SaveChanges();
                saveTarjetaPorPeriodo = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la tarjeta por periodo repository", ex.Message);
            }
            return saveTarjetaPorPeriodo;
        }
    }
}
