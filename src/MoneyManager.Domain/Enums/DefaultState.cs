namespace MoneyManager.Domain.Enums
{
    /// <summary>
    /// Default status.
    /// </summary>
    public enum DefaultState
    {
        /// <summary>
        /// Inactive. Logically deleted. Cannot be used in new transactions.
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// Active. Can be viewed and used across application.
        /// </summary>
        Active = 1
    }
}