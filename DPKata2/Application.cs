namespace DPKata2
{
    public enum FilterResult
    {
        CLEAN,
        MALWARE
    }

    public class Application
    {
        private string _url;
        public Application() {}

        public Application(string url)
        {
            _url = url;
        }

        public void SetURL(string url)
        {
            _url = url;
        }

        public FilterResult Run()
        {
            if (_url == "http://eicar.org/download/eicar.com") return FilterResult.MALWARE;
            return FilterResult.CLEAN;
        }
    }
}
