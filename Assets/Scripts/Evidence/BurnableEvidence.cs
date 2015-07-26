using UnityEngine;
using System.Collections;

public class BurnableEvidence : MonoBehaviour, AbstractEvidence
{
	public string evidenceFlag;
	
	public string EvidenceFlag ()
	{
		return evidenceFlag;
	}
}
