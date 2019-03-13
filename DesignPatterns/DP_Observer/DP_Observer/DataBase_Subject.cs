using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Observer
{
    class DataBase_Subject
    {
        List<IDataBaseObserver> observersList = new List<IDataBaseObserver>();
        String dataBaseHistory = "";

        public void RegisterObserver_DB_Change(IDataBaseObserver observer)
        {
            observersList.Add(observer);
        }

        public void UnRegisterObserver_DB_Change(IDataBaseObserver observer)
        {
            observersList.Remove(observer);
        }

        private void NotifyObservers(String operation, String record)
        {
            foreach (IDataBaseObserver observer in observersList)
            {
                observer.DoOnDataBaseChange(operation, record);
            }
        }

        public void EditRecord(String operation, String record)
        {
            dataBaseHistory += ("operation: " + operation + " record: " + record + "\n");
            NotifyObservers(operation, record);

        }

        public void PrintHistory()
        {
            Console.WriteLine(" DataBase History:\n***************************************\n");
            Console.WriteLine(dataBaseHistory);
        }
    }
}
