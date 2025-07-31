using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MudBlazorApp.Services
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _js;

        public SweetAlertService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task ShowSuccess(string title, string message)
        {
            await _js.InvokeVoidAsync("SwalHelper.ShowSuccess", title, message);
        }

        public async Task ShowError(string title, string message)
        {
            await _js.InvokeVoidAsync("SwalHelper.ShowError", title, message);
        }

        public async Task ShowConfirm(string title, string message, DotNetObjectReference<object> dotNetRef)
        {
            await _js.InvokeVoidAsync("SwalHelper.ShowConfirm", title, message, dotNetRef);
        }
    }
}