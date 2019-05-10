using UnityEngine;

namespace TowerDefense.Inspections
{
    public class SomeService
    {
        public void DoSomethingExpensive(MonoBehaviour behaviour)
        {
            var component = behaviour.GetComponent<Grid>();
            Debug.Log(component);
        }
    }
}