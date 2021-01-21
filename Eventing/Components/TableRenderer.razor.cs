using Eventing.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventing.Components
{
    public partial class TableRenderer<T> : ComponentBase, IDisposable
    {
        [Inject]
        private ITableRendererState TableRendererState { get; set; }

        [Parameter]
        public List<T> Items { get; set; }
        [Parameter]
        public RenderFragment HeadTemplate { get; set; }
        [Parameter]
        public RenderFragment<T> BodyRowTemplate { get; set; }
        [Parameter]
        public EventCallback OnCreateNewEventCallback { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                TableRendererState.OnNewItemEventHandler += TableRendererState_OnNewItemEventHandler;
            }

            base.OnAfterRender(firstRender);
        }

        private void TableRendererState_OnNewItemEventHandler(object sender, EventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        private void FireOnCreateNewEventCallback()
        {
            if (OnCreateNewEventCallback.HasDelegate)
                OnCreateNewEventCallback.InvokeAsync(null);

            StateHasChanged();
        }

        public void Dispose()
        {
            TableRendererState.OnNewItemEventHandler -= TableRendererState_OnNewItemEventHandler;
        }
    }
}
