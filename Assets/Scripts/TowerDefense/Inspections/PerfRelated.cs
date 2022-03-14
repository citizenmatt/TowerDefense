using System;
using UnityEngine;

namespace TowerDefense.Inspections
{
    // Rider encodes various performance related best practices into inspections
    public class PerfRelated : MonoBehaviour
    {
        private float maxAngle;
        private float yAngle;

        private void Start()
        {
            // Repeatedly calling a property implemented in native code (`transform`) is unnecessarily expensive. Call
            // once and cache the result
            // Alt+Enter on the inspection and introduce a variable
            maxAngle = transform.eulerAngles.x;
            yAngle = transform.eulerAngles.y;

            // Transform.position is also implemented as native code
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            // Note position is not highlighted here - reading this value again is valid, as it has been altered by
            // setting localPosition
            transform.localPosition = new Vector3(x, y, z);
            var y1 = transform.position.y;

            // Passing a string ID to methods that set properties on animators, or materials, etc. is expensive, as the
            // first thing Unity will do is convert the string to an integer ID
            // QF to introduce a field that caches the integer ID
            var animator = GetComponent<Animator>();
            animator.SetFloat("test", 10f, 10f, 10f);
        }

        // Empty event functions are still called from native code, which is an unnecessarily expense
        // QF to remove
        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            // Comparing the tag property to a string literal causes an allocation in the `tag` property. Use the
            // CompareTag method to compare without allocations
            // QF to rewrite the check, use bulk fix to fix across file, project, solution, etc.
            if (tag == "Player" || other.tag == "GameController")
            {
                Debug.Log("Found it!");
            }
        }

        private GameObject InstantiateAndSet(GameObject root)
        {
            // Instantiating an object will create it at a default location in the hierarchy and recalculates various
            // properties. Setting the parent immediately after invalidates this works and recalculates values again.
            // This is unnecessarily expensive, and should be combined
            // QF to combine creation and setting the parent. This is also available as a bulk fix
            var go = Instantiate(gameObject);
            go.transform.parent = root.transform;
            return go;
        }

        private Component DoGetComponent()
        {
            // Avoid getting a component by string. Use the generic version which can perform a much more efficient
            // lookup (and is type safe)
            // QF to fix. Also available in bulk
            return GetComponent("Grid");
        }

        private void AvoidPhysicsAllocations()
        {
            // These physics methods allocate an array for results on each call
            // QF to convert to the non-allocating version. These require pre-allocated results (use alt+enter to
            // introduce parameter/field, etc.
            RaycastHit[] hits = Physics.RaycastAll(Vector3.up, Vector3.one);
            var result = Physics.OverlapBox(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity, 0,
                QueryTriggerInteraction.Collide);
        }
    }
}
