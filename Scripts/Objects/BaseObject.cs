using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Libraries.Bolt.Objects
{
    public abstract class BaseObject : MonoBehaviour, IObject
    {
        public virtual IObject Build() => 
            this;

        public virtual void OnStart() {}

        public virtual bool OnUpdate() => 
            IsActive();

        public virtual void OnRun() {}
        
        public void SetActive(bool active) => 
            gameObject.SetActive(active);
        
        public bool IsActive() =>
            gameObject.activeSelf;
        
        public T GetComponent<T>(ref T original) => 
            original ??= GetComponent<T>();
    
        public T GetComponentInChildren<T>(ref T original) => 
            original ??= GetComponentInChildren<T>(true);
    
        public List<T> GetComponentsInChildren<T>(ref List<T> original) => 
            original ??= GetComponentsInChildren<T>(true).ToList();

        public T GetComponentInParent<T>(ref T original) =>
            original ??= GetComponentInParent<T>(true);
    }
}