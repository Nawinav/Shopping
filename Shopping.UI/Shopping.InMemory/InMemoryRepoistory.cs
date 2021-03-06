﻿using Shopping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.InMemory
{
        public class InMemoryRepoistory<T> : IRepoistory<T> where T : BaseEntity
        {
            ObjectCache cache = MemoryCache.Default;
            List<T> items;
            string className;

            public InMemoryRepoistory()
            {
                className = typeof(T).Name;
                items = cache[className] as List<T>;
                if (items == null)
                {
                    items = new List<T>();
                }
            }
            public void commit()
            {
                cache[className] = items;
            }
            public void Insert(T t)
            {
                items.Add(t);
            }
            public void Update(T t)
            {
                T tToUpdate = items.Find(x => x.Id == t.Id);

                if (tToUpdate != null)
                {
                    tToUpdate = t;
                }
                else
                {
                    throw new Exception();
                }
            }
            public T Find(string Id)
            {
                T tFind = items.Find(x => x.Id == Id);
                if (tFind != null)
                {
                    return tFind;
                }
                else
                {
                    throw new Exception();
                }
            }
            public IQueryable<T> Collection()
            {
                return items.AsQueryable();
            }

            public void Delete(string Id)
            {
                T tToDelete = items.Find(x => x.Id == Id);

                if (tToDelete != null)
                {
                    items.Remove(tToDelete);
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }

