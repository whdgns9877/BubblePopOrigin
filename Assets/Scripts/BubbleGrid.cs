using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� ��ġ�� ���¸� �����ϴ� Ŭ����
// 2D �迭�� ����Ͽ� ���� �׸��带 ǥ���ϰ�, ������ �߰�, �̵�, ���� ���� ����
// �ֺ� ������� ���� ���θ� Ȯ���ϰ�, ������� �׷����� ����� ����
public class BubbleGrid : MonoBehaviour
{
    // Bubble���� �߰��ǰų� �����Ǵ����� �����Ƿ� �迭���ٴ� ListȰ��
    [SerializeField] private List<Bubble> bubbleGrid = new List<Bubble>();
    [SerializeField] private GameObject bubble;  // �� ������
    [SerializeField] private int gridWidth;  // �׸����� ���� ũ��
    [SerializeField] private int gridHeight; // �׸����� ���� ũ��
    [SerializeField] private float cellSize; // ���� ũ��

    private void Start()
    {
        GenerateBubble();
    }

    // ���� ������� ���� ����
    private void GenerateBubble()
    {
        // �׸����� �ݳʺ�� �ݳ��� ���
        float halfWidth = gridWidth * 0.5f;
        float halfHeight = gridHeight * 0.5f;

        for (int row = 0; row < gridHeight; row++)
        {
            int offset = row % 2 == 1 ? 1 : 0; // Ȧ�� ���� ������ ����
            float yRowOffset = row * cellSize * -0.75f; // �࿡ ���� y �� ������

            for (int col = 0; col < gridWidth - offset; col++)
            {
                // ���� �߽� ��ǥ ���
                float xPos = col * cellSize + (offset * cellSize * 0.5f) - halfWidth * cellSize;
                float yPos = yRowOffset - (halfHeight * cellSize);

                // �� ���� �� ��ġ ����
                GameObject cell = Instantiate(bubble, transform);
                cell.transform.position = new Vector2(xPos, yPos);
                AddBubble(cell.GetComponent<Bubble>());
            }
        }
    }

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
