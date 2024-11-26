using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using mp3.library.Models;
using mp3.library.Services;

namespace mp3.library.ViewModels;

public class DiaryViewModel :ViewModelBase
{
    private readonly IDiaryStorage _diaryStorage;
    

    public DiaryViewModel(IDiaryStorage diaryStorage)
    {
        _diaryStorage = diaryStorage;
  
        InitializeCommand = new AsyncRelayCommand(InitializeAsync);
        InsertCommand = new AsyncRelayCommand(InsertAsync);
        ListCommand = new AsyncRelayCommand(ListAsync);
        SearchCommand = new RelayCommand(() => SearchAysnc(SearchKeyword));
        OnInitializedCommand = new AsyncRelayCommand(OnInitializedAsync);

    }
    
    
    public async Task InitializeAsync() =>
        await _diaryStorage.InitializeAsync();

    public ICommand InitializeCommand { get; }

    public async Task InsertAsync() =>
        await _diaryStorage.InsertAsync(new Diary {
            Content = "内容" + new Random().Next()
        });

    public ICommand InsertCommand { get; }

    public ObservableCollection<Diary> Diaries { get; set; }
        = new();

    public async Task ListAsync() {
        var diaries = await _diaryStorage.ListAsync();
        Diaries.Clear();
        foreach (var diary in diaries) {
            Diaries.Add(diary);
        }
    }

    public ICommand ListCommand { get; set; }
    
    private Diary _selectedDiary;

    public Diary SelectedDiary
    {
        get => _selectedDiary;
        set => SetProperty(ref _selectedDiary, value);
    }
    
    private string _searchKeyword;
    public string SearchKeyword
    {
        get => _searchKeyword;
        set => SetProperty(ref _searchKeyword, value);
    }
    
    public async Task SearchAysnc(string keyword)
    {
        if (!string.IsNullOrEmpty(keyword))
        {
            var diaries = await _diaryStorage.QueryAsync(keyword);
            Diaries.Clear();
            foreach (var diary in diaries)
            {
                Diaries.Add(diary);
            }
        }
    }

    public RelayCommand SearchCommand { get; }
    
    private ICommand OnInitializedCommand { get; }

    public async Task OnInitializedAsync()
    {
        await ListAsync();
       
    }
}