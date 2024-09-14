using System.Text.Json.Serialization;

namespace BoletoApi.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusBoletoEnum
    {
        Pago,
        AguardandoPagamento,
        Vencido 
    }
}
