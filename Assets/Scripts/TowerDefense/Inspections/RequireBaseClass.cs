#if UNITY_EDITOR

using UnityEditor;

namespace TowerDefense.Inspections
{
    // External annotations provide additional context for Unity features, such as using the CustomEditor attribute
    // requires a base class of Editor
    // Commented out by default, as this shows as a warning in the Unity editor at load time
    // [CustomEditor(typeof(MyMonoBehaviour))]
    // public class RequiresEditorBaseClass
    // {
    // }
}

#endif