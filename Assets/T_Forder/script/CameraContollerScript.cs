using UnityEngine;
using System.Collections;

public class CameraContollerScript : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float spinSpeed = 1f;
    public float distance = 5f;

    Vector3 nowPos;
    Vector3 pos = Vector3.zero;
    public Vector2 mouse = Vector2.zero;

    public GameObject targetPoint;  //目標オブジェクト
    public float speed = 0.01f;      //補間スピード
    private Vector3 eyePos;

    void Start()
    {
        // 初期位置の取得
        nowPos = transform.position;
    }

    void Update()
    {
        //操作ない場合
        if (Input.GetAxis("RightStickHorizontal") == 0 && Input.GetAxis("RightStickVertical") == 0)
        {
            // ターゲット方向のベクトルを取得
            Vector3 targetPosition = targetPoint.transform.position - this.transform.position;
            // 方向を、回転情報に変換
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, speed);

            transform.position = Vector3.Lerp(this.transform.position, eyePos, 1.01f);
            // 座標の更新
          
          //transform.LookAt(target2.position);
        }
        else
        {

            mouse += new Vector2(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical")) * Time.deltaTime * spinSpeed;


            mouse.y = Mathf.Clamp(mouse.y, -0.3f + 0.5f, 0.3f + 0.5f);

            // 球面座標系変換
            pos.x = distance * Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Cos(mouse.x * Mathf.PI);
            pos.y = -distance * Mathf.Cos(mouse.y * Mathf.PI);
            pos.z = -distance * Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Sin(mouse.x * Mathf.PI);

            pos *= nowPos.z;

            pos.y += nowPos.y;

          
            // 座標の更新
            //transform.position = Vector3.Lerp(this.transform.position, (pos + target.position), 0.01f);
            transform.position = pos + target.position;
            transform.LookAt(target.position);
        }


    }

    public void SetEyePosition(Vector3 _eyePos)
    {
        //距離を
        //Vector3 work = _eyePos - eyePos;
        //float distance = work.magnitude;
        eyePos = _eyePos;
    }

}