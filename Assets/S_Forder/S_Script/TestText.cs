using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    [SerializeField] private ControllerManager cm;

    public Text text; // Textオブジェクト
    public Text leftAngle;
    public Text rightAngle;

    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        text.text = "入力なし";

        cm.Update();

        float left = cm.GetLeftAngle();
        float right = cm.GetRightAngle();

        if(Input.GetButton("Maru"))
        {
            text.text = "Maru";
        }
        if (Input.GetButton("Batu"))
        {
            text.text = "Batu";
        }
        if (Input.GetButton("Sankaku"))
        {
            text.text = "Sankaku";
        }
        if (Input.GetButton("Sikaku"))
        {
            text.text = "Sikaku";
        }
        if (Input.GetButton("L1"))
        {
            text.text = "L1";
        }
        if (Input.GetButton("L2"))
        {
            text.text = "L2";
        }
        if (Input.GetButton("R1"))
        {
            text.text = "R1";
        }
        if (Input.GetButton("R2"))
        {
            text.text = "R2";
        }
        if (Input.GetButton("Share"))
        {
            text.text = "Share";
        }
        if (Input.GetButton("Option"))
        {
            text.text = "Option";
        }
        if (Input.GetButton("PS"))
        {
            text.text = "PS";
        }
        if (Input.GetButton("TrackPad"))
        {
            text.text = "TrackPad";
        }


        if (cm.LeftStickUp())
        {
            text.text = "左スティック：上";
        }
        if(cm.LeftStickDown())
        {
            text.text = "左スティック：下";
        }
        if (cm.LeftStickRight())
        {
            text.text = "左スティック：右";
        }
        if (cm.LeftStickLeft())
        {
            text.text = "左スティック：左";
        }
        if (cm.LeftStickRightUp())
        {
            text.text = "左スティック：右上";
        }
        if (cm.LeftStickRightDown())
        {
            text.text = "左スティック：右下";
        }
        if (cm.LeftStickLeftUp())
        {
            text.text = "左スティック：左上";
        }
        if (cm.LeftStickLeftDown())
        {
            text.text = "左スティック：左下";
        }


        if (cm.RightStickUp())
        {
            text.text = "右スティック：上";
        }
        if (cm.RightStickDown())
        {
            text.text = "右スティック：下";
        }
        if (cm.RightStickRight())
        {
            text.text = "右スティック：右";
        }
        if (cm.RightStickLeft())
        {
            text.text = "右スティック：左";
        }
        if (cm.RightStickRightUp())
        {
            text.text = "右スティック：右上";
        }
        if (cm.RightStickRightDown())
        {
            text.text = "右スティック：右下";
        }
        if (cm.RightStickLeftUp())
        {
            text.text = "右スティック：左上";
        }
        if (cm.RightStickLeftDown())
        {
            text.text = "右スティック：左下";
        }

        leftAngle.text = "LeftAngle:" + left.ToString();
        rightAngle.text = "RightAngle:" + right.ToString();
    }
}