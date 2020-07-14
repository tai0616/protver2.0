using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleController : MonoBehaviour
{
    public Transform catslePos;
    /// <summary>
    /// レイの当たり判定
    /// </summary>
    Ray ray;
    RaycastHit hit;            //Rayが当たったオブジェクトの情報を入れる箱
    public float ray_distance;
    public Transform ray_startpos;


    /// <summary>
    /// 巨獣の動くスピード関連
    /// </summary>
    Rigidbody KyojyuuRb;
    public float frontSpeed = 1;
    public float sideSpeed = 1;
    [SerializeField] private bool movenow = false;

    private float hogetime;
    private int rlRandom = 0;
    public float sMoveTime;//横に移動する秒数
    private void Start()
    {
        KyojyuuRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //KyojyuuRb.AddForce(0, 0, frontSpeed);

        this.transform.LookAt(catslePos);
        float step = frontSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, catslePos.position, step);

        ///////////////レイで岩山を判断///////////////
        ray = new Ray(ray_startpos.transform.position, transform.TransformDirection(new Vector3(0, 0, ray_distance)));

        //レイを可視化
        Debug.DrawRay(ray_startpos.transform.position, transform.TransformDirection(new Vector3(0, 0, ray_distance)), Color.yellow);

        //岩山を自動で避ける時
        if (Physics.Raycast(ray, out hit, ray_distance))//Rayの当たり判定
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "RockMountain" && movenow == false)
            {
                movenow = true;
                rlRandom = Random.Range(0,1);
                KyojyuuRb.velocity = Vector3.zero;
                hogetime = 0;
                //KyojyuuRb.angularVelocity = Vector3.zero;
            }
        }

        //横に移動処理
        if (movenow == true)//横に移動中
        {
            hogetime += Time.deltaTime;

            //巨獣の動き
            if (rlRandom == 0)//右に移動
            {
                KyojyuuRb.AddForce(sideSpeed, 0, 0);

                if (hogetime >= sMoveTime)//移動終わったら
                {
                    movenow = false;
                }

                Debug.Log(hogetime);
            }
            else//左に移動
            {
                KyojyuuRb.AddForce(-sideSpeed, 0, 0);

                if (hogetime >= sMoveTime)//移動終わったら
                {
                    movenow = false;
                }
                Debug.Log(hogetime);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MountainRock")
        {
            //Destroy(this.gameObject);
        }
    }
}
