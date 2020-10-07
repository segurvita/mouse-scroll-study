using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MouseScrollDeltaStudy : MonoBehaviour
{
    /// <summary>現在値テキストボックス</summary>
    public Text uiTextCurrent;

    /// <summary>最小値テキストボックス</summary>
    public Text uiTextMin;

    /// <summary>最大値テキストボックス</summary>
    public Text uiTextMax;

    /// <summary>合計値テキストボックス</summary>
    public Text uiTextSum;

    /// <summary>合計値スライダー</summary>
    public Slider uiSliderSum;

    /// <summary>速度テキストボックス</summary>
    public Text uiTextSpeed;

    /// <summary>速度スライダー</summary>
    public Slider uiSliderSpeed;

    /// <summary>最小値</summary>
    private float _min = float.MaxValue;

    /// <summary>最大値</summary>
    private float _max = -float.MaxValue;

    /// <summary>合計値</summary>
    private float _sum = 0;

    /// <summary>速度</summary>
    private float _speed = 1f;

    /// <summary>
    /// 初期化
    /// </summary>
    async void Start()
    {
        UpdateLoop(this.GetCancellationTokenOnDestroy()).Forget();
    }

    /// <summary>
    /// 毎フレーム呼ばれる関数
    /// </summary>
    void Update()
    {
        // 現在の数値を取得する。
        float current = Input.mouseScrollDelta.y;

        // 表示する。
        Refresh(current);

        if (current == 0.0)
        {
            return;
        }

        // 合計する。
        _sum += current;

        // 最小値を更新する。
        _min = Mathf.Min(current, _min);

        // 最大値を更新する。
        _max = Mathf.Max(current, _max);
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _sum = 0;
        _min = float.MaxValue;
        _max = -float.MaxValue;

        // 表示する。
        Refresh(0);
    }

    /// <summary>
    /// UIを更新する
    /// </summary>
    /// <param name="current"></param>
    private void Refresh(float current)
    {
        uiTextCurrent.text = current.ToString();
        uiTextMin.text = _min.ToString();
        uiTextMax.text = _max.ToString();
        uiTextSum.text = _sum.ToString();
        uiSliderSum.value = _sum;
        uiTextSpeed.text = _speed.ToString();
        uiSliderSpeed.value = _speed;
    }

    class ScrollRecord
    {
        public float Value;
        public float Time;

        public ScrollRecord(float value, float time)
        {
            this.Value = value;
            this.Time = time;
        }
    }

    async UniTaskVoid UpdateLoop(CancellationToken cancellationToken)
    {
        List<ScrollRecord> listRec = new List<ScrollRecord>();

        while (true)
        {
            // 1フレーム待つ
            await UniTask.Yield();
            cancellationToken.ThrowIfCancellationRequested();

            // 1秒以内の記録だけ残す
            listRec = listRec
                .Where(rec => Time.time - rec.Time <= 1f)
                .ToList();

            // 現在の数値を取得する。
            float current = Input.mouseScrollDelta.y;
            if (current != 0)
            {
                // 絶対値と時刻を記録する
                ScrollRecord recCurrent = new ScrollRecord(Math.Abs(current), Time.time);
                listRec.Add(recCurrent);
            }

            // 速度を出す
            _speed = listRec.Sum(rec => rec.Value);
        }
    }
}