using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace Forms.GoogleMaps.Sample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<Position> MapClickedCommand { get; }

        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Main Page";

            _pageDialogService = pageDialogService;

            MapClickedCommand = new DelegateCommand<Position>(MapClicked);
        }

        private async void MapClicked(Position obj)
        {
            try
            {
                var message = $"Latitude: {obj.Latitude} Longitude: {obj.Longitude}.";
                await _pageDialogService.DisplayAlertAsync("Atenção", message, "Ok");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
