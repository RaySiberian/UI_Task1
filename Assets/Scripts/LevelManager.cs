using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] levels;
    [SerializeField] private GameObject stagePanel;
    [SerializeField] private GameObject winPanelObject;
    [SerializeField] private WinPanel winPanel;
    public static LevelManager Instance { get; private set; }
    public int currentLevelId;
    private Level currentLevel;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        currentLevelId = 0;
        currentLevel = levels[currentLevelId];
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowWinPanel(true);
            winPanel.SetActiveStars(1);
            SetStarsActive(1,currentLevelId);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowWinPanel(true);
            winPanel.SetActiveStars(2);
            SetStarsActive(2,currentLevelId);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowWinPanel(true);
            winPanel.SetActiveStars(3);
            SetStarsActive(3,currentLevelId);
        }
    }

    public void ShowWinPanel(bool status)
    {
        winPanelObject.SetActive(status);
    }
    
    public void ShowStagePanel(bool status)
    {
        stagePanel.SetActive(status);
    }
    
    private void SetStarsActive(int count, int levelId)
    {
        levels[levelId].Stars = count;
    }
    
    public void UpdateLevelsData()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            for (int j = 0; j < levels[i].Stars; j++)
            {
                levels[i].StarsGameObject[j].SetActive(false);
            }
        }
    }
}
