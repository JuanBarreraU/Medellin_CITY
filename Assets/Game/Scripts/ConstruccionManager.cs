using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConstruccionManager : MonoBehaviour
{
	public GameObject [] casas;
    public GameObject[] edificios;
	public GameObject[] calles;
	public GameObject[] antiContaminantes;
	public GameObject banco;
	public GameObject almacen;
	public GameObject canvasPropiedades;
	public int costoCasaOro;
	public int costoCasaMadera;
	public int costoCasaHierro;
	public int costoCasaPlastico;
	public int costoCasaGemas;
	public int[] costoEdificiosOro;
	public int[] costoEdificiosMadera;
	public int[] costoEdificiosHierro;
	public int[] costoEdificiosPlastico;
	public int[] costoCallesOro;
	public int[] costoCallesMadera;
	public int[] costoCallesHierro;
	public int[] costoCallesPlastico;
	public int[] costoAntiContaminantesOro;
	public int[] costoAntiContaminantesMadera;
	public int[] costoAntiContaminantesHierro;
	public int[] costoAntiContaminantesPlastico;
	public int[] cantidadMaximaCasas;
	public int[] cantidadMaximaEdificios;
	public int[] cantidadMaximaAntiContaminantes;
	public int cantidadCalles;
	public Text[] textCantidadCasas;
	public Text[] textCantidadEdificios;
	public Text[] textCantidadAntiContaminantes;
	public int[] cantidadCasas;
	public int[] cantidadEdificios;
	public int[] cantidadAntiContaminantes;
	private ConstruccionPlacement construccionPlacement;

	//Se inicia accediendo a una instancia d este script.
	void Start ()
	{
		construccionPlacement = GetComponent<ConstruccionPlacement> ();

	}

	//Se llama la funcion ActualizarTextosCantidades para que los textos se mantengan actualizados.
	void Update()
	{
		ActualizarTextosCantidades ();
	}

	//Si se llama esta funcion se debe ingresar un argumento, segun el numero del argumento se construye la casa indicada.
	//Para construir la casa se debe de contar con los materiales necsarios, los cuales son verificados desde el script ControlAlmacen.
	//Si se posee el oro y los materiales necesarios, estos se restan respectivamente del almacen y del banco y se aumenta la contaminacion, la poblacion y la experiencia.
	public void ConstruirCasa (int casa)
	{
		if (canvasPropiedades.GetComponent<ControlRemover> ().remover == false) 
		{
			if (casa == 0) 
			{
				if (banco.GetComponent<ControlBanco> ().totalOro >= costoCasaOro &&
				    almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] >= costoCasaMadera &&
				    almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] >= costoCasaHierro &&
				    almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] >= costoCasaPlastico) 
				{
					if (cantidadCasas [casa] < cantidadMaximaCasas [casa]) 
					{
						construccionPlacement.SetItem (casas [casa]);
						cantidadCasas [casa] += 1;
						banco.GetComponent<ControlBanco> ().totalOro -= costoCasaOro;
						almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] -= costoCasaMadera;
						almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] -= costoCasaHierro;
						almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] -= costoCasaPlastico;
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (1.5f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (5);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (10);

					}
				}
			}
		
			if (casa == 1) 
			{
				if (banco.GetComponent<ControlBanco> ().gemas >= costoCasaGemas) 
				{
					if (cantidadCasas [casa] < cantidadMaximaCasas [casa]) 
					{
						construccionPlacement.SetItem (casas [casa]);
						cantidadCasas [casa] += 1;
						banco.GetComponent<ControlBanco> ().gemas -= costoCasaGemas;
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (1.5f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (10);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (20);
						if (cantidadCasas [casa] == 2) 
						{
							canvasPropiedades.GetComponent<ControlObjetivos> ().Objetivo [1] = true;
						}
					}
				}
			}
        
		}
	}

	//Si se llama esta funcion se debe ingresar un argumento, segun el numero del argumento se construye el edificio indicado.
	//Para el edificio se debe de contar con los materiales necsarios, los cuales son verificados desde el script ControlAlmacen.
	//Si se posee el oro y los materiales necesarios, estos se restan respectivamente del almacen y del banco y se aumenta la contaminacion, la poblacion y la experiencia.
	public void ConstruirEdificio(int edificio)
	{
		if (canvasPropiedades.GetComponent<ControlRemover> ().remover == false) 
		{
			if (banco.GetComponent<ControlBanco> ().totalOro >= costoEdificiosOro [edificio] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] >= costoEdificiosMadera [edificio] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] >= costoEdificiosHierro [edificio] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] >= costoEdificiosPlastico [edificio]) 
			{
				if (cantidadEdificios [edificio] < cantidadMaximaEdificios [edificio]) 
				{
					construccionPlacement.Construir (edificios [edificio]);
					cantidadEdificios [edificio] += 1;
					banco.GetComponent<ControlBanco> ().totalOro -= costoEdificiosOro [edificio];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] -= costoEdificiosMadera [edificio];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] -= costoEdificiosHierro [edificio];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] -= costoEdificiosPlastico [edificio];

					switch (edificio) 
					{
					case 0:
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (3f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (300);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (40);
						break;
					case 1:
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (4f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (200);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (30);
						break;
					case 2:
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (2f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (100);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (50);
						break;
					case 3:
						canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (5f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (50);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (50);
						canvasPropiedades.GetComponent<ControlObjetivos> ().Objetivo [0] = true;
						break;
					}
				}
			}
		}
	}

	//Si se llama esta funcion se debe ingresar un argumento, segun el numero del argumento se construye la calle indicada.
	//Para construir la calle se debe de contar con los materiales necsarios, los cuales son verificados desde el script ControlAlmacen.
	//Si se posee el oro y los materiales necesarios, estos se restan respectivamente del almacen y del banco y se aumenta la contaminacion, la poblacion y la experiencia.
	public void ConstruirCalle(int calle)
	{
		if (canvasPropiedades.GetComponent<ControlRemover> ().remover == false) 
		{
			if (banco.GetComponent<ControlBanco> ().totalOro >= costoCallesOro [calle] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] >= costoCallesMadera [calle] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] >= costoCallesHierro [calle] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] >= costoCallesPlastico [calle]) 
			{
				construccionPlacement.SetItem (calles [calle]);
				banco.GetComponent<ControlBanco> ().totalOro -= costoCallesOro [calle];
				almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] -= costoCallesMadera [calle];
				almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] -= costoCallesHierro [calle];
				almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] -= costoCallesPlastico [calle];
				switch (calle) 
				{
				case 0:
					canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (2f);
					canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (2);
					canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (10);
					break;
				case 6:
					canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (2f);
					canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (2);
					canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (10);
					break;
				default:
					canvasPropiedades.GetComponent<ControlContaminacion> ().AumentarContaminacion (1f);
					canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (1);
					canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (5);
					break;
				}

				cantidadCalles += 1;
				if (cantidadCalles == 10) 
				{
					canvasPropiedades.GetComponent<ControlObjetivos> ().Objetivo [2] = true;
				}
			}
		}
	}

	//Si se llama esta funcion se debe ingresar un argumento, segun el numero del argumento se construye el anticontaminante indicado.
	//Para construir el anticontaminante se debe de contar con los materiales necsarios, los cuales son verificados desde el script ControlAlmacen.
	//Si se posee el oro y los materiales necesarios, estos se restan respectivamente del almacen y del banco y se reduce la contaminacion, y se aumentan, la poblacion y la experiencia.
	public void ConstruirAntiContaminante(int antiContaminante)
	{
		if (canvasPropiedades.GetComponent<ControlRemover> ().remover == false) 
		{
			if (banco.GetComponent<ControlBanco> ().totalOro >= costoAntiContaminantesOro [antiContaminante] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] >= costoAntiContaminantesMadera [antiContaminante] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] >= costoAntiContaminantesHierro [antiContaminante] &&
			    almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] >= costoAntiContaminantesPlastico [antiContaminante]) 
			{
				if (cantidadAntiContaminantes [antiContaminante] < cantidadMaximaAntiContaminantes [antiContaminante]) 
				{
					construccionPlacement.SetItem (antiContaminantes [antiContaminante]);
					cantidadAntiContaminantes [antiContaminante] += 1;
					banco.GetComponent<ControlBanco> ().totalOro -= costoAntiContaminantesOro [antiContaminante];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [0] -= costoAntiContaminantesMadera [antiContaminante];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [1] -= costoAntiContaminantesHierro [antiContaminante];
					almacen.GetComponent<ControlAlmacen> ().cantMateriales [2] -= costoAntiContaminantesPlastico [antiContaminante];

					switch (antiContaminante) 
					{
					case 0:
						canvasPropiedades.GetComponent<ControlContaminacion> ().DisminuirContaminacion (10f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (50);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (50);
						break;
					case 1:
						canvasPropiedades.GetComponent<ControlContaminacion> ().DisminuirContaminacion (20f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (100);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (100);
						break;
					case 2:
						canvasPropiedades.GetComponent<ControlContaminacion> ().DisminuirContaminacion (30f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (150);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (150);
						break;
					case 3:
						canvasPropiedades.GetComponent<ControlContaminacion> ().DisminuirContaminacion (40f);
						canvasPropiedades.GetComponent<ControlPoblacion> ().AumentarCantidadPersonas (200);
						canvasPropiedades.GetComponent<ControlExperiencia> ().AumentarExperiencia (200);
						break;
					}
				}
			}
		}
	}

	//Al llamar esta funcion se actualizan todos los textos pertenecientes a este script.
	public void ActualizarTextosCantidades()
	{
		for (int i = 0; i < textCantidadCasas.Length; i++) 
		{
			textCantidadCasas [i].text = cantidadCasas [i] + "/" + cantidadMaximaCasas [i];
			
		}
		for (int i = 0; i < textCantidadEdificios.Length; i++) 
		{
			textCantidadEdificios [i].text = cantidadEdificios [i] + "/" + cantidadMaximaEdificios [i];

		}
		for (int i = 0; i < textCantidadAntiContaminantes.Length; i++) 
		{
			textCantidadAntiContaminantes [i].text = cantidadAntiContaminantes [i] + "/" + cantidadMaximaAntiContaminantes [i];

		}
	}
				
		
}
