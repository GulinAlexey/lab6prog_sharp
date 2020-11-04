//Гулин А. Н., ПИ-92. Лаб. 7 "Модификации"
using System;

namespace lab6prog_sharp
{
    struct Worker //работник заповедника
    {
        public int num_tr; //номер трудовой книжки
        public string name_surname; //имя и фамилия
        public string dolzh; //должность
        public int hours; //кол-во рабочих часов
        public int zarpl; //зарплата в месяц в рублях
        public int progools; //кол-во прогулов (в днях)

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

    struct Reserve //заповедник
    {
        public string title;  //название заповедника
        public int budget;          //бюджет заповедника
        public int expens;          //расходы
        public int kolvow;         //кол-во работников в заповеднике
        public Worker[] workers; //работники заповедника

        //конструктор с параметрами
        public Reserve(string titl, int budg, int exp, int kolv, Worker[] works)
        {
            this.title = titl;
            this.budget = budg;
            this.expens = exp;
            this.kolvow = kolv;
            this.workers = new Worker[100];

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
            this.workers = new Worker[100];
            for (int i = 0; i < kolv; i++)
            {
                this.workers[i] = works;
            }
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
                Console.WriteLine("Num of workbook: {0}\n", workers[i].num_tr);
                Console.WriteLine("Name and surname: {0}\n", workers[i].name_surname);
                Console.WriteLine("Dolzhnost: {0}\n", workers[i].dolzh);
                Console.WriteLine("Work hours: {0}\n", workers[i].hours);
                Console.WriteLine("Zarplata: {0}\n", workers[i].zarpl);
                Console.WriteLine("Progools: {0}\n", workers[i].progools);
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
		    	this.workers[i].zarpl= workers[i].zarpl + izm; //добавить изменение к текущему
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

            Console.WriteLine("\nEnd of program. Press any key to exit...");
            Console.ReadKey(); //ожидание нажатия любой клавиши для выхода.

        }
    }
}
