namespace Account.API.Models
{
    public class UpdateAccountRequest
    {
        public long AccountId { get; set; } 
        
        public string NewName { get; set; }
        
        public string NewEmail { get; set; }
        
        public string NewPassword { get; set; }
    }
}
