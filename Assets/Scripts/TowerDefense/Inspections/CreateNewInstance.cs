using UnityEngine;

namespace TowerDefense.Inspections
{
    public class CreateNewInstance
    {
        public void DoSomething()
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