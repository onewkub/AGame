using UnityEngine;

public class NurseTrigger : MonoBehaviour
{
    public GameObject NormalNurse;
    public GameObject MadnessNures;
    public GameObject Player;
    public GameObject Runtrigger;
    public GameObject SounfFXTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ghost")
        {
            Debug.Log("Im ready to hunt them");
            NormalNurse.SetActive(false);
            MadnessNures.SetActive(true);
            SceneEventSecondFloor.Instance.closeAllLight();
            MadnessNures.GetComponent<NurseMadnessSecondFloor>().SetTargetPostion(Player.transform);
            Runtrigger.SetActive(true);
            SounfFXTrigger.SetActive(true);
			SoundController.Instance.BGMusic.Stop();
        }
    }
}
