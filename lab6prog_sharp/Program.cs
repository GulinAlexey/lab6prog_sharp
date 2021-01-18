//Гулин А. Н., ПИ-92. Лаб. 11 Массивы
using System;

namespace lab6prog_sharp
{
    //для создания обработки своих исключений (для лаб. 10)
    class WorkerException : Exception //Используется наследование
    {
        private int errorCode;
        public WorkerException(string error_message, int error_code)
            : base(error_message) //вызов конструктора базового класса
        {
            errorCode = error_code;
        }

        public int ErrorCode { get { return errorCode; } }
    }


    class Worker //работник заповедника
    {
        private int num_tr; //номер трудовой книжки
        private string name_surname; //имя и фамилия
        private string dolzh; //должность
        private int hours; //кол-во рабочих часов
        private int zarpl; //зарплата в месяц в рублях
        private int progools; //кол-во прогулов (в днях)

        //конструктор со всеми параметрами (для лаб. 9)
        public Worker(int num_trud, string name_sur, string dolzhno, int hourss, int zarplat, int progoo)
        {
            if (num_trud < 0 || hourss < 0 || zarplat < 0 || progoo < 0) //(для лаб. 10)
            {
                throw new WorkerException("Negative value", 33);
            }


            this.num_tr = num_trud;
            this.name_surname = name_sur;
            this.dolzh = dolzhno;
            this.hours = hourss;
            this.zarpl = zarplat;
            this.progools = progoo;
        }

        public Worker(string name_sur) //конструктор с одним параметром (для лаб. 9)
        {
            this.num_tr = 12345;
            this.name_surname = name_sur;
            this.dolzh = "Worker";
            this.hours = 200;
            this.zarpl = 20000;
            this.progools = 0;
        }

