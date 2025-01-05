namespace MC.Web.Models.UI
{
    public class SidebarItem
    {
        public SidebarItem(string key, string icon, string link, string title)
        {
            Key = key;
            Icon = icon;
            Link = link;
            Title = title;
        }

        public string Key { get; init; }
        public string Icon { get; init; }
        public string Link { get; init; }
        public string Title { get; init; }
    }
}
