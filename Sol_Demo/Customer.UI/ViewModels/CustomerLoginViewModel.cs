using Customer.UI.Models;
using Customer.UI.ViewComponentsService.Handlers;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Reusable.LoginPage.Models;
using Reusable.LoginPage.ViewModels;
using Reusable.LoginPage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.UI.ViewModels
{
    public abstract class CustomerLoginViewModel : ComponentBase
    {
        public CustomerLoginViewModel()
        {
            LoginModel = new LoginModel();
        }

        [Inject]
        public IMediator Mediator { get; set; }

        protected internal CustomerLoginModel CustomerLogin { get; set; }

        protected internal Action<EditContext> OnSubmitAction { get; set; }

        protected internal LoginModel LoginModel { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                OnSubmitAction = async (editContext) => await Mediator.Publish<OnLoginSubmitCommand>(new OnLoginSubmitCommand()
                {
                    CustomerLoginView = this,
                    Edit = editContext
                });

                base.StateHasChanged();
            }
        }
    }
}