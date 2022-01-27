using UnityEngine;

public class Level : MonoBehaviour
{
    public int Id;
    public int Stars;

    public GameObject[] StarsGameObject;

    public void SetCurrentLevelBtn()
    {
        LevelManager.Instance.currentLevelId = Id;
        LevelManager.Instance.ShowStagePanel(false);
    }
}