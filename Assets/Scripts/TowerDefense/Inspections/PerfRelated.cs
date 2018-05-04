using UnityEngine;

namespace TowerDefense.Inspections
{
    public class PerfRelated : MonoBehaviour
    {
        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (tag == "Player" || other.tag == "Enemy")
            {
                Debug.Log("Found it!");
            }
        }
    }
}