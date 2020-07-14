using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    static float leftStickHorizontal, leftStickVertical;    //左スティック入力
    static float rightStickHorizontal, rightStickVertical;  //右スティック入力

    static float leftAngle, rightAngle; //成す角度

    public void Update()
    {
        //左スティックの入力値を取得
        leftStickHorizontal = Input.GetAxis("LeftStickHorizontal");
        leftStickVertical = Input.GetAxis("LeftStickVertical");
        //Vertical成分Horizontal成分と原点の成す角度を求める
        leftAngle=Mathf.Atan2(leftStickVertical, leftStickHorizontal);
        leftAngle = leftAngle * Mathf.Rad2Deg;

        //右スティックの入力値を取得
        rightStickHorizontal = Input.GetAxis("RightStickHorizontal");
        rightStickVertical = Input.GetAxis("RightStickVertical");
        //Vertical成分Horizontal成分と原点の成す角度を求める
        rightAngle = Mathf.Atan2(rightStickVertical, rightStickHorizontal);
        rightAngle = rightAngle * Mathf.Rad2Deg;
    }

    //左スティックを上に傾けている判定
    public bool LeftStickUp()
    {
        bool check = false;

        if (67.5f <= leftAngle && leftAngle < 112.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを下に傾けている判定
    public bool LeftStickDown()
    {
        bool check = false;

        if (-112.5f <= leftAngle && leftAngle < -67.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右に傾けている判定
    public bool LeftStickRight()
    {
        bool check = false;

        if (-22.5f <= leftAngle && leftAngle < 22.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左に傾けている判定
    public bool LeftStickLeft()
    {
        bool check = false;

        if (leftAngle < -157.5f || leftAngle >= 157.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右上に傾けている判定
    public bool LeftStickRightUp()
    {
        bool check = false;

        if (22.5f <= leftAngle && leftAngle < 67.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左上に傾けている判定
    public bool LeftStickLeftUp()
    {
        bool check = false;

        if (112.5f <= leftAngle && leftAngle < 157.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを右下に傾けている判定
    public bool LeftStickRightDown()
    {
        bool check = false;

        if (-67.5f <= leftAngle && leftAngle < -22.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //左スティックを左下に傾けている判定
    public bool LeftStickLeftDown()
    {
        bool check = false;

        if (-157.5f <= leftAngle && leftAngle < -112.5f)
        {
            if (leftStickHorizontal != 0 || leftStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }

    //右スティックを上に傾けている判定
    public bool RightStickUp()
    {
        bool check = false;

        if (67.5f <= rightAngle && rightAngle < 112.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを下に傾けている判定
    public bool RightStickDown()
    {
        bool check = false;

        if (-112.5f <= rightAngle && rightAngle < -67.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右に傾けている判定
    public bool RightStickRight()
    {
        bool check = false;

        if (-22.5f <= rightAngle && rightAngle < 22.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左に傾けている判定
    public bool RightStickLeft()
    {
        bool check = false;

        if (rightAngle < -157.5f || rightAngle >= 157.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右上に傾けている判定
    public bool RightStickRightUp()
    {
        bool check = false;

        if (22.5f <= rightAngle && rightAngle < 67.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左上に傾けている判定
    public bool RightStickLeftUp()
    {
        bool check = false;

        if (112.5f <= rightAngle && rightAngle < 157.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを右下に傾けている判定
    public bool RightStickRightDown()
    {
        bool check = false;

        if (-67.5f <= rightAngle && rightAngle < -22.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }
    //右スティックを左下に傾けている判定
    public bool RightStickLeftDown()
    {
        bool check = false;

        if (-157.5f <= rightAngle && rightAngle < -112.5f)
        {
            if (rightStickHorizontal != 0 || rightStickVertical != 0)
            {
                check = true;
            }
        }

        return check;
    }

    public float GetLeftAngle()
    {
        return leftAngle;
    }
    public float GetRightAngle()
    {
        return rightAngle;
    }
}