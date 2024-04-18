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

    public string language;
    public uint playerID;
    public bool requestedQueue = false;
    public uint LobbyID;

    public void SetRequestedToTrue()
    {
        requestedQueue = true;
    }


    int wait = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerID = (uint)match.GetUserID();
        print("---------------------------------------- your player id: " + playerID);
    }

    // Update is called once per frame
    void Update()
    {
        if (language != "en" && language != "es")
        {
            print("=== langauge not set");
            match.GetUserLanguage();
            
        } else
        {
            print("=== langauge set");
        }

        wait++;

        if (wait > 400 && wait % 150 == 0 && requestedQueue)
        {
            match.CheckMatches();
        }

        if (wait > 400 && wait % 400 == 0 && requestedQueue)
        {
            if (language == "en")
            {
                if (match.CheckIfEnglishPaired(playerID))
                {   
                    int lobby = match.GetEnglishLobbyID(playerID);
                    print("======================================= placed in match, moving to room: " + match.GetEnglishLobbyID(playerID));

                    if (lobby != -1)
                    {

                        requestedQueue = false;
                        MoveNormcoreRoom(lobby);
                        lobbyRoom.SetActive(false);
                        matchRoom.SetActive(true);
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
                        print("======================================= placed in match, moving to room: " + match.GetSpanishLobbyID(playerID));
                        requestedQueue = false;
                        MoveNormcoreRoom(lobby);
                        lobbyRoom.SetActive(false);
                        matchRoom.SetActive(true);
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

    private void MoveNormcoreRoom(int lobbyID)
    {

        int wait = 0;
        while (wait != 100)
        {
            wait++;
        }
        
        realtime.Disconnect();
        realtime = null;
        realtime = FindObjectOfType<Realtime>();
        string lobbyString = lobbyID.ToString();
        print("=== moving to lobbyID: " + lobbyString);
        realtime.Connect(lobbyString);
        
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
