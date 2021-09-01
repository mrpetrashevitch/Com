using Microsoft.Extensions.DependencyInjection;
using WPF.Model;

namespace WPF.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
