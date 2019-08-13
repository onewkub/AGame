using System.Collections;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public GameObject MadnessNurse;
    private SoundFXController sfxController;

    private void Awake()
    {
        sfxController = MadnessNurse.GetComponent<SoundFXController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            sfxController.AttackToElevator();
            StartCoroutine(waitSound());
            Debug.Log("Pass");
        }

    }

    IEnumerator waitSound()
    {
        yield return new WaitWhile(() => sfxController.AttackSoundIsPlaying());
        Debug.Log("Yeah");
        SceneLoadManager.Instance.SwitchSceneinLoading();
    }
}
