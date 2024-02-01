using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAppNetCore8.Components.Pages
{
    public partial class Home : IAsyncDisposable
    {
        #region Injections
        [Inject] IJSRuntime JSRuntime { get; set; }
        #endregion

        private IJSObjectReference jsModule;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Console.WriteLine("OnAfterRender");
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Initializing");
        }

        public async ValueTask DisposeAsync()
        {
            if (jsModule is not null)
            {
                await jsModule.DisposeAsync();
            }
        }
    }
}
