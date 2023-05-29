using UnityEngine;

public enum TouchState { TouchBegan, TouchMoved, TouchEnd }

public static class PlayerInput
{
    public static TouchState state;
    public static Vector2 touchPos;

    public static void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                state = TouchState.TouchBegan;
                touchPos = GetScreenPosition(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                state = TouchState.TouchMoved;
                touchPos = GetScreenPosition(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                state = TouchState.TouchEnd;
            }
        }
    }

    private static Vector2 GetScreenPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }
}
