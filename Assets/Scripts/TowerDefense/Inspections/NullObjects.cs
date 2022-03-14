using UnityEngine;

namespace TowerDefense.Inspections
{
    public class NullObjects : MonoBehaviour
    {
        public void NullCoalescing(MyMonoBehaviour mb)
        {
            // ?? will bypass the lifetime check that `if (mb)` would perform, thanks to an implicit cast to bool
            // Alt+Enter convert to conditional expression will check the lifetime of the underlying lifetime
            // Use "Why is Rider suggesting this?" to find out more
            var behaviour = mb ?? gameObject.AddComponent<MyMonoBehaviour>();

            // ?. also bypasses the lifetime check. There is no QF available for this code
            if (behaviour?.CompareTag("Finish") == true)
            {
                // ...
            }

            // The UnityEngine.Object.Equals(Object x, Object y) method will compare any two Unity Object based objects,
            // even if they are of different type. This is not likely to be correct, so Rider will warn if the types are
            // different
            Renderer coolRenderer = GetComponent<Renderer>();
            if (coolRenderer == transform)
            {
            }
        }
    }
}