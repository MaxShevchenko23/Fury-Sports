namespace sport_shop_bll.Models.GET
{
    public class OrderGet
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ClientName { get; set; } = null!;

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int? AccountId { get; set; }

        public string ClientPhoneNumber { get; set; } = null!;

        public string ClientAddress { get; set; } = null!;

        public int Status { get; set; }

        public string? Post { get; set; }

        public string? Payment { get; set; }

        //public virtual Account? Account { get; set; }

        public ProductShortGet Product { get; set; } = null!;

    }
}
