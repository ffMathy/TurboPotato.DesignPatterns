using System;

namespace TurboPotato.DesignPatterns.Adapter
{
    public interface IMicroUsbPhone
    {
        string RechargeUsingMicroUsb();
    }

    public interface ILightningPhone
    {
        string RechargeUsingLightning();
    }

    class IPhone : ILightningPhone
    {
        public string RechargeUsingLightning()
        {
            return "Recharge using lightning";
        }
    }

    class Android : IMicroUsbPhone
    {
        public string RechargeUsingMicroUsb()
        {
            return "Recharge using Micro USB";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class LightningToMicroUsbAdapter : IMicroUsbPhone
    {
        private readonly ILightningPhone _lightningPhone;

        public LightningToMicroUsbAdapter(ILightningPhone lightningPhone)
        {
            this._lightningPhone = lightningPhone;
        }

        public string RechargeUsingMicroUsb()
        {
            return _lightningPhone.RechargeUsingLightning();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var android = new Android();
            Console.WriteLine(android.RechargeUsingMicroUsb());

            var iphone = new IPhone();
            Console.WriteLine(iphone.RechargeUsingLightning());

            var adapter = new LightningToMicroUsbAdapter(iphone);
            Console.WriteLine(adapter.RechargeUsingMicroUsb());
        }
    }
}
