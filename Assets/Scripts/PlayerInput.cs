using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �Է��� �����ϰ� ó���ϴ� Ŭ����
// �÷��̾��� ��ġ �Է��� �޾� �ش� ��ġ�� ������ �߻��ϴ� ����� �����մϴ�.
// �Է¿� ���� ������ �߻� ����� �ӵ��� �����մϴ�.

public enum TouchState { TouchBegan, TouchMoved, TouchEnd }
public class PlayerInput : MonoBehaviour
{
    public TouchState state;
    private void Update()
    {
        // ��ġ�� ���۵Ǿ��� ��
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

        } // ��ġ ���� �� ���������� ��
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // �������� ó��
        }
        // ��ġ�� ������ ��
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled))
        {
            // ��ġ ���� ó��
        }
    }
}
