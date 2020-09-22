///////////////////////////////////////////////////////////
//  PeriodoDeAceptabilidad.cs
//  Implementation of the Class PeriodoDeAceptabilidad
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:07 PM
//  Original author: Franco
///////////////////////////////////////////////////////////

using System;
using TPANUAL;

public class PeriodoDeAceptabilidad : Condicion {

	private TimeSpan periodo;

	public PeriodoDeAceptabilidad(int dias){
		periodo = new TimeSpan(dias/2, 0, 0, 0);
	}

    public TimeSpan Periodo { get => periodo; set => periodo = value; }

    public override bool cumpleCondicion(OperacionDeEgreso opegreso, OperacionDeIngreso opingreso){
		DateTime inferior = opingreso.Fecha.Subtract(Periodo);
		DateTime superior = opingreso.Fecha.Add(Periodo);

		return opegreso.Fecha < superior && opegreso.Fecha > inferior;
	}
}