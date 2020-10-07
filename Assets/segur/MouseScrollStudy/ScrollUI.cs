using UnityEngine;
using UnityEngine.UI;

namespace MouseScrollCoordinator
{
    /// <summary>
    /// スクロールUI
    /// </summary>
    public class ScrollUI : MonoBehaviour
    {
        public Slider uiSliderSpeed;
        public Text uiTextSpeed;

        public Slider uiSliderCurrent;
        public Text uiTextCurrent;

        public Slider uiSliderMin;
        public Text uiTextMin;

        public Slider uiSliderMax;
        public Text uiTextMax;

        public Slider uiSliderCurrentPerSpeed;
        public Text uiTextCurrentPerSpeed;

        public Slider uiSliderMinPerSpeed;
        public Text uiTextMinPerSpeed;

        public Slider uiSliderMaxPerSpeed;
        public Text uiTextMaxPerSpeed;

        private ScrollMinMaxMeasurer _minMaxMeasurer;
        private ScrollSpeedMeasurer _speedMeasurer;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        void Start()
        {
            _minMaxMeasurer = GetComponent<ScrollMinMaxMeasurer>();
            _speedMeasurer = GetComponent<ScrollSpeedMeasurer>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            uiSliderSpeed.value = _speedMeasurer.Speed;
            uiTextSpeed.text = _speedMeasurer.Speed.ToString();

            uiSliderCurrent.value = _minMaxMeasurer.Current;
            uiTextCurrent.text = _minMaxMeasurer.Current.ToString();

            uiSliderMin.value = _minMaxMeasurer.Min;
            uiTextMin.text = _minMaxMeasurer.Min.ToString();

            uiSliderMax.value = _minMaxMeasurer.Max;
            uiTextMax.text = _minMaxMeasurer.Max.ToString();

            uiSliderCurrentPerSpeed.value = _minMaxMeasurer.CurrentPerSpeed;
            uiTextCurrentPerSpeed.text = _minMaxMeasurer.CurrentPerSpeed.ToString();

            uiSliderMinPerSpeed.value = _minMaxMeasurer.MinPerSpeed;
            uiTextMinPerSpeed.text = _minMaxMeasurer.MinPerSpeed.ToString();

            uiSliderMaxPerSpeed.value = _minMaxMeasurer.MaxPerSpeed;
            uiTextMaxPerSpeed.text = _minMaxMeasurer.MaxPerSpeed.ToString();
        }
    }
}
