namespace BookFavorites.Services
{
    public class ShortStringServices:IShortStrings
    {
        public string GetShort(string str, int len)
        {
            if (str == null)
                return str;
            if (str.Length < len)
                return str;
            return str.Substring(0, len) + "...";
        }
    }
}
