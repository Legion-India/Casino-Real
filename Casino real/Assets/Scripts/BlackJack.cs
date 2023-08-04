using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class BlackJack : MonoBehaviour
{
    private GameObject Start_Button, Hit_Button, Stand_Button, Result, Continue_Button;

    private GameObject Player_Hand, Dealer_Hand;
    private GameObject[] Player_Cards = new GameObject[5], Dealer_Cards = new GameObject[5];

    private int Player_Score, Dealer_Score, Round, Player_Choice, Dealer_Choice;
    private int[] Player_Hits = new int[5], Dealer_Hits = new int[5];

    bool Game_On, Taking_Input, Player_Won;
    private TMP_Text Result_Text;

    public void Start()
    {
        Start_Button = GameObject.Find("Start"); Start_Button.SetActive(true);
        Hit_Button = GameObject.Find("Hit"); Hit_Button.SetActive(false);
        Stand_Button = GameObject.Find("Stand"); Stand_Button.SetActive(false);
        Result = GameObject.Find("Result"); Result.SetActive(false);
        Continue_Button = GameObject.Find("Continue"); Continue_Button.SetActive(false);
        Result_Text = Result.GetComponent<TMP_Text>();

        Game_On = false; Taking_Input = false;

        Player_Hand = GameObject.Find("Player_Hand");
        Dealer_Hand = GameObject.Find("Dealer_Hand");
        for (int i = 0; i < Player_Cards.Length; i++)
        {
            Player_Cards[i] = GameObject.Find("Player_Hand/Player_Card_" + (char)(49 + i));
            Player_Cards[i].SetActive(true);
        }
        for (int i = 0; i < Dealer_Cards.Length; i++)
        {
            Dealer_Cards[i] = GameObject.Find("Dealer_Hand/Dealer_Card_" + (char)(49 + i));
            Dealer_Cards[i].SetActive(true);
        }
    }

    public void Start_Game()
    {
        Start_Button.SetActive(false);
        Hit_Button.SetActive(true);
        Stand_Button.SetActive(true);

        for (int i = 0; i < Player_Cards.Length; i++) Player_Cards[i].SetActive(false);
        for (int i = 0; i < Dealer_Cards.Length; i++) Dealer_Cards[i].SetActive(false);
        Player_Score = 0; Dealer_Score = 0; 
        Round = 0;
        Player_Choice = 1; Dealer_Choice = 1;

        Game_On = true; Taking_Input = true;
    }

    public void End_Game()
    {
        if (Player_Won) Result_Text.SetText("YOU WIN!!");
        else Result_Text.SetText("YOU LOSE!!");
        Result.SetActive(true); Continue_Button.SetActive(true); Hit_Button.SetActive(false); Stand_Button.SetActive(false);
    }

    async public void Hit()
    {
        if (!Taking_Input) return;
        Taking_Input = false;
        await Task.Delay(1000);
        Taking_Input = true;
        Round++;
        Player_Draws();
        Dealer_Draws();
    }

    async public void Stand()
    {
        if (!Taking_Input) return;
        Player_Choice = 0;
        Taking_Input = false;
        await Task.Delay(1000);
        Taking_Input = true;
    }

    // Update is called once per frame
    async void Update()
    {
        if (Taking_Input)
        {
            Hit_Button.SetActive(true); Stand_Button.SetActive(true);
        }
        else
        {
            Hit_Button.SetActive(false); Stand_Button.SetActive(false);
        }

        if ( (Player_Choice == 0 && Dealer_Choice == 0) || Round == 5) End_Game();

        if (Player_Choice == 0 && Dealer_Choice == 1) if (Round < 5)
            {
                Dealer_Draws();
                Round++;
            }
    }

    public void Player_Draws()
    {
        int rand = new System.Random(new System.DateTime().Millisecond).Next(1,13);
        Player_Hits[Round] = rand;
        //Player_Cards[Round].GetComponent<Image>.sprite = Card_Image[rand - 1];
        Player_Cards[Round].SetActive(true);
    }

    public void Dealer_Draws()
    {

    }
}
