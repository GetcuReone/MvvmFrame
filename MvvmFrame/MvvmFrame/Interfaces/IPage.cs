namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Interface for page
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// <para>Initialize component. Instead of constructor</para>
        /// <para>DataContext = <paramref name="viewModel"/>; InitializeComponent();</para>
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel;
    }
}
