using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> List(); //Listeleme Methodu

        int Insert(T p);    //Ekleme Methodu

        int Update(T p);    //Güncelleme Methodu
        int Delete(T p);    //Silme Methodu
        T GetByID(int id);  //ID ye Göre Bilgi Getirme

    }
}
