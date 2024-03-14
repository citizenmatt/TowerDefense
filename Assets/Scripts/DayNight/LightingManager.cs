using UnityEngine;

namespace DayNight
{
    [ExecuteInEditMode]
    public class LightingManager : MonoBehaviour
    {
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightingPreset Preset;
    
        [SerializeField, Range(0, 24)] private float TimeOfDay;

        private void UpdateLighting(float timePercent)
        {
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);

            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
                DirectionalLight.transform.localRotation = Quaternion.Euler(
                    new Vector3((timePercent * 360f) - 90f, -170, 0));
            }
        }

        private void Update()
        {
            if (Preset == null)
                return;

            if (Application.isPlaying)
            {
                TimeOfDay += Time.deltaTime;
                TimeOfDay %= 24; // Clamp between 0 - 24
                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                UpdateLighting(TimeOfDay / 24f);
            }
        }

        private void OnValidate()
        {
            if (DirectionalLight != null)
                return;

            if (RenderSettings.sun != null)
            {
                DirectionalLight = RenderSettings.sun;
            }
            else
            {
                // Find first directional light in the scene
                var lights = GameObject.FindObjectsOfType<Light>();
                foreach (var light in lights)
                {
                    if (light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
                }
            }
        }
    }
}
