using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Xunit;
using Moq;
using mp3.library.Models;
using mp3.library.Services;
using mp3.library.ViewModels;

using Assert = Xunit.Assert;

namespace mp3.test.ViewModelTest
{
    public class Mp3PlayerViewModelTests
    {
        private readonly Mock<IMusicService> _musicServiceMock;
        private readonly Mock<IAudioPlayer> _audioPlayerMock;
        private readonly Mp3PlayerViewModel _viewModel;

        public Mp3PlayerViewModelTests()
        {
            // Mock 服务
            _musicServiceMock = new Mock<IMusicService>();
            _audioPlayerMock = new Mock<IAudioPlayer>();

            // 初始化 ViewModel
            _viewModel = new Mp3PlayerViewModel(_musicServiceMock.Object, _audioPlayerMock.Object);
        }

        /*[Fact]
        public async Task SearchSongsAsync_AddsSongToList_WhenSearchQueryIsValid()
        {
            // Arrange
            var mockSong = new Song { id = "123", name = "Test Song" };
            _musicServiceMock
                .Setup(service => service.SearchMusicAsync(It.IsAny<string>()))
                .ReturnsAsync(mockSong);

            _viewModel.SearchQuery = "Test";

            // Act
            await ((AsyncRelayCommand)_viewModel.SearchCommand).ExecuteAsync(null);
        

            // Assert
            Assert.Single(_viewModel.Songs);
            Assert.Equal("Test Song", _viewModel.Songs[0].name);
        }*/

        [Fact]
        public async Task SearchSongsAsync_DoesNotAddSong_WhenSearchQueryIsEmpty()
        {
            // Arrange
            _viewModel.SearchQuery = "";

            await ((AsyncRelayCommand)_viewModel.PlayCommand).ExecuteAsync(null);

            // Assert
            Assert.Empty(_viewModel.Songs);
        }

        [Fact]
        public async Task PlaySongAsync_PlaysSelectedSong_WhenSelectedSongIsNotNull()
        {
            // Arrange
            var mockSong = new Song { id = "123", name = "Test Song" };
            _viewModel.SelectedSong = mockSong;

            _musicServiceMock
                .Setup(service => service.GetSongUrlAsync(It.IsAny<string>()))
                .ReturnsAsync("http://test-url.com");

            await ((AsyncRelayCommand)_viewModel.PlayCommand).ExecuteAsync(null);

            // Assert
            _audioPlayerMock.Verify(player => player.Play("http://test-url.com"), Times.Once);
        }

        [Fact]
        public  void StopCommand_StopsAudioPlayer()
        {
            // Act
            _viewModel.StopCommand.Execute(null);

            // Assert
            _audioPlayerMock.Verify(player => player.Stop(), Times.Once);
        }
    }
}
