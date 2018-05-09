using UnityEngine;

namespace TowerDefense.Inspections
{
    public class CreateNewInstance : MonoBehaviour
    {
        public void DoSomething(GameObject go)
        {
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