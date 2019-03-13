using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Observer
{
    class Program
    {
        static void Main(string[] args)
        {

            DataBase_Subject subject_dataBase = new DataBase_Subject();
            DataBaseObserver1 observer1_client = new DataBaseObserver1();
            DataBaseObserver2 observer2_boss = new DataBaseObserver2();

            Console.WriteLine("* Starting = no observers registered *");
            subject_dataBase.EditRecord("add", "record 1");

            subject_dataBase.RegisterObserver_DB_Change(observer2_boss);
            Console.WriteLine("* observer2 - boss is registered *");

            subject_dataBase.EditRecord("add", "record 2");

            subject_dataBase.RegisterObserver_DB_Change(observer1_client);
            Console.WriteLine("* observer1 - client is also registered *");

            subject_dataBase.EditRecord("add", "record 3");
            subject_dataBase.EditRecord("print", "all records");

            subject_dataBase.UnRegisterObserver_DB_Change(observer2_boss);
            
            Console.WriteLine("* observer2 - boss Unregistered *");
            subject_dataBase.EditRecord("delete", "record 2");

            subject_dataBase.UnRegisterObserver_DB_Change(observer1_client);

            Console.WriteLine("* observer1 - client Unregistered - no more observers are registered*");
            subject_dataBase.EditRecord("delete", "all");

            subject_dataBase.PrintHistory();


        }
    }
}
