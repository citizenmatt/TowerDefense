using System.Collections;
using UnityEngine;

namespace TowerDefense.Inspections
{
    public class CommonTest : MonoBehaviour
    {
        private Rigidbody2D item;

        // Update is called frequently, so don't directly or indirectly call expensive methods
        public void Update()
        {
            if (item == null)
                item = GetComponent<Rigidbody2D>();

            ResetEnemy();
            FindTarget();

            new SomeService().DoSomethingExpensive(this);
        }

        private void ResetEnemy()
        {
            var temp = gameObject.GetComponent<Rigidbody2D>();
            // ...
        }

        private void FindTarget()
        {
            ResetEnemy();
            // ...
        }

        public void Start()
        {
            // Coroutines are called frequently, so don't call expensive methods from them
            StartCoroutine("UpdateTargets");
            StartCoroutine(CheckHealth());
        }

        public IEnumerator UpdateTargets()
        {
            var x = gameObject.GetComponent<Transform>();
            yield break;
        }

        public IEnumerator CheckHealth()
        {
            var x = GetComponent<Transform>();
            yield break;
        }
    }
}