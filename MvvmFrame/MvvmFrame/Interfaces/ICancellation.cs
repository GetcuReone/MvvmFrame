namespace GetcuReone.MvvmFrame.Interfaces
{
    /// <summary>
    /// Interface cancel
    /// </summary>
    public interface ICancellation
    {
        /// <summary>
        /// True - canceled, False - not canceled
        /// </summary>
        bool IsCancel { get; }

        /// <summary>
        /// Cancel
        /// </summary>
        void Cancel();
    }
}
