using BoletoApi.Data;
using BoletoApi.Models;

namespace BoletoApi.Service.BoletoService
{
    public class BoletoService : IBoletoInterface
    {
        private readonly AppDbContext _context;
        public BoletoService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<BoletoModel>>> CreateBoletos(BoletoModel novoBoleto)
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = new ServiceResponse<List<BoletoModel>>();
            try
            {
                if (novoBoleto == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                }

                _context.Add(novoBoleto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Boletos.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BoletoModel>>> DeleteBoleto(int id)
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = new ServiceResponse<List<BoletoModel>>();
            try
            {
                BoletoModel boleto = _context.Boletos.FirstOrDefault(x => x.Id == id);

                if (boleto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Boleto não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Boletos.Remove(boleto);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Boletos.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<BoletoModel>> GetBoletoById(int id)
        {
            ServiceResponse<BoletoModel> serviceResponse = new ServiceResponse<BoletoModel>();
            try
            {
                BoletoModel boleto = _context.Boletos.FirstOrDefault(x => x.Id == id);
                if (boleto == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Boleto não Localizado!";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = boleto;
            }
            catch(Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BoletoModel>>> GetBoletos()
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = new ServiceResponse<List<BoletoModel>>();
            try
            {
                serviceResponse.Dados = _context.Boletos.ToList();
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nehum boleto encontrado. ";
                }
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BoletoModel>>> UpdateBoleto(BoletoModel EditandoBoleto)
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = new ServiceResponse<List<BoletoModel>>();
            try
            {
                BoletoModel boleto = _context.Boletos.FirstOrDefault(x => x.Id == EditandoBoleto.Id);
                if (boleto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Boleto não Localizado!";
                    serviceResponse.Sucesso = false;
                }
                boleto.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Boletos.Update(EditandoBoleto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Boletos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
