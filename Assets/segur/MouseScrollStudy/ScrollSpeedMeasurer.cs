using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MouseScrollCoordinator
{
    /// <summary>
    /// スクロール速度計測器
    /// </summary>
    public class ScrollSpeedMeasurer : MonoBehaviour
    {
        /// <summary>速度</summary>
        public float Speed { get; private set; } = 1f;

        private List<ScrollRecord> _listRec;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        void Start()
        {
            _listRec = new List<ScrollRecord>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            // 1秒以内の記録だけ残す
            _listRec = _listRec
                .Where(rec => Time.time - rec.Time <= 1f)
                .ToList();

            // 現在の数値を取得する。
            float current = Input.GetAxis("Mouse ScrollWheel");
            if (current != 0)
            {
                // 絶対値と時刻を記録する
                ScrollRecord recCurrent = new ScrollRecord(Math.Abs(current), Time.time);
                _listRec.Add(recCurrent);
            }

            // 速度を出す
            Speed = _listRec.Sum(rec => rec.Value);
        }
    }
}
