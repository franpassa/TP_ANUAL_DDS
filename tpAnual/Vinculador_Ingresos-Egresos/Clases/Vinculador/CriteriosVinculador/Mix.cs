///////////////////////////////////////////////////////////
//  Mix.cs
//  Implementation of the Class Mix
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:05 PM
//  Original author: Franco
///////////////////////////////////////////////////////////
using System.Collections.Generic;
using TPANUAL;

public class Mix : CriterioVinculador {

	private List<CriterioVinculador> Criterios = new List<CriterioVinculador>();

	public Mix(List<CriterioVinculador> criterios){
		Criterios = criterios;
	}

	public override void vincular(DB_Context _contexto, Organizacion _org)
	{
		foreach (CriterioVinculador c in Criterios) { c.vincular(_contexto, _org); }
	}

}