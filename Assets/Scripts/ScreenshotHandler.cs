using System.IO;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    public void TakeScreenshot()
    {
        // Render main camera to temporary render texture
        var camera = GameObject.FindObjectOfType<Camera>(true);
        camera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        camera.Render();
        
        // Grab render texture contents and save as screenshot
        var renderTexture = camera.targetTexture;
        var renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        var rectangle = new Rect(0, 0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rectangle, 0, 0);

        byte[] bytes = renderResult.EncodeToPNG();
        File.WriteAllBytes(Path.Combine(Application.dataPath, "screenshot.png"), bytes);
        Debug.Log(" Saved to: " + Path.Combine(Application.dataPath, "screenshot.png"));
        
        // Restore camera
        RenderTexture.ReleaseTemporary(renderTexture);
        camera.targetTexture = null;
    }
}
