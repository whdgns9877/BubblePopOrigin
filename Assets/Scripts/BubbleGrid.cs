using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� ��ġ�� ���¸� �����ϴ� Ŭ����
// 2D �迭�� ����Ͽ� ���� �׸��带 ǥ���ϰ�, ������ �߰�, �̵�, ���� ���� ����
// �ֺ� ������� ���� ���θ� Ȯ���ϰ�, ������� �׷����� ����� ����
public class BubbleGrid : MonoBehaviour
{
    // Bubble���� �߰��ǰų� �����Ǵ����� �����Ƿ� �迭���ٴ� ListȰ��
    private List<Bubble> bubbleGrid = new List<Bubble>();

    // bubbleGrid�� bubble �߰�(�÷��̾ �߻��� ����)
    private void AddBubble(Bubble bubble)
    {
        bubbleGrid.Add(bubble);
    }

    // bubbleGrid���� bubble ����(������� ������ ����)
    private void RemoveBubble(Bubble bubble)
    {
        bubbleGrid.Remove(bubble);
    }
}
