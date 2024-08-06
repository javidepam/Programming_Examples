using Programming_Examples.Delegates;

namespace Programming_Examples.Handlers
{
    /// <summary> 
    /// Delegates
    /// <para>Delegate can be used as the function pointer</para> 
    /// <para>Delagate is meant for callbacks</para> 
    /// <para>Delegate can be converted to Multicast</para>
    /// <para>In Multicast, clients can manipulate the Senders delegate object</para>
    /// <para>Event is pure publisher subscriber model</para>
    /// <para>Event is a encapsulation over delegates</para>
    /// </summary> 
    public static class DelegateHandler
    {
        public delegate int CalculateDelegate(int i);
        public static CalculateDelegate? cd;

        public static void DelegateFunc()
        {
            #region Delegate as function pointer
            cd = CalculateAge;
            var f = cd.Invoke(1999);
            CalculateDelegate intDelegate = new(CalculateAge); // delegate as function pointer
            Console.WriteLine(intDelegate(5));
            #endregion

            #region Delegate as CallBack
            DelegateCallbackExample dlegCb = new();
            dlegCb.sender = Receiver;
            Thread t = new(new ThreadStart(dlegCb.RunningFunc));
            //t.Start();
            #endregion

            #region Delegate for Multicasting (or broadcasting)
            //multicast can get manipulated
            DelegateCallbackExample dlegCbMcast = new();
            dlegCbMcast.sender += Receiver1;
            dlegCbMcast.sender += Receiver2;
            dlegCbMcast.sender += Receiver3;
            Thread m = new(new ThreadStart(dlegCbMcast.RunningFunc));
            //m.Start();
            #endregion

            #region Delegate as Publisher Subscriber(Event based) using event -- Observer Design Pattern
            //events can only be observed and can't be manipulated
            DelegateEvents de = new();
            de.sender += Receiver1;
            de.sender += Receiver2;
            de.sender += Receiver3;
            Thread e = new(new ThreadStart(de.RunningFunc));
            e.Start();
            #endregion
        }


        private static void Receiver(int i)
        {
            Console.WriteLine(i);
        }

        private static void Receiver1(int i)
        {
            Console.WriteLine("Receiver1: " + i.ToString());
        }

        private static void Receiver2(int i)
        {
            Console.WriteLine("Receiver2: " + i.ToString());
        }

        private static void Receiver3(int i)
        {
            Console.WriteLine("Receiver3: " + i.ToString());
        }

        private static int CalculateAge(int year)
        {
            return year + 10;
        }
    }
}
