using Admin.UI.Models;
using Admin.UI.ViewComponentsService.Handlers;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Reusable.LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.UI.ViewModels
{
    public class AdminLoginViewModel : ComponentBase
    {
        public AdminLoginViewModel()
        {
            LoginModel = new LoginModel();
        }

        [Inject]
        public IMediator Mediator { get; set; }

        protected internal AdminLoginModel AdminLogin { get; set; }

        protected internal LoginModel LoginModel { get; set; }

        protected private Action<EditContext> OnSubmitAction { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                OnSubmitAction = async (editContext) => await Mediator.Publish<OnLoginSubmitCommand>(new OnLoginSubmitCommand()
                {
                    AdminLoginView = this,
                    Edit = editContext
                });

                base.StateHasChanged();
            }
        }
    }
}