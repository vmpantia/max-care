using AntDesign;
using MC.Web.Models.UI;

namespace MC.Web.Extensions
{
    public class UIExtension
    {
        public static IEnumerable<SidebarItem> GetSidebarItems() =>
            new List<SidebarItem>
            {
                new SidebarItem("1", IconType.Outline.Home, "", "Home"),
                new SidebarItem("2", IconType.Outline.User, "counter", "Counter"),
                new SidebarItem("3", IconType.Outline.User, "weather", "Weather"),
            };
    }
}
