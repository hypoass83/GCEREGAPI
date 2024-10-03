using System.Collections.Generic;
using System.Linq;

using System;
using Domain.InterfacesStores.Security;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.InterfacesStores;

namespace Infrastructure.Stores
{

    public class Store<E, M> : IStore<E, M> where E : class where M : class

    {
        private readonly FsContext context;
        private readonly AutoMapper.IMapper _mapper;

        private DbSet<E> _table;
        public Store(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            context = dbContext;

            _mapper = mapper;
            _table = context.Set<E>();
        }


        public M? Find(int key)
        {
            return _mapper.Map<M>(context.Set<E>().Find(key));
        }

        public IEnumerable<M> FindAll
        {
            get
            {
                //save();
                _table = context.Set<E>();
                return _table.ToList().Select( _mapper.Map<M>);
            }
        }


        public M Update(M obj)
        {
            _table.Attach(_mapper.Map<E>(obj));
            context.Entry(obj).State = EntityState.Modified;
            save();
            return obj;
        }

        public M Update(M updated, int key)
        {
            if (updated == null)
                return null;

            E existing = context.Set<E>().Find(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                save();
            }
            return _mapper.Map<M>(existing);
        }

        public M Create(M obj)
        {
            _table.Add(_mapper.Map<E>(obj));
            save();
            return obj;
        }

        public IEnumerable<M> CreateAll(IEnumerable<M> tList)
        {
            context.Set<E>().AddRange(tList.Select(_mapper.Map<E>));
            context.SaveChanges();
            return tList;
        }

        public M Delete(M obj)
        {
            _table.Remove(_mapper.Map<E>(obj));
            save();
            return obj;
        }

        public void Delete(int key)
        {
            _table.Remove(  _mapper.Map<E>(Find(key)));
            save();
        }

        public IEnumerable<M> DeleteAll(IEnumerable<M> tList)
        {
            foreach (M t in tList)
            {
                this.Delete(t);
            }
            return tList;
        }

        private void save()
        {
            context.SaveChanges();
        }



    }
}
