using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AdvancedAirPatrol : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    public float WaitTime = 3f; //время, которое объект будет стоять(ждать) в какой-то точке
    private bool CanGo = true; //можем мы идти или нет
    private int i = 1;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanGo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed*Time.deltaTime); // 1- откуда будем двигаться, 2- куда нужно двигаться 3 - скорость передвижения

        if (transform.position == points[i].position) //меняем точки местами, чтобы муха летела в точку 2
        {
            if (i < points.Length - 1)
            {
                i++;
            }
            else
                i = 0;
            CanGo = false;
            StartCoroutine(Waiting());

        }
    }

    IEnumerator Waiting() //создание карутины
    {
        yield return new WaitForSeconds(WaitTime);
        CanGo = true;
    } 


}
