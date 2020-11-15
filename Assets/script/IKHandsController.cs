using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandsController : MonoBehaviour
{
    [SerializeField] Transform leftHandIk;
    [SerializeField] Transform rightHandIk;

    bool isIkActive = false;
    Animator anim;
    TreasureBoxController tb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         tb = TreasureBoxController.FindObjectOfType<TreasureBoxController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tb.isOpen == true)
        {
            isIkActive = true;
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (!isIkActive)
        {
            return;
        }

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIk.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandIk.rotation);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIk.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIk.rotation);
    }
}
