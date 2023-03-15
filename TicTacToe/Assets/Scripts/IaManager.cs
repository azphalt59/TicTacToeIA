using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaManager : MonoBehaviour
{ 
    public void IaPlay()
    {
        int rand = Random.Range(0, GameManager.Instance.EmptyCases.Count);
        GameManager.Instance.EmptyCases[rand].GetComponent<Case>().IaTake();
    }


    public void MakeAiMove()
    {
        int bestVal = -11;
        int[] bestMove = new int[9];
        Case[] newBoard = new Case[9];
        List<GameObject> movePossibilities = new List<GameObject>();

        for (int i = 0; i < GameManager.Instance.Cases.Count; i++)
        {
            newBoard[i] = GameManager.Instance.Cases[i]; 
        }
        for (int i = 0; i < GameManager.Instance.EmptyCases.Count; i++)
        {
            movePossibilities.Add(GameManager.Instance.EmptyCases[i].gameObject);
        }

        foreach (int[] move in movePossibilities)
        {
            int value = Minimax(,movePossibilities.Count, false);
            if(value > bestVal)
            {
                bestVal = value;
                bestMove = move;
            }
        }


    }

    public int Minimax(int position ,int depth, bool isMaximizingPlayer)
    {
        // Vérifier si le jeu est terminé ou si la profondeur maximale a été atteinte
        if (GameManager.Instance.EmptyCases.Count == 0 || depth == 0)
        {
            return 0; // évaluer le plateau de jeu
        }

        // Déterminer le joueur qui doit jouer
        int player = isMaximizingPlayer ? 1 : -1;
        int bestScore = int.MinValue;

        // Explorer tous les coups possibles et choisir le meilleur score
       

        return bestScore;
    }



}
