//버블의 기본 정보를 저장하는 클래스
//버블의 색상, 타입 등을 저장하고, 버블 간의 데이터를 교환할 때 사용
using UnityEngine;

public class BubbleData
{
    public Color bubbleColor;

    public BubbleData(Color bubbleColor)
    {
        this.bubbleColor = bubbleColor;
    }
}
