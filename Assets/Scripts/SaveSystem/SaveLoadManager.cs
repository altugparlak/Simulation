using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    public List<ISavable> iSaveableObjectList;

    protected override void Awake()
    {
        base.Awake();

        iSaveableObjectList = new List<ISavable>();
    }

    public void StoreCurrentSceneData()
    {
        // loop through all ISaveable objects and trigger store scene data for each
        foreach (ISavable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.ISaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSceneData()
    {
        // loop through all ISaveable objects and trigger restore scene data for each
        foreach (ISavable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}
