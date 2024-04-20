namespace MVC;

public class AppSettings
{
	public string CatalogUrl { get; set; }
	public string BasketUrlBff { get; set; }
	public string BasketUrlApi { get; set; }
	public string OrderUrlBff { get; set; }
	public string OrderUrlApi { get; set; }
	public int SessionCookieLifetimeMinutes { get; set; }
	public string CallBackUrl { get; set; }
	public string IdentityUrl { get; set; }
}
