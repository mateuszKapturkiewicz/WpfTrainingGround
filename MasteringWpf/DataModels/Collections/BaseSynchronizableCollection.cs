﻿using MasteringWpf.DataModels.Interfaces;
using MasteringWpf.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.DataModels.Collections
{
    public class BaseSynchronizableCollection<T> : BaseCollection<T> where T : class, ISynchronizableDataModel<T>, INotifyPropertyChanged, new()
    {
        /// <summary>
        /// Initialises a new BaseSynchronisableCollection collection and adds the items from the collection specified by the input parameter.
        /// </summary>
        public BaseSynchronizableCollection(IEnumerable<T> collection) : base(collection) { }

        /// <summary>
        /// Initialises a new BaseSynchronisableCollection collection and adds the items from the collection specified by the input parameter.
        /// </summary>
        public BaseSynchronizableCollection(params T[] collection) : base(collection as IEnumerable<T>) { }

        /// <summary>
        /// Initialises a new empty BaseSynchronisableCollection collection.
        /// </summary>
        public BaseSynchronizableCollection() : base() { }

        /// <summary>
        /// Gets a value that specifies whether any properties in any object in the collection have changed since they were last synchronised or not.
        /// </summary>
        public virtual bool HasChanges
        {
            get { return this.Any(i => i.HasChanges); }
        }

        /// <summary>
        /// Gets a value that specifies whether the objects in the collection have all been synchronised or not.
        /// </summary>
        public virtual bool AreSynchronized
        {
            get { return this.All(i => i.IsSynchronized); }
        }

        /// <summary>
        /// Gets a collection of objects from this collection that have changed since their last synchronisation.
        /// </summary>
        public virtual IEnumerable<T> ChangedCollection
        {
            get { return this.Where(i => i.HasChanges); }
        }

        /// <summary>
        /// Synchronises the value of the OriginalState property with the current values of every object in the collection.
        /// </summary>
        public virtual void Synchronize()
        {
            this.ForEach(i => i.Synchronize());
        }

        /// <summary>
        /// Reverts the values of all of the properties in every object in the collection to the state that they were in when they were last synchronised.
        /// </summary>
        public virtual void RevertState()
        {
            this.ForEach(i => i.RevertState());
        }
    }
}
