> Hivatalos diasor: http://users.nik.uni-obuda.hu/vamossy/SZPE2018/
>
> Hivatalos segédanyagok: https://www.tankonyvtar.hu/hu/tartalom/tamop425/0053_Tobbszalu_Tobbmagos_Processzorarchitekturak_Programozasa/tobbszalu.pdf, https://www.inf.elte.hu/dstore/document/287/Parhuzamos-algoritmusok.pdf, https://docplayer.hu/1783123-Szamitogep-architekturak-i-ii-iii.html
>
> Ez csak egy jegyzet a tárgyhoz!

# Tartalom:
- [Bevezetés](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#bevezetes)
- [EA-GY1](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy1)
  - [Alapfogalmak](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#alapfogalmak)
  - [Párhuzamos rendszerek osztályozása](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#p%C3%A1rhuzamos-rendszerek-oszt%C3%A1lyoz%C3%A1sa)
    - [Michael J.Flynn-féle osztályozás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#michael-jflynn-f%C3%A9le-oszt%C3%A1lyoz%C3%A1s)
    - [`P`arallel `R`andom `A`ccess `M`achine - modell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#parallel-random-access-machine-pram---modell)
    - [Adatfolyam-gráf modell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#adatfolyam-gr%C3%A1f-modell)
    - [Feladat/csatorna modell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#feladatcsatorna-modell)
    - [Futószalagelvű végrehajtás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#fut%C3%B3szalagelv%C5%B1-v%C3%A9grehajt%C3%A1s)
    - [Szuperskalár végrehajtás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#szuperskal%C3%A1r-v%C3%A9grehajt%C3%A1s)
    - [Vektoralapú (SIMD) végrehajtás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#vektoralap%C3%BA-simd-v%C3%A9grehajt%C3%A1s)
    - [Vektoralapú (VLIW) végrehajtás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#vektoralap%C3%BA-vliw-v%C3%A9grehajt%C3%A1s)
    - [Szál szinten párhuzamos végrehajtás](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#sz%C3%A1l-szinten-p%C3%A1rhuzamos-v%C3%A9grehajt%C3%A1s)
    - [Az UMA-és a NUMA memóriamodell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#az-uma-%C3%A9s-a-numa-mem%C3%B3riamodell)
    - [Hibrid (N)UMA-memóriamodell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#hibrid-numa-mem%C3%B3riamodell)
    - [A ccUMA-és a ccNUMA memóriamodell](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#a-ccuma-%C3%A9s-a-ccnuma-mem%C3%B3riamodell---cache-coherent)
    - [Párhuzamos rendszerek elemei közötti kommunikáció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#p%C3%A1rhuzamos-rendszerek-elemei-k%C3%B6z%C3%B6tti-kommunik%C3%A1ci%C3%B3)
      - [Hálózati topológiák jellemzői](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#h%C3%A1l%C3%B3zati-topol%C3%B3gi%C3%A1k-jellemz%C5%91i)
      - [Kommunikáció időbeli jellemzői](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#kommunik%C3%A1ci%C3%B3-id%C5%91beli-jellemz%C5%91i)
- [EA-GY2](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy2)      
- [EA-GY3](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy3)
 - [Szinkronizáció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#szinkroniz%C3%A1ci%C3%B3)
- [EA-GY4](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy4)
  - [`monitor` osztály](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#monitor-oszt%C3%A1ly)
- [EA-GY5](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy-5)  
  - [kölcsönös kizárás `interloicked`](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#k%C3%B6lcs%C3%B6n%C3%B6s-kiz%C3%A1r%C3%A1s-interlocked-oszt%C3%A1llyal)
  - [`mutex`](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#mutex)
  - [`.Semaphore` osztály](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#semaphore-oszt%C3%A1ly)
  - [többszálú program tervezése](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#t%C3%B6bbsz%C3%A1l%C3%BA-program-tervez%C3%A9se)
  - [dekompzíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#1-dekompoz%C3%ADci%C3%B3)
    - [párhuzamossági fok](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#p%C3%A1rhuzamoss%C3%A1gi-fok)
    - [kölcsönhatási gráf](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#k%C3%B6lcs%C3%B6nhat%C3%A1si-gr%C3%A1f)
    - [dekompozíciós módszerek](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#dekompoz%C3%ADci%C3%B3s-m%C3%B3dszerek)
    - [rekurzív dekompozíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#rekurz%C3%ADv-dekompoz%C3%ADci%C3%B3)
    - [output adat dekompozíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#output-adat-dekompoz%C3%ADci%C3%B3)
    - [input adat dekompozíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#input-adat-dekompoz%C3%ADci%C3%B3)
    - [felderítő dekompozíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#felder%C3%ADt%C5%91-dekompoz%C3%ADci%C3%B3)
    - [spekulatív dekompozíció](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#spkulat%C3%ADv-dekompoz%C3%ADci%C3%B3)
   - [System.Threading.ThreadPool osztály](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#systemthreadingthreadpool-oszt%C3%A1ly)
   - [System.Threading.BackgroundWorker osztály](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#systemthreadingbackgroundworker-oszt%C3%A1ly)
- [EA-GY6](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy-6)
  - [eventwaithandle](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#eveentwaithandle)
  - [Lekghosszabb közös részsorozat](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#lekghosszabb-k%C3%B6z%C3%B6s-r%C3%A9szsorozat)
- [EA-GY7 - GPU programozás 1.](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy7---gpu-programozás-1)  
  - [ `C` kód `CUDA`sítása](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#c-kód-cudasítása)
  - [típusok/kulcsszavak](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#típusokkulcsszavak)
  - [CUDA könyvtárak](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#cuda-könyvtárak)
  - [CUDA errorok](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#cuda-errorok)
  - [Szálak és blokkok](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#szálak-és-blokkok)
    - [Substring keresési feladat](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#substring-keresési-feladat)
- [EA-GY7 - GPU blokkok és szálak](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#ea-gy7---gpu-blokkok-és-szálak)
  - [Több dimenziós blokkok](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#több-dimenziós-blokkok)
    - [Substring keresési feladat blokkokra optimalizálva](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#substring-keresési-feladat-blokkokra-optimalizálva)
  - [Blokkok közti kommunikáció `shared` memóriával](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#blokkok-közti-kommunikáció-shared-memóriával)
    - [Szókereső feladat - vázlat](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#szókereső-feladat---vázlat)
    - [Rendezés feladat](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra#rendezés)
---

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
> 
> *A matematikai kifejezés, melyet implementálni szeretnénk egy szöveges fájlban van leírva, melyben a kifejezés ki- és bemenetei, valamint átmeneti az változók is definiálva vannak. Az program a szöveges fájl alapján építi fel a kifejezés adatfolyam gráf reprezentációját, melyben minden operátor egy csúccsal van leírva, és minden csúcshoz hozzá van rendelve az operátornak megfelelő műveletvégző egység késleltetése.*
>
> *A következő lépésben a gráf csúcsait szintekhez [36] rendeljük. A gráfból egy speciális páros gráf lesz, melyben minden él olyan csúcshoz mutat, mely közvetlenül a következő szinten van.*
> 
> *forrás: [https://regi.tankonyvtar.hu/hu/tartalom/tamop412A/2011-0052_21_parhuzamos_szamitogep_architekturak_processzortombok/ar01s07.html](https://regi.tankonyvtar.hu/hu/tartalom/tamop412A/2011-0052_21_parhuzamos_szamitogep_architekturak_processzortombok/ar01s07.html)*


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

##### Párhuzamos rendszerek elemei közötti kommunikáció
> Teljesítmény növelés szempontjából lényeges, a párhuzamosított szálak közti kommunikáció minimalizálása a tervezés során.
> Topológiák:
> - teljes
> - csillag
> - lineáris 1D tömb
> - 2D vagy 3D tömb
> - [hiperkocka: 0D, 1D, 2D, 3D, 4D](https://hu.wikipedia.org/wiki/Hiperkocka)
> - fák: 
>   - statikus [bináris fa](http://aszt.inf.elte.hu/~asvanyi/ad/ad1jegyzet.pdf#73)
>   - dinamikus bináris fa
> ###### Hálózati topológiák jellemzői
> - Átmérő: a hálózatban két csomóbpont közti legnagyobb kimérhető távolság
> - szomszédos élek száma: bármely két csomópont közti összeköttetések száma
> - kapcsolati számosság: minimális élszám amit ha kiveszünk akkor a hálózat kettészakad
> - felezési szélesség: az a minimális élszám amit ha kiveszünk a hálózat két ***egyforma*** hálózatra esik szét
> - felezési sávszélesség: a hálózat bármely két része közti minimálisan meglévő sávszélesség
> - költség: kapcsolatok sázmával, átviteli paraméterekkel arányos jellemző
> ###### Kommunikáció időbeli jellemzői
> - késleltetés: az üzenet indítása és megérekzése közti idő, jobb algoritmussal csökkenthető. Csökkentési lehetőségek:
>   - nem blokkoló küldési és fogadási műveletek
>   - többszálú programozás
> - sávszélesség: időegységenkánt átvihető maximális adatmennyiség, a közeg határozza meg

### EA-GY2
> Moore törvénye alkalmazható a számítási kapacitásra is, csak ahhoz, hogy igaz legyen párhuzamosításra van szükség.Explicit párhuzamosság az amiről eddig volt szó, mikor párhuzamos programozási modellek teszik lehetővé a párhuzamosítást. Implicit párhuzamosítás az mikor párhuzamos algoritmusokat írunk. A párhuzamos algoritmusokat a **folymatok tulajdonságai**, a **folyamatok közti interakció** és az **adatkezelés módja** különbözteti meg egymástól.
#### Fejlesztési irányok: 
##### Fordítóprogramok funkcionalitásának bővítése
> Párhuzamosításra képes fordítóprogramok amik a soros programozási nyelvben korábban megírt programokban lehetséges párhuzamosítsái lehetőségeket felfedezik és megoldják.
> 
> Előnyei: 
> - nem kell újraiírni sok szoftvert
> - pénzt és időt spórol
> Hátrányai:
> - a soros vezérélési szerkezet és a ciklusok nehezen párhuzamosítható feladatok.
##### Programozási nyelvek bővítése
> Meglévő nyelvet kibővítünk egy párhuzamosításra alkalmas utasításkészlettel
> 
> Előnyei: 
> - kevés plusz munka
> - gyorsan lekészül(t)
> - könnyen továbbfejleszthető
> Hátrányai:
> - a fordprog nem optializál
> - nehéz debuggolás
##### Párhuzamos programozási rétegek kialakítása
> - Az alsó rétegek a számítási műveleteket tartalmazzák
> - Felső réteg: szabályozza a feldolgozási folyamatok létrehozását, szinkronizációját és befejezését.
> Következmény: a párhuzamos program irányított gráfként jeleníthető meg, ahol a csomópont soros művelet, élei adatfüggőségek, ugyanakkor ez egy új módszer.
##### Párhuzamos programozási nyelv
> - [Occam nyelv](http://wotug.ukc.ac.uk/parallel/occam/)   
> - explicit párhuzamosság áll elő, és a programnyelv sé a programozó egymást segíti így, ugynakkor ez új fordítóprogramokat ígényel, és nem garantált a különböző architectúrák közti átjára a nyelvnek.
##### Foster négylépéses modell
> ###### Felosztás
> *számítás és/vagy adatok kisebb részekre bontása, gyakorlati szempontok figyelmen kívűl hagyásával, párhuzamosításra törekedve*
> - adatfelosztás:
>   - kisebb egységekre szedjük az adatokat, hogy megválasszuk, az adatokhoz elvégzendő számításokat
>   - pl: 3D mátrixot 2D szeletekre, azok 1D szeletekre
> - funkcionális felosztás: 
>   - a feladatot részfeladatokra bontjuk
>   - pl: számozott színezés esetén minden színezés külön részfeladat lehet
> Ezek helyessgét így ellenőrizhetjük:
> - legalább egy nagyságrenddel több részfeladat mint végrehajtóegység
> - ne legyen felesleges számítás/tár ígény
> - azonos méretűek a részfeladatok
> - a részfeladatok száma növekedjen a megoldandó feladattal arányosan
> - alternatívák felállítása
>
> **Függőségi Gráf**:
> - csomópont: változó hozzárendelés, konstans deklarálás, operátor/függvény hívás
> - élek: változók/konstansok használata vezérlésben/adatfolyamban
> ###### Kommunikáció
> *Kommunikációs ígények megállapítása, megfelelő struktúrák kialakítása. A kommunikáció alapvetően a párhuzamosítás okán fellépő szükséges rossz, amire egy soros algoritmusnál nem volna szükség.*
> - **lokális kommunikáció**: kevés szomszédos feldolgozó egység. pl képfeldolgozás
> - **globális kommunikáció**: feldolgozóegységeknek részeredményt kell szolgáltatnia
> 
> Más felosztási lehetőség:
> - strukturált és ne mstrukturált
> - statikus és dinamikus
> - szinkron és aszinnkron
>
> Iránymutatás:
> - részfeladatok valóban egyidejű végrehajtása lehetséges lesz a választott kommunikációs módszerrel
> - arányos-e a kommunikáció és a részfeladatok mennyisége
> - a minimális számú egységgel kommunikál-e egy-egy egység
> - lehetséges-e az egyidejű kommunikáció
> ###### Összevonás
> *az előzőek felülvizsgálata, a megvalósítást figyelembe véve optimalizálási céllal*
> - az eddigiekkel ellentétben pont hogy nagyobb csoportokba csoportosítjuk a fealdatokat
> - **kommunikációs veszteségek minimalizálása**:
>     - gyakran kommunikáló feladatok összevonása
>     - gyakran küldő és fogad feladatok összegyűjtése az elküldendő üzenetek számának csökkentése végett => kevesebb de nagyobb üzenetcsomagok
> - **párhuzamosítás és skálázhatóság fenntartása**: ne legyenek nagyok az összevonási méretek, hogy processzorszámtól függetlenül jól fusson.
> - **fejlesztési költésg csökkentés**: inkább meglévő kódot párhuzamosítsunk mint teljesen újat írjunk
> tanácsok:
> - javított-e az összevonás időben, adatmásolásban, kommunikációs ígényben
> - részfeladatok száma elgendő-e, de nem-e túl sok?
> - párhuzamosításra áttérni ésszerű-e
> ###### Leképzés: 
> *Feladatok feldolgozóegységekhez rendelése. Kommunikáció minimalizálása.*
> - maximális a kihasználtásg, ha a számítások elosztása tökéletes
> - két részfeladat azonos processzorra leképzésével csökken a kommunikációs ígény => csoportosítás
> - legjobb egynesúly megtalálása
> - független feladatokat különböző OS folyamatokra
> - kritikus feladatokat a lgegyorsabban elérhető OS feladathoz rendelve
> - sokat kommunikáló feladatok ugynazon az OS szálon
> **=> NP teljes probléma, csak heursiztikával megoldható**
##### Amdahl törvénye
*egy rendszer sebessége legfeljebb milyen mértékben növelhető, ha csupán részben (azaz csak egyes elemeit) gyorsítják fel*
> 1/((1-P)+(P/S))
- *P*: a számítás felgyosított szakasza
- *S*: a P gyorsulásának mértéke
**Párhuzamosításra:**
> 1/(F+((1-F)/N)) 
- *F*: számítás soros szakaszra
- *N*: feldolgozó egységek száma
##### Gustafson törvénye
*nagyméretű, könnyen párhuzamosítható (ismétlődő elemekből álló) adathalmazok feldolgozása hatékonyan párhuzamosítható*
> S(P) = P-alpha*(P-1)
- *P*: feldolgozóegységek száma
- *S*: eredő gyorsulás mértéke
- *alpha*: nem párhuzamosítható problémarész
#### Programhelyesség
- prgamok helyességének biztosítása vagy megőrzése
- versengés mértéke

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

### EA-GY4
- Szálak életciklusa: start -> futás -> két lépésben megáll
- `waitsleepjoin`: vár a flag állapotára, és nem kell `sleep`ekre várni
- mikor a másik szál befejezte a dolgát `join`ol
#### `Monitor osztály`
- `Wait()`, `Pulse()`, `PulseAll()` csak a kritikus szakaszban használható
  - `PulseAll()` öszes várakozó szál felébresztése
  - `Pulse()` kritkikus szakszra várakozó szál felébresztése
  - `Monitor.Enter()` -> *készenállók sora* -> lock -> `Monitor.Exit()`
  -                                                ->`Monitor.Wait()` -> *várakozók sora* -> `Method.Pulse()`
#### Termelő-fogyasztó probléma - `szinkronizált puffer`
- beleteszünk a puferba, `pulse`-sal felébreszti az olvasót
- kiolvasunk, ha nincs mit olvasni várakozik
- ha több szál foglalja ugyanazt a kulcsot akkor egy logikai `flag` használatával lehet átállítani.

### EA-GY 5
#### Kölcsönös kizárás `interlocked` osztállyal
> Egyes egyszerű műveletek oszthatatlan végrehajtását biztosítja (igen gyors). 

.NET osztály: `System.Threading.Interlocked`
- `Add()` - 32/64b hozzáadása egészként változóhoz
- `CompareExchange()` - hivatkozott változó értékének összehasonlítása és egy értékadás is egyben, bővebben:https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=net-5.0 
- `Decrement()`,`Increment()` - A hivatkozott változó értékének csökkentése, illetve növelése 1-gyel
- `Exchange()` - A hivatkozott változó értékének beállítása és az eredeti érték visszaadása
- `Read()` - hivatkozott 64 bites változó értékének kiolvasása (32 bites rendszeren is atomi műveletként)
```C#
static long sum; //non atomic on 32 bit CPU
static void Main()
{
sum = 0; //non-atomic on 32-bit CPU
Interlocked.Increment(ref sum);//1
Interlocked.Decrement(ref sum);//0

Interlocked.Add(ref sum, 3);//3
Console.Writeline(Interlocked.Read(ref sum)); //3
Console.Writeline(sum); //10

Console.Writeline(Interlocked.CompareExchange(ref sum, 123, 10)); //10
Console.Writeline(sum); //123
Console.Readline();
}
```

#### `Mutex`
**!Megj:** kifejezetteen foylmatok közötti szinkronizációra való, egy folymaton belül a `lock` használatos!

> 1. példányosítani kell
> 2. `WaitOne()` és `ReleaseMutex()` hasznlata
>     - `WaitOne()` - kezdete
>     - `ReleaseMutex()` - vége
> - `name` paraméter egyedi lehet és akkor az alapján azonosítható, hogy mikor melyik `mutex`ről beszélünk
> - `GetCurrentProcess()` és `GetProcess()`a processek azonosításában segíhet
```C#
using System;
using System.Threading;

namespace interlocked_gyakorlas
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "albahari OneAtTimeDemo"); // második paraméter a `mutex` neve amit vizsgál, hogy létrejött-emár hasonló
static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
            {
                Console.WriteLine("another instance in use");
                return;
            }
            try
            {
                Console.WriteLine("running, press enter to exit");
                Console.ReadLine();
            }
            finally { mutex.ReleaseMutex(); }
        }
    }
}
```

Másik példa, `Main`en belüli `mutex` definiálással:
```C#
using System;
using System.Threading;

namespace interlocked_gyakorlas
{
    class Program
    {
        static void Main()
        {
            bool first;
            Mutex mutex = new Mutex(false, "albahari OneAtTimeDemo", out first); // második paraméter a `mutex` neve amit vizsgál, hogy létrejött-emár hasonló
            if (!first) //most hoztuk létre a mutexet vagy már egy másik program létrehozta?
            {
                Console.WriteLine("another instance in use");
                return;
            }
            else
                try
                {
                    Console.WriteLine("running, press enter exit");
                    Console.ReadLine();
                }
                finally { mutex.ReleaseMutex(); }
        }
    }
}
```

#### `.Semaphore` osztály
itt is használhatóak:
- `WaitOne()` és `Release()`
- `Thread.Sleep()`-el várakozunk
```C#
using System;
using System.Threading;

namespace interlocked_gyakorlas
{
    class Program
    {
        static Semaphore s = new Semaphore(3, 3); //első érték: elérhetőek száma, hogy a tlejes kapacitásban hány elérhető; a második érték a kapacitás
        static void Main()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            s.WaitOne();
            Console.WriteLine(id + " is in!");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + " is leaving");
            s.Release();
        }
    }
}
```
*Kérdés, hogy a fenti példában melyik ami a konstruktor két paramétere kzül a kapacitásnak megfelelő érték, ami a szemafor kritikus szakaszában.*

**[VIZSGAKÉRDÉS]Folyamatok közötti szemaforok esetében a konstruktorban milyen lehetőségek vannak, miből kell osztály szintű metódust létrehozni, mikor nem kell?**

#### többszálú program tervezése
##### 1. Dekompozíció
Függőségi gráf egy irányított gráf

**Példák:**

Sűrű mátrix vektorral szorzása
> Sűrű mátrix: sok nem használt vagy nem fontos elem, pl 0 egy-egy sorban
>
> Párhuzamosításhoz azonos méretű részeket rendelünbk a mátrixból és vektorból (szemcsézettség) amivel szorzunk és összeadunk.

Adatlekérdezés
> ha egyszerre szeretnénk a *piros*, *2001*-es és *civic* márkájú autókat kigyűjteni akkor lehet párhuzamosan kivenni a külön-külön részfeladatokat, amiket  összeéselhetjük, metszhetjük, stb stb stb
>
> a különböző részfeladat felosztási lehetőségek közül a lehető legoptimálisabb kiválasztása viszont nem triviális

###### párhuzamossági fok:
- vezérlésről/függőségekről ad információt
- meghatározza hány ágban tudunk tovább ténykedni, hogy hágny részfeladat meghatározható
- átlagos párhuzamossági fok`teljes idő/kritikus út`
- kritikus út meghatározása: maximum érték a gráf csúcsaiban szereplő értékek összege egy-egy leghozszzabb, számítható úton

###### kölcsönhatási gráf:
- feldolgozandó adatokról ad információt
- irányítatlan gráf
- mátrix reprezentáció

###### dekompozíciós módszerek
- adat dekompozíció
- rekurzív dekompozíció - *feladat dekompozíció*
- felderítő dekompozíció - *feladat dekompozíció*
- spekulatív dekompozíció - *feladat dekompozíció*
- hibrid dekompozíció

###### Rekurzív dekompozíció
> pl: Quicksort
>
> ![quick sort](https://www.geeksforgeeks.org/wp-content/uploads/gq/2014/01/QuickSort2.png)

###### output adat dekompozíció
> két `nxn`mátrix , A és B szorzat eredménye C, az eredméyn mátrix négy részre s osztható
> ![mátrix dekompozíció](https://d2vlcm61l7u1fs.cloudfront.net/media%2F2ed%2F2ed6b691-d84e-4f51-8ba6-6715ce5da13a%2FphpR5Whcs.png)

**Áruházak felosztása, hogya vásárló több helyre menjen**:

> - tranzakciós adatbázisokban cikkhalmazok gyakoriságának meghatározása, output szerint particionálás
> - van egy lista amit a vásárló szeet venni
> - van egy lista amit mi szeretnénk eladni
> ![áruházmodell](https://slideplayer.com/slide/4914294/16/images/22/Example%3A+Database+Transaction.jpg)

###### Input adat dekompozíció
Az előző áruházas modell, csak fordítva, azt részesítsük előnyben amit eladni szeretnénk

###### Felderítő dekompozíció
Olyan sázmítások dekompozíciója ahol a megoldás állapottérben történő keresésekhez kapcsolódik. Leírása álllapotterekkel történik. különböző lehetéses követő lépések mint önálló feladatokat vizsgálunk.
> **Anomáliák a számításban**
>
> felderítő dekompozíció esetében a dekompozíciós technika megváltoztathatja a munkamennyiséget akár megnövelheti akár csökkentheti azt. *Nem biztos, hogy mind hasznons munka!*

###### Spkulatív dekompozíció
diszkrét események szimulációjára használatos, 
- idő szerint eseménylista a központi adatstrukltúra
- események idő szerinti sorrendben kerlülnek beillesztésre
- csak spekulációval párhuzamosítható
- állapot visszaállítási extra feladatot követel
**[hf]: mi a különbség a fentiek között

#### `System.Threading.ThreadPool` osztály
fájl: http://users.nik.uni-obuda.hu/vamossy/SZPE2018/01%20-%20P%C3%A1rhuzamos%20programoz%C3%A1s%20.NET%20k%C3%B6rnyezetben.pdf
> Gyakran ismétlődő rövid ideig tartó erősen párhuzamos művelete
> 
> Használatával megtakarítható az aprólékos munka.

```C#

```

#### `System.Threading.BackgroundWorker` osztály
```
UI szál                 Háttérszál
 |                          |
 | - RunWorkerAsnc()        |
 |                          | - DoWork()
 |                          | - ReportProgress()
 | - ProgressChanged        |
 | - CancelAsync()          |
 |                          | - CancellationPending?
 | - RunWorkerCompleted()   
```
- `RunWorkerAsync()`            - háttérszál indítása
- `CancelAsync()`               - háttérszál leállítása
- `ReportProgress`              - Háttérszál folyamatjelzése
- `IsBusy`                      - Háttérszál aktív-e  
- `CancellationPending`         - leállítás folyamatban
- `WorkerSupportsCancellation`  - kérés esetén a háttérszál idő előtti leállítása

```C#
static BackgroundWorker bw;
static void Main()
{
bw = new Backgroundworker(),
bw.WorkerReportsProgress = true;
bw.WorkerSupportsCancellation = true;
bw.DoWork += bw_DoWork;
bw.ProgressChanged += bw_ProgressChanged;
bw.RunWorkerCompleted +=bw_RunWorkerCompleted;

bw.RunWorkerAsync("Hi worker");

Console.Write("press enter to cancel next 5 sec");
Console.Readline();
if(bw.IsBusy
```

2. kezdeti felosztás
3. kommunikáció
4. öszevont felahasználás
5. végleges program

### EA-GY 6
**Dinamikus programozás párhuzamosításssal**
fájl: https://users.nik.uni-obuda.hu/vamossy/SZPE2018/09-10%20-%20Dinamikus%20programoz%c3%a1s%20p%c3%a1rhuzamos%c3%adt%c3%a1ssal.pdf

> **dinamikus programozás**: optimalizációs problémák megoldása, csomagolási, string kezelési probléma
> - problémákat rész problémákra osztjuk
>   - azokat is tovább bontjuk alapesetig, aminek triviális megoldása van
> - a részfeladatok megoldásait eltároljuk

Példa: útkeresés
- hurokmentes, irányított gráfban a legrövidebb út
- *i*,*j* csomópontot összekötő él költsége *c(i,j)*
- *n* csomópontot tartalmaz a gráf *0,1,...n-1* és az *i* csomópontból a *j* csomópontba akkor vezet él, ha *i<j* A *0* csomópont a forrás és az *n-1* a cél.
- ha 0 és 4 csomópont között nézzük akkor: *f(4) = min{f(3)+c(3,4),f(2)+c(2,4)}* akkor meg kell nézzük az egy csomópontba bemenő élek értékeit.

> #### soros egyszerű argumentumú példák:
>
> ***legrövidebb út probléma többszintes gráfon***
> - a gráf súlyozott, több szintű, szintek száma *r+1*, minden szinten *n* csomópont van, és minden csomópont az *i*. szintről az *i+1* összes csomópontjáról. A *0*. és *r*. csak egy csomópontot tartalmaz.
> 
> ![hátizsák gráf](https://github.com/gabboraron/szoftverfejlesztes_parhuamos_architecturakra/blob/master/0-1hatizsak_problema.png)
>
> szintenként meghatározzuk a minimumot, az összes lehetésges esetet megviszgálva, de a két szint közti szakaszokat is beleszámolva és ezen szintek közti minimumot is meghatározzuk

> ***0/1 típusú hátizsák probléma***
> - adott *S* halmaz, *n* elemmel és egy súlyhatár *c*, minden *i* elemnek van egy *pi* egész értéke és egy *wi* egész súlya.
> - most nem fogallkozunk elemek darabolásával
> - cél olyan elemek  kiválasztása, hogy az összérték maximális legyen de az összsúy kisebb legyen mint *c*
> - többféle megközelítés lehet
>   - mohó, ahol legnagyobb értékűt használjuk 
>   - dinamikus megközelítés, ahol első *i* elem figyelembe vételével, ahol maximális súlyt alkalmazunk, *x*-et, így kapjuk *F[i,x]*-et ahol ha *wi>x* akkor *i* elem meghaladja a súlyhatárt és nem hozzávehető, és ha a legjobb *Si-1* részhalmazhoz ha jön újabb *i* elem akkor *x-wi* nem eredményez túl nagy súly növekedést
> ```C#
> Algorithm 0-1Knapsack(S, c):
>   Input: S halmaz elemei pi értékkel, wi súllyal; valamint a max. súly c
>   Output: a legjobb részhalmaz értéke (F[n, c]), hogy teljesül: összsúly ≤ c
>   
>   for x <- 0 to c do
>     F[0, x] <- 0
>     for i <- 0 to n do
>       F[i, 0] <- 0
>     for i <- 0 to n do
>       for x <- 0 to c do
>         if wi <= x
>           F[i, x] <- max(F[i - 1, x], F[i - 1, x - wi] + pi)
>         else
>           F[i, x] <- F[i - 1, x]
> ```
> 
> *n=4*, *c=5* és az alábbi elemek esetén:
> ```
>  i    wi    pi
>  1    2     3
>  2    3     4
>  3    4     5
>  4    5     6
> ```
> - létrehozunk egy *nxc* méretű táblát, így a soros futási idő ezzel arányos

#### `eveentWaitHandle`
```C#
static EventWaitHandle wh = new AutoResetEvent(false); //signalozott, vagy ne msiganlozott állapotban van, a kapu nyitva van-e
        
        static void Main(string[] args)
        {
            new Thread(Waiter).Start();
            Thread.Sleep(1000);
            wh.Set();
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting...");
            wh.WaitOne();//signalra várakozik
            Console.WriteLine("Notified");
        }
```

#### Lekghosszabb közös részsorozat
Adott két részsorozat, *X* és *Y*, *pl:X = <c,a,d,b,r,z> és Y=<a,s,b,z>, leghosszabb közös részsorozata X és Y-nak: <a,b,z>*.
- *i* az *X* eslő *i* eleme
- *j* az *Y* eslő *j* eleme

Rekurzív kifejezés:
- 0 ha i = 0 vagy j=0
- F[i-1,j-1]+1   ha i,j>0 és xi=yj
- max{f[i,j-1],F[i-1,j]} ha i,j>0 és xi != yj

1. Kiszámoljuk a két dimenziós F táblát sor-oszlop sorrendben
2. átlós csomópontok mind új részprroblémát szülnek
3. mindig létrehozunk egy plusz nulladik sort és oszlopot kinullázva
4. az előző sorból a tőle eggyel balra eső elemhez hozzáadunk egyet ha egyezőség van
5. az így kapott értékek mindig az addig eső részsorozatokban lévő hasonló elemek számát adja meg
6. 
```Text
    H E A G A W G H E E
  0 0 0 0 0 0 0 0 0 0 0
P 0 0 0 0 0 0 0 0 0 0 0
A 0 0 0 1 1 1 1 1 1 1 1
W 0 0 0 1 1 1 2 2 2 2 2
H 0 1 1 1 1 1 2 2 3 3 3
E 0 1 2 2 2 2 2 2 3 4 4
A 0 1 2 3 3 3 3 3 3 4 4
E 0 1 2 3 3 3 3 3 3 4 5
```

### EA-GY7 - GPU programozás 1.
> hivatalos anyag: http://szfi.nik.uni-obuda.hu/elearning/app/
>
> **Ha online szeretnénk futtatni** pl NVIDIA GPU hiányában:
> 1. https://colab.research.google.com
> 2. `file`>`new notebook`
> 3. `%%writefile first.cu` parancsot fűzünk a kód elejére -> kiíródik a `first.cu` fájlba
> 4. `!nvcc first.cu -o first` parancsal lefordítjuk
> 5. `!./first` parancsal futtathatjuk a parancsot
>
> beállítások: `edit` > `notebook settings` > `GPU`


#### `C` kód `CUDA`sítása
> Egy vektor elemeit megszorozzuk kettővel

`CUDA` verzió **1** szállal
```CUDA
#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include "<stdio.h>"

int A[] = {1,2,3,4,5}; 
__devcie__ int dev_A[5];

__global__ voiod szorzas(){
  for(int i=0; i<5; i++)
   dev_A[i] *= 2;
}

int main(){
  cudaMemcpyToSymbol(dev_A, A, 5*sizeof(int)); //CPU oldalról GPU oldalra másol //hova, honnan, méret
  szorzas<<<1,1>>>();//blokkok,szálak száma
  cudaMemcpyFromSymbol(A, dev_A, 5*sizeof(int)); //GPU oldalról CPU oldalra másol
  
  for(int i=0;i<5;i++)
    printf("A[%d]=%d\n", i,A[i]);
}
```

`CUDA` verzió **5** szállal
```CUDA
#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include "<stdio.h>"

int A[] = {1,2,3,4,5}; 
__devcie__ int dev_A[5];

__global__ voiod szorzas(){
  int i = threadIdx.x;
   dev_A[i] *= 2;
}

int main(){
  cudaMemcpyToSymbol(dev_A, A, 5*sizeof(int));
  szorzas<<<1,5>>>(/*ha lenne paraméter itt adóda át, de ugyanaz adódik át az összes szálnak!*/);//blokkok,szálak száma
  cudaMemcpyFromSymbol(A, dev_A, 5*sizeof(int));
  
  for(int i=0;i<5;i++)
    printf("A[%d]=%d\n", i,A[i]);
}
```

#### típusok/kulcsszavak
**vektor típusok:**
- `char1`, `uchar1`...`char4`, `uchar4`...
- `short1`, `ushort1`... `short4`, `ushort4`...
- `int...`
- `long...`
- `float...`
ahol az `int4` a 4 elemű `int` vektor

**`dim3`** - több dimenziós adatok tárolására

- **`__device__`** - egy olyan fv elé kell ami GPU-n fut és másik GPU-n belüli függvényből lehet meghívni
- **`__global__`** - belépési pont GPU-ra, azaz CPU oldalról elindítható

```CUDA
__global__ void vectorMul(float *A)
{
  int i = threadidx.x;
  A[i] = A[i]*2;
}
```

#### CUDA könyvtárak
> Ezek előre megírt számítások, pl mátrix sázmítások, Furier transzformációk
> - szinkronizációs műveletek
> - atomi műveletek

#### CUDA errorok
> Az errort generáló függvények `cudaError_t` típusúak.
>
> Minden egyes hívásnál ellenőrizni kell, mert nincs egyéb visszajelzés a hibáról.

#### Szálak és blokkok
A szálak blokkokba vannak szervezve, ezért:
- `blockIdx` - így lehet lekérni egy blokk azonosítót
- `blockDim` - egy blokk méretét adja meg
- `gridDim` - összesen hány ilyen blokk van


**Képernyőn kívűl más interfész nincs!**
```CUDA
//>=CC2.0

__global__ static void VectorShift(float *devA){
   float tmp = devA[threadIdx.x];
   __syncthreads();
   printf("%f%f\n", threadIdx.x, tmp);
   devA[threadIdx.x+1] = tmp;
}
```

**Kernel indítás**
```CUDA
__global__ void kernelSample(float* A, int b)
{
   //...
}

//...

float* A = ...
//másolás GPU-ra

//kernel hívás
kernelSample <<<1,200>>>(A,B) // <<<blokkok_szama,szalak_szama_a_blokkon>>>(parameter_A,parameter_B)

//visszakapott eredmény másolása GPU-ról
```

![CUDA threading](https://www.microway.com/wp-content/uploads/CUDA-GridBlockThread-Structure.png)

`CC3.0` utáni verzióknál a GPU szálak is indíthatnak szálakat

-> kernel block szinkronizáció: `void __syncthreads()` -> ebben az esetben minden szálnak hozzá kell férnie ugyanahhoz a `__syncthreads()`-hez pl ne dugjuk el egy `if`be, vagy hasonlók **!**

##### Substring keresési feladat
```CUDA
//két char vektor:
// szo:     [s,z,o] M=3 
// mondat:  [a,s,z,i,s,z,o,k] N=8
// talalat: [-1] //a szo kezdetének kezdőindexe
// N-M+1 szálat használhatunk
// vagy (N-M+1)*M 

#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include <stdio.h>

#define N 20
#define M 3

char text[N+1] = "Ez egy hosszú szöveg";
char word[M+1] = "szo";

__device__ char dev_text[N];
__device__ char dev_word[M];
__device__ int dev_pos;

//
__global__ void findWordSingle()
{
  for(int i = 0; i<=N-M; i++)
  {
     int j = 0;
     while(j<M && dev_text[i+j] == dev_word[j])
       j++;
     if(j == M) 
       dev_pos = i;
  }
}

//
__global__ void findWordN()
{
  int j = 0;
  while(j<M && dev_text[threadIdx.x + j] == dev_word[j])
    j++;
  if(j== M)
    dev_pos = threadIdx.x;
}

//
__device__ char dev_temp[N];
__global__ void findWordNM()
{
   if(threadIdx.y == 0)
     dev_temp[threadIdx.x] = 0;
   
   __syncthtread();
   if(dev_text[threadIdx.x +threadIdx.y] != dev_word[]threadIdx.y)
     dev_temp[threadIdx.x] = 1;
     
   __syncthtread();  
   if(threadIdx.y == 0)
     if(dev_temp[threadIdx.x] == 0)
       dev_pos = threadIdx.x;
}

//
__global__ void findWordNMSync()
{
   if(threadIdx.y == 0)
     dev_temp[threadIdx.x] = 0;
   __syncthreads();
   
   if(dev_text[threadIdx.x + threadIdx.y] != dev_word[threadIdx.y])
     dev_temp[threadIdx.x] = 1;
   __syncthreads();
   
   if(threadIdx.y == 0)
     if(dev_temp[threadIdx.x] == 0)
       dev_pos = threadIdx.x;
}

int main(){
  int pos = -1;
  for(int  i = 0; i<=N-M;i++){
    int j = 0;
    while(j<M && text[i+j] == word[j])
      j++;
    if(j == M)
      pos = i;
  }
}

cudaMemcpyToSymbol(dev_text, text, N*sizeof(char));
cudaMemcpyToSymbol(dev_word, word, M*sizeof(char));
cudaMemcpyToSymbol(dev_pos, &npos, sizeof(int));

findWordSingle<<<1,1>>>();
cudaMemcpyFromSymbol(&pos, dev_pos, sizeof(int));
printf("GPU result 1: %d\n",pos);

findWordN<<<1,N-M+1>>>();
cudaMemcpyFromSymbol(&pos, dev_pos, sizeof(int));
printf("GPU result N: %d\n",pos);

findWordNM<<<1,dim3(N-M+1,M)>>>();
cudaMemcpyFromSymbol(&pos, dev_pos, sizeof(int));
printf("GPU result NxM: %d\n",pos);

findWordNM<<<1,dim3(N-M+1,M)>>>();
cudaMemcpyFromSymbol(&pos, dev_pos, sizeof(int));
printf("GPU result NxM synchronized: %d\n",pos);

```

### EA-GY8 - GPU blokkok és szálak

> Rögzített, hogy egy blokkon belül hány szál indítható maximum: az újabb verziókban `1024`. 
> 
> **A blokkok közötti kommunikáció/adatcsere/szinkronizáció nem létezik!**
>
> ![streaming multiprocesszor VS core](https://www.researchgate.net/profile/Stamatios_Sotiropoulos/publication/236666656/figure/fig1/AS:299544987357185@1448428498422/Typical-NVIDIA-GPU-architecture-The-GPU-is-comprised-of-a-set-of-Streaming.png)
> A GPU-n belül a streaming processor futtat több blokkot
> 
> pl:
> ```CUDA
> //100 000 szál létrehozásához használnunk kell 
> //100 blokkot
> //blokkonként 1000 szálat
> 
> kernel<<<100,1000>>>...
> 
> //ha kevés a streaming multiprocesszor, akkor
> //amint egy blokknyi szál végzett a feladatával akkor
> //a streamingmultiprocesszor befejezi a futtatását, és kicseréli a következő blokkra
> //ezért a futtatás nem lesz sem pont párhuzamos, sem pont egyidejű
> //tehát ebben az esetben 100 db blokk fog egymástól teljesen függetlenül futtatni 1000 db szálat
> ```
 
#### Több dimenziós blokkok
> Létrehozhatunk több dimenziós blokkokat amik a háttérben több szálat futtatnak gyakorlatilag
>
> ![több dimenziós szálak](https://codingbyexample.com/wp-content/uploads/2018/12/gridWBlock-1014x1024.png)
>
> ```CUDA
> kernel<<<dim3(2,2),dim3(2,2)>>>
> ```
> 
> Kernelen belül blokk azonosítók haszánlata:
> ```CUDA
> __global__ void vectorMul(float* A, intN)
> {
>   int i = blockIdx.x*blockDim.x+threadIdx.x;
>   if(i<N)
>   { A[i]=A[i]*2; }
> }
>
> float* A = ...
> ... transferdata CPU -> GPU ...
> vectorMul<<<4,250>>>(A,1000);
> ... transferresults GPU -> CPU ...
> ```

**De mennyi szál és mennnyi blokk kell?**
```CUDA
blokk méret: BM = 10
T szál
blokkok száma = összes_szál_száma/blokk_méret = T/BM ha 10-el osztható számú szállal, egyébként:
[(T-1)/BM]alsó egész + 1

 T   blokk
 9     1
 10    1
 11    2 //mert 10 a blokk méret 
```

##### Substring keresési feladat blokkokra optimalizálva
```CUDA
#include "cuda_runtime.h"
#include "device_launch_paramters.h"
#include <stdio.h>
#define N 10000
#define BLOCK_SIZE 100

int A[N];
__device__ void szorzas(int mennyivel){
  int i = blockIdx * blockDim.x + threadIdx.x;
  dev_A[i] *= mennyivel;
}

int main(){
  for(int i = 0; i< N; i++)
    A[i] = i
  cudaMemcpyToSymbol(dev_A, A, N*sizof(int));
  int block_count = (N-1)/BLOCK_SIZE + 1;
  szorzas<<<block_count,BLOCK_SIZE>>>(3);
  cudaMemcpyFromSymbol(A, dev_A, N*sizeof(int));
  for(int i=0; i<N; i++)
    printf("A[%d]=%d\n",i,A[i])
}
```

#### Blokkok közti kommunikáció shared memóriával

A `shared` memória egy blokkon belüli közös memóriaterületet ad. `48 KB` memória nagyjából.
`shared` memórián elérhető változó deklarálása:
```CUDA
__shared__ int a;
```

`devie memory` egy lassú de minden szál/blokk által látott memória terület ami kártya saját memóriája.
```CUDA
__device__ int y;
```

adatok másolása `devie memory`ból `shared`-re:
```CUDA
__device__ int y;
__global__ void f(){
   ...
   int x;
   __shared__ int z;
   x = y;
   z = 5;
   z = y;
}
```

##### Szókereső feladat - vázlat 
```CUDA
// szöveg: abcdefgh
// szó:    xyz
//
// => szöveg mérete*szó mérete mennyiségű szál
//
//   abcdefgh
//   xyz
// 1 x==a  x==b  x==c  ...
// 2 y==b  y==c  y==d  ...
// 3 z==c  z==d  z==e  ...
// => N-M+1 szál van
// => érdemes bemásolni a szót és a szöveget is beolvasni a shared memóriába
```

##### Rendezés
```CUDA
// 3 8 7 1 2 9 4 1
// N elem => N/2 szál
// 2x és 2x+1. szálak összehasonlítása
//
// I. lépés
// tömb elemek: 3  8  7  1  2  9  4  1
//               \/    \/    \/    \/
// szálak:        0     1     2    3
//
// II. lépés
// tömb elemek: 3  8  1  7  2  9  1  4
//                  \/    \/    \/    
// szálak:           0     1     2    (3.-nem fut)
//
// III. lépés
// tömb elemek: 3  1  8  2  7  1  9  4
//               \/    \/    \/    \/
// szálak:        0     1     2     3
//
// IV. lépés
// tömb elemek: 1  3  2  8  1  7  4  9
// 
// ...
//
// (N/2 + N/2)*N/2 ~ O(N^2) művelet, de O(N) idő


#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include <stdio.h>

#define N 20
#define M 3

char text[N+1] = "Ez egy hosszú szöveg";
char word[M+1] = "szo";

__device__ char dev_text[N];
__device__ char dev_word[M];
__device__ int dev_pos;



// x:0..N-M
// y:0..M-1

__global__ void findWordNMSyncShared()
{
   __shared__ char shr_text[N];
   __shared__ char shr_word[M];
   __shared__ char shr_temp[N]
   
   int i = threadIdx.x + threadIdx.y * blockDim.x;
   if(i < N)
      shr_text[i] = ev_text[i]
   
   if(theradIdx.x == 0)
      shr_word[threadIdx.y] = dev_word[threadIdx.y];
   
   if(threadIdx.y == 0)
     shr_temp[threadIdx.x] = 0;
   __syncthreads();
   
   if(shr_text[threadIdx.x + threadIdx.y] != shr_word[threadIdx.y])
     shr_temp[threadIdx.x] = 1;
   __syncthreads();
   
   if(threadIdx.y == 0)
     if(shr_temp[threadIdx.x] == 0)
       dev_pos = threadIdx.x;
}

int main(){
  int pos = -1;
  for(int  i = 0; i<=N-M;i++){
    int j = 0;
    while(j<M && text[i+j] == word[j])
      j++;
    if(j == M)
      pos = i;
  }
}

cudaMemcpyToSymbol(dev_text, text, N*sizeof(char));
cudaMemcpyToSymbol(dev_word, word, M*sizeof(char));
cudaMemcpyToSymbol(dev_pos, &npos, sizeof(int));

findWordNMSyncShared<<<1,dim3(N-M+1, M)>>>();
cudaMemcpyFromSymbol(&pos, dev_pos, sizeof(int));
printf("GPU result 1: %d\n",pos);
```

### EA 9 - taskok és threadek
#### Thread Class
https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=netcore-3.1

#### ThreadPool Class
![threadpool wiki](https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Thread_pool.svg/1920px-Thread_pool.svg.png)
https://docs.microsoft.com/en-us/dotnet/api/system.threading.threadpool?view=netcore-3.1

#### Task Class
https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=netcore-3.1

### EA-GY10 - szálbiztos adatszerkezetek
> https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/

**Konkurens gyűjtemények:**
-https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent?view=net-5.0
- `cocurentbag`
- `ConcurrentDictionary`
- `blockingCollections`
