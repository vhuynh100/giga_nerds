using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Normal.Realtime;

public class MatchMakingController : MonoBehaviour
{
    [SerializeField] MatchMaking match;
    [SerializeField] Realtime realtime;
    [SerializeField] GameObject matchRoom;
    [SerializeField] GameObject lobbyRoom;
    [SerializeField] PlayerJoin playerJoin;
    [SerializeField] GameObject mainMenu;

    public string language;
    public uint playerID;
    public bool requestedQueue = false;
    public uint LobbyID;
    private bool BothPlayersJoined = false;
    private int playerNum = 0;
    private int JoinLobbyWait = 0;
    private bool waitingJoined = false;

    public void SetRequestedToTrue()
    {
        requestedQueue = true;
    }

    int wait = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerID = (uint)match.GetUserID();
        //print("---------------------------------------- your player id: " + playerID);
    }

    // Update is called once per frame
    void Update()
    {
        if (language != "en" && language != "es")
        {
            print("=== langauge not set");
            match.GetUserLanguage();
            
        } else {
            print("=== langauge set");
        }

        if(playerNum == 1)
        {
            playerJoin.SetPlayer1JoinStatus(true);
        }
        
        if(waitingJoined == true)
        {
            print("==== waiting");
            JoinLobbyWait++;
            print("==== JoinLobbyWait: " + JoinLobbyWait);
            if(JoinLobbyWait == 500)
            {
                JoinLobby();
                JoinLobbyWait = 0;
                waitingJoined = false;
            }
        }

        print("======= player 1 joined: " + playerJoin.GetPlayer1JoinStatus());
        print("======= player 2 joined: " + playerJoin.GetPlayer2JoinStatus());

        if (BothPlayersJoined == false & playerJoin.GetPlayer1JoinStatus() & playerJoin.GetPlayer2JoinStatus())
        {
            print("=== both players joined");
            BothPlayersJoined = true;
        }

        if (BothPlayersJoined == true & (playerJoin.GetPlayer1JoinStatus() == false | playerJoin.GetPlayer2JoinStatus() == false))
        {
            print("=== a player left");
            BothPlayersJoined = false;
            LeaveLobby();
        }



        wait++;

        if (wait > 400 && wait % 150 == 0 && requestedQueue)
        {
            match.CheckMatches();
        }

        if (wait > 400 && wait % 300 == 0 && requestedQueue)
        {
            if (language == "en")
            {
                if (match.CheckIfEnglishPaired(playerID))
                {   
                    int lobby = match.GetEnglishLobbyID(playerID);
                    //print("======================================= placed in match, moving to room: " + match.GetEnglishLobbyID(playerID));

                    if (lobby != -1)
                    {
                        requestedQueue = false;
                        MoveNormcoreRoom(lobby);
                        lobbyRoom.SetActive(false);
                        matchRoom.SetActive(true);
                        waitingJoined = true;
                        print("===== waitingJoined = " + waitingJoined);
                    }
                }
            }

            else if (language == "es")
            {
                if (match.CheckIfSpanishPaired(playerID))
                {
                    
                    int lobby = match.GetSpanishLobbyID(playerID);
                    
                    if (lobby != -1)
                    {
                        //print("======================================= placed in match, moving to room: " + match.GetSpanishLobbyID(playerID));
                        requestedQueue = false;
                        MoveNormcoreRoom(lobby);
                        lobbyRoom.SetActive(false);
                        matchRoom.SetActive(true);
                        waitingJoined = true;
                        print("===== waitingJoined = " + waitingJoined);
                    }
                }
            }
        }
    }


    //getters and setters
    public int GetPlayerID()
    {
        return (int)playerID;
    }

    public void SetPlayerID(int playerID)
    {
        this.playerID = (uint)playerID;
    }

    public string GetPlayerLanguage()
    {
        return language;
    }

    public void LeaveLobby()
    {
        print("=== leaving lobby");
        playerJoin.SetPlayer1JoinStatus(false);
        playerNum = 0;
        int wait = 0;

        MoveNormcoreRoom(0);
        lobbyRoom.SetActive(true);
        matchRoom.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void JoinLobby()
    {
        if(playerJoin.GetPlayer1JoinStatus() == false)
        {
            playerJoin.SetPlayer1JoinStatus(true);
            playerNum = 1;
        } else if (playerJoin.GetPlayer2JoinStatus() == false)
        {
            playerJoin.SetPlayer2JoinStatus(true);
            playerNum = 2;
        }
    }

    private void MoveNormcoreRoom(int lobbyID)
    {

        int wait = 0;
        while (wait != 300)
        {
            wait++;
        }
        if(wait == 300)
        {
            realtime.Disconnect();
            realtime = null;
            realtime = FindObjectOfType<Realtime>();
            string lobbyString = lobbyID.ToString();
            print("=== moving to lobbyID: " + lobbyString);
            realtime.Connect(lobbyString);
        }
    }

    public void SetPlayerLanguageEnglish()
    {
        match.SetUserLanguageEnglish();
        language = "en";
    }

    public void SetPlayerLanguageSpanish()
    {
        match.SetUserLanguageSpanish();
        language = "es";
    }
}
