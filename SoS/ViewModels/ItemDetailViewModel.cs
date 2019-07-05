using System;

using SoS.Models;

namespace SoS.ViewModels
{
    public class ItemDetailViewModel<T> : BaseViewModel where T : IBaseEvent
    {
        public T Item { get; set; }
        public ItemDetailViewModel(T item)
        {
            Title = item.Name;
            Item = item;
        }
    }
}
