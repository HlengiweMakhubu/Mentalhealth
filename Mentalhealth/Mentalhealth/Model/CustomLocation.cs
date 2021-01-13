
using static Android.Icu.Text.Transliterator;

namespace Mentalhealth.Model
{
    public class CustomLocation : Location
    {
        public string PlaceName { get; }
        public string Url { get; }


        public CustomLocation(string address, string description, Position position, string placeName, string url) : base(address,description,position)
        {
            PlaceName = placeName;
            Url = url;
        }
    }
}
