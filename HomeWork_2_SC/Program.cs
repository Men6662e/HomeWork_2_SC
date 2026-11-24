class Program
{
    static void Main(string[] args)
    {
        void stroki() // Создаём строку для более эстетичности
        {
            Console.WriteLine("---------------------------------------------------------");
        }


        stroki();
        Console.WriteLine("            --- Расчёт заработной платы ---"); // Загаловок
        stroki();

        List<Employee> employees = new List<Employee>(); //  Создание списка, который может хранить объекты типа Employee.
                                                         //  Благодаря наследованию, мы можем положить в этот список и Manager, и Developer.
        
        employees.Add(new Manager("Иван Петров", 80000, 25000)); // Создаем менеджера Ивана
        employees.Add(new Developer("Анна Сидорова", 70000, 50500)); // Создаем разработчика Анну
        employees.Add(new Manager("Олег Васильев", 90000, 40000)); // Создаем менеджера Олега

        foreach (Employee emp in employees) // Цикл foreach, который перебирает каждого сотрудника из списка employees.
                                            // На каждой итерации текущий объект доступен через переменную emp.
        {
            string position = emp.GetType().Name == "Manager" ? "Менеджер" : "Разработчик"; // Строка определяет тип класса на русском языке для красивого вывода.
                                                                                            // Если имя класса равен "Manager", переменная
                                                                                            // получит текст "Менеджер", иначе — "Разработчик".

            Console.WriteLine($"\nЗарплата для {position} {emp.Name}: {emp.CalculateMonthlySalary()}\n"); //Главная демонстрация полиморфизма. Несмотря на то, что переменная
                                                                                                          //emp имеет тип Employee,
                                                                                                          //программа сама "знает" точный тип объекта и вызывает правильную
                                                                                                          //(переопределенную) версию метода CalculateMonthlySalary().
                                                                                                          //Результат выводится на экран.
            stroki();
        }
    }
}