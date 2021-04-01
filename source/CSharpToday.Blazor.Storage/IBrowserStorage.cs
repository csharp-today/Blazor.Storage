using System.Threading.Tasks;

namespace CSharpToday.Blazor.Storage
{
    public interface IBrowserStorage
    {
        ValueTask<string> GetItemAsync(string key);
        ValueTask RemoveItemAsync(string key);

        ValueTask SetItemAsync(string key, string value);
    }
}
