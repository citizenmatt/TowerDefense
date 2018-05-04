using UnityEditor;
using UnityEngine;

namespace TowerDefense.Inspections
{
    [InitializeOnLoad]
    public class RedundantAttributes : MonoBehaviour
    {
        [SerializeField] public string MyName { get; set; }

        [HideInInspector]
        public int MyValue { get; set; }

        [ExecuteInEditMode]
        public void Execute()
        {
        }
    }
}