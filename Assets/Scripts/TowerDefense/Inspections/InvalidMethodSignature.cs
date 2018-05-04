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

        [DidReloadScripts]
        public void OnDidReload()
        {
        }

        [PostProcessBuild]
        public static void OnPostProcessScene()
        {
        }
    }
}