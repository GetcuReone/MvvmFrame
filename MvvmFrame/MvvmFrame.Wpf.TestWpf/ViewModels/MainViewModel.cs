﻿using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.EventArgs;
using MvvmFrame.Wpf.Models;
using MvvmFrame.Wpf.TestWpf.Pages;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestWpf.ViewModels
{
    public sealed class MainViewModel: ViewModelBase
    {
        public ButtonModel GoBack_ButtonModel { get; private set; }

        public ButtonModel GoForward_ButtonModel { get; private set; }

        public ButtonModel Navigate_ButtonModel { get; private set; }

        public ButtonModel Refresh_ButtonModel { get; set; }

        protected override void Initialize()
        {
            base.Initialize();

            GoBack_ButtonModel = GetModel<ButtonModel>();
            GoBack_ButtonModel.Command = new Command(GoBack);

            GoForward_ButtonModel = GetModel<ButtonModel>();
            GoForward_ButtonModel.Command = new Command(GoForward);

            Navigate_ButtonModel = GetModel<ButtonModel>();
            Navigate_ButtonModel.Command = new Command(Navigate);

            Refresh_ButtonModel = GetModel<ButtonModel>();
            Refresh_ButtonModel.Command = new Command(Refresh);
        }

        private void GoBack(CommandArgs e) => NavigationManager.GoBack();

        private void GoForward(CommandArgs e) => NavigationManager.GoForward();

        private void Refresh(CommandArgs e) => NavigationManager.Refresh();

        private void Navigate(CommandArgs e) => Navigate<HomePage, HomeViewModel>("Hi, home");

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            return base.OnGoPageAsync(navigateParam);
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            return base.OnLeavePageAsync(args);
        }

        protected override ValueTask OnLoadPageAsync()
        {
            return base.OnLoadPageAsync();
        }
    }
}
