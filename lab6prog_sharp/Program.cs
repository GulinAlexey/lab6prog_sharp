//Гулин А. Н., ПИ-92. Лаб. 8 "Статические поля и методы"
using System;

namespace lab6prog_sharp
{
    class Worker //работник заповедника
    {
        private int num_tr; //номер трудовой книжки
        private string name_surname; //имя и фамилия
        private string dolzh; //должность
        private int hours; //кол-во рабочих часов
        private int zarpl; //зарплата в месяц в рублях
        private int progools; //кол-во прогулов (в днях)

        //конструктор с параметрами
        public Worker(int num_trud, string name_sur, string dolzhno, int hourss, int zarplat, int progoo)
        {
            this.num_tr = num_trud;
            this.name_surname = name_sur;
            this.dolzh = dolzhno;
            this.hours = hourss;
            this.zarpl = zarplat;
            this.progools = progoo;
        }

        //свойства полей
        public int Num_tr
        {
            get { return num_tr; }
            set { num_tr = value; }
        }

        public string Name_surname
        {
            get { return name_surname; }
            set { name_surname = value; }
        }

        public string Dolzh
        {
            get { return dolzh; }
            set { dolzh = value; }
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public int Zarpl
        {
            get { return zarpl; }
            set { zarpl = value; }
        }

        public int Progools
        {
            get { return progools; }
            set { progools = value; }
        }


        //инициализация
        public void Init(int num_trud, string name_sur, string dolzhno, int hourss, int zarplat, int progoo)
        {
            this.num_tr = num_trud;
            this.name_surname = name_sur;
            this.dolzh = dolzhno;
            this.hours = hourss;
            this.zarpl = zarplat;
            this.progools = progoo;
        }

        //Получение и установление соответствующих полей
        public void set_num(int num)
        {
            this.num_tr = num;
        }
        public int get_num()
        {
            return num_tr;
        }

        public void set_h(int h)
        {
            this.hours = h;
        }
        public int get_h()
        {
            return hours;
        }

        public void set_z(int z)
        {
            this.zarpl = z;
        }
        public int get_z()
        {
            return zarpl;
        }

        public void set_prog(int prog)
        {
            this.progools = prog;
        }
        public int get_prog()
        {
            return progools;
        }

        public void set_name(string nam)
        {
            this.name_surname = nam;
        }

        public string get_name()
        {
            return name_surname;
        }

        public void set_dol(string dol)
        {
            this.dolzh = dol;
        }

        public string get_dol()
        {
            return dolzh;
        }

        public void Read() //ввод
	    {
		    Console.WriteLine("\nInput info about worker.\n");
		    Console.WriteLine("Input num of workbook: ");
		    num_tr=Int32.Parse(Console.ReadLine());
		    Console.WriteLine("Input name and surname: ");
		    name_surname=Console.ReadLine();
		    Console.WriteLine("Input dolzhnost: ");
		    dolzh=Console.ReadLine();
		    Console.WriteLine("Input work hours: ");
		    hours=Int32.Parse(Console.ReadLine());
		    Console.WriteLine("Input zarplata: ");
		    zarpl=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input progools: ");
		    progools=Int32.Parse(Console.ReadLine());
	    }

        public void Display() //вывод
	    {
		    Console.WriteLine("\nOutput info about worker.\n");
            Console.WriteLine("Num of workbook: {0}\n", num_tr);
            Console.WriteLine("Name and surname: {0}\n", name_surname);
            Console.WriteLine("Dolzhnost: {0}\n", dolzh);
            Console.WriteLine("Work hours: {0}\n", hours);
            Console.WriteLine("Zarplata: {0}\n", zarpl);
            Console.WriteLine("Progools: {0}\n", progools);

	    }

        public void Add(Worker wr1, Worker wr2) //сложение
        {
            Worker wrsum = new Worker(12345, "No Name", "No Prof", 0, 0, 0);
            wrsum = wr1;
            wrsum.hours += wr2.hours; //прибавить к имеющимся числовым переменным суммарного объекта значения из второго объекта (кроме номера трудовой)
            wrsum.zarpl += wr2.zarpl;
            wrsum.progools += wr2.progools;
            this.Init(wrsum.num_tr, wrsum.name_surname, wrsum.dolzh, wrsum.hours, wrsum.zarpl, wrsum.progools); //вернуть итоговый объект как результат
        }

        //обнуление прогулов (прикладное)
        public void Obnul()
        {
            this.progools = 0; //обнулить прогулы
        }

        public void Izm_zarpl() //изменение зарплаты (прикладное)
	    {
		    Console.WriteLine("\nChanging zarplata of worker\n");
		    Console.WriteLine("Input changes of zarplata: ");
		    int izm; //переменная с прибавкой или убавкой зарплаты
            izm = Int32.Parse(Console.ReadLine());
		    this.zarpl+=izm; //добавить изменение к текущей зарплате
	    }
    }

