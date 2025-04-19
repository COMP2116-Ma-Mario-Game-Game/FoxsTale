using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        public static LevelUI instance;
        public float timeLimit;
        private float _time;
        private long _score;

        private Label _lbTimerValue;
        private Label _lbScoreValue;

        private bool _timeing = true;

        public void StartTimeing()
        {
            _timeing = true;
        }
        public void StopTimeing()
        {
            _timeing = false;
            AddScore(Mathf.FloorToInt(_time));
            _time = 0;
            ShowTime();
            GameObject.Find("MarkObject").GetComponent<Mark>().mark = _score;
        }
        public void AddScore(long score)
        {
            _score += score;
            _lbScoreValue.text = $"{_score:0000}";
        }
        private void ShowTime()
        {
            var minutes = Mathf.FloorToInt(_time / 60);
            var seconds = Mathf.FloorToInt(_time % 60);
            _lbTimerValue.text = $"{minutes:00}:{seconds:00}";
        }
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            _time = timeLimit;
            _score = 0;

            var uiDocument = GetComponent<UIDocument>();
            _lbTimerValue = uiDocument.rootVisualElement.Q<Label>("lbTimerValue");
            _lbScoreValue = uiDocument.rootVisualElement.Q<Label>("lbScoreValue");
        }

        // Update is called once per frame
        private void Update()
        {
            if (_timeing)
            {
                var _deltaTime = Time.deltaTime;
                if (_time > _deltaTime)
                {
                    _time -= _deltaTime;
                }
                else
                {
                    _time = 0;
                }
                ShowTime();
            }
        }
    }
}