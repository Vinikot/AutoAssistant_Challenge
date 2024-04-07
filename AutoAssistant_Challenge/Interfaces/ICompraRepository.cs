using AutoAssistant_Challenge.Models;

namespace AutoAssistant_Challenge.Interfaces
{
    public interface ICompraRepository
    {
        ICollection<CompraModel> GetCompras();
        CompraModel GetCompra(int id);
        bool CompraExists(int compraId);
        bool CreateCompra(CompraModel compra);
        bool UpdateCompra(CompraModel compra);
        bool DeleteCompra(CompraModel compra);
        bool Save();
    }
}
