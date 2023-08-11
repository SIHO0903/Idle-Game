using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class DataManager : MonoBehaviour
{
    [SerializeField] Player playerData = new Player();
    [SerializeField] GameManager gameManagerData = new GameManager();
    [SerializeField] List<Ability> abilitiyDatas = new List<Ability>();

    public static DataManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Save()
    {
        string jplayerdata  = JsonConvert.SerializeObject(playerData);
        string jgamemanagerdata = JsonConvert.SerializeObject(gameManagerData);
        string jabilitydatas = JsonConvert.SerializeObject(abilitiyDatas);

        File.WriteAllText(Application.dataPath + "/playerdata", jplayerdata);
        File.WriteAllText(Application.dataPath + "/gamemanagerdata", jgamemanagerdata);
        File.WriteAllText(Application.dataPath + "/abilitydatas", jabilitydatas);
    }
    public void Load()
    {
        string jplayerdata = File.ReadAllText(Application.dataPath + "/playerdata");
        string jgamemanagerdata = File.ReadAllText(Application.dataPath + "/gamemanagerdata");
        string jabilitydatas = File.ReadAllText(Application.dataPath + "/abilitydatas");

        playerData = JsonConvert.DeserializeObject<Player>(jplayerdata);
        gameManagerData = JsonConvert.DeserializeObject<GameManager>(jgamemanagerdata);
        abilitiyDatas = JsonConvert.DeserializeObject<List<Ability>>(jabilitydatas);
    }
}
