using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Repository.DAC.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
		private readonly GastosDbContext _context;
		private readonly ILogger<CategoriaRepository> _logger;

		public CategoriaRepository(GastosDbContext context, ILogger<CategoriaRepository> logger) { 
			_logger = logger;
			_context = context;
		}
        public List<Categorium> GetAllCategoria()
        {
			List<Categorium> listCategoria = null;

            try
			{
				 listCategoria = _context.Categoria.ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener categorias", ex.Message);
			}
			return listCategoria;
        }

        public Categorium GetByIdCategoria(string categoriaId)
        {
			Categorium? categorium = new Categorium();
			try
			{
				categorium = _context.Categoria.Where(x => x.Categoriald.ToString().Equals(categoriaId)).FirstOrDefault();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener categorias", ex.Message);

			}
			return categorium;
        }
    }
}
