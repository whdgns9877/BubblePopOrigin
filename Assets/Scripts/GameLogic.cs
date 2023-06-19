
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private LineRenderer rayLine;
    [SerializeField] private Transform ballInitPos;
    [SerializeField] private int maxReflections = 5;
    [SerializeField] private float rayLength = 100;

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        PlayerInput.Update();

        switch (PlayerInput.state)
        {
            case TouchState.TouchBegan:
                rayLine.gameObject.SetActive(true);
                CastRay(ballInitPos.position, GetClampedDirection(PlayerInput.touchPos - (Vector2)ballInitPos.position).normalized, 0);
                break;

            case TouchState.TouchMoved:
                CastRay(ballInitPos.position, GetClampedDirection(PlayerInput.touchPos - (Vector2)ballInitPos.position).normalized, 0);
                rayLine.SetPosition(0, ballInitPos.position);
                break;

            case TouchState.TouchEnd:
                rayLine.gameObject.SetActive(false);
                break;
        }
    }

    private Vector3 GetClampedDirection(Vector3 direction)
    {
        //// ���͸� ����ȭ�մϴ�.
        //direction.Normalize();

        //// ���� ������ �����մϴ�.
        //float maxAngle = 60f;

        //// Vector3.up ���Ϳ��� ������ ���մϴ�.
        //float angle = Vector3.Angle(direction, Vector3.up);

        //// ������ ���� ������ �ʰ��ϸ� ������ �����մϴ�.
        //if (angle > maxAngle)
        //{
        //    // ���� ���� �̳����� ���� ����� ���� ���͸� ����մϴ�.
        //    float clampedAngle = Mathf.Clamp(angle, 0f, maxAngle);
        //    Vector3 clampedDirection = Quaternion.Euler(0f, 0f, Mathf.Sign(direction.x) * clampedAngle) * Vector3.up;

        //    // ������ ���ѵ� �������� �����մϴ�.
        //    direction = clampedDirection;
        //}

        //// Ŭ���ε� ���� ���͸� ��ȯ�մϴ�.
        return direction;
    }

    private void CastRay(Vector3 origin, Vector3 direction, int reflections)
    {
        if (reflections > maxReflections)
            return;

        rayLine.positionCount = reflections + 2;
        rayLine.SetPosition(reflections, origin);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                Vector3 reflection = Vector3.Reflect(direction, hit.normal);
                rayLine.SetPosition(reflections + 1, hit.point);
                CastRay(hit.point, reflection, reflections + 1);
            }
            else
            {
                // ���� �ƴ� ���, ���⿡�� ���ϴ� ó���� �߰��մϴ�.
                // ���� ���, ������ ��ġ�� �����ϰų� �ݻ����� �ʴ´ٸ� �׸��� �� �ֽ��ϴ�.
                Debug.Log("���� �ƴѰ� �¾Ҵ�!");
            }
        }
        else
        {
            rayLine.SetPosition(reflections + 1, origin + direction * rayLength);
        }
    }


    private void OnDrawGizmos()
    {
        // ���̸� �����Ϳ��� ǥ���ϱ� ���� Gizmos.DrawRay�� ����մϴ�.
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ballInitPos.position, rayLine.GetPosition(1) - ballInitPos.position);
    }
}
