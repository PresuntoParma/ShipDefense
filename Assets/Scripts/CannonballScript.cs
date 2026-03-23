using System;
using System.Collections;
using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector2 touchEnd;
    private Touch touch;

    private enum directions {left, right, up, down};
    [SerializeField] private directions direction;
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private int life;
    [SerializeField] private GameObject arrow;


    private void Start()
    {
        GetDirection();
        GetScale();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Swipe();
        }
    }

    private void GetScale()
    {
        transform.localScale = new Vector3(1 + (life * 0.4f), 1 + (life * 0.4f), 1);
    }

    private void Swipe()
    {
        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            touchEnd = touch.position;
            Vector2 touchValue = touchEnd - touchStart;

            if (Mathf.Abs(Vector2.Distance(touchStart, touchEnd)) <= minSwipeDistance)
            {
                print("não swipou o suficiente");
            }
            else if (Mathf.Abs(touchValue.x) > Mathf.Abs(touchValue.y))
            {
                //HORIZONTAL
                print("Horizontal");
                if (touchValue.x > 0)
                {
                    print("direita");
                    Destroy(directions.right);
                }
                else
                {
                    print("esquerda");
                    Destroy(directions.left);
                }
            }
            else
            {
                //VERTICAL
                print("Vertical");
                if (touchValue.y > 0)
                {
                    print("cima");
                    Destroy(directions.up);
                }
                else
                {
                    print("baixo");
                    Destroy(directions.down);
                }
            }
        }
    }

    private void GetDirection()
    {
        int directionNumber = UnityEngine.Random.Range(0, 4);

        switch (directionNumber)
        {
            case 0:
                {
                    direction = directions.left;
                    arrow.transform.eulerAngles = new Vector3(0, 0, 90);
                }
                break;
            case 1:
                {
                    direction = directions.right;
                    arrow.transform.eulerAngles = new Vector3(0, 0, -90);
                }
                break;
            case 2:
                {
                    direction = directions.up;
                    arrow.transform.eulerAngles = Vector2.zero;
                }
                break;
            case 3:
                {
                    direction = directions.down;
                    arrow.transform.eulerAngles = new Vector3(0, 0, 180);
                }
                break;
        }
            
    }

    private void Destroy(directions d)
    {
        if (d == direction)
        {
            life--;
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                GetDirection();
                GetScale();
            }
        }
    }
}
