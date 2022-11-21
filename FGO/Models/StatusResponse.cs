namespace FGO.Models
{
    public class StatusResponse
    {
        public int StatusCode;
        public string? StatusDescription;

        public List<Servants>? ServantResponse = new();
        public List<NoblePhantasm> NoblePhantasmResponse = new();
    }
}
