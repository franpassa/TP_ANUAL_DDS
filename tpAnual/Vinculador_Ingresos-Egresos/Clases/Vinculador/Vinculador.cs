///////////////////////////////////////////////////////////
//  Vinculador.cs
//  Implementation of the Class Vinculador
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:01 PM
//  Original author: Franco
///////////////////////////////////////////////////////////
using System.Collections.Generic;
using TPANUAL;

public class Vinculador {

	private List<Condicion> condiciones;
	private CriterioVinculador criterio;
    public List<Condicion> Condiciones { get => condiciones; set => condiciones = value; }
    public CriterioVinculador Criterio { get => criterio; set => criterio = value; }

	public Vinculador(List<Condicion> condiciones){
		Condiciones = condiciones;
	}

	public void cambiarCriterio(CriterioVinculador criterio){
		Criterio = criterio;
	}

	public void cambiarCriterio(List<CriterioVinculador> criterios){
		Criterio = new Mix(criterios);
	}

	public bool cumpleCondiciones(OperacionDeEgreso opegreso, OperacionDeIngreso opingreso){
		bool flag = true;
		foreach(Condicion condicion in Condiciones)
        {
			flag = flag && condicion.cumpleCondicion(opegreso, opingreso);
        }
		return flag;
	}

	public void vincular(DB_Context contexto, Organizacion organizacion) {

        Criterio.vincular(contexto, organizacion);
	}
}