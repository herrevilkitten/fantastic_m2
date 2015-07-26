using UnityEngine;
using System.Collections;

public class WipeableEvidence : WipeEvidence, AbstractEvidence
{
	public string evidenceFlag;
	
	public string EvidenceFlag ()
	{
		return evidenceFlag;
	}
}
