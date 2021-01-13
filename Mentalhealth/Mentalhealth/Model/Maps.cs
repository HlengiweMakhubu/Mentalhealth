using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Mentalhealth.Model
{
    class Maps
    {
        public async Task GetLocation(string address)
        {
            var placemark = new Placemark();
            placemark.Thoroughfare = address;
            await Map.OpenAsync(placemark);

            //await MapAddress.GetLocation(OrderAddress.Address);
        }
    }
}
