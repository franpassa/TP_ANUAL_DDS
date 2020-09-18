///////////////////////////////////////////////////////////
//  Moneda.cs
//  Implementation of the Class Moneda
//  Generated by Enterprise Architect
//  Created on:      04-Sep-2020 11:29:29 PM
//  Original author: Ignacio Andre Keiniger
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using API_MercadoLibre;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_MercadoLibre {
	[Table("moneda")]
	public class Moneda {
		[Key]
		[Column("ID_Moneda")]
		public string ID_Moneda { get; set; }		

		[Column("Descripcion")]
		public string Descripcion { get; set; }

		[Column("Simbolo")]
		public string Simbolo { get; set; }

		public Moneda(String _id)
        {
			// Pido info de la moneda en la API
			WebRequest request_moneda = HttpWebRequest.Create("https://api.mercadolibre.com/currencies/" + _id);
			bool leidoCorrectamente = true;
			try
			{
				request_moneda.GetResponse();
			}
			catch (System.Net.WebException e)
			{
				Console.WriteLine(e);
				Console.WriteLine("\nId de moneda " + _id + " erroneo.");
				leidoCorrectamente = false;
			}
			if (leidoCorrectamente)
			{
				WebResponse response_moneda = request_moneda.GetResponse();
				StreamReader reader_moneda = new StreamReader(response_moneda.GetResponseStream());

				// Guardo el JSON leido en un objeto
				string objetoJSON_moneda = reader_moneda.ReadToEnd();
				ML_Currency ML_CurrencyObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ML_Currency>(objetoJSON_moneda);

				ID_Moneda = ML_CurrencyObject.id;
				Descripcion = ML_CurrencyObject.description;
				Simbolo = ML_CurrencyObject.symbol;
			}
        }

		public Moneda() { }

		public Double cambioDivisa(Pais _otroPais, Double _cantidad){
			WebRequest webRequestCurrency = HttpWebRequest.Create("https://api.mercadolibre.com/currency_conversions/search?from=" + ID_Moneda + "&to=" + _otroPais.Moneda.ID_Moneda);
			WebResponse responseCurrency = webRequestCurrency.GetResponse();
			StreamReader readerCurrency = new StreamReader(responseCurrency.GetResponseStream());

			string currency_JSON = readerCurrency.ReadToEnd();
			double exchange = Newtonsoft.Json.JsonConvert.DeserializeObject<ML_CurrencyConversion>(currency_JSON).inv_rate;

			return (double)exchange * _cantidad;
		}
	}
}