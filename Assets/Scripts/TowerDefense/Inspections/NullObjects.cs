using UnityEngine;

namespace TowerDefense.Inspections
{
    public class NullObjects : MonoBehaviour
    {
        public void NullCoalescing(MyMonoBehaviour mb)
        {
            var behaviour = mb ?? gameObject.AddComponent<MyMonoBehaviour>();

            if (behaviour?.CompareTag("foo") == true)
            {
                // ...
            }
        }
    }
}