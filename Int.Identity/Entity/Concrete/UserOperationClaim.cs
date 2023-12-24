namespace Int.Identity.Entity
{
    public class UserOperationClaim
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
