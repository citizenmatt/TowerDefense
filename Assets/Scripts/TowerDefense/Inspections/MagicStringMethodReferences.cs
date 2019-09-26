using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TowerDefense.Inspections
{
    public class MagicStringMethodReferences : MonoBehaviour
    {
        [SuppressMessage("ReSharper", "UseNameofExpression")]
        public void CallsInvoke()
        {
            Invoke("FireProjectile", 2.0f);
            InvokeRepeating("FireProjectile", 2.0f, 2.0f);

            Invoke("HasWrongSignature", 2.0f);

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