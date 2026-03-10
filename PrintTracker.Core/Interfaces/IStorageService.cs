using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTracker.Core.Interfaces
{
    public interface IStorageService
    {

        public void SaveData<T>(T data);

        public T? LoadData<T>(); 

    }
}
