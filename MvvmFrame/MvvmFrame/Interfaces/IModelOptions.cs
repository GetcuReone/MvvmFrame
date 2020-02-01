namespace GetcuReone.MvvmFrame.Interfaces
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
        /// use <see cref="IModel.OnVerification(EventArgs.MvvmElementPropertyVerifyChangeEventArgs)"/>
        /// </summary>
        bool UseOnVerification { get; set; }
        /// <summary>
        /// use <see cref="IModel.VerifyPropertyChange"/>
        /// </summary>
        bool UseVerifyPropertyChange { get; set; }
    }
}
