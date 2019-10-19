using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using MvvmFrame.EventHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        IModelOptions ModelOptions { get; set; }

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
        /// Verification hendler
        /// </summary>
        /// <param name="e"></param>
        void OnVerification(MvvmElementPropertyVerifyChangeEventArgs e);

        /// <summary>
        /// Hendler errors
        /// </summary>
        /// <param name="details"></param>
        void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details);
    }
}
