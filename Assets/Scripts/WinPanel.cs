using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] emptyStars;
    [SerializeField] private CanvasGroup canvasGroup;
    private float temp;

   public bool spawning;
   public bool fading;

   private void Update()
    {
        if (spawning)
        {
            transform.localScale = new Vector3(temp, temp, temp);
            
            temp += 0.005f;
            if (temp > 0.99)
            {
                spawning = false;
            }
        }
        if (fading)
        {
            canvasGroup.alpha = temp;
            temp -= 0.005f;
            if (temp < 0.01)
            {
                fading = false;
                Close();
            }
        }
    }

    public void ClosePanels()
    {
        fading = true;
    }

    private void Close()
    {
        for (int i = 0; i < emptyStars.Length; i++)
        {
            emptyStars[i].SetActive(true);
        }

        transform.localScale = new Vector3(0, 0, 0);
        canvasGroup.alpha = 1;
        
        LevelManager.Instance.ShowStagePanel(true);
        LevelManager.Instance.ShowWinPanel(false);
        LevelManager.Instance.UpdateLevelsData();
    }
    
    public void SetActiveStars(int count)
    {
        spawning = true;
        for (int i = 0; i < count; i++)
        {
            emptyStars[i].SetActive(false);
        }
    }
}