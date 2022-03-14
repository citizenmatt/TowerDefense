using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Inspections
{
    // Unity uses a lot of magic strings. Because Rider indexes assets and project settings, it can validate that the
    // string values are correct, and provide code completion
    public class MagicStringCompletion : MonoBehaviour
    {
        public void ValidationAndCompletionOfInputAxes()
        {
            // Input axis values. Provides validation and code completion
            UnityEngine.Input.GetAxis("UnknownAxis");
            UnityEngine.Input.GetAxis("Horizontal");
        }

        public void ValidationAndCompletionOfTags()
        {
            // Validation and code completion of tags
            if (CompareTag("UnknownTag") || CompareTag("Player"))
            {
            }

            // Validation and code completion for tags and simple string comparisons.
            // Note that normally, the validation is hidden by the check for explicit tag comparisons (use CompareTag)
            // ReSharper disable once Unity.ExplicitTagComparison
            if (tag == "UnknownTag")
            {
            }
        }

        public void ValidationAndCompletionOfLayers()
        {
            // Validation and code completion of layers
            var mask = LayerMask.GetMask("Default", "Towers", "FlyingEnemies");
            var layer = LayerMask.NameToLayer("UnknownLayers");
        }

        public void ValidationAndCompletionOfScenes()
        {
            // Validation and completion of scene names
            SceneManager.LoadScene("Level5");
            SceneManager.LoadScene("UnknownScene");

            // Validation that a scene is included in Build Settings for a player
            // QF will update Build Settings to add the scene
            SceneManager.LoadScene("Prototype");
        }
    }
}