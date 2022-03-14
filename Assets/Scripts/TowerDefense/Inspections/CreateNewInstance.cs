using UnityEngine;

namespace TowerDefense.Inspections
{
    public class CreateNewInstance : MonoBehaviour
    {
        public void DoSomething(GameObject go)
        {
            // Unity doesn't allow you to create a new instance of a script component or scriptable object via `new`.
            // This compiles, but will fail at runtime.
            // Alt+Enter to convert to correct methods
            var behaviour = new MyMonoBehaviour();
            var scriptableObject = new MyScriptableObject();
        }
    }

    public class MyMonoBehaviour : MonoBehaviour
    {
    }

    public class MyScriptableObject : ScriptableObject
    {
    }
}