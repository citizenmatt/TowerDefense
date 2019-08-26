using UnityEngine;

namespace TowerDefense.Inspections
{
    public class SomeService
    {
        // This method is marked as performance critical, because it is called from an Update method - in another file!
        public void DoSomethingExpensive(MonoBehaviour behaviour)
        {
            var component = behaviour.GetComponent<Grid>();
            Debug.Log(component);
        }
    }
}