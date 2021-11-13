using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airPatrol : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 2;
    public float waitTime = 3f;
    private bool CanGo = true;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanGo)
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed*Time.deltaTime); // 1- откуда будем двигаться, 2- куда нужно двигаться 3 - скорость передвижения

        if (transform.position == point1.position) //меняем точки местами, чтобы муха летела в точку 2
        {
            Transform t = point1;
            point1 = point2;
            point2 = t;
            CanGo = false;
            StartCoroutine(Waiting());

        }
    }

    IEnumerator Waiting() //создание карутины
    {
        yield return new WaitForSeconds(waitTime);
        CanGo = true;
    } 
    
    
}
