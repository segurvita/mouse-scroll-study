using UnityEngine;
using UnityEngine.UI;

public class MouseScrollStudy : MonoBehaviour
{
    /// <summary>テキストボックス</summary>
    public Text uiTextMouseScrollDelta;
    
    /// <summary>テキストボックス</summary>
    public Text uiTextSum;

    /// <summary>スライダー</summary>
    public Slider uiSlider;

    /// <summary>合計値</summary>
    private float _sum = 0;

    /// <summary>
    /// 毎フレーム呼ばれる関数
    /// </summary>
    void Update()
    {
        // 現在の数値を取得する。
        float currentValue = Input.mouseScrollDelta.y;

        if (currentValue == 0.0)
        {
            return;
        }
        
        // 合計する
        _sum += currentValue;

        // 入力値を表示する。
        uiTextMouseScrollDelta.text = currentValue.ToString();
        
        // 合計値を表示する。
        uiTextSum.text = _sum.ToString();
        uiSlider.value = _sum;
    }
}
