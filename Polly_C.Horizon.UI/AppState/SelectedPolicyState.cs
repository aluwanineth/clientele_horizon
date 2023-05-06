namespace Polly_C.Horizon.UI.AppState
{
    public class SelectedPolicyState
    {
        public string PolicyNumber { get; private set; } = string.Empty;

        public string ClientFullName { get; private set; } = string.Empty;


        public event Action OnChange;

        public void SetPolicyInfo(string policyNumber, string clientName)
        {
            PolicyNumber = policyNumber;
            ClientFullName = clientName;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
