namespace Insurance.Service.Dto
{
    public class ClaimDto
    {
        public int Id { get; set; }
        public string UCR { get; set; } = null!;
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string Assured_Name { get; set; } = null!;
        public decimal Incurred_Loss { get; set; }
        public bool Closed { get; set; }

        public int ClaimEndedInDays { get; set; }
    }
}
