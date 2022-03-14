using System.Collections;
using UnityEngine;

namespace TowerDefense.Inspections
{
    // Mark specific methods as "performance critical context". These are methods that are called frequently, and where
    // the user should avoid known expensive methods, e.g. `Update`, `LateUpdate` and `FixedUpdate`. This methods are
    // marked as "Frequently called".
    // Known expensive methods are highlighted, such as `GetComponent` or `Debug.Log`.
    // These are NOT warnings or errors, but indicates that these methods are known to be expensive. It is up to the
    // user to profile and decide if the code needs changing.
    // This inspection can be turned off in settings: Preferences | Languages & Frameworks | Unity Engine
    // (This is the same strategy as Heap Allocation Viewer)
    public class CommonTest : MonoBehaviour
    {
        private Rigidbody2D item;

        // Update is called on every frame, so avoid known expensive APIs
        // The Code Vision link is highlighted as "used frequently" and the method scope is highlighted when the caret
        // is inside the method
        public void Update()
        {
            // Equality against null will call native code. This isn't necessarily bad, but is expensive when called on
            // every frame. This is not a warning - Rider doesn't know if the object could be destroyed, and this check
            // might be valid. But you should be aware that this is expensive
            if (item == null)
            {
                // GetComponent is expensive. Ideally, this component should be fetched in Awake or Start, and cached
                // Alt+Enter to introduce field and initialise in Awake or Start
                item = GetComponent<Rigidbody2D>();
            }

            // These methods are local to this file, called from a performance critical context, and call known
            // expensive APIs. Therefore, they are now known expensive APIs too.
            ResetEnemy();
            FindTarget();

            // This method is in another file. Rider will do cross-file, solution wide analysis to know that methods are
            // called from a performance critical context, and to know that they call known expensive APIs
            new SomeService().DoSomethingExpensive(this);

            // Avoid accessing Camera.main, which would perform a very slow lookup for the main camera. Unity 2019.4.9
            // and above have improved this lookup, however it is now equivalent to calling GetComponent, and it is
            // still advisable to cache this value. See "Why is Rider suggesting this?" for more details
            var camera = Camera.main;
        }

        // This method is called from Update. It is marked as "Frequently called"
        private void ResetEnemy()
        {
            // Because it's frequently called, calls to known expensive methods are highlighted
            if (item == null)
                item = gameObject.GetComponent<Rigidbody2D>();

            Debug.Log("Reset enemy");
            // ...
        }

        private void FindTarget()
        {
            // Indirect usage of expensive API calls
            ResetEnemy();
            // ...
        }

        public void Start()
        {
            // Coroutines are called frequently, so don't call expensive methods from them
            StartCoroutine("UpdateTargets");
            StartCoroutine(CheckHealth());
        }

        // Coroutines are called per-frame (unless a yield is made to wait), so they are marked as frequently called
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