    class Reserve //заповедник
    {
        private string title;  //название заповедника
	    private int budget;          //бюджет заповедника
	    private int expens;          //расходы
	    private int kolvow;         //кол-во работников в заповеднике
	    private Worker[] workers = new Worker[100]; //работники заповедника
        const double NALOGG=0.13; //процент налоговых отчислений (изначально) (для лаб. 8)
        private static double nalog = NALOGG; //налоговые отчисления (для лаб. 8)

        //конструктор с параметрами
        public Reserve(string titl, int budg, int exp, int kolv, Worker[] works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            for (int i = 0; i < kolv; i++)
            {
                this.workers[i] = works[i];
            }
        }

        //конструктор с параметрами (вторая перегрузка)
        public Reserve(string titl, int budg, int exp, int kolv, Worker works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            for (int i = 0; i < kolv; i++)
            {
                this.workers[i] = works;
            }
        }

        //свойства полей
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        public int Expens
        {
            get { return expens; }
            set { expens = value; }
        }

        public int Kolvow
        {
            get { return kolvow; }
            set { kolvow = value; }
        }

        //инициализация
        public void Init(string titl, int budg, int exp, int kolv, Worker[] works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            for (int i = 0; i < kolv; i++)
            {
                this.workers[i] = works[i];
            }
        }

        public void Display() //вывод
	    {
		    Console.WriteLine("\nOutput info about reserve.\n");
		    Console.WriteLine("Title: {0}\n", title);
		    Console.WriteLine("Budget: {0}\n", budget);
		    Console.WriteLine("Expenses: {0}\n", expens);
		    Console.WriteLine("Count of workers: {0}\n", kolvow);
		    int n = this.kolvow; //получить кол-во работников
		    for(int i=0; i<n; i++)
		    {
                Console.WriteLine("\nWorker {0}\n", i + 1);
                Console.WriteLine("Num of workbook: {0}\n", workers[i].Num_tr);
                Console.WriteLine("Name and surname: {0}\n", workers[i].Name_surname);
                Console.WriteLine("Dolzhnost: {0}\n", workers[i].Dolzh);
                Console.WriteLine("Work hours: {0}\n", workers[i].Hours);
                Console.WriteLine("Zarplata: {0}\n", workers[i].Zarpl);
                Console.WriteLine("Progools: {0}\n", workers[i].Progools);
		    }
	    }

        public void Read() //ввод
	    {
		    Console.WriteLine("\nInput info about reserve.\n");
		    Console.WriteLine("Input title: ");
		    this.title=Console.ReadLine();
		    Console.WriteLine("Input budget: ");
		    this.budget=Int32.Parse(Console.ReadLine());
		    Console.WriteLine("Input expenses: ");
		    this.expens=Int32.Parse(Console.ReadLine());
		    Console.WriteLine("Input count of workers: ");
            this.kolvow = Int32.Parse(Console.ReadLine());
		    int n_k = this.kolvow;
		    for(int i=0; i<n_k; i++)
			    this.workers[i].Read();
		
	    }

        public Worker get_worker(int i) //получить работника с выбранным номером
        {
            return workers[i];
        }

        static public double get_nalog() //получение значения процента налоговых отчислений (для лаб. 8)
        {
            return nalog;
        }

        static public void set_nalog(double nalogi) //установление значения процента налоговых отчислений (для лаб. 8)
        {
            nalog = nalogi;
        }

        public int get_kolvo() //получение значения кол-ва работников
        {
            return kolvow;
        }

        public void Add(Reserve r1, Reserve r2) //сложение
        {
            Reserve rsum;
            rsum = r1; //переписать первую структуру в суммарную структуру
            rsum.budget += r2.budget; //прибавить к имеющимся числовым переменным суммарной структуры значения из второй структуры
            rsum.expens += r2.expens;
            rsum.kolvow += r2.kolvow;
            this.Init(rsum.title, rsum.budget, rsum.expens, rsum.kolvow, rsum.workers); //вернуть итоговый объект как результат
        }

        public void ZarplChange() //изменение зарплаты всех (прикладное)
	    {
		    Console.WriteLine("\nChanging zarplata of all workers\n");
		    Console.WriteLine("Input changes of zarplata: ");
		    int izm; //переменная с прибавкой или убавкой
            izm = Int32.Parse(Console.ReadLine());
		    int n = this.kolvow; //получить кол-во работников
		    for(int i=0; i<n; i++)
		    {
		    	this.workers[i].set_z(workers[i].Zarpl+izm); //добавить изменение к текущему
		    }
	    }

        public void BudgChange() //изменение бюджета (прикладное)
	    {
		    Console.WriteLine("\nChanging budget of reserve\n");
		    Console.WriteLine("Input changes of budget: ");
		    int izm; //переменная с прибавкой или убавкой
            izm = Int32.Parse(Console.ReadLine());
		    this.budget+=izm; //добавить изменение к текущему
	    }

        public int nal_otchisl(int otchisl) //налоговые отчисления
        {
            otchisl = (int)(expens * nalog);
            return otchisl;
        }

        public void sohr(ref double sohr) //сохранённая (неиспользованная) часть бюждета (через ref)
        {
            sohr = budget - expens;
        }

        public static Reserve operator+(Reserve r1, int a) //увеличение бюджета через +
        {
            Reserve rsum;
            rsum = r1;
            rsum.Budget = r1.Budget + a;
            return rsum;
        }

        public static Reserve operator++(Reserve r1) //увеличение расходов через ++
        {
            ++r1.Expens;
            return r1;
        }

        public void found_name_surname(String names_surnames) //поиск по имени и фамилии (обработка строк)
	    {
		    int rez=0;
		    for(int i=0; i<kolvow; i++)
		    {
                rez=String.Compare(names_surnames, workers[i].Name_surname);
		    	if(rez==0) //сравнить строки на идентичность
		    	{
		    		Console.WriteLine("\nWorker found.\n");
		    		break;
		    	}
		    }
		    if(rez!=0)
		    {
                Console.WriteLine("\nWorker didn't found.\n");
		    }
	    }

        public static void sravn_kolvow(Reserve r1, Reserve r2) //сравнить два заповедника по кол-ву работников (статический метод) (для лаб. 8)
	    {
		    if(r1.get_kolvo()>r2.get_kolvo())
		    {
		    	Console.WriteLine("\nMore workers in first reserve.\n");
		    }
		    if (r1.get_kolvo()<r2.get_kolvo())
		    {
		    	Console.WriteLine("\nMore workers in second reserve.\n");
		    }
		    if (r1.get_kolvo()==r2.get_kolvo())
		    {
                Console.WriteLine("\nCounts of workers in reserves are equal.\n");
		    }
	    }
    }

    class Program
    {
        static void Main(string[] args) //основная программа (главная)
        {
            const int LEN = 100;
            Console.WriteLine("Start program for working with workers and reserves.\n");
            Worker[] w0 = new Worker[LEN]; //начальные данные работника для инициализации заповедника
            for (int i = 0; i < LEN; i++)
                w0[i] = new Worker(12345, "No Name", "No Prof", 0, 0, 0);
            Reserve res1= new Reserve("No Name", 0, 0, 100, w0); //объект заповедника с массивом объектов работников
		    res1.Read();
		    res1.Display();
		    res1.ZarplChange();
		    res1.Display();
		    res1.BudgChange();
		    res1.Display();

            int nal=0; //отчисления
            res1.nal_otchisl(nal);
            Console.WriteLine("Reserve's charity is {0}\n", nal);

            double soh=0; //неиспользованная часть бюджета
            res1.sohr(ref soh);
            Console.WriteLine("Reserve's unused part of the budget is {0}\n", soh);

            Console.WriteLine("Reserve after +500 in budget\n");
            res1 = res1 + 500; //оператор +
            res1.Display();
            Console.WriteLine("Prefix and Postfix\n");
            res1 = res1++;
            res1.Display();
            res1 = ++res1;
            res1.Display();

            Console.WriteLine("\nInput name, surname of worker\nwhat would you like to found: ");
		    string search = Console.ReadLine(); //строка для поиска
		    res1.found_name_surname(search);

            Console.WriteLine("\nEnd of program. Press any key to exit...");
            Console.ReadKey(); //ожидание нажатия любой клавиши для выхода.

        }
    }
}
