using UnityEngine;

namespace Basketball_YG.Mono
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Ring : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {
            print(other.name);
        }
    }
}