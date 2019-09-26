#if UNITY_EDITOR

using UnityEditor;

namespace TowerDefense.Inspections
{
    [CustomEditor(typeof(MyMonoBehaviour))]
    public class RequiresEditorBaseClass
    {
    }
}

#endif