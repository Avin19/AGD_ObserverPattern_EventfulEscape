using System;
using System.Collections.Generic;
using UnityEngine;
using static LightSwitchView;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;
    public static event Action lightToggleAction;

    private void OnEnable() => lightToggleAction += onLightSwitch;

    private void OnDisable() => lightToggleAction -= onLightSwitch;

    private void Start() => currentState = SwitchState.Off;

    public void Interact() => lightToggleAction?.Invoke();

    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void onLightSwitch()
    {
        toggleLights();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
        GameService.Instance.GetInstructionView().HideInstruction();
    }
}



//Good Practices

//1. Alaways append the listerener using +=
//2. Always have  unsub to any delegate/event
//3. Always have null check while invokng any delgate/event using?.InVoke();