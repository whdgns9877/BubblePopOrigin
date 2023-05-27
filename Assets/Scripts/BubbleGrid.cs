using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버블들의 배치와 상태를 관리하는 클래스
// 2D 배열을 사용하여 버블 그리드를 표현하고, 버블의 추가, 이동, 삭제 등을 관리
// 주변 버블과의 맞춤 여부를 확인하고, 버블들을 그룹으로 만들어 관리
public class BubbleGrid : MonoBehaviour
{
    // Bubble들이 추가되거나 삭제되는일이 많으므로 배열보다는 List활용
    private List<Bubble> bubbleGrid = new List<Bubble>();

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
