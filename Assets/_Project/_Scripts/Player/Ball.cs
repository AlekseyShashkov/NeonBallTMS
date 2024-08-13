using Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private Rigidbody ballRigidbody;
        [SerializeField] private BallInputBehaviour inputBehaviour;
        [SerializeField] private float speed = 10f;
        public UnityEvent OnBallFall = new();

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var velocity = speed * Time.deltaTime;
            var direction = inputBehaviour.Direction() * velocity;

            ballRigidbody.AddForce(new Vector3(direction.x, 0, direction.y));

            if (transform.position.y < -2f)
            {
                OnBallFall?.Invoke();
            }
        }

        public void StopMove()
        {
            speed = 0f;
        }
    }
}
