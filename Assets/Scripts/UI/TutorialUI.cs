using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAltText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadMoveText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAltText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBinding(GameInput.Binding.Interact);
        keyInteractAltText.text = GameInput.Instance.GetBinding(GameInput.Binding.Interact_Alt);
        keyPauseText.text = GameInput.Instance.GetBinding(GameInput.Binding.Pause);
        keyGamepadInteractText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAltText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Interact_Alt);
        keyGamepadPauseText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
