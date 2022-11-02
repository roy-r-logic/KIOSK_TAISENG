namespace SSKWeb.Models.ViewModels
{
    public class GetCollectQueueListViewModel
    {
        public int CollectQueueListId { get; set; }
        public string RefCode { get; set; }
        public int RepairDetailsId { get; set; }
        public string CaseNo { get; set; }
        public string PhoneNo { get; set; }
        public string Status { get; set; }
        public string IssueTime { get; set; }

        public string CreatedOn { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
