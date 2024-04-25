using Normal.Realtime;
using Normal.Realtime.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class MatchMaking : RealtimeComponent<MatchMakingModel>
{
    private RealtimeDictionary<SpanishSpeakerModel> _unpairedSpanishSpeakers;
    private RealtimeDictionary<EnglishSpeakerModel> _unpairedEnglishSpeakers;
    private RealtimeDictionary<SpanishSpeakerModel> _pairedSpanishSpeakers;
    private RealtimeDictionary<EnglishSpeakerModel> _pairedEnglishSpeakers;

    [SerializeField] GameObject mainMenu;
    [SerializeField] MatchMakingController matchMakingController;

    public uint playerID;
    public string language;

    public void Awake()
    {
        GenerateUserID();
        print("----------------------------------------- user ID generated: " + playerID);
        
    }
    protected override void OnRealtimeModelReplaced(MatchMakingModel previousModel, MatchMakingModel currentModel)
    {
        base.OnRealtimeModelReplaced(previousModel, currentModel);
    }

    public void GenerateUserID()
    {
        System.Random random = new System.Random();
        int newID = random.Next(1, 1000);

        playerID = (uint)newID;

    }

    public int GetUserID()
    {
        return (int)playerID;
    }

    public string GetUserLanguage()
    {
        return language;
    }

    public void SetUserLanguageEnglish()
    {
        language = "en";
    }

    public void SetUserLanguageSpanish()
    {
        language = "es";
    }

    public bool CheckIfEnglishPaired(uint playerID)
    {
        print("==================================================== checking for pair");
        print("==================================================== player langauge: " + language);
        if (model.unpairedEnglishSpeakers.ContainsKey(playerID))
        {
            print("================== player lobby: " + model.unpairedEnglishSpeakers[playerID].lobbyID);
            if (model.unpairedEnglishSpeakers[playerID].lobbyID != 0)
            {
                print("===================================== english match found, lobbyID: " + model.unpairedEnglishSpeakers[playerID].lobbyID);

                return true;
            }
            return false;
        }
        else
        {
            print("---------------------------------------- player not found while checking for pair");
            return false;
        }

    }

    public bool CheckIfSpanishPaired(uint playerID)
    {
        print("==================================================== checking for pair");
        print("==================================================== player langauge: " + language);

        
            print("================== player lobby: " + model.unpairedSpanishSpeakers[playerID].lobbyID);
            if (model.unpairedSpanishSpeakers[playerID].lobbyID != 0)
            {
                print("===================================== spanish match found");
                return true;
            }
        return false;
        

    }

    public int GetSpanishLobbyID(uint playerID)
    {
        if (model.unpairedSpanishSpeakers.ContainsKey(playerID))
        {
            print("================== player lobby: " + model.unpairedSpanishSpeakers[playerID].lobbyID);
            if (model.unpairedSpanishSpeakers[playerID].lobbyID != 0)
            {
                print("===================================== spanish match found");

                SpanishSpeakerModel duplicate = new SpanishSpeakerModel();
                duplicate.spanishSpeakerID = playerID;
                duplicate.lobbyID = model.unpairedSpanishSpeakers[playerID].lobbyID;

                if (!model.pairedSpanishSpeakers.ContainsKey(playerID)) { 
                    model.pairedSpanishSpeakers.Add(playerID, duplicate);
                }
                if (model.unpairedSpanishSpeakers.ContainsKey(playerID))
                {
                    model.unpairedSpanishSpeakers.Remove(playerID);
                }

                return (int)model.pairedSpanishSpeakers[playerID].lobbyID;
            }
            return -1;
        }
        return -1;
    }

    public int GetEnglishLobbyID(uint playerID)
    {
        print("==================================================== retreiving lobby id - "+ language);
        if (model.unpairedEnglishSpeakers.ContainsKey(playerID))
        {
            print("================== player lobby: " + model.unpairedEnglishSpeakers[playerID].lobbyID);
            if (model.unpairedEnglishSpeakers[playerID].lobbyID != 0)
            {
                print("===================================== english match found");
                EnglishSpeakerModel duplicate = new EnglishSpeakerModel();
                duplicate.englishSpeakerID = playerID;
                duplicate.lobbyID = model.unpairedEnglishSpeakers[playerID].lobbyID;
                if(!model.pairedEnglishSpeakers.ContainsKey (playerID)) { 
                    model.pairedEnglishSpeakers.Add(playerID, duplicate);
                }
                if (model.unpairedEnglishSpeakers.ContainsKey(playerID))
                {
                    model.unpairedEnglishSpeakers.Remove(playerID);
                }

                return (int)model.pairedEnglishSpeakers[playerID].lobbyID;

            }
            return -1;
        }
        return -1;
    }


    public uint CheckIfPaired(string language, uint playerID)
    {
        print("==================================================== checking for pair");
        print("==================================================== player langauge: " + language);
        if (language == "en") {
            if (model.unpairedEnglishSpeakers.ContainsKey(playerID))
            {
                print("================== player lobby: " + model.unpairedEnglishSpeakers[playerID].lobbyID);
                if (model.unpairedEnglishSpeakers[playerID].lobbyID != 0)
                {
                    //print("===================================== english match found");
                    EnglishSpeakerModel duplicate = new EnglishSpeakerModel();
                    duplicate.englishSpeakerID = playerID;
                    duplicate.lobbyID = model.unpairedEnglishSpeakers[playerID].lobbyID;
                    if (!model.pairedEnglishSpeakers.ContainsKey(playerID))
                    {
                        model.pairedEnglishSpeakers.Add(playerID, duplicate);
                    } else if (model.pairedEnglishSpeakers.ContainsKey(playerID))
                    {
                        model.pairedEnglishSpeakers[playerID].lobbyID = duplicate.lobbyID;
                    }
                    model.unpairedEnglishSpeakers.Remove(playerID);
                    return model.pairedEnglishSpeakers[playerID].lobbyID;
                }
            }
            else
            {
                print("---------------------------------------- player not found while checking for pair");
            }
        }
        else if (language == "es")
        {
            if (model.unpairedSpanishSpeakers.ContainsKey(playerID))
            {
                print("================== player lobby: " + model.unpairedSpanishSpeakers[playerID].lobbyID);
                if (model.unpairedSpanishSpeakers[playerID].lobbyID != 0)
                {
                    print("===================================== spanish match found");

                    SpanishSpeakerModel duplicate = new SpanishSpeakerModel();
                    duplicate.spanishSpeakerID = playerID;
                    duplicate.lobbyID = model.unpairedSpanishSpeakers[playerID].lobbyID;

                    if (!model.pairedSpanishSpeakers.ContainsKey(playerID))
                    {
                        model.pairedSpanishSpeakers.Add(playerID, duplicate);
                    }
                    else if (model.pairedSpanishSpeakers.ContainsKey(playerID))
                    {
                        model.pairedSpanishSpeakers[playerID].lobbyID = duplicate.lobbyID;
                    }
                    model.unpairedSpanishSpeakers.Remove(playerID);
                    return model.pairedSpanishSpeakers[playerID].lobbyID;
                }
            }
        }
        
        return 0;
    }


    public void RemoveEnglishPlayer(uint playerID)
    {
        if (model.unpairedEnglishSpeakers.ContainsKey(playerID))
        {
            model.unpairedEnglishSpeakers.Remove(playerID);
        }
        if (model.pairedEnglishSpeakers.ContainsKey(playerID))
        {
            model.unpairedEnglishSpeakers.Remove(playerID);
        }
    }

    public void RemoveSpanishPlayer(uint playerID)
    {
        if (model.unpairedSpanishSpeakers.ContainsKey(playerID))
        {
            model.unpairedSpanishSpeakers.Remove(playerID);
        }
        if (model.pairedSpanishSpeakers.ContainsKey(playerID))
        {
            model.unpairedSpanishSpeakers.Remove(playerID);
        }
    }



    public int GetSpanishSpeakers()
    {
        return model.unpairedSpanishSpeakers.Count;
    }

    public int GetEnglishSpeakers()
    {
        return model.unpairedEnglishSpeakers.Count;
    }

    public void CreateLobby(uint spanishID, uint englishID)
    {
        LobbyModel newLobby = new LobbyModel();
        System.Random random = new System.Random();

        int newLobbyID = random.Next(1, 1000);
        while (model.lobbies.ContainsKey((uint)newLobbyID))
        {
            newLobbyID = random.Next(1, 1000); 
        }

        newLobby.lobbyID = (uint)newLobbyID;
        print("========================================= created lobby: " + newLobbyID);

        //model.lobbies.Add((uint)newLobbyID, newLobby);
        if (model.unpairedSpanishSpeakers[spanishID].lobbyID == 0)
        {
            model.unpairedSpanishSpeakers[spanishID].lobbyID = (uint)newLobbyID;
        }
        if (model.unpairedEnglishSpeakers[englishID].lobbyID == 0)
        {
            model.unpairedEnglishSpeakers[englishID].lobbyID = (uint)newLobbyID;
        }
    }

    public uint GetSpanishSpeakerLobby(uint playerId)
    {
        try
        {
            SpanishSpeakerModel _ = model.pairedSpanishSpeakers[playerId];
            return _.lobbyID;
        }
        catch
        {
            return 0;
        }
    }

    public uint GetEnglishSpeakerLobby(uint playerId)
    {
        try
        {
            EnglishSpeakerModel _ = model.pairedEnglishSpeakers[playerId];
            return _.lobbyID;
        }
        catch
        {
            return 0;
        }
    }



    public void AddNewSpanishSpeaker(int playerId)
    {
        RemoveSpanishPlayer((uint)playerId); // refresh queue
        SpanishSpeakerModel newSpanishSpeakerModel = new SpanishSpeakerModel();
        newSpanishSpeakerModel.spanishSpeakerID = (uint)playerId;
        newSpanishSpeakerModel.lobbyID = 0;
        model.unpairedSpanishSpeakers.Add((uint)playerId, newSpanishSpeakerModel);
        print("================================================= added user: " + playerId);
        mainMenu.SetActive(false);
        matchMakingController.SetRequestedToTrue();
    }

    public void AddNewEnglishSpeaker(int playerId)
    {
        RemoveSpanishPlayer((uint)playerId); // refresh queue
        EnglishSpeakerModel newEnglishSpeakerModel = new EnglishSpeakerModel();
        newEnglishSpeakerModel.englishSpeakerID = (uint)playerId;
        newEnglishSpeakerModel.lobbyID = 0;
        model.unpairedEnglishSpeakers.Add((uint)playerId, newEnglishSpeakerModel);
        print("================================================= added user: " + playerId);
        mainMenu.SetActive(false);
        matchMakingController.SetRequestedToTrue();
    }

    public void AddNewUserToQueue()
    {
        string userLanguage = GetUserLanguage();
        if(userLanguage == "en")
        {
            AddNewEnglishSpeaker((int)playerID);
        }
        else if(userLanguage == "es") 
        {
            AddNewSpanishSpeaker((int)playerID);
        }
        else
        {
            print("----------------------------- invalid language, cannot add player to queue");
        }
    }

    private uint GetFirstSpanishSpeaker()
    {
        uint key = 0;
        bool found = false;

        while(found == false)
        {
            key++;
            if (model.unpairedSpanishSpeakers.ContainsKey(key)){

                if (model.unpairedSpanishSpeakers[key].lobbyID == 0)
                {
                    print("=========================================================================" + model.unpairedSpanishSpeakers[key].spanishSpeakerID);
                    found = true;
                    return model.unpairedSpanishSpeakers[key].spanishSpeakerID;
                }
            }
        }
        return 0;
    }

    private uint GetFirstEnglishSpeaker()
    {
        uint key = 0;

        bool found = false;

        while (found == false)
        {
            key++;
            if (model.unpairedEnglishSpeakers.ContainsKey(key))
            {
                if (model.unpairedEnglishSpeakers[key].lobbyID == 0)
                {
                print("=========================================================================" + model.unpairedEnglishSpeakers[key].englishSpeakerID);
                found = true;
                return model.unpairedEnglishSpeakers[key].englishSpeakerID;
                }
                

            }
        }
        return 0;
    }

    


    public void AddRandomSpanishUser()
    {
        SpanishSpeakerModel newSpanishSpeakerModel = new SpanishSpeakerModel();

        System.Random random = new System.Random();

        int newID = random.Next(1, 1000);
        newSpanishSpeakerModel.spanishSpeakerID = (uint)newID;
        newSpanishSpeakerModel.lobbyID = 0;

        model.unpairedSpanishSpeakers.Add( (uint)newID , newSpanishSpeakerModel);
    }

    public void AddRandomEnglishUser()
    {
        EnglishSpeakerModel newEnglishSpeakerModel = new EnglishSpeakerModel();

        System.Random random = new System.Random();

        int newID = random.Next(1, 1000);
        newEnglishSpeakerModel.englishSpeakerID = (uint) newID;
        newEnglishSpeakerModel.lobbyID = 0;

        model.unpairedEnglishSpeakers.Add( (uint) newID, newEnglishSpeakerModel);
    }

    public void AddPlaceHolders()
    {
        EnglishSpeakerModel newEnglishSpeakerModel = new EnglishSpeakerModel();
        SpanishSpeakerModel newSpanishSpeakerModel = new SpanishSpeakerModel();
        System.Random random = new System.Random();

        uint newID = 0;
        newEnglishSpeakerModel.englishSpeakerID = newID;
        newEnglishSpeakerModel.lobbyID = 0;

        newSpanishSpeakerModel.spanishSpeakerID = newID;
        newSpanishSpeakerModel.lobbyID = 0;

        model.unpairedEnglishSpeakers.Add(newID, newEnglishSpeakerModel);
        model.unpairedSpanishSpeakers.Add(newID, newSpanishSpeakerModel);
    }




    public void CheckMatches()
    {
        
        if (model.unpairedSpanishSpeakers.Count > 0)
        {
            if (model.unpairedEnglishSpeakers.Count > 0) { 
                print("================================================== match found");
                uint spanishID = 0;
                uint englishID = 0;

                uint key = 1;
                int maxKey = 1000;
                bool found = false;

                while (found == false & key < maxKey)
                {
                    key++;
                    if (model.unpairedEnglishSpeakers.ContainsKey(key))
                    {
                        if (model.unpairedEnglishSpeakers[key].lobbyID == 0)
                        {
                            print("=========================================================================" + model.unpairedEnglishSpeakers[key].englishSpeakerID);
                            found = true;
                            englishID = model.unpairedEnglishSpeakers[key].englishSpeakerID;
                        }
                    }
                }

                key = 1;
                found = false;

                while (found == false & key < maxKey)
                {
                    key++;
                    if (model.unpairedSpanishSpeakers.ContainsKey(key))
                    {
                        if (model.unpairedSpanishSpeakers[key].lobbyID == 0)
                        {
                            print("=========================================================================" + model.unpairedSpanishSpeakers[key].spanishSpeakerID);
                            found = true;
                            spanishID = model.unpairedSpanishSpeakers[key].spanishSpeakerID;
                        }
                    }
                }


                if(englishID != 0 & spanishID != 0)
                {

                    CreateLobby(spanishID, englishID);
                    //print(" ============================================ removing: " + spanishID +" and " + englishID);
                    //model.unpairedSpanishSpeakers.Remove(spanishID);
                    //model.unpairedEnglishSpeakers.Remove(englishID);

                    //print(model.unpairedEnglishSpeakers.ContainsKey(englishID));
                    //print("------------------------------- removed english, count = ");
                }

                key = 0;

                print("====================================== players in session: " + model.unpairedSpanishSpeakers.Count);
                print("====================================== players in session: " + model.unpairedEnglishSpeakers.Count);







                



            }
        }
        //return false;
    }








    private void RemovePlayersFromUnpaired(uint spanishSpeakerID) //, uint englishSpeakerID)
    {
        print("--------------------- removing spanish user");
        model.unpairedSpanishSpeakers.Remove(spanishSpeakerID);
        print("===================== removed spanish user");
        try
        {
            
            //model.unpairedEnglishSpeakers.Remove(englishSpeakerID);
            print("------------------------------- removed english, count = " + model.unpairedEnglishSpeakers.Count);
        }
        catch
        {
            print("===================================== error encountered, ignored lol");
        }
    }


    private void PairPlayers(uint spanishSpeakerID, uint englishSpeakerID)
    {
        
        print("=============================== pog");
        print("------------------------------------------------- removing from ");
        //RemovePlayersFromUnpaired(spanishSpeakerID);// , englishSpeakerID);

        System.Random random = new System.Random();


        int newLobbyID = random.Next(1, 100000);
        uint lobbyID = (uint)newLobbyID; // needs to cast to uint for dictionary key

        model.unpairedSpanishSpeakers[spanishSpeakerID].lobbyID = lobbyID;
        model.unpairedEnglishSpeakers[englishSpeakerID].lobbyID = lobbyID;

        print("========================== english speaker lobby ID: " + model.unpairedEnglishSpeakers[englishSpeakerID].lobbyID);
        print("========================== spanish speaker lobby ID: " + model.unpairedSpanishSpeakers[spanishSpeakerID].lobbyID);

        print("match created");
        print("unpaired spanish: " + model.unpairedSpanishSpeakers.Count);
        print("unpaired english: " + model.unpairedEnglishSpeakers.Count);
        
    }

}