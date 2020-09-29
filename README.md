# Tartalom:
- [Bevezetés](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#bevezetes)
- [EA-GY1](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy1)
  - [Alapfogalmak]()
  - [Párhuzamos rendszerek osztályozása]()
    - [Michael J.Flynn-féle osztályozás]()
    - [`P`arallel `R`andom `A`ccess `M`achine - modell]()
    - [Adatfolyam-gráf modell]()
    - [Feladat/csatorna modell ]()
    - [Futószalagelvű végrehajtás]()
    - [Szuperskalár végrehajtás]()
    - [Vektoralapú (SIMD) végrehajtás]()
    - [Vektoralapú (VLIW) végrehajtás]()
    - [Szál szinten párhuzamos végrehajtás]()
    - [Az UMA-és a NUMA memóriamodell]()
    - [Hibrid (N)UMA-memóriamodell]()
    - [A ccUMA-és a ccNUMA memóriamodell]()
- [EA-GY3](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy2)
 - [Szinkronizáció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#szinkroniz%C3%A1ci%C3%B3)

## Bevezetés
> Párhuzamos programozáshoz a Neumann architectúrás gépeken szükséges a programnyelv kifejezett támogatása a számítási feladatok egymással egyidőben való részfeladatokra bontására és a számítás elvégzésére közel párhuzamosítva.
>
> **Miért van erre szükség**
> 
> - A reálisan elérhető maximális órajel 5GHz, míg a processzorok belsejében lévő adatutak hossza elég hosszú ahhzo, hoyg ha fénysebességgel is közlekedik az adat akkor sem érjen át időben egyik végéből a másikba, a sávszél növelésével pedig nagy hőingadozáshoz jutunk a processzor egyik végétől a másikig.
> - A számítási korlátok sem elhanyagolhatóak, egy általános programban 4-6, de gyakorlatialg inkább 2-3 utasítás fut párhuzamosan. A memóriák sebességének nvekedése elmarad a processzoroktól, így, párhuzamosítva viszont jobban kihasználhatóak. Az elosztott hálózati számításokra való ígény is igen magas.
> 
> **Párhuzamosítás határai**
> - *Függőségek*, egymárautaltságok alakulnak ki két feladat között, amik akadályozhatják a párhuzaomsítást. Ilyen lehet:
>    - *adatfüggőség* mikor egy művelet eredményét egy másik művelet bementként várja
>    - *elágazási függőség* egy művelet eredméyne dönti el, hogy egy másik műveletet végre kell-e hajtani, vagy melyik művelet jöjjön sorra
>    - *erőforrás függőség* egy erőforrásra több művelet is foglalkozna és meg kell várják míg az egyik végez a másikkal.
> - *Szinkronizáció* segítésgével két párhuzamos feladat között megjósolható közös pontot keresünk. Használható két művelet eredményeinek ellenőrzésére például. Ha nincs szükség szinkronizálása akkor *aszinkron* műveletet kapunk.

### EA-GY1
#### Alapfogalmak:
- soros végrehajtás: fizikailag egy időben, eegy művelet végrehajtásának lehetősége.
- párhuzamos végrehajtás: egy időben egynél több művelet végrehajtásának lehetősége
- kvázipárhuzamos végrehajtás: látszólagos párhuzamosság időosztásos technológiával
- egyidejűség: párhuzamos végrehajtás esetén kettő vagy több művelet egy időben egymást átfedő végrehajtása
- kvázi egyidejűség: kvázipárhuzamos végrehajtás kettő vagy több művelet logikailag időben egymást átfedő végrehajtása
- program: utasítások halmaza, feladatokra bontható
- folyamat: végrehajtás alatt álló progaram, szőröstől bőröstől
- szál: folyamaton belüli alegység
- végrehajtási egység: egy adott szál legkisebb végrehajtható részhalmaza
- feldolgozó egység: végreajtási egységet feldolgozó hardverelem
#### Párhuzamos rendszerek osztályozása
##### Michael J.Flynn-féle osztályozás
> *1966-ból származó osztályozás a legismertebb és legnépszerűbb osztályozási módszere. Alapfelvetés: minden számítógép utasításfolymaokat hajt végre, melyek segítségével adatfolyamokon végez műveleteket:*
> | **SISD** 1 utasítás, 1 adatfolyam  | **SIMD** 1 utasítás, több adatfolyam |
> | ---------------------------------- | ------------------------------------ |
> | Soros működésű, hagyományos gépek  | Vektorszámítógépek, több formában léteztek már, GPGPU architectúrák |

> | **MISD** több utasítás, 1 adatfolyam  | **MIMD** több utasítás, több adatfolyam |
> | ------------------------------------- | --------------------------------------- |
> | Hibatűrő architectúrák, űrrepülők, stb, melyeknél több VE is ugyanazt végzi, és az eredméyeknek egyezniük kell | teljesen párhuzamos sázmítógép melynél minden egység külön programozható fel  |
> 
> **Problémák:**
> - Általában a memóriából származnak az adatok, és csak soronként kerülnek a memóriába.
> - Tulzó, a kis különbségek tekintetében
> - Nem ismer köztes osztályokat => nehezen finomítható
> - Erősen hardverközpontú => nehéz kialakítani párhuzamos rendszereket.
**Finomítás:**
- prognyelv és környezet dimenziója
- Végrehajtási elemk együttműködésének dimenziói
- implicit párhuzamosság, fordító progam által vezérelt párhuzamosság, stb

##### `P`arallel `R`andom `A`ccess `M`achine (PRAM) - modell 
> Egy Neumann-elvű gép továbbgondolása párhuzamos formában.
> - Osztott memória
> - elvben akármyneni feldolgozó egységgel
> - elhanyagolja a kommunikáció és szinkronizáció problémáit
> - ütközésekre négy módszer:
>   - EREW: kizárólagos olvasás és írás
>   - CREW: egyidejű olvasás és kizárólagos írás
>   - ERCW: kizárólagos olvasás és egyidejű írás
>   - CRCW: egyidejű olvasás és egyidejű írás
> 
> egyidejű írás kezelése:
> - közös: minden írási művelet ugyanazt az adatot írja
> - önkényes: egyik írás sikeres a többi továbblép
> - prioritásos: fontossági mutató dönt, hogy melyik lesz sikeres
> - egyéb, mint AND, OR, SUM kombinálása
>
> **Algoritmusok becsülyt költsége:`O`*`(időígény*processzorszám)`***

##### Adatfolyam-gráf modell 
> bemenő adatfolymaokból a modellstruktúrát felépítő feldolgozó egységek kimenő adatfolyamokat állítanak elő. Adatfolyam-ábrával moddelezhető.

##### Feladat/csatorna modell 
> *Ian T. Foster, 1995*
>
> [https://www.mcs.anl.gov/~itf/dbpp/](https://www.mcs.anl.gov/~itf/dbpp/)
> - A párhuzamosítató utasítások egy nagy feladathalmaz
> - egy feladat önmagában hagyományos soros végrehajtású program aminek helyi memória és be/ki menetei portok állnak rendelkezésére. 
> Négy alapművelet:
>  - üzenet küldése
>  - üzenet fogadása
>  - új feladat létrehozása
>  - feladat befejezése 

##### Futószalagelvű végrehajtás
> A végrehajtást lépcsőkre bontjuk, és órajelenként lépünk a lépcsőben:
>![futószalag ábra](https://upload.wikimedia.org/wikipedia/commons/2/21/Fivestagespipeline.png)

##### Szuperskalár végrehajtás
> Egyszerre több (pl két) futószallagot működtetünk párhuzamosan, viszont a valóságban a függőségek miatt nem lehet gételenül növelni.
>![szuperskalár ábra](https://upload.wikimedia.org/wikipedia/commons/4/46/Superscalarpipeline.svg)

##### Vektoralapú (SIMD) végrehajtás
> a fordítóprogramra hagyjuk a párhuzamosítás lehetőségének észlelését, például ugyanazon művelet más-más adatsoron való futtatása

##### Vektoralapú (VLIW) végrehajtás
> a fordítóprogramra egy hosszú gépi kódú utasításszóba elemzést követően több utasítást is beprésel amik párhuzamosan hajtódnak végre. Ezek általánosítása fikció egyenlőre.

##### Szál szinten párhuzamos végrehajtás
> Mivel egy  végrehajtási szálon belül biztosan lesznek feloldhatatlan adatfüggőségek amik korlátozzák a párhuzamosítást, a várakozás alatt levő szabad számítási kapacitást egynél több szállal is ellát egy-egy végrehajtó egységet.
> - **Szimetrikus Többszálú feldolgozás**
>   - egy processzoron belül bizonyos részegységek sokszorozása, de mindig kevesebbé mint a teljes processzor!
>   - [Intel Hyper-Threading](https://en.wikipedia.org/wiki/Hyper-threading)
> - **Többmagos processzor**
>   - egy egységen belül több processzor, speciálisan összekötve
> - **Többmagos processzor SMT-vel**
>   - kombinálva az előző két megoldási lehetőséget

##### Az UMA-és a NUMA memóriamodell
> **UMA: Uniform Memory Access (közös memória)** más néven: *(symmetric multiprocessor - SMP)*
> - minden processzor egy közös memórában tárol MINDENT
> **NUMA: Non-Uniform Memory Access (elosztott memória)** más néven: *(distributed memory - DM)*
> - minden processzor saját, egymástól független memóriát használ

##### Hibrid (N)UMA memóriamodell
> - egynél több memóriarész, de nincs mindegyik processzornak sajátja, hanem csokrokba kötve
> - szuperszámítógépeknél használt

##### A ccUMA-és a ccNUMA memóriamodell - *cache-coherent*
> külön koherencia protokollt megvalósító egység felel a kommunikációs hálózattal való kapcsolatáról a processzoroknak





### EA-GY3
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







