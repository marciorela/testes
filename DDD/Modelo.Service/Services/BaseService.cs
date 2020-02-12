using FluentValidation;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            repository.Delete(id);
        }

        public T Get(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero");
            }

            return repository.Select(id);
        }

        public IList<T> Get() => repository.SelectAll();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;            
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                throw new Exception("Registros não detectados!");
            }

            validator.ValidateAndThrow(obj);
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }
    }
}
