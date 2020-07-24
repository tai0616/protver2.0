using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAim : MonoBehaviour
{
    [SerializeField] private float speed;   //移動倍率

    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("RightStickHorizontal");
        y = Input.GetAxis("RightStickVertical");

        this.transform.Translate(x * speed, y * speed, 0);
    }
}
