using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public float speed = 4f;
    private bool isWate = false; //ждет ли наш жук момента чтобы выпрыгнуть или скрыться 
    private bool isHidden = false; //спрятан наш жук или он вышел из земли
    public float waitTime=4f;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWate == false)
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed*Time.deltaTime);
        if (transform.position == point.position)
        {
            if (isHidden)
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                isHidden = false;
            }
            
            else
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                isHidden = true;
            }

            isWate = true;
            StartCoroutine(Waiting());
        }
            
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        isWate = false;
    }
}
