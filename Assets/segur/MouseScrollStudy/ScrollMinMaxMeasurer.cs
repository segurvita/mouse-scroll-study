using UnityEngine;

namespace MouseScrollCoordinator
{
    /// <summary>
    /// スクロール最小値最大値計測器
    /// </summary>
    public class ScrollMinMaxMeasurer : MonoBehaviour
    {
        /// <summary>現在値</summary>
        public float Current { get; private set; } = 0;

        /// <summary>最小値</summary>
        public float Min { get; private set; } = float.MaxValue;

        /// <summary>最大値</summary>
        public float Max { get; private set; } = -float.MaxValue;
        
        /// <summary>現在値/速度</summary>
        public float CurrentPerSpeed { get; private set; } = 0;

        /// <summary>最小値/速度</summary>
        public float MinPerSpeed { get; private set; } = float.MaxValue;

        /// <summary>最大値/速度</summary>
        public float MaxPerSpeed { get; private set; } = -float.MaxValue;
        
        /// <summary>速度計測器</summary>
        private ScrollSpeedMeasurer _speedMeasurer;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        void Start()
        {
            _speedMeasurer = GetComponent<ScrollSpeedMeasurer>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            // 現在の数値を取得する。
            float current = Input.GetAxis("Mouse ScrollWheel");
            
            // 0ならここで終わり
            if (current == 0.0 || _speedMeasurer.Speed == 0)
            {
                return;
            }

            // 現在値を更新する。
            Current = Mathf.Abs(current);

            // 最小値を更新する。
            Min = Mathf.Min(Mathf.Abs(current), Min);

            // 最大値を更新する。
            Max = Mathf.Max(Mathf.Abs(current), Max);

            // 現在値/速度を更新する。
            CurrentPerSpeed = Mathf.Abs(current) / _speedMeasurer.Speed;

            // 最小値/速度を更新する。
            MinPerSpeed = Mathf.Min(CurrentPerSpeed, MinPerSpeed);

            // 最大値/速度を更新する。
            MaxPerSpeed = Mathf.Max(CurrentPerSpeed, MaxPerSpeed);
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void Reset()
        {
            Current = 0;
            Min = float.MaxValue;
            Max = -float.MaxValue;
            CurrentPerSpeed = 0;
            MinPerSpeed = float.MaxValue;
            MaxPerSpeed = -float.MaxValue;
        }
    }
}
