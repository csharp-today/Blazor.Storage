using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CSharpToday.Blazor.Storage
{
    public class BrowserStorage : IBrowserStorage
    {
        private readonly IJSRuntime _js;

        public ValueTask<string> GetItemAsync(string key) => _js.InvokeAsync<string>("localStorage.getItem", key);

        public ValueTask RemoveItemAsync(string key) => _js.InvokeVoidAsync("localStorage.removeItem", key);

        public ValueTask SetItemAsync(string key, string value) => _js.InvokeVoidAsync("localStorage.setItem", key, value);
    }
}
