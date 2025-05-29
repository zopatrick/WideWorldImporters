namespace WideWorldImporters.Server.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string FormalName { get; set; } = string.Empty;
        public string IsoAlpha3Code { get; set; } = string.Empty;
        public int IsoNumericCode { get; set; }
        public string CountryType { get; set; } = string.Empty;
        public Int64? LatestRecordedPopulation { get; set; }
        public string Continent { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Subregion { get; set; } = string.Empty;
        //public string Border { get; set; } = string.Empty;
        //public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
