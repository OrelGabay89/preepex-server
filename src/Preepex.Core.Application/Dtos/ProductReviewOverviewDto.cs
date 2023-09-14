namespace Preepex.Core.Application.Dtos
{
    public class ProductReviewOverviewDto
    {
        public int ProductId { get; set; }

        public int RatingSum { get; set; }

        public int TotalReviews { get; set; }

        public bool AllowCustomerReviews { get; set; }

        public bool CanAddNewReview { get; set; }
    }
}
