using UnityEngine;

public class tutorialControl_script : MonoBehaviour
{
    [SerializeField] camera_control cameraScript;
    [SerializeField] int[] stepPage;
    [SerializeField] GameObject[] stepObject;
    int currentStep = 0;

    public void SetupTutorial()
    {
        currentStep = 0;
        cameraScript.SwitchScreen(stepPage[currentStep]);
        stepObject[currentStep].SetActive(true);
    }

    public void nextStep()
    {
        stepObject[currentStep].SetActive(false);
        currentStep++;
        cameraScript.SwitchScreen(stepPage[currentStep]);
        stepObject[currentStep].SetActive(true);
    }
}
