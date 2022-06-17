using UnityEngine;
using UnityEngine.Serialization;

namespace alisahanyalcin
{
    public enum FPSCounterPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
    
    public class FPSCounter : MonoBehaviour
    {
        public float updateInterval = 0.5f;
        public Color textColor = Color.white;
        public FPSCounterPosition fpsPosition = FPSCounterPosition.TopLeft;
        
        [HideInInspector] public Vector2 position = new Vector2(5, 5);
    
        private readonly GUIStyle _textStyle = new GUIStyle();
        private int _frames = 0;
        private float _accum = 0.0f;
        private float _timeLeft;
        private float _fps;
        private float _height = 25;
        private float _width = 100;

        private void Update()
        {
            _textStyle.normal.textColor = textColor;
        
            _timeLeft -= Time.deltaTime;
            _accum += Time.timeScale / Time.deltaTime;
            ++_frames;

            // Interval ended - update GUI text and start new interval
            if (_timeLeft <= 0.0)
            {
                // display two fractional digits (f2 format)
                _fps = (_accum / _frames);
                _timeLeft = updateInterval;
                _accum = 0.0f;
                _frames = 0;
            }
        }

        private void OnGUI()
        {
            position = fpsPosition switch
            {
                FPSCounterPosition.TopLeft => new Vector2(5, 5),
                FPSCounterPosition.TopRight => new Vector2(Screen.width - _width + _height, 5),
                FPSCounterPosition.BottomLeft => new Vector2(5, Screen.height - _height),
                FPSCounterPosition.BottomRight => new Vector2(Screen.width - _width + _height, Screen.height - _height),
                _ => position
            };

            GUI.Label(new Rect(position.x, position.y, _width, _height), _fps.ToString("F2") + "FPS", _textStyle);
        }
    }
}