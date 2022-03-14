#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace TowerDefense.Inspections
{
    // Rider will mark attributes as redundant if they will have no effect
    // InitializeOnLoad means Unity will call a static constructor when the editor loads. If there is no static
    // constructor, this attribute is redundant.
    // QF to create a static constructor
    // QF to remove this redundant attribute, or remove in bulk
    [InitializeOnLoad]
    public class RedundantAttributes : MonoBehaviour
    {
        // NonSerialized takes precedence over SerializeField
        [SerializeField, NonSerialized] private string nonSerialisedField;

        // Some attributes do not have a valid AttributeTarget value, so can be applied to the wrong code element. This
        // can be a subtle cause of bugs - e.g. trying to serialise a property with [SerializeField]
        // Context action is available on properties to convert to property with serialised backing field
        [SerializeField] public string MyName { get; set; }

        // HideInInspector should be applied to a serialised field, not a property
        [HideInInspector]
        public int MyValue { get; set; }

        // ExecuteInEditMode should be applied on classes
        [ExecuteInEditMode]
        public void Execute()
        {
        }
    }
}

#endif