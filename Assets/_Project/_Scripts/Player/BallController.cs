using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Transform ball = null;
        private Vector3 startPosition = Vector3.zero;

        private void Awake()
        {
            startPosition = ball.position;
        }

        public void ReturnToStart()
        {
            ball.position = startPosition;
        }
    }
}