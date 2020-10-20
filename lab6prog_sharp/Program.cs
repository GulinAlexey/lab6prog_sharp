//Гулин А. Н., ПИ-92. Лаб. 6 "Первая программа на С#"
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
                Console.WriteLine("Num of workbook: {0}\n", workers[i].get_num());
                Console.WriteLine("Name and surname: {0}\n", workers[i].get_name());
                Console.WriteLine("Dolzhnost: {0}\n", workers[i].get_dol());
                Console.WriteLine("Work hours: {0}\n", workers[i].get_h());
                Console.WriteLine("Zarplata: {0}\n", workers[i].get_z());
                Console.WriteLine("Progools: {0}\n", workers[i].get_prog());
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


    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
