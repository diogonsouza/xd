namespace Admin.Helpers.Extensions
{
    public class BreadcrumbItem
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public Icon Icon { get; set; }

        public BreadcrumbItem()
        {
            this.Url = "#";
        }
    }
}