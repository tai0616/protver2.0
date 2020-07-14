﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContler : MonoBehaviour
{
    Rigidbody rb;


    public GameObject monster;
    public GameObject monsterTop;
    public GameObject monsterDown;


    public float maxDistance;

    public float moveSpeed;              // 移動速度
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度

    float horizontalInput;
    float verticalInput;
    float heightInput;

    bool moveDistance = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveDistance)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Q))
            {
                heightInput = -0.5f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                heightInput = 0.5f;
            }
        }


        var nearPoint = NearestPointOnLineSegment(monsterTop.transform.position, monsterDown.transform.position, transform.position);
        var distance = Vector3.Distance(nearPoint, transform.position);


        //近づいたら動くやつ
        if (distance < maxDistance)
        {
            if (!moveDistance)
            {
                Pointtarget(nearPoint);
            }
        }

        moveDistance = false;
    }

    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        moveVector.x = moveSpeed * horizontalInput;
        moveVector.y = moveSpeed * heightInput;
        moveVector.z = moveSpeed * verticalInput;
        rb.AddForce(moveForceMultiplier * (moveVector - rb.velocity));
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
            NewPos.x = monster.transform.position.x + 8.0f;
        }
        else
        {
            NewPos.x = monster.transform.position.x - 8.0f;
        }
        //transform.position = NewPos;

        StartThrow(this.gameObject, -15.0f, transform.position, NewPos, 60.0f);
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
        return Vector3.Lerp(a, b, t);
    }
}
