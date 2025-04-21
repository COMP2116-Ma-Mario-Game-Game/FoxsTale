using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        public static LevelUI instance;
        public float timeLimit;
        public GameObject lbTimerValue;
        public GameObject lbScoreValue;
        private float _time;
        private long _score;

        private Text _lbTimerValue;
        private Text _lbScoreValue;

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
            DontDestroyOnLoad(GameObject.Find("MarkObject"));
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

            _lbTimerValue = lbTimerValue.GetComponent<Text>();
            _lbScoreValue = lbScoreValue.GetComponent<Text>();
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