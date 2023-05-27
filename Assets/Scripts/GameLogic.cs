using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// GameLogic클래스에서 사용할 점수와 게임오버 정보를 담는 struct
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

//게임의 규칙과 진행을 관리하는 클래스
//버블이 사라질 때 점수를 계산하고, 게임 오버 조건을 확인
public class GameLogic : MonoBehaviour
{
    private GameData gameData;

    public void AddScore(int scoreToBeAdded) => gameData.score += scoreToBeAdded;

    public void GameOver(bool gameOver) => gameData.gameOver = gameOver;
}
