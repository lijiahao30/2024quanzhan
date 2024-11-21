using System.Threading.Tasks;
using mp3.library.Services;
using Ursa.Controls;

namespace mp3.service;

public class AlertService : IAlertService {
    public async Task AlertAsync(string title, string message) =>
        await MessageBox.ShowAsync(message, title, button: MessageBoxButton.OK);
}