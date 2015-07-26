using UnityEngine;
using System.Collections;

public class TossableEvidence : MonoBehaviour, AbstractEvidence
{
	public string evidenceFlag;
	
	public string EvidenceFlag ()
	{
		return evidenceFlag;
	}
}
