using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestInterGrupoMovil.Models;
using TestInterGrupoMovil.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TestInterGrupoMovil.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Varables
        private ApiService _apiService;
        public ObservableCollection<Country> _Countries;
        List<Country> _listCountry = new List<Country>();
        string _FilterCountry;
        #endregion Varables

        #region Constructor
        // Constructor
        public HomeViewModel()
        {

            _apiService = new ApiService();
            LoadCountries();

        }
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Command
        public ICommand OpenMapsCommand
        {
            get
            {
                //return new RelayCommand(openMaps); 
                return new Command<Country>(async (model) => await openMaps(model));
            }
        }
        #endregion Command

        #region Properties
        public string FilterCountry
        {
            get
            {
                return _FilterCountry;
            }
            set
            {
                if (value != _FilterCountry)
                {
                    _FilterCountry = value;
                    Device.BeginInvokeOnMainThread(async () =>
                    {

                        await SearchCountry();
                    });
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(FilterCountry))
                        );
                }
            }
        }

        #endregion Properties

        #region ObservableCollection
        public ObservableCollection<Country> Countries
        {
            get
            {
                return _Countries;
            }
            set
            {
                if (value != _Countries)
                {
                    _Countries = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Countries))
                        );
                }
            }
        }
        #endregion ObservableCollection

        #region Functions
        async Task SearchCountry()
        {
            List<Country> filterCountry = new List<Country>();

            try
            {
                if (string.IsNullOrEmpty(FilterCountry))
                {
                    Countries = new ObservableCollection<Country>(_listCountry);
                }
                else
                {
                    // var countryFilter = listCountry.FindAll(x => x.capital.ToLower().Contains(FilterCountry.ToLower())).FindAll(x => x.region.ToLower().Contains(FilterCountry.ToLower())).FindAll(x => x.name.ToLower().Contains(FilterCountry.ToLower()));

                    if (FilterCountry.Length >= 2)
                    {
                        string filterCountryToUpper = FilterCountry.ToUpper();
                        var filter = _listCountry.Where((e => e.name.ToUpper().Contains(filterCountryToUpper) || e.region.ToUpper().Contains(filterCountryToUpper) || e.capital.ToUpper().Contains(filterCountryToUpper))).ToList();

                        if (filter != null && filter.Count > 0)
                            Countries = new ObservableCollection<Country>(filter);

                    }

                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Task Canceled");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                using (UserDialogs.Instance.Loading("Ha ocurrido un error al filtrar el cliente"))
                    await Task.Delay(TimeSpan.FromSeconds(3));
                return;
            }
        }

        private async void LoadCountries()
        {
            // end point
            var url = "https://restcountries-v1.p.rapidapi.com/all";
            // Api Key, pass in parameters
            var api_key = "497b760508msheda6e3ccc8b736ep1fa2b6jsn79a3071afea5";
            var response = await _apiService.Get<Country>(url, api_key);
            ReloadCountries((List<Country>)response.Result);

            //var mainViewModel = new MainViewModel;

        }


        private void ReloadCountries(List<Country> result)
        {
            // in this method i will clean list
            if (Countries != null && Countries.Any())
                Countries.Clear();
            else
                Countries = new ObservableCollection<Country>();
            Countries = new ObservableCollection<Country>(result);
            _listCountry = result;
        }

        private async Task openMaps(Country country)
        {
            string url = string.Empty;
            url = String.Format("http://maps.apple.com/maps?q={0}", country.name);
            Uri uri = new Uri(url);
            Device.OpenUri(uri);
        }
        /// on this function, i get the name of contry and open google maps

    }

    #endregion
}
