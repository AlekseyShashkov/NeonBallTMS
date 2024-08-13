using Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public abstract class BallInputBehaviour : MonoBehaviour, IBallInput
    {
        public abstract Vector2 Direction();
    }
}
