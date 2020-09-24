# Tartalom:
- [EA-GY2]()
 - [Szinkronizáció]()
 
### EA-GY2
Csak egyszer írja ki, ohgy `Done`, kihasználva, hogy C#-ban a `bool` alapértelmezett értéke `false`:
```C#
class ThreadTest {
  bool done;
  static void Main() {
    ThreadTest tt = new ThreadTest(); // Create a common instance
    new Thread (tt.Go).Start();
    tt.Go();
  }
  // Note that Go is now an instance method
  
  void Go() {
    if (!done) { Console.WriteLine ("Done"); done = true; }
  }
}
```

Nagy valószínűséggel megadja kétszer a `Done`-t.
```C#
class ThreadTest
    {
        static bool done; // Static fields are shared between all threads
        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }
        static void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        }
    }
```


A szál elindításakor nem egyértelmű, hogy melyik kap hamarabb vezérlést a `szál` vagy a `Main`, ezért nem determinisztikus amit kiír:
```C#
class ThreadTest {
  static void Main() {
    Thread t = new Thread (Go);
    t.Start (true); // == Go (true)
    Go (false);
  }
  
  static void Go (object upperCase) {
    bool upper = (bool) upperCase;
    Console.WriteLine (upper ? "HELLO!" : "hello!");
  }
}
```
```C#
// Az alábbiak csak kommentek:
public delegate void ThreadStart(); =>
public delegate void ParameterizedThreadStart (object obj);

Thread t = new Thread (new ParameterizedThreadStart (Go));
t.Start (true);
```

`Anonymous delegate`-ként is használhatjuk a szál függvényt, és a vislekedés szintén nem determinisztikus, lehet `After` és `Before` is kiírva hamarabb.
```C#
static void Main() {
  string text = "Before";
  Thread t = new Thread (delegate() { WriteText (text); });
  t.Start();
  text = "After";
}
static void WriteText (string text) { Console.WriteLine (text); }

// Az alábbiak csak kommentek:
static void Main() {
  Thread t = new Thread (delegate() { Console.WriteLine ("Hello!"); });
  t.Start();
}
```

Háttér típusú lesz az `Anonymous` szál, és egy billentyű leütésre vár, de mivel `háttér típusú` ezért ha a `Main` hamarabb fut le akkor nem vár a billentyű leütésre, ezrt a végeredmény sizntén nem determinisztikus:
```C#
class PriorityTest {
  static void Main (string[] args) {
    Thread worker = new Thread (delegate() { Console.ReadLine(); });
    if (args.Length > 0) worker.IsBackground = true;
    worker.Start();
  }
}
```

Kivételkezeléssel `try-catch`-el szálak esetében **rosszul**:
```C#
public static void Main() {
  try {
    new Thread (Go).Start();
  }
  catch (Exception ex) {
  // We'll never get here!
    Console.WriteLine ("Exception!");
  }

  static void Go() { throw null; } // unhandeled NullReferenceException
}
```

A fenti helyett a **jó**, fontos, hogy a kivételkezelést a szálban valósítsuk meg, `abort`álni is a `thread`en belül ajánlott, hogy elkapjuk és visszalépjünk a `Main`-be:
```C#
public static void Main() {
  new Thread (Go).Start();
}

static void Go() {
  try {
    ...
    throw null; // this exception will get caught below
    ...
  }
  catch (Exception ex) { // előbb kéne a speciális kivétel, ha le szeretnénk kezelni.
    //Typically log the exception, and/or signal another thread
    //that we've come unstuck
    ...
   }
}

// Másképp is lehetne kivételt kezelni: try{}finally{}
```
### Szinkronizáció
> Jól meghatározott kimenet érdekében érdemes használni.
> Egy egyszerű C# kód: 
> ```C#
> class Program
> {
> static void Main()
>  { 
>    string message = "Hello";
>    message += "world";
>    Console.WriteLine(Message);
>  }
> }
> ```
> 
> Az ennek megfelelő köztes nyelvi kód majd annak megfelelő assembly kód alakul ki. Így ha egy másik szál hozzáférhetne a `message`-hez akkor a kiírt érték megváltozhatna. Erre sajátos C# osztályokat használhatunk, biztosítékul, hogy nem férhetne hozzá más szál az általunk használt memóriaterületekhez. Erre megoldás a `szemafor` is.

Használhatjuk a következő metóduusokat:
- `Thread.Sleep()` -  blokkkolja a szálat
- `Thread.Join()` - szál befejezésére vár
- ` lock` - egy szál hozzáférhet az erőforráshoz, kódrészlethez, pl:
```C#
class Account 
{
  long value = 0;
   object obj = new object();
   
   public void Deposit(long amount)
   {
      lock (obj) { value += amount; }
   }
   
   public void Withdraw(long amount)
   {
      lock (obj) { value -= amount; }
   } 
} 
```
Ekkor amíg `lock`olva van az `obj` addig várni kell, hogy elvégezze a másik szál amit szeretne. *Ebben az esetben erre az időre felfüggesztődik a párhuzamosítás, és szekvenciálissá válik a működés* **!** 

**! Ha osztály szintű a szál akkor osztály szintű legyen a kulcs, ha példány szintű akkor példány szintű!**
```C#
using System;
using System.Threading;
class Program
{
    private static int counter = 0;
    private static object lockObject = new Object();
    static void Main(string[] args)
    {
        Thread t1 = new Thread(ThreadMethod);
        t1.Start();
        Thread t2 = new Thread(ThreadMethod);
        t2.Start();
     }
     
     private static void ThreadMethod()
     {
       lock (lockObject)
       { 
           counter++;
           Thread.Sleep(500);
           Console.WriteLine("A számláló állása: " + counter);
         }
    }
}
```
**Ezzel kapcsolatos problémák:**
`lock`olunk olyan eszközt amit más is `lock`ol, ezzel **Holtpőont, deadlock** alakulhat ki:
> Egyik szálon:
> ```C#                               
>  lock (a) { 
>   // feldolgozás
>   lock (b)     { // feldolgozás    }
> }
> ```
> miközben másik sázlon:
> ```C#
> lock (b) {
>   // feldolgozás
>   lock (a)     { // feldolgozás    }
> } 
> ```
**Livelock, élőpont** is kialakulat, ha egy rövid ideig egymásba zárolunk.

Ezekre megoldás a `Monitor` osztály, a háttérben a `lock` szintén ezt használja:
- `Enter()`
- `TryEnter()`
- `Exit()`







