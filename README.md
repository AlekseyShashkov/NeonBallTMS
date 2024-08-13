## 🎬Видеокассета:
<!-- Кассета --> 
https://github.com/user-attachments/assets/4fd148a5-67a6-4b17-b0dd-8f90e3ecdb1d

## 🔧Логика:
- [<i>BallController.cs</i>](https://github.com/AlekseyShashkov/NeonBallTMS/blob/main/Assets/_Project/_Scripts/Player/BallController.cs) - перемещение шара "на место" в случае падения;
<details><summary><b>BallController</b></summary> 
 
```csharp
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
```
</details>

- [<i>UIController.cs</i>](https://github.com/AlekseyShashkov/NeonBallTMS/blob/main/Assets/_Project/_Scripts/UI/UIController.cs) - ведение и отображение счётчика звёзд, а также "уведомление" о "завершении игры".<br/>
<details><summary><b>UIController</b></summary> 
 
```csharp
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
```
</details>

При "завершении игры" вызывается метод <b>StopMove()</b> в [<i>Ball.cs</i>](https://github.com/AlekseyShashkov/NeonBallTMS/blob/main/Assets/_Project/_Scripts/Player/Ball.cs).
<details><summary><b>Ball</b></summary> 
 
```csharp
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
```
</details>
