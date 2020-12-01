///////////////////////////////////////////////////////////
//  Criterio.cs
//  Implementation of the Class Criterio
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:02 PM
//  Original author: Franco
///////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;
using TPANUAL;


public abstract class CriterioVinculador {

	private Vinculador vinculador;

    public Vinculador Vinculador { get => vinculador; set => vinculador = value; }

	public abstract void vincular(DB_Context contexto, Organizacion organizacion);

	public bool cumpleCondicionesVinculador(OperacionDeEgreso opegreso, OperacionDeIngreso opingreso)
    {
		return Vinculador.cumpleCondiciones(opegreso, opingreso);
    }

	public void asociarEgresoIngreso(DB_Context contexto, OperacionDeEgreso egreso, OperacionDeIngreso ingreso)
	{
		contexto.Database
			.ExecuteSqlCommand(
			"UPDATE OperacionDeEgreso SET IngresoAsociado_ID_OperacionDeIngreso = {0} WHERE (ID_OperacionDeEgreso = {1}) and (IngresoAsociado_ID_OperacionDeIngreso is null)", ingreso.ID_OperacionDeIngreso, egreso.ID_OperacionDeEgreso);
		egreso.IngresoAsociado = ingreso;
	}
}