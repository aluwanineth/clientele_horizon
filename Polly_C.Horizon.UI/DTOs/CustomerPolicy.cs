namespace Polly_C.Horizon.UI.DTOs
{
    public class CustomerPolicy
    {
        public int PolicyNO { get; set; }
        
        public string IFANo { get; set; } = string.Empty;
        
        public string Product { get; set; } = string.Empty;
        
        public string PolicyStatus { get; set; } = string.Empty;
        
        public DateTime Status_Date { get; set; }
        
        public DateTime DOC { get; set; }
        
        public string Payer { get; set; } = string.Empty;
        
        public string MainMemberFullName { get; set; } = string.Empty;
        
        public Nullable<decimal> Policy_Premium { get; set; }
        
        public DateTime Billed_to { get; set; }
        
        public DateTime Paid_to { get; set; }
        
        public Nullable<int> Premium_Count { get; set; }
        
        public int Premium_Frequency { get; set; }
        
        public string SalesPerson { get; set; } = string.Empty; 
        
        public string DebiCheckStatus { get; set; } = string.Empty; 
        
        public int EntityID { get; internal set; }
        
        public string EntityNo { get; set; } = string.Empty;
    }
}
