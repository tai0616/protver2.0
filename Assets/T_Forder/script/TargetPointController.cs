using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointController : MonoBehaviour
{
    
    public GameObject player;
    public GameObject giantBeast;

    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //索敵モードカメラワーク
        //巨獣とプレイヤーの間くらいを見る
        transform.position = (player.transform.position + giantBeast.transform.position) / 2;

        //目線はプレイヤーの後ろくらい
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        cameraTransform.position = player.transform.position+direction * 5.0f;
        cameraTransform.position += Vector3.up*3.0f;
    }
}
