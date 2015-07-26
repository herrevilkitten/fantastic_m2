using UnityEngine;
using System.Collections;

public class PlantableEvidence : MonoBehaviour, AbstractEvidence
{
	public string evidenceFlag;

	public string EvidenceFlag ()
	{
		return evidenceFlag;
	}
}
