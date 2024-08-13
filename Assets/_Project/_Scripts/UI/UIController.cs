using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text starsCounterView = null;
        [SerializeField] private int starsCounter = 0;
        public UnityEvent GameOver = new();

        private void Awake()
        {
            starsCounterView.text = starsCounter.ToString();
        }

        public void IncreaseStarsCounter()
        {
            starsCounter++;
            starsCounterView.text = starsCounter.ToString();
        }

        public void DecreaseStarsCounter()
        {
            starsCounter--;
            starsCounterView.text = starsCounter.ToString();

            if (starsCounter <= 0)
            {
                GameOver?.Invoke();
                Debug.Log("Game Over");
            }
        }
    }
}
