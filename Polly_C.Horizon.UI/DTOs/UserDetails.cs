namespace Polly_C.Horizon.UI.DTOs
{
    public class UserDetails
    {
        public string Username { get; set; } = string.Empty;
        
        public string? LegacyPolicyNumber { get; set; }
        
        public string? Surname { get; set; } = string.Empty;
        
        public string? FirstName { get; set; } = string.Empty;
        
        public string? EmailAddress { get; set; } = string.Empty;
        
        public string? CellphoneNumber { get; set; } = string.Empty;
    }
}
