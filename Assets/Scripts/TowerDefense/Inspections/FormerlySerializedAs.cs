using UnityEngine;

namespace TowerDefense.Inspections
{
    public class FormerlySerializedAs : MonoBehaviour
    {
        // Renaming a serialised field can break existing serialised data, which is keyed by field name.
        // When renaming a serialised field, Rider will add a FormerlySerialisedAs attribute to tell the serialiser to
        // use existing data
        public string mySerializedField;
    }
}