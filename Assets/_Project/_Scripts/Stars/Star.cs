using UnityEngine;
using UnityEngine.Events;

namespace Stars
{
    [RequireComponent(typeof(Collider))]
    public class Star : MonoBehaviour
    {
        public UnityEvent Collected = new();

        private void OnTriggerEnter(Collider other)
        {
            Collected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
