using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    private GameObject Start_Button, Hit_Button, Stand_Button;

    private GameObject Player_Hand, Dealer_Hand;
    private GameObject[] Player_Cards = new GameObject[5], Dealer_Cards = new GameObject[5];

    private int Player_Score, Dealer_Score, Round, Player_Choice, Dealer_Choice;
    private int[] Player_Hits = new int[5], Dealer_Hits = new int[5];

    bool Game_On, taking_input;

    public void Start()
    {
        Start_Button = GameObject.Find("Start"); Start_Button.SetActive(true);
        Hit_Button = GameObject.Find("Hit"); Hit_Button.SetActive(false);
        Stand_Button = GameObject.Find("Stand"); Stand_Button.SetActive(false);

        Game_On = false; taking_input = false;

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
        Player_Choice = 0; Dealer_Choice = 0;

        Game_On = true; taking_input = true;
    }

    async public void Hit()
    {
        if (!taking_input) return;
        taking_input = false;
        await Task.Delay(1000);
        taking_input = true;
    }

    async public void Stand()
    {
        if (!taking_input) return;
        taking_input = false;
        await Task.Delay(1000);
        taking_input = true;
    }

    // Update is called once per frame
    async void Update()
    {
        if (taking_input)
        {
            Hit_Button.SetActive(true); Stand_Button.SetActive(true);
        }
        else
        {
            Hit_Button.SetActive(false); Stand_Button.SetActive(false);
        }
    }
}
