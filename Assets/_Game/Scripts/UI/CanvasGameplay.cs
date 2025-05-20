using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CanvasGameplay : MonoBehaviour
{
    [SerializeField] private RectTransform buttonsPanel;
    [SerializeField] private RectTransform guidePanel;
    [SerializeField] private GameObject boxChat;
    private void Start()
    {
        OnInit();
        HideBoxChat();
        StartCoroutine(HideGuidePanel());
    }
    public void OnInit()
    {
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

    private void FireWork()
    {
        
    }

    private void ShowBanner()
    {
        
    }

    private void ShowText()
    {
        
    }
    
    #endregion

}
