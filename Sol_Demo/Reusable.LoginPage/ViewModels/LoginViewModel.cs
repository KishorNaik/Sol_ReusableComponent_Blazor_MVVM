using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Reusable.LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Parameter]
        public LoginModel LoginModel { get; set; }

        [Parameter]
        public String Title { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }
    }
}