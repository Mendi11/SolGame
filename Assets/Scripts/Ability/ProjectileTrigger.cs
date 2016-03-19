using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour {

    ProjectileTrigger[] mTig;
    [SerializeField]
    private bool mTriggered = false;

    void Start()
    {
        var triggers = GameObject.FindGameObjectsWithTag("Trigger");// ;.GetComponent<ProjectileTrigger>();
        mTig = new ProjectileTrigger[triggers.Length];
        for(int i = 0; i < triggers.Length; i++)
        {
            mTig[i] = triggers[i].GetComponent<ProjectileTrigger>();
        }
    }

	//Gets triggered when a fireball projectile collides.
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            foreach(ProjectileTrigger trigger in mTig)
            {
                trigger.mTriggered = false;
            }
            mTriggered = true;
        }

    }

}
