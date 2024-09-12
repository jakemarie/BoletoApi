using BoletoApi.Models;

namespace BoletoApi.Service.BoletoService
{
    public interface IBoletoInterface
    {
        Task<ServiceResponse<List<BoletoModel>>> GetBoletos();
        Task<ServiceResponse<List<BoletoModel>>> CreateBoletos(BoletoModel novoBoleto);
        Task<ServiceResponse<BoletoModel>> GetBoletoById(int id);
        Task<ServiceResponse<List<BoletoModel>>> UpdateBoleto(BoletoModel EditandoBoleto);
        Task<ServiceResponse<List<BoletoModel>>> DeleteBoleto(int id);

    }
}
