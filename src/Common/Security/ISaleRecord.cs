namespace Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um usuário no sistema.
    /// </summary>
    public interface ISaleRecord
    {
        /// <summary>
        /// Obtém o identificador único da venda.
        /// </summary>
        /// <returns>O ID da venda como uma string.</returns>
        public string Id { get; }

        /// <summary>
        /// Obtém o número de venda.
        /// </summary>
        /// <returns>O número de venda.</returns>
        public int SaleNumber { get; }

    }
}
