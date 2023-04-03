using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaManager : MonoBehaviour
{ 

    public void IaPlay()
    {
        // Random IA Play
        //RandomIaPlay();
        // Unbeatable IA
        FindBestMove();
    }
     public void RandomIaPlay()
     {
        int rand = Random.Range(0, GameManager.Instance.EmptyCases.Count);
        GameManager.Instance.EmptyCases[rand].GetComponent<Case>().IaTake();
        GameManager.Instance.turnState = GameManager.TurnState.PlayerTurn;
     }

    public void IATakeCase(int index)
    {
        GameManager.Instance.Cases[index].GetComponent<Case>().IaTake();
    }
    private void FindBestMove()
    {
        int bestMove =-1;
        int bestScore = int.MinValue;

        for (int i = 0; i < 9; i++)
        {
            if(GameManager.Instance.Cases[i].Type == Case.CaseType.Free)
            {
                GameManager.Instance.SimulateTurn(i, Case.CaseType.IA);
                int score = Minimax(Case.CaseType.IA);
                GameManager.Instance.CancelTurn(i);
                if(score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }
        Debug.Log("Le meilleur score est de " + bestScore);
        Debug.Log("La meilleure case à prendre est la case n° " + bestMove);
        IATakeCase(bestMove);
    }
   
    private int Minimax(Case.CaseType type)
    {
        if(GameManager.Instance.CheckWin(Case.CaseType.Player))
        {
            return -1;
        }
        else if (GameManager.Instance.CheckWin(Case.CaseType.IA))
        {
            return 1;
        }
        else if(GameManager.Instance.CheckDraw())
        {
            return 0;
        }

        int bestScore = type == Case.CaseType.IA ? int.MinValue : int.MaxValue;
        for (int i = 0; i < 9; i++)
        {
            if(GameManager.Instance.Cases[i].Type == Case.CaseType.Free)
            {
                GameManager.Instance.SimulateTurn(i, type);
                int score = Minimax(type == Case.CaseType.IA ? Case.CaseType.Player : Case.CaseType.IA);
                GameManager.Instance.CancelTurn(i);
                if(type == Case.CaseType.IA)
                {
                    bestScore = Mathf.Max(bestScore, score);
                }
                else
                {
                    bestScore = Mathf.Min(bestScore, score);
                }
            }
        }
        return bestScore;
    }



}
