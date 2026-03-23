using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector2 touchEnd;
    private Touch touch;

    private enum directions {left, right, up, down};
    [SerializeField] private directions direction;
    [SerializeField] private float minSwipeDistance = 50f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Swipe();
        }
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

    private void Destroy(directions d)
    {
        if (d == direction)
        {
            Destroy(this.gameObject);
        }
    }
}
