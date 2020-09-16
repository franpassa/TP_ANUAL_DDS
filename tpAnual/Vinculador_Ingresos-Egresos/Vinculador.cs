///////////////////////////////////////////////////////////
//  Vinculador.cs
//  Implementation of the Class Vinculador
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:01 PM
//  Original author: Franco
///////////////////////////////////////////////////////////

using System.Collections.Generic;

/// <summary>
/// This class is configured with a ConcreteStrategy object, maintains a reference
/// to a Strategy object and may define an interface that lets Strategy access its
/// data.
/// </summary>
public class Vinculador {

	private List<Condicion> condiciones;
	private CriterioVinculador criterio;

	public Vinculador(){

	}

	public void cambiarCriterio(CriterioVinculador criterio){

	}

	public void cambiarCriterioAMix(List<CriterioVinculador> criterios){

	}

	public bool cumpleCondiciones(){

		return false;
	}

	public void vincular(){

	}

}//end Vinculador