using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 입력을 감지하고 처리하는 클래스
// 플레이어의 터치 입력을 받아 해당 위치에 버블을 발사하는 기능을 구현합니다.
// 입력에 따라 버블의 발사 방향과 속도를 결정합니다.

public enum TouchState { TouchBegan, TouchMoved, TouchEnd }

public class PlayerInput : MonoBehaviour
{
    public TouchState state;

    private void Update()
    {
        // 터치가 시작되었을 때
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            state = TouchState.TouchBegan;
        } // 터치 시작 후 스와이프할 때
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            state = TouchState.TouchMoved;
        }
        // 터치가 끝났을 때
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled))
        {
            state = TouchState.TouchEnd;
        }
    }
}
