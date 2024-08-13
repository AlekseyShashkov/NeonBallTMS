using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public class BallInputController : BallInputBehaviour
    {
        [SerializeField] private BallInputBehaviour[] ballInputBehaviours;

        public override Vector2 Direction()
        {
            var direction = Vector2.zero;
            foreach (var inputBehaviour in ballInputBehaviours)
            {
                direction += inputBehaviour.Direction();
            }
            return direction;
        }
    }
}
