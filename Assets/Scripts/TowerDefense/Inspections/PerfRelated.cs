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

            transform.position = transform.position + transform.position;
//            transform.localPosition = Vector3.back;
            transform.position = transform.position;

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

        private void LateUpdate()
        {
            var c = GetComponent("Grid");

            gameObject.SendMessage("Fire");

            RaycastHit[] hits = Physics.RaycastAll(Vector3.up, Vector3.one);
            var result = Physics.OverlapBox(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity, 0,
                QueryTriggerInteraction.Collide);

            var mainCamera = Camera.main;
        }

        private void Test(GameObject root)
        {
            var go = Instantiate(gameObject);
            go.transform.parent = root.transform;
        }
    }
}