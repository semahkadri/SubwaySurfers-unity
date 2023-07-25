using UnityEngine;
using UnityEngine.UI;

public class touchdetector : MonoBehaviour
{
    public Button button;
    public Button button2;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Vector2 touchPos = Input.GetTouch(0).position;


            if (RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), touchPos))
            {
                
                button.onClick.Invoke();
            }
            else if ( RectTransformUtility.RectangleContainsScreenPoint(button2.GetComponent<RectTransform>(), touchPos))
            {
                button2.onClick.Invoke();   
            }
        }
    }
}