using System;
using System.Threading;

namespace SingletonPattern;

internal class ApplicationContext
{
    private static Lazy<ApplicationContext> _instance = new Lazy<ApplicationContext>(() => new ApplicationContext());
    public static ApplicationContext Instance => _instance.Value;

    public string LoggedUser { get; set; }
    public DateTime LoggedOn { get; set; }
    public string Theme { get; set; }

    public ApplicationContext()
    {
        LoggedOn = DateTime.Now;
        Theme = "Dark";

        Thread.Sleep(1000);
    }

}
