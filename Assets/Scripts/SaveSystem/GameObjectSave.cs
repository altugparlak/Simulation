using System.Collections.Generic;

[System.Serializable]
public class GameObjectSave
{
    // string key = scene name
    public Dictionary<string, SceneSave> sceneData; // dictionary for each scene

    public GameObjectSave()
    {
        sceneData = new Dictionary<string, SceneSave>();
    }

    public GameObjectSave(Dictionary<string, SceneSave> sceneData)
    {
        this.sceneData = sceneData;
    }
}
