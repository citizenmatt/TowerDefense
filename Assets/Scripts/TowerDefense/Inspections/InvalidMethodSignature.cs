#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.ShortcutManagement;
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

//        [Shortcut("Shortcut ID")]
//        public int HasShortcut(int i)
//        {
//        }

//        [OnOpenAsset]
//        public int DoOpenAsset()
//        {
//            return -1
//        }
    }
}

#endif
