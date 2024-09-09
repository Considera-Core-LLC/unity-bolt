using System.Collections.Generic;

namespace Libraries.Bolt.Objects
{
    public interface IObject
    {
        IObject Build();
        
        void OnStart();
        
        bool OnUpdate();
        
        void OnRun();
        
        T GetComponent<T>(ref T original);
        
        T GetComponentInChildren<T>(ref T original);

        List<T> GetComponentsInChildren<T>(ref List<T> original);
    }
}