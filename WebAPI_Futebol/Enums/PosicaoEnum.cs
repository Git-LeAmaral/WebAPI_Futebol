using System.Text.Json.Serialization;

namespace WebAPI_Futebol.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PosicaoEnum
    {
        GOLEIRO,
        LATERAL,
        ZAGUEIRO,
        MEIO_CAMPO_DEFENSIVO,
        MEIO_CAMPO_OFENSIVO,
        MEIA_ATACANTE,
        ATACANTE
    }
}
