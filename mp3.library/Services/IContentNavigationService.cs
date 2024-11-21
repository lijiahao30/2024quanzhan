namespace mp3.library.Services;

public interface IContentNavigationService {
    void NavigateTo(string view,object parameter=null);
}
public static class ContentNavigationConstant {
    public const string Mp3PlayerView = nameof(Mp3PlayerView);

}