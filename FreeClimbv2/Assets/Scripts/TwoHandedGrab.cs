using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedGrab : XRGrabInteractable
{

    public List<XRSimpleInteractable> secondHandGrabPoint = new List<XRSimpleInteractable>();

    void Start()
    {
        foreach (var item in secondHandGrabPoint)
        {
            item.onSelectEnter.AddListener(OnSecondHandGrab);
            item.onSelectExit.AddListener(OnSecondHandRelease);
        }
    }

    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        Debug.Log("2nd grab");
    }
    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        Debug.Log("2nd release");
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {        
        base.OnSelectEnter(interactor);
        Debug.Log("1st grab");

        if (interactor is XRDirectInteractor)
        {
            Climber.climbingHand = interactor.GetComponent<XRController>();
        }
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        Debug.Log("1st Release");

        if (interactor is XRDirectInteractor)
        {
            if (Climber.climbingHand && Climber.climbingHand.name == interactor.name)
            {
                Climber.climbingHand = null;
            }
        }
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isAlreadyGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && isAlreadyGrabbed;
    }
}
