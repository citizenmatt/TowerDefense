#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace TowerDefense.Inspections
{
    public class InvalidMethodSignature : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod]
        public void DoLoad()
        {
        }

//        [DidReloadScripts]
//        public void OnDidReload()
//        {
//        }

//        [PostProcessBuild]
//        public static void OnPostProcessScene()
//        {
//        }

        [DrawGizmo(GizmoType.Active, typeof(Editor))]
        public void DoDrawGizmo()
        {
        }
    }
}

#endif