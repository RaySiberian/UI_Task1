using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] emptyStars;
    
    public void ClosePanels()
    {
        LevelManager.Instance.ShowStagePanel(true);
        for (int i = 0; i < emptyStars.Length; i++)
        {
            emptyStars[i].SetActive(true);
        }
        LevelManager.Instance.ShowWinPanel(false);
        LevelManager.Instance.UpdateLevelsData();
    }

    public void SetActiveStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            emptyStars[i].SetActive(false);
        }
    }
}