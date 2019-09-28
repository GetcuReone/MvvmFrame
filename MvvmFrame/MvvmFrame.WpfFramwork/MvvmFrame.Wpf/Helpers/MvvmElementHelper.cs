﻿using MvvmFrame.EventArgs;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvvmFrame.Wpf.Helpers
{
    internal static class MvvmElementHelper
    {
        public static bool OnVerifyPropertyChange(IModel element, Action<MvvmElementPropertyVerifyChangeEventArgs> onVerifyPropertyChange, string propertyName)
        {
            var options = element.Options ?? ModelOptions.Default;
            if (!options.UseVerifyPropertyChange)
                return false;

            var args = new MvvmElementPropertyVerifyChangeEventArgs(propertyName);
            onVerifyPropertyChange(args);

            if (!args.IsValid)
                element.OnErrors(args._errorFuncs);

            return args.IsValid;
        }

        public static void OnPropertyChanged(IModel element, Action<PropertyChangedEventArgs> onPropertyChanged, string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            onPropertyChanged(args);
        }

        public static bool SetPropertyValue<TProperty>(
            IModel model,
            ref TProperty property,
            TProperty value,
            string propertyName)
        {
            IModelOptions options = model.Options ?? ModelOptions.Default;

            if (options.UseOnlyOnPropertyChanged)
            {
                property = value;
                model.OnPropertyChanged(propertyName);
                return true;
            }

            if (property == null & value == null)
                return true;
            else if (property != null && property.Equals(value))
                return true;

            TProperty oldValue = property;
            property = value;

            if (options.UseVerification)
            {
                string errorMessage = model.Verification(propertyName);
                if (!(string.IsNullOrEmpty(errorMessage) || string.IsNullOrWhiteSpace(errorMessage)))
                {
                    property = oldValue;
                    model.OnErrors(new List<Func<string>> { () => errorMessage });
                    return false;
                }
            }
            if (options.UseVerifyPropertyChange && !model.OnVerifyPropertyChange(propertyName))
            {
                property = oldValue;
                return false;
            }

            model.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
