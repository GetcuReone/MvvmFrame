namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Interface for view-models
    /// </summary>
    public interface IViewModel : IModel
    {
        /// <summary>
        /// Method creation view-model
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        TViewModel GetViewModel<TViewModel>() where TViewModel : IViewModel, new();
    }
}
