#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace TowerDefense.Inspections
{
    // Some callbacks are identified by attributes. Rider will show a warning if the method signature is not correct,
    // and provides Alt+Enter quick fix
    // Note that some items are commented out because they can cause a compile error if the signature is incorrect
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

        // [OnOpenAsset]
        // public int DoOpenAsset()
        // {
        // }
    }
}

#endif
