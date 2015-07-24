using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerIK : MonoBehaviour {
	public bool ikActive = false;

	Vector3 leftFootPos;
	Vector3 rightFootPos;
	Quaternion leftFootRot;
	Quaternion rightFootRot;

	float leftFootWeight = 1f;
	float rightFootWeight = 1f;

	Transform leftFoot;
	Transform rightFoot;

	protected Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator>();

		leftFoot = animator.GetBoneTransform (HumanBodyBones.LeftFoot);
		rightFoot = animator.GetBoneTransform (HumanBodyBones.RightFoot);

		leftFootRot = leftFoot.rotation;
		rightFootRot = rightFoot.rotation;
	}

	void Update ()
	{
		RaycastHit leftHit;
		RaycastHit rightHit;
		Vector3 leftPos = leftFoot.TransformPoint (Vector3.zero);
		Vector3 rightPos = rightFoot.TransformPoint (Vector3.zero);

		if (Physics.Raycast (leftPos, -Vector3.up, out leftHit, 1)) {
			leftFootPos = leftHit.point;
			leftFootRot = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
		}

		if (Physics.Raycast (rightPos, -Vector3.up, out rightHit, 1)) {
			rightFootPos = rightHit.point;
			rightFootRot = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
		}
	}

	void OnAnimatorIK()
	{
		if(animator) {
			if(ikActive) {
				leftFootWeight = animator.GetFloat ("LeftFootIKWeight");
				rightFootWeight = animator.GetFloat ("RightFootIKWeight");

				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,leftFootWeight);
				animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,rightFootWeight);

				animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,leftFootWeight);  
				animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,rightFootWeight);  

				animator.SetIKPosition(AvatarIKGoal.LeftFoot,leftFootPos);
				animator.SetIKPosition(AvatarIKGoal.RightFoot,rightFootPos);

				animator.SetIKRotation(AvatarIKGoal.LeftFoot,leftFootRot);
				animator.SetIKRotation(AvatarIKGoal.RightFoot,rightFootRot);
			}

			else {
				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,0); 
				//animator.SetLookAtWeight(0);
			}
		}
	}
}
