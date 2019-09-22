namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// <see cref="IModel"/> options
    /// </summary>
    public interface IModelOptions
    {
        /// <summary>
        /// use only <see cref="IModel.OnPropertyChanged(string)"/>
        /// </summary>
        bool UseOnlyOnPropertyChanged { get; set; }
        /// <summary>
        /// use <see cref="IModel.Verification(string)"/>
        /// </summary>
        bool UseVerification { get; }
        /// <summary>
        /// use <see cref="IModel.VerifyPropertyChange"/>
        /// </summary>
        bool UseVerifyPropertyChange { get; }
    }
}
