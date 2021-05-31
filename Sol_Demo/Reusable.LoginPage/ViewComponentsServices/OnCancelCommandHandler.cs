using MediatR;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reusable.LoginPage.ViewComponentsService.Handlers
{
    public class OnCancelCommand : INotification
    {
    }

    public class OnCancelCommandHandler : INotificationHandler<OnCancelCommand>
    {
        private Task<IJSObjectReference> _module = null;
        private IJSRuntime jsRuntime = null;

        public OnCancelCommandHandler(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        async Task INotificationHandler<OnCancelCommand>.Handle(OnCancelCommand notification, CancellationToken cancellationToken)
        {
            _module = jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Reusable.LoginPage/Cancel.js").AsTask();

            await (await _module).InvokeVoidAsync(identifier: "onCancel");
        }
    }
}