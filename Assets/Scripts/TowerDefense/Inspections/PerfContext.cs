using System.Collections;
using UnityEngine;

namespace TowerDefense.Inspections.Perf
{
    public class CommonTest : MonoBehaviour
    {
        private Rigidbody2D myRigidBody2D;

        public void Start()
        {
            // Coroutines are called frequently, so don't call expensive methods from them
            StartCoroutine("HotMethod");
            StartCoroutine(HotMethod2());
        }

        public IEnumerator HotMethod()
        {
            var x = gameObject.GetComponent<Transform>();
            yield break;
        }
        
        public IEnumerator HotMethod2()
        {
            var x = GetComponent<Transform>();
            yield break;
        }
        
        // Update is called frequently, so don't directly or indirectly call expensive methods
        public void Update()
        {
            if (myRigidBody2D == null)
                myRigidBody2D = GetComponent<Rigidbody2D>();

            IndirectCostly();
            IndirectlyCostly2();
        }
        
        private void IndirectCostly()
        {
            var temp = gameObject.GetComponent<Rigidbody2D>();
        }

        private void IndirectlyCostly2()
        {
            IndirectCostly();
        }
    }
}