using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData", order = 0)]
public class SaveData : ScriptableObject
{
    public int highscore;
    
    public void Save(int highscore, string gameObjectName)
    {
        this.highscore = highscore;
        FileHandler.SaveToJSON(this,gameObjectName);
    }

    public void Load(out int highscore, string gameObjectName)
    {
        FileHandler.ReadFromJSONOverwrite(gameObjectName,this);
        highscore = this.highscore;
    }
}