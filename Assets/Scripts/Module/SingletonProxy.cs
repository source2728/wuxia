
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

public class SingletonProxy : Proxy {

    List<string> MultitonKeys = new List<string>();

    public SingletonProxy(string proxyName) : base(proxyName)
    {
    }

    public SingletonProxy(string proxyName, object data) : base (proxyName, data)
    {
    }

    private new void InitializeNotifier (string key) {
        base.InitializeNotifier(key);
        this.MultitonKey = "";
        this.MultitonKeys.Add(key);
    }
}
