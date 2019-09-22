using MvvmFrame.EventHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Base interface for model and view-model
    /// </summary>
    public interface IModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event virification <see cref="IModel"/>
        /// </summary>
        event MvvmElementPropertyVerifyChangeEventHandler VerifyPropertyChange;

        /// <summary>
        /// Model options
        /// </summary>
        IModelOptions Options { get; set; }

        /// <summary>
        /// Property change verification method
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        string Verification(string propertyName);

        /// <summary>
        /// Method creation model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        TModel GetModel<TModel>() where TModel : IModel, new();

        /// <summary>
        /// Hendler <see cref="VerifyPropertyChange"/>
        /// </summary>
        /// <param name="propertyName"></param>
        bool OnVerifyPropertyChange([CallerMemberName]string propertyName = "");

        /// <summary>
        /// Hendler <see cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged([CallerMemberName]string propertyName = "");

        /// <summary>
        /// Handler warnings
        /// </summary>
        /// <param name="getWarningMessageList"></param>
        void OnWarnings(List<Func<string>> getWarningMessageList);

        /// <summary>
        /// Hendler errors
        /// </summary>
        /// <param name="getErrorMessageList"></param>
        void OnErrors(List<Func<string>> getErrorMessageList);
    }
}
