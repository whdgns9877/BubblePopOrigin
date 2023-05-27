using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// GameLogicŬ�������� ����� ������ ���ӿ��� ������ ��� struct
public struct GameData
{
    public int score;
    public bool gameOver;

    public GameData(int score, bool gameOver)
    {
        this.score = score;
        this.gameOver = gameOver;
    }
}

//������ ��Ģ�� ������ �����ϴ� Ŭ����
//������ ����� �� ������ ����ϰ�, ���� ���� ������ Ȯ��
public class GameLogic : MonoBehaviour
{
    private GameData gameData;

    public void AddScore(int scoreToBeAdded) => gameData.score += scoreToBeAdded;

    public void GameOver(bool gameOver) => gameData.gameOver = gameOver;
}
