using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inputs
{
    public class JoystickInput : BallInputBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private float joystickRange = 50f;

        [SerializeField] private Vector2 joystickPosition;
        [SerializeField] private RectTransform joystickRectTransform;
        private Vector2 joystickCenter;

        void Start()
        {
            joystickCenter = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 newPosition = eventData.position - joystickCenter;
            newPosition = Vector2.ClampMagnitude(newPosition, joystickRange);

            transform.position = joystickCenter + newPosition;

            joystickPosition = newPosition / joystickRange;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            joystickRectTransform.anchoredPosition = Vector2.zero;
            joystickPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public override Vector2 Direction()
        {
            return joystickPosition;
        }
    }
}
