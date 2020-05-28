using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SketchController : MonoBehaviour
{
    public XRController applauseAndLaughterXRController;
    public InputHelpers.Button applauseActivationButton;
    public InputHelpers.Button laughterActivationButton;


    public XRController weatherXRController;
    public InputHelpers.Button weatherActivationButton;


    public AudioClip[] applauseSounds;
    public AudioClip[] laughterSounds;
    public Material[] skyBoxMaterials;

    public float activationThreshold = 0.1f;
    public AudioSource audio;
    private int applauseIndex = 0;
    private int laughterIndex = 0;
    private int weatherIndex = 0;
    private bool applauseButtonLastState = false;
    private bool laughterButtonLastState = false;
    private bool weatherButtonLastState = false;
    private bool newActivationState;


    public InputHelpers.Button confettiActivationButton;
    private bool confettiButtonLastState = false;
    private bool confettiActive = false;
    private int confettiIndex = 0;
    private ParticleSystem currentConfettiParticleSystem;
    public ParticleSystem[] confettiParticleSystems;

    public InputHelpers.Button avatarHeadActivationButton;

    public GameObject[] avatarHeads;
    private int avatarHeadIndex = 0;
    private bool avatarHeadActivationButtonLastState = false;

    // Start is called before the first frame update
    void Start()
    {
/*        audio = GetComponent<AudioSource>();
        currentConfettiParticleSystem = confettiParticleSystems[0];*/
        for (int i = 0; i < avatarHeads.Length; i++)
        {
            avatarHeads[i].SetActive(false);
        }
        avatarHeads[avatarHeadIndex].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
/*        
        // APPLAUSE
        newActivationState = CheckIfActivated(applauseAndLaughterXRController, applauseActivationButton);
        if (newActivationState && (newActivationState != applauseButtonLastState))
        {

            //Debug.Log("applauseIndex = " + applauseIndex);
            audio.clip = applauseSounds[applauseIndex];
            audio.Play();
            applauseIndex++;
            if (applauseIndex == applauseSounds.Length) applauseIndex = 0;
        }
        applauseButtonLastState = newActivationState;

        
        // LAUGHTER
        newActivationState = CheckIfActivated(applauseAndLaughterXRController, laughterActivationButton);
        if (newActivationState && (newActivationState != laughterButtonLastState))
        {

            //Debug.Log("laughterIndex = " + laughterIndex);
            audio.clip = laughterSounds[laughterIndex];
            audio.Play();
            laughterIndex++;
            if (laughterIndex == laughterSounds.Length) laughterIndex = 0;
        }
        laughterButtonLastState = newActivationState;

        
        // WEATHER
        newActivationState = CheckIfActivated(weatherXRController, weatherActivationButton);
        if (newActivationState && (newActivationState != weatherButtonLastState))
        {
            //Debug.Log("skyBoxMaterials.Length = " + skyBoxMaterials.Length + ", weatherIndex = " + weatherIndex);
            RenderSettings.skybox = skyBoxMaterials[weatherIndex];
            weatherIndex++;
            if (weatherIndex == skyBoxMaterials.Length) weatherIndex = 0;

        }
        weatherButtonLastState = newActivationState;


        // CONFETTI
        newActivationState = CheckIfActivated(weatherXRController, confettiActivationButton);
        if (newActivationState && (newActivationState != confettiButtonLastState))
        {
            //Debug.Log("confettiIndex = " + confettiIndex);
            currentConfettiParticleSystem.Stop();
            confettiIndex++;
            if (confettiIndex == confettiParticleSystems.Length) confettiIndex = 0;
            currentConfettiParticleSystem = confettiParticleSystems[confettiIndex];
            currentConfettiParticleSystem.Play();
        }
        confettiButtonLastState = newActivationState;
*/


        // AVATAR HEAD MODEL
        newActivationState = CheckIfActivated(applauseAndLaughterXRController, avatarHeadActivationButton);
        if (newActivationState && (newActivationState != avatarHeadActivationButtonLastState))
        {
            avatarHeads[avatarHeadIndex].SetActive(false);

            avatarHeadIndex++;
            if (avatarHeadIndex == avatarHeads.Length) avatarHeadIndex = 0;
            avatarHeads[avatarHeadIndex].SetActive(true);
        }
        avatarHeadActivationButtonLastState = newActivationState;

    }

    public bool CheckIfActivated(XRController controller, InputHelpers.Button activationButton)
    {
        InputHelpers.IsPressed(controller.inputDevice, activationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

}
