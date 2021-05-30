using Customer.UI.Models;
using Customer.UI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.UI.ViewComponentsService.Handlers
{
    public class OnLoginSubmitCommand : INotification
    {
        public EditContext Edit { get; set; }

        public CustomerLoginViewModel CustomerLoginView { get; set; }
    }

    public class OnLoginSubmitCommandHandler : INotificationHandler<OnLoginSubmitCommand>
    {
        private readonly NavigationManager navigationManager = null;

        public OnLoginSubmitCommandHandler(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public Task Handle(OnLoginSubmitCommand notification, CancellationToken cancellationToken)
        {
            var flag = notification.Edit.Validate();
            if (flag == false) return Task.CompletedTask;

            notification.CustomerLoginView.CustomerLogin = new CustomerLoginModel()
            {
                UserName = notification.CustomerLoginView.LoginModel.UserName,
                Password = notification.CustomerLoginView.LoginModel.Password
            };

            navigationManager.NavigateTo("/index");

            return Task.CompletedTask;
        }
    }
}