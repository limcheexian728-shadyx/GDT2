using UnityEngine;

public class tutorialControl_script : MonoBehaviour
{
    [SerializeField] camera_control cameraScript;
    [SerializeField] int[] stepPage;
    [SerializeField] GameObject[] stepObject;
    int currentStep = 0;

    public void SetupTutorial()
    {
        foreach (GameObject step in stepObject)
        {
            step.SetActive(false);
        }
        currentStep = 0;
        cameraScript.SwitchScreen(stepPage[currentStep]);
        stepObject[currentStep].SetActive(true);
    }

    public void nextStep()
    {
        stepObject[currentStep].SetActive(false);
        currentStep++;
        if (currentStep < stepPage.Length)
        {
            cameraScript.SwitchScreen(stepPage[currentStep]);
            stepObject[currentStep].SetActive(true);
        }
    }
}
