using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Inspections
{
    public class MagicStringCompletion : MonoBehaviour
    {
        public void ValidationAndCompletionOfInputAxes()
        {
            UnityEngine.Input.GetAxis("UnknownAxis");
            UnityEngine.Input.GetAxis("Horizontal");
        }

        public void ValidationAndCompletionOfTags()
        {
            if (CompareTag("UnknownTag"))
            {

            }

            if (this.CompareTag("EditorOnly"))
            {
            }
        }

        public void ValidationAndCompletionOfLayers()
        {
            var mask = LayerMask.GetMask("Default", "Towers", "FlyingEnemies");
            var layer = LayerMask.NameToLayer("UnknownLayers");
            LayerMask.NameToLayer("");
        }

        public void ValidationAndCompletionOfScenes()
        {
            SceneManager.LoadScene("Level5");
            SceneManager.LoadScene("UnknownScene");
        }
    }
}