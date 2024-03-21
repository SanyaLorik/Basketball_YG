using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }

        private void OnCollisionEnter(Collision collision)
        {
            
        }

        private void OnCollisionExit(Collision collision)
        {
            
        }
    }
}