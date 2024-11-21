namespace mp3.library.Services;

public interface IAlertService {
    Task AlertAsync(string title, string message);
}