using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("타이틀")]
    public string korTitleText;
    public string engTitleText;
    public TextMeshProUGUI koreanTitle;    // 너를 배우는 계절
    public TextMeshProUGUI englishTitle;   // Season to Learn you
    
    [Header("배경")]
    public Image backgroundImage;
    public string backgroundResourcePath = "Backgrounds/";  // Resources 폴더 내 경로 -> 끌어다가 넣으면 됨
    
    [Header("캐릭터 일러스트")]
    public Image characterImage;
    public string characterResourcePath = "Characters/";    // Resources 폴더 내 경로 -> 끌어다가 넣으면 됨

    [Header("버튼")]
    private Transform ButtonPanel;
    public Button startButton;
    public Button albumButton;
    public Button exitButton;
    
    private void Start()
    {
        ButtonPanel = GameObject.Find("Canvas").GetComponent<Canvas>().transform.Find("ButtonPanel");
        // 버튼 이벤트 설정
        if (startButton != null) startButton.onClick.AddListener(StartGame);
        if (albumButton != null) albumButton.onClick.AddListener(OpenAlbum);
        if (exitButton != null) exitButton.onClick.AddListener(ExitGame);
        
        // 타이틀 텍스트 설정
        if (koreanTitle != null) koreanTitle.text = korTitleText;
        if (englishTitle != null) englishTitle.text = engTitleText;
        
        // 초기 배경과 캐릭터 설정
        LoadBackground("default_bg");
        LoadCharacter("default_char");
    }

    private void Update()
    {
    }

    // 동적으로 배경 불러오는 함수 -> 필요없을 듯
    public void LoadBackground(string backgroundName)
    {
        if (backgroundImage != null)
        {
            Sprite bgSprite = Resources.Load<Sprite>(backgroundResourcePath + backgroundName);
            if (bgSprite != null)
            {
                backgroundImage.sprite = bgSprite;
            }
        }
    }

    // 동적 캐릭터 불러오기 함수 -> 필요없을 듯
    public void LoadCharacter(string characterName)
    {
        if (characterImage != null)
        {
            Sprite charSprite = Resources.Load<Sprite>(characterResourcePath + characterName);
            if (charSprite != null)
            {
                characterImage.sprite = charSprite;
            }
        }
    }

    public void MenuUiActive(bool ActiveSwitch)
    {
            englishTitle.gameObject.SetActive(ActiveSwitch);
            koreanTitle.gameObject.SetActive(ActiveSwitch);
            ButtonPanel.gameObject.SetActive(ActiveSwitch);
    }

    public void StartGame()
    {
        // 게임 시작 -> 챕터화면 이동
        MenuUiActive(false);
    }
    
    public void OpenAlbum()
    {
        // 앨범 열기
    }
    
    public void ExitGame() // 게임 끄기
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}