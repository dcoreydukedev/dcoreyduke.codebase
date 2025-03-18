using System;

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    /// <summary>
    /// Represents a URL with components such as scheme, subdomain, domain name, top-level domain, port number, path,
    /// query, parameters, and fragment.
    /// https://blog.hubspot.com/marketing/parts-url
    /// https://www.geeksforgeeks.org/components-of-a-url/
    /// </summary>
    public class Url
    {

        private string? _scheme, _subdomain, _domainName, _topLevelDomain, _portNumber, _path, _query, _parameters, _fragment, _url, _value;

        private Url() { }
        public Url(string url) : this()
        {
            _url = url;
            ParseUrl(_url);
        }


        private void ParseUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {

                if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri? uri))
                {
                    _scheme = uri.Scheme;
                    _subdomain = uri.Host;
                    _domainName = uri.Host;
                    _topLevelDomain = uri.Host;
                    _portNumber = uri.Port.ToString();
                    _path = uri.AbsolutePath;
                    _query = uri.Query;
                    _parameters = uri.Query;
                    _fragment = uri.Fragment;
                }
                else
                {
                    throw new ArgumentException("Invalid URL");
                }
                _value = url;
            }

        }

        public string? Scheme => _scheme;
        public string? Subdomain => _subdomain;
        public string? DomainName => _domainName;
        public string? TopLevelDomain => _topLevelDomain;
        public string? PortNumber => _portNumber;
        public string? Path => _path;
        public string? Query => _query;
        public string? Parameters => _parameters;
        public string? Fragment => _fragment;
        public string? Value => _value;
    }
}
