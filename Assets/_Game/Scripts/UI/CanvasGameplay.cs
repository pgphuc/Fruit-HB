using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : MonoBehaviour
{
    public static CanvasGameplay instance;
    [SerializeField] private RectTransform buttonsPanel;
    [SerializeField] private RectTransform guidePanel;
    [SerializeField] private GameObject boxChat;

    [SerializeField] private RectTransform winGame;
    [SerializeField] private Image completeWindow;
    [SerializeField] private RectTransform completeText;
    private void Start()
    {
        instance = this;
        OnInit();
        HideBoxChat();
        StartCoroutine(HideGuidePanel());

    }
    public void OnInit()
    {
        completeText.gameObject.SetActive(false);
        Color color = completeWindow.color;
        color.a = 0;
        completeWindow.color = color;
        winGame.gameObject.SetActive(false);
        
        boxChat.SetActive(true);
        guidePanel.anchoredPosition = new Vector2(-160f, 800f);
        buttonsPanel.anchoredPosition = new Vector2(0f, 100f);
    }

    #region Start game

    private void HideBoxChat()
    {
        boxChat.transform.DOScale(Vector3.zero, 2f)
            .SetEase(Ease.InBack)
            .OnComplete(() => boxChat.SetActive(false));
    }
    private IEnumerator HideGuidePanel()
    {
        yield return new WaitForSeconds(2f);
        guidePanel.DOAnchorPos(new Vector2(160f, 800f), 1f);
        ShowButtons();
    }
    private void ShowButtons()
    {
        buttonsPanel.DOAnchorPos(new Vector2(0f, -100f), 1f);
    }

    public void Back()
    {
        Debug.Log("Back");
    }

    public void Replay()
    {
        Debug.Log("Replay");
    }

    #endregion
    
    #region Win game


    public void EndGame()
    {
        Debug.Log("EndGame");
        StartCoroutine(CompleteSequence());
    }
    private IEnumerator CompleteSequence()
    {
        winGame.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        completeWindow.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);
        completeText.gameObject.SetActive(true);
        completeText.localScale = new Vector3(10f, 10f, 10f);
        completeText.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
    
    #endregion

}