        public Worker() //конструктор без параметров (для лаб. 9)
        {
            num_tr = 0;
            name_surname = "no_name";
            dolzh = "employee";
            hours = 0;
            zarpl = 0;
            progools = 0;
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
            try //(для лаб. 10)
            {
                Console.WriteLine("Input num of workbook: ");
                num_tr = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not a number.\nPress any key.");
                Console.ReadKey();
                return;
            }
           
            Console.WriteLine("Input name and surname: ");
            name_surname = Console.ReadLine();
		    Console.WriteLine("Input dolzhnost: ");
		    dolzh=Console.ReadLine();

            try //(для лаб. 10)
            {
                Console.WriteLine("Input work hours: ");
                hours = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not a number.\nPress any key.");
                Console.ReadKey();
                return;
            }
            try //(для лаб. 10)
            {
                Console.WriteLine("Input zarplata: ");
                zarpl = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not a number.\nPress any key.");
                Console.ReadKey();
                return;
            }
            try //(для лаб. 10)
            {
                Console.WriteLine("Input progools: ");
                progools = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not a number.\nPress any key.");
                Console.ReadKey();
                return;
            }
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

        static public Worker Add(Worker wr1, Worker wr2) //сложение
        {
            Worker wrsum = new Worker(12345, "No Name", "No Prof", 0, 0, 0);
            wrsum = wr1;
            wrsum.hours += wr2.hours; //прибавить к имеющимся числовым переменным суммарного объекта значения из второго объекта (кроме номера трудовой)
            wrsum.zarpl += wr2.zarpl;
            wrsum.progools += wr2.progools;
            return wrsum; //вернуть итоговый объект как результат
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
	    private int kolvow;         //кол-во работников в заповеднике на одном участке
        private int area; //кол-во участков в заповеднике (на каждом свои работники) //лаб 11
	    private Worker[] workers = new Worker[50]; //работники заповедника
        private Worker[,] workersa = new Worker[50, 50]; //работники заповедника, если несколько участков //лаб 11
        const double NALOGG=0.13; //процент налоговых отчислений (изначально) (для лаб. 8)
        private static double nalog = NALOGG; //налоговые отчисления (для лаб. 8)

        //конструктор со всеми параметрами (для лаб. 9)
        public Reserve(string titl, int budg, int exp, int kolv, Worker[] works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            for (int i = 0; i < kolv; i++)
                this.workers[i] = works[i];
        }

        //конструктор для лаб 11 (когда есть деление на участки)
        public Reserve(string titl, int budg, int exp, int kolv, int areas, Worker[,] works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            this.area = areas;
            for (int i = 0; i < areas; i++)
            {
                for (int j = 0; j < kolv; j++)
                {
                    this.workersa[i, j] = works[i, j];
                }
            }
        }

        //конструктор со всеми параметрами (для лаб. 9) (вторая перегрузка)
        public Reserve(string titl, int budg, int exp, int kolv, Worker works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            for (int i = 0; i < kolv; i++)
                this.workers[i] = works;
        }

        public Reserve() //конструктор без параметров (для лаб. 9)
        {
            title = "title";
            budget = 0;
            expens = 0;
            kolvow = 0;
            area = 0;
        }

        public Reserve(int kolv) //конструктор с одним параметром (для лаб. 9)
        {
            this.title = "Reserve";
            this.budget = 1000000;
            this.expens = 100000;
            this.kolvow = kolv;
            Worker w_konstr = new Worker("Ivan Ivanov");
            for (int i = 0; i < kolv; i++)
                this.workers[i] = w_konstr;
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

        public int Area
        {
            get { return area; }
            set { area = value; }
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

        public void Display_areas() //вывод по участкам //лаб 11
        {
            Console.WriteLine("\nOutput info about reserve.\n");
            Console.WriteLine("Title: {0}\n", title);
            Console.WriteLine("Budget: {0}\n", budget);
            Console.WriteLine("Expenses: {0}\n", expens);
            Console.WriteLine("Count of workers on area: {0}\n", kolvow);
            Console.WriteLine("Count of areas: {0}\n", area);
            int n = this.kolvow; //получить кол-во работников
            int na = this.area; //получить кол-во участков
            for (int i = 0; i < na; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("\nWorker {0} on area {1}\n", j+1, i+1);
                    Console.WriteLine("Num of workbook: {0}\n", workersa[i, j].Num_tr);
                    Console.WriteLine("Name and surname: {0}\n", workersa[i, j].Name_surname);
                    Console.WriteLine("Dolzhnost: {0}\n", workersa[i, j].Dolzh);
                    Console.WriteLine("Work hours: {0}\n", workersa[i, j].Hours);
                    Console.WriteLine("Zarplata: {0}\n", workersa[i, j].Zarpl);
                    Console.WriteLine("Progools: {0}\n", workersa[i, j].Progools);
                }
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

        static public Reserve Add(Reserve r1, Reserve r2) //сложение
        {
            Reserve rsum;
            rsum = r1; //переписать первую структуру в суммарную структуру
            rsum.budget += r2.budget; //прибавить к имеющимся числовым переменным суммарной структуры значения из второй структуры
            rsum.expens += r2.expens;
            rsum.kolvow += r2.kolvow;
            return rsum; //вернуть итоговый объект как результат
        }

        public void ZarplChange() //изменение зарплаты всех работников (прикладное) //лаб 11
	    {
		    Console.WriteLine("\nChanging zarplata of all workers\n");
		    Console.WriteLine("Input changes of zarplata: ");
		    int izm; //переменная с прибавкой или убавкой
            izm = Int32.Parse(Console.ReadLine());

            if (area == 0) //если заповедник без разделения на участки
            {
                for (int i = 0; i < this.kolvow; i++)
                {
                    this.workers[i].set_z(workers[i].Zarpl + izm); //добавить изменение к текущему
                }
            }
            else
            {
                for (int i = 0; i < this.area; i++)
                {
                    for (int j = 0; j < this.kolvow; j++)
                    {
                        this.workersa[i, j].set_z(workersa[i, j].Zarpl + izm); //добавить изменение к текущему
                    }
                }
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
            Console.WriteLine("Start program for working with workers and reserves.\n");
            
            /*
            //(для лаб. 10)
            try
            {
                Worker wrk88 = new Worker(22222, "Oleg Olegov", "Gribnik", -5, 8000, 3);
            }
            catch (WorkerException ex)
            {
                //пользовательский
                Console.WriteLine("\nError: " + ex.Message + "; error's code: " + ex.ErrorCode);
            }
            */

            /*
            Worker wrk99 = new Worker(); //(для лаб. 10)
            wrk99.Read();
            wrk99.Display();
            */

            Worker wrk11 = new Worker();
		    Worker wrk12 = new Worker("Vlad Vladov");
		    Worker wrk13 = new Worker(22222, "Oleg Olegov", "Gribnik", 150, 8000, 3);
		    Console.WriteLine("\nWorker: constructor without value.\n");
		    wrk11.Display();
		    Console.WriteLine("\nWorker: constructor with one value.\n");
		    wrk12.Display();
		    Console.WriteLine("\nWorker: constructor with all value.\n");
		    wrk13.Display();

		    Reserve res11 = new Reserve();
		    Reserve res12 = new Reserve(2);
		    Reserve res13 = new Reserve("White Sand", 2000000, 400000, 0, wrk11);
		    Console.WriteLine("\nReserve: constructor without value.\n");
		    res11.Display();
		    Console.WriteLine("\nReserve: constructor with one value.\n");
		    res12.Display();
            Console.WriteLine("\nReserve: constructor with all value.\n");
		    res13.Display();
		
		    Worker[] wrk2= new Worker[2];
		    for(int i=0; i<2; i++)
		    {
			    wrk2[i]= new Worker("Ivan Ivanov"); //инициализация небольшого массива конструктором с одним параметром
		    }

            //для лаб 11
            Console.WriteLine("Input count of workers: ");

            int kolvv = Int32.Parse(Console.ReadLine());
            Worker[] wrkk = new Worker[kolvv];
            for (int i = 0; i < kolvv; i++)
            {
                wrkk[i] = new Worker();
                wrkk[i].Read();
            }
            for (int h = 0; h < kolvv; h++)
            {
                wrkk[h].Display();
            }

            Reserve res123 = new Reserve("Svetilo", 1000000, 500000, kolvv, wrkk); //для лаб 11

            //для лаб 11
            Console.WriteLine("Input count of areas in reserve: ");
            int ar = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input count of workers on area: ");
            kolvv = Int32.Parse(Console.ReadLine());
            Worker[,] wrk55 = new Worker[ar, kolvv];
            for (int i = 0; i < ar; i++)
            {
                for (int j = 0; j < kolvv; j++)
                {
                    wrk55[i, j] = new Worker();
                    wrk55[i, j].Read();
                }
            }
            Reserve rees = new Reserve("Opyata", 2000000, 1500000, kolvv, ar, wrk55);
            rees.Display();
            rees.ZarplChange();
            rees.Display();

            /*
            Reserve res2 = new Reserve("No Name", 0, 0, 100, w0); //объект заповедника с массивом объектов работников
            res2.Read();
            res2.Display();
            //для лаб. 8
            Reserve.sravn_kolvow(res1, res2);
            Reserve.set_nalog(0.05);
            Console.WriteLine("\nNew tax is {0}\n", Reserve.get_nalog());

            Console.WriteLine("\nInput name, surname of worker\nwhat would you like to found in reserve 1: ");
            string search = Console.ReadLine(); //строка для поиска
            res1.found_name_surname(search);
            */

            Console.WriteLine("\nEnd of program. Press any key to exit...");
            Console.ReadKey(); //ожидание нажатия любой клавиши для выхода.

        }
    }
}
