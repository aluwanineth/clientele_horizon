namespace Polly_C.Horizon.UI.DTOs.PolicyDetail
{
    public class SelectListItem
    {
        public int item_id { get; set; }
        public string item_description { get; set; }
        public SelectListItem(int _item_id, string _item_description)
        {
            item_id = _item_id;
            item_description = _item_description;
        }
    }
}
