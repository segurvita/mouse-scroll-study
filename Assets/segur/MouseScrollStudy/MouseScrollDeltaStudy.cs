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

    /// <summary>スライダー</summary>
    public Slider uiSlider;

    /// <summary>合計値</summary>
    private float _sum = 0;

    /// <summary>最小値</summary>
    private float _min = float.MaxValue;
    
    /// <summary>最大値</summary>
    private float _max = -float.MaxValue;

    /// <summary>
    /// 毎フレーム呼ばれる関数
    /// </summary>
    void Update()
    {
        // 現在の数値を取得する。
        float current = Input.mouseScrollDelta.y;

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

        // 表示する。
        Refresh(current);
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
        uiSlider.value = _sum;
    }
}
