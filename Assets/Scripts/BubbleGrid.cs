using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버블들의 배치와 상태를 관리하는 클래스
// 2D 배열을 사용하여 버블 그리드를 표현하고, 버블의 추가, 이동, 삭제 등을 관리
// 주변 버블과의 맞춤 여부를 확인하고, 버블들을 그룹으로 만들어 관리
public class BubbleGrid : MonoBehaviour
{
    // Bubble들이 추가되거나 삭제되는일이 많으므로 배열보다는 List활용
    [SerializeField] private List<Bubble> bubbleGrid = new List<Bubble>();
    [SerializeField] private GameObject bubble;  // 셀 프리팹
    [SerializeField] private int gridWidth;  // 그리드의 가로 크기
    [SerializeField] private int gridHeight; // 그리드의 세로 크기
    [SerializeField] private float cellSize; // 셀의 크기

    private void Start()
    {
        GenerateBubble();
    }

    // 벌집 모양으로 버블 생성
    private void GenerateBubble()
    {
        // 그리드의 반너비와 반높이 계산
        float halfWidth = gridWidth * 0.5f;
        float halfHeight = gridHeight * 0.5f;

        for (int row = 0; row < gridHeight; row++)
        {
            int offset = row % 2 == 1 ? 1 : 0; // 홀수 행의 오프셋 조정
            float yRowOffset = row * cellSize * -0.75f; // 행에 따른 y 축 오프셋

            for (int col = 0; col < gridWidth - offset; col++)
            {
                // 셀의 중심 좌표 계산
                float xPos = col * cellSize + (offset * cellSize * 0.5f) - halfWidth * cellSize;
                float yPos = yRowOffset - (halfHeight * cellSize);

                // 셀 생성 및 위치 조정
                GameObject cell = Instantiate(bubble, transform);
                cell.transform.position = new Vector2(xPos, yPos);
                AddBubble(cell.GetComponent<Bubble>());
            }
        }
    }

    // bubbleGrid에 bubble 추가(플레이어가 발사한 버블)
    private void AddBubble(Bubble bubble)
    {
        bubbleGrid.Add(bubble);
    }

    // bubbleGrid에서 bubble 삭제(버블들이 터질때 실행)
    private void RemoveBubble(Bubble bubble)
    {
        bubbleGrid.Remove(bubble);
    }
}
