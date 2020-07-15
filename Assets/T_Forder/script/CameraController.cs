using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPoint;  //目標オブジェクト
    public float speed = 0.1f;      //補間スピード

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //**********************************************************
        //ターゲット方向へ向く
        //**********************************************************

        // ターゲット方向のベクトルを取得
        Vector3 targetPosition = targetPoint.transform.position - this.transform.position;
        // 方向を、回転情報に変換
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
        // 現在の回転情報と、ターゲット方向の回転情報を補完する
        transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, speed);


    }
}
