using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    /// <summary>
    /// The timer length, in seconds, for players to receive income gold
    /// </summary>
    readonly int INCOME_TICK_SPACE = 30;

    /// <summary>
    /// The current timer for income ticks, in seconds
    /// </summary>
    float incomeTimer = 0;

    UIController uiCont;

    Barrack[] rax;

    Player[] players;

    [SerializeField]
    Settings setting;
    /// <summary>
    /// current time in game
    /// </summary>
    float time = 0;

    /// <summary>
    /// The current in-game time
    /// </summary>
    public float GameTime
    {
        get
        {
            return time;
        }
    }

	// Use this for initialization
	void Start () {
        uiCont = gameObject.AddComponent<UIController>();
        rax = GameObject.FindObjectsOfType<Barrack>();
        players = GameObject.FindObjectsOfType<Player>();

        foreach(Player p in players)
        {
            p.GiveGold(500);
        }
	}
	
	// Update is called once per frame
	void Update () {

        //increment timer
        time += Time.deltaTime;
        incomeTimer += Time.deltaTime;

        UpdateBarrackCounters(Time.deltaTime);

        if(incomeTimer > INCOME_TICK_SPACE)
        {
            incomeTimer = 0;
            foreach(Player p in players)
            {
                p.GiveIncome();
            }
        }
        //UpdatePlayerGold();
	}

    /// <summary>
    /// Update the timer that tracks barrack spawns
    /// </summary>
    /// <param name="t">the time elapsed </param>
    void UpdateBarrackCounters(float t)
    {
        foreach(Barrack barrack in rax)
        {
            barrack.UpdateCounter(t);
        }
    }
}
