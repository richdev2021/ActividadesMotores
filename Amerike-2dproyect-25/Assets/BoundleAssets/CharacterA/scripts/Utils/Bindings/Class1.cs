using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
namespace Utils.Bindings
{
    [Serializable]
    public abstract class ValueBindings<T> : UnityEvent<T>
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected string parameter;

        protected T value;

        public abstract T Value { get; set; }
    }
}
