namespace BookShop.Presentantion.Contracts
{
    using Newtonsoft.Json;

    public class Error
    {
        public int? StatusCode { get; set; }

        public ICollection<string>? Message { get; set; } = new List<string>();

        public DateTime? TimeSpan { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
