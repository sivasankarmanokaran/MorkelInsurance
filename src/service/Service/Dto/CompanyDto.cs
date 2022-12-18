namespace Insurance.Service.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string Address3 { get; set; } = null!;
        public string PostCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime InsuranceEndDate { get; set; }
        public bool HasActiveInsurance { get; set; }
    }
}
