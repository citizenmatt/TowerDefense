using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TowerDefense.Inspections
{
    // Validation, code completion, find usages and rename of method names from magic strings
    // Unity provides the ability to Invoke a specific method, or start a method as a coroutine
    public class MagicStringMethodReferences : MonoBehaviour
    {
        [SuppressMessage("ReSharper", "UseNameofExpression")]
        public void CallsInvoke()
        {
            // Ctrl+Click navigation to FireProjectile
            // Find Usages will show usages in strings
            // Rename the method by renaming the reference in the string literal
            Invoke("FireProjectile", 2.0f);
            InvokeRepeating("FireProjectile", 2.0f, 2.0f);

            // Validation that the method has the correct signature
            Invoke("HasWrongSignature", 2.0f);

            // Same features for coroutines
            StartCoroutine("MyCoroutine");
            StartCoroutine("CallsInvoke");
        }

        public void SuggestsNameofForCSharp6()
        {
            Invoke("FireProjectile", 2.0f);
        }


        public void FireProjectile()
        {
            // ...
        }

        public int HasWrongSignature(int value)
        {
            return value;
        }

        public IEnumerator MyCoroutine()
        {
            yield break;
        }
    }
}