using System;
using UnityEngine;

namespace TowerDefense.Inspections
{
    public class PerfRelated : MonoBehaviour
    {
        private float maxAngle;
        private float yAngle;

        private void Start()
        {
            maxAngle = transform.eulerAngles.x;
            yAngle = transform.eulerAngles.y;

            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            transform.localPosition = new Vector3(x, y, z);

            var animator = GetComponent<Animator>();
            animator.SetFloat("test", 10f, 10f, 10f);
        }

        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (tag == "Player" || other.tag == "GameController")
            {
                Debug.Log("Found it!");
            }
        }

        private GameObject InstantiateAndSet(GameObject root)
        {
            var go = Instantiate(gameObject);
            go.transform.parent = root.transform;
            return go;
        }

        private void LateUpdate()
        {
            var c = GetComponent("Grid");

            gameObject.SendMessage("Fire");

            RaycastHit[] hits = Physics.RaycastAll(Vector3.up, Vector3.one);
            var result = Physics.OverlapBox(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity, 0,
                QueryTriggerInteraction.Collide);

            var mainCamera = Camera.main;
        }
    }
}
