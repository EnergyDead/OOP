public struct Url
{
    public string url;
    public Protocol protocol;
    public int port;
    public string host;
    public string document;

    public Url( Protocol protocol, string url, int port, string host, string document ) : this()
    {
        this.protocol = protocol;
        this.url = url;
        this.port = port;
        this.host = host;
        this.document = document;
    }
}