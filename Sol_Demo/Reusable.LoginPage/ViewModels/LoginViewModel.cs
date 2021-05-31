using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Reusable.LoginPage.Models;
using Reusable.LoginPage.ViewComponentsService.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusable.LoginPage.ViewModels
{
    public abstract class LoginViewModel : ComponentBase
    {
        public LoginViewModel()
        {
        }

        [Inject]
        public IMediator Mediator { get; set; }

        [Parameter]
        public LoginModel LoginModel { get; set; }

        [Parameter]
        public String Title { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        protected private Action OnCancel { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                OnCancel = async () => await Mediator.Publish<OnCancelCommand>(new OnCancelCommand());

                base.StateHasChanged();
            }
        }
    }
}