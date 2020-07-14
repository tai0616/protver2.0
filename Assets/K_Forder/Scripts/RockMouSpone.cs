using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMouSpone : MonoBehaviour
{
    public GameObject rockMounObj;

    public Transform catsleObj;

    private Vector3[] rockMonuPos;

    private int Ri1_kazu = 5;
    private int Ri2_kazu = 5;
    private int Ri3_kazu = 5;
    private int Ri4_kazu = 5;
    private int Ri5_kazu = 5;
    private int Ri6_kazu = 5;
    private int Ri7_kazu = 5;
    private int Ri8_kazu = 5;
    private int Ri9_kazu = 5;
    private int Ri10_kazu = 5;

    private int rock_Ring_kazuSum;

    private float rock_Ring1_radius = 1000;
    private float rock_Ring2_radius = 2000;
    private float rock_Ring3_radius = 3000;
    private float rock_Ring4_radius = 4000;
    private float rock_Ring5_radius = 5000;
    private float rock_Ring6_radius = 6000;
    private float rock_Ring7_radius = 7000;
    private float rock_Ring8_radius = 8000;
    private float rock_Ring9_radius = 9000;
    private float rock_Ring10_radius = 10000;

    private void Awake()
    {
        rock_Ring_kazuSum = Ri1_kazu +
                            Ri2_kazu +
                            Ri3_kazu +
                            Ri4_kazu +
                            Ri5_kazu +
                            Ri6_kazu +
                            Ri7_kazu +
                            Ri8_kazu +
                            Ri9_kazu +
                            Ri10_kazu;

        rockMonuPos = new Vector3[rock_Ring_kazuSum];
    }

    void Start()
    {

        for (int count = 1; count < Ri1_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring1_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring1_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu; count < Ri1_kazu + Ri2_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring2_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring2_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring3_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring3_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring4_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring4_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring5_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring5_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring6_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring6_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring7_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring7_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu + Ri8_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring8_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring8_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu + Ri8_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu + Ri8_kazu + Ri9_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring9_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring9_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }
        for (int count = Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu + Ri8_kazu + Ri9_kazu; count < Ri1_kazu + Ri2_kazu + Ri3_kazu + Ri4_kazu + Ri5_kazu + Ri6_kazu + Ri7_kazu + Ri8_kazu + Ri9_kazu + Ri10_kazu; count++)
        {
            float RanPos = Random.Range(1.0f, 100.0f);
            rockMonuPos[count].x = rock_Ring10_radius * Mathf.Sin(RanPos);      //X軸の設定
            rockMonuPos[count].z = rock_Ring10_radius * Mathf.Cos(RanPos);      //Y軸の設定
        }


        for (int count = 0; count < rock_Ring_kazuSum; count++)
        {
            Instantiate(rockMounObj, catsleObj.transform.position + rockMonuPos[count], new Quaternion(0, 0, 0, 1));
        }
    }
}
