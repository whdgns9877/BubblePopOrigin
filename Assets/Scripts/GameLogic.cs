
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
        //// 벡터를 정규화합니다.
        //direction.Normalize();

        //// 제한 각도를 설정합니다.
        //float maxAngle = 60f;

        //// Vector3.up 벡터와의 각도를 구합니다.
        //float angle = Vector3.Angle(direction, Vector3.up);

        //// 각도가 제한 각도를 초과하면 방향을 조정합니다.
        //if (angle > maxAngle)
        //{
        //    // 제한 각도 이내에서 가장 가까운 방향 벡터를 계산합니다.
        //    float clampedAngle = Mathf.Clamp(angle, 0f, maxAngle);
        //    Vector3 clampedDirection = Quaternion.Euler(0f, 0f, Mathf.Sign(direction.x) * clampedAngle) * Vector3.up;

        //    // 방향을 제한된 방향으로 설정합니다.
        //    direction = clampedDirection;
        //}

        //// 클램핑된 방향 벡터를 반환합니다.
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
                // 벽이 아닌 경우, 여기에서 원하는 처리를 추가합니다.
                // 예를 들어, 마지막 위치를 세팅하거나 반사하지 않는다면 그만둘 수 있습니다.
                Debug.Log("벽이 아닌게 맞았다!");
            }
        }
        else
        {
            rayLine.SetPosition(reflections + 1, origin + direction * rayLength);
        }
    }


    private void OnDrawGizmos()
    {
        // 레이를 에디터에서 표시하기 위해 Gizmos.DrawRay를 사용합니다.
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ballInitPos.position, rayLine.GetPosition(1) - ballInitPos.position);
    }
}
