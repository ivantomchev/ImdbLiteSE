﻿namespace ImdbLite.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;

    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models;

    public class ImdbLiteData : IImdbLiteData
    {
        private readonly IApplicationDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ImdbLiteData(IApplicationDbContext context)
        {
            this.context = context;
        }

        public IApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IDeletableEntityRepository<User> Users
        {
            get { return this.GetDeletableEntityRepository<User>(); }
        }

        public IDeletableEntityRepository<Genre> Genres
        {
            get { return this.GetDeletableEntityRepository<Genre>(); }
        }

        public IDeletableEntityRepository<Actor> Actors
        {
            get { return this.GetDeletableEntityRepository<Actor>(); }
        }

        public IDeletableEntityRepository<Director> Directors
        {
            get { return this.GetDeletableEntityRepository<Director>(); }
        }

        public IDeletableEntityRepository<Producer> Producers
        {
            get { return this.GetDeletableEntityRepository<Producer>(); }
        }

        public IDeletableEntityRepository<Writer> Writers
        {
            get { return this.GetDeletableEntityRepository<Writer>(); }
        }
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
