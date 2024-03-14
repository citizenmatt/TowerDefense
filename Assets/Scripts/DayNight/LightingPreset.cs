using System;
using UnityEngine;

namespace DayNight
{
    [Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "TowerDefense/Lighting Preset", order = 1)]
    public class LightingPreset : ScriptableObject
    {
        public Gradient AmbientColor;
        public Gradient DirectionalColor;
    }
}
