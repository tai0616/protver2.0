using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContler : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody monsterrb;

    [SerializeField] private ControllerManager cm;
    [SerializeField] private float dashSpeed;

    public GameObject monster;
    public GameObject monsterTop;
    public GameObject monsterDown;


    public float maxDistance;
    Vector3 oldPos;

    public float moveSpeed;              // 移動速度
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度

    float horizontalInput;
    float verticalInput;
    float heightInput;

    bool moveDistance = false;

    public enum MODE
    {
        SerchMode,
        KenjakuMode,
        PullMode,
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        monsterrb = monster.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        oldPos = transform.position;
        if (!moveDistance)
        {
            horizontalInput = Input.GetAxis("LeftStickHorizontal");
            verticalInput = Input.GetAxis("LeftStickVertical");

            if (Input.GetButton("Maru"))
            {
                horizontalInput *= dashSpeed;
                verticalInput *= dashSpeed;
            }
            bool inputKey_ = false;
            if (Input.GetButton("L1"))
            {
                heightInput = -1.5f;
                inputKey_ = true;
            }
            if (Input.GetButton("R1"))
            {
                heightInput = 1.5f;
                inputKey_ = true;
            }
            if (!inputKey_)
            {
                heightInput = 0f;
            }
        }


        var nearPoint = NearestPointOnLineSegment(monsterTop.transform.position, monsterDown.transform.position, transform.position);
        var distance = Vector3.Distance(nearPoint, transform.position);


        //近づいたら動くやつ
        if (distance < maxDistance)
        {
            if (!moveDistance)
            {
                horizontalInput = verticalInput = 0;
                Pointtarget(nearPoint);
            }
        }

        moveDistance = false;
    }

    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        //moveVector.x = moveSpeed * horizontalInput;
        //moveVector.y = moveSpeed * heightInput;
        //moveVector.z = moveSpeed * verticalInput;
        
        //rb.AddForce(moveForceMultiplier * (moveVector - rb.velocity));

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * verticalInput + Camera.main.transform.right * horizontalInput;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, heightInput * moveSpeed, 0);


        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    // 点Pから最も近い線分AB上にある点を返す
    Vector3 NearestPointOnLineSegment(Vector3 a, Vector3 b, Vector3 p)
    {
        Vector3 ab = b - a;
        float length = ab.magnitude;
        ab.Normalize();

        float k = Vector3.Dot(p - a, ab);
        k = Mathf.Clamp(k, 0, length);
        return a + k * ab;
    }
    //点対象の場所に移動
    void Pointtarget(Vector3 nearP_)
    {
        Vector3 moveVec = nearP_ - transform.position;

       
        Vector3 NewPos = monster.transform.position + moveVec;
        NewPos.y = monster.transform.position.y;
    
        if (moveVec.x > 0)
        {
            NewPos.x = monster.transform.position.x + maxDistance + 2.0f;
        }
        else
        {
            NewPos.x = monster.transform.position.x - maxDistance - 2.0f;
        }

        NewPos.z = monster.transform.position.z;

     

        if (cm.LeftStickRightUp())
        {
            StartThrow(this.gameObject, 18.0f, this.transform.position, NewPos, 50.0f);
        }
        else if (cm.LeftStickRightDown())
        {
            StartThrow(this.gameObject, -18.0f, this.transform.position, NewPos, 50.0f);
        }
        else if (cm.LeftStickLeftUp())
        {
            StartThrow(this.gameObject, 18.0f, this.transform.position, NewPos, 50.0f);
        }
        else if (cm.LeftStickLeftDown())
        {
            StartThrow(this.gameObject, -18.0f, this.transform.position, NewPos, 50.0f);
        }

       
    }

    void StartThrow(GameObject target, float height, Vector3 start, Vector3 end, float duration)
    {
        // 中点を求める
        Vector3 half = end - start * 0.50f + start;
        half.y += Vector3.up.y + height;
        StartCoroutine(LerpThrow(target, start, half, end, duration));
    }

    IEnumerator LerpThrow(GameObject target, Vector3 start, Vector3 half, Vector3 end, float duration)
    {
        float startTime = Time.timeSinceLevelLoad;
        float rate = 0f;
        while (true)
        {
            if (rate >= 1.0f)
                yield break;

            float diff = Time.timeSinceLevelLoad - startTime;
            rate = diff / (duration / 60f);
            target.transform.position = CalcLerpPoint(start, half, end, rate);

            yield return null;
        }
    }

    Vector3 CalcLerpPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {

        moveDistance = true;
        var a = Vector3.Lerp(p0, p1, t);
        var b = Vector3.Lerp(p1, p2, t);
        Vector3 kaesu_= Vector3.Lerp(a, b, t);
        kaesu_.z = transform.position.z;
        return kaesu_;
    }

}
