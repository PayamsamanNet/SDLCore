using Core.Base;

namespace Data.Dto
{
    public class BoxTypeDto : BaseEntity
    {

        public string Name { get; set; }
        public double Capacity { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }


        public decimal MonthlyPriceRatio { get; set; }
        public decimal TrustPriceRatio { get; set; }
        public decimal BlockedPriceRatio { get; set; }

        public decimal? RunningPrice { get; set; }
        public decimal? ShortDatePrice { get; set; }
        public decimal? LongDatePrice { get; set; }
    }
}
