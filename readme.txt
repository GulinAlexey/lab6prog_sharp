Прикладной задачей данной работы является управление заповедниками. 
Нужно вести учёт работников заповедника для хорошего управления, а также самих заповедников для 
эффективного распределения средств. Использовать классы.

//////////////////////////////////////////
Класс: Worker (работник заповедника) (будет вызываться другим классом)

Поля:

private int num_tr                     номер трудовой книжки
private String name_surname            имя и фамилия
private String dolzh                   должность
private int hours                      кол-во рабочих часов
private int zarpl                      зарплата в месяц в рублях
private int progools                   кол-во прогулов (в днях)

Методы:

public Worker(int num_trud, String name_sur, String dolzhno, int hourss, int zarplat, int progoo)         конструктор с параметрами
public void Init(int num_trud, String name_sur, String dolzhno, int hourss, int zarplat, int progoo)  Инициализация
public void Display()                                         вывод
public void Read()                                            ввод
public void Add(Worker wr1, Worker wr2)                       сложение
public void Obnul()                                           обнуление прогулов (прикладное)
public void Izm_zarpl()                                       изменение зарплаты (прикладное)

          Получение и установление соответствующих полей
public void set_num(int num)
public int get_num()
public void set_h(int h)
public int get_h()
public void set_z(int z)
public int get_z()
public void set_prog(int prog)
public int get_prog()
public void set_name(String nam)
public String get_name()
public void set_dol(String dol)
public String get_dol()


//////////////////////////////////////////
Класс: Reserve (заповедник) (будет вызывать класс Worker)

Поля:
private String title        название заповедника
private int budget          бюджет заповедника
private int expens          расходы
private int kolvow          кол-во работников в заповеднике
private Worker workers[LEN]  работники заповедника

Методы:

public Reserve(String titl, int budg, int exp, int kolv, Worker[] works)              конструктор с параметрами
public void Init(String titl, int budg, int exp, int kolv, Worker[] works)          Инициализация
public Reserve(String titl, int budg, int exp, int kolv, Worker works)                  Конструктор с параметрами (выполняет инициализацию, вторая перегрузка)
public void Display()                                                   вывод
public void Read()                                                      ввод
public void Add(Reserve r1, Reserve r2)                                 сложение
public void ZarplChange()                                               изменение зарплаты всех работников (прикладное)
public void BudgChange()                                                изменение бюджета (прикладное)
