using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public class KeyboardBallInput : BallInputBehaviour
    {
        public override Vector2 Direction()
        {
            return new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
        }
    }
}
