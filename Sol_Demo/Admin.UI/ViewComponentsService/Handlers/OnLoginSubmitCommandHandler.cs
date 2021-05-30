using Admin.UI.Models;
using Admin.UI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.UI.ViewComponentsService.Handlers
{
    public class OnLoginSubmitCommand : INotification
    {
        public EditContext Edit { get; set; }

        public AdminLoginViewModel AdminLoginView { get; set; }
    }

    public class OnLoginSubmitCommandHandler : INotificationHandler<OnLoginSubmitCommand>
    {
        public readonly NavigationManager navigation = null;

        public OnLoginSubmitCommandHandler(NavigationManager navigation)
        {
            this.navigation = navigation;
        }

        Task INotificationHandler<OnLoginSubmitCommand>.Handle(OnLoginSubmitCommand notification, CancellationToken cancellationToken)
        {
            var flag = notification.Edit.Validate();
            if (flag == false) return Task.CompletedTask;

            notification.AdminLoginView.AdminLogin = new AdminLoginModel()
            {
                UserName = notification.AdminLoginView.LoginModel.UserName,
                Password = notification.AdminLoginView.LoginModel.Password,
            };

            navigation.NavigateTo("/index");

            return Task.CompletedTask;
        }
    }
}