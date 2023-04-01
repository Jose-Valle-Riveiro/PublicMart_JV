using System.Drawing;
using System.Globalization;

class Mercado
{
    //PARAMETROS
    string NIT, email, nombre;
    double Subtotal, DineroGenerado, PuntosGenerados;
    int ProductosVendidos, VentasCredito, VentasEfectivo;
    int FacturasGeneradas;

    public void Facturacion()
    {
        DateTime thisDay = DateTime.Today;
        Random rnd = new Random();
        int x = rnd.Next(1, 1001);

        //PEDIR DATOS
        Console.WriteLine("INGRESE EL NIT: ");
        NIT = Console.ReadLine();

        Console.WriteLine("INGRESE EL E-MAIL");
        email = Console.ReadLine();

        Console.WriteLine("INGRESE EL NOMBRE");
        nombre = Console.ReadLine();


        int cantidad, CantidadS;
        double precio, PrecioT = 0, PrecioS;
        int Cantidad001 = 0, Cantidad002 = 0, Cantidad003 = 0, Cantidad004 = 0, Cantidad005 = 0;
        double precio001 = 0, precio002 = 0, precio003 = 0, precio004 = 0, precio005 = 0;

        //METER CODIGOS
        bool MeterCodigos = true;
        int opcion = 0;

        while (MeterCodigos == true)
        {

            
            
            bool opcionValida = false;
            while (opcionValida == false)//VALIDACION DEL CODIGO INGRESADO
            {
                Console.WriteLine("INGRESE EL CODIGO DEL PRODUCTO");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion > 0 && opcion <= 5)
                    {
                        opcionValida = true;

                    }
                    else
                    {
                        Console.WriteLine("ERROR: INGRESE UN NUMERO ENTRE EL 1 AL 5");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO (UN NUMERO)");
                    Console.ReadKey();
                }
                Console.Clear();

            }//WHILE VALIDACION

            //INGRESAR LOS CODIGOS
            switch (opcion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("PAN FRACES: INGRESE LA CANTIDAD DEL PRODUCTO");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        precio = 1.10;


                        Cantidad001 = Cantidad001 + cantidad;
                        PrecioT = cantidad * precio;

                        precio001 = precio001 + PrecioT;
                        PrecioT = 0;
                        cantidad = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO(UN NUMERO)");
                    }
                    break;

                case 2:
                    try
                    {


                        Console.WriteLine("LIBRA DE AZUCAR: INGRESE LA CANTIDAD DEL PRODUCTO");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        precio = 5.00;


                        Cantidad002 = Cantidad002 + cantidad;
                        PrecioT = cantidad * precio;

                        precio002 = precio002 + PrecioT;
                        PrecioT = 0;
                        cantidad = 0;
                    }
                    catch(Exception e) 
                    {
                     Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO(UN NUMERO)");
                    }
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("CAJA DE GALLETAS: INGRESE LA CANTIDAD DEL PRODUCTO");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        precio = 7.30;


                        Cantidad003 = Cantidad003 + cantidad;
                        PrecioT = cantidad * precio;

                        precio003 = precio003 + PrecioT;
                        PrecioT = 0;
                        cantidad = 0;
                    }
                    catch(Exception e)
                    {
                       Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO(UN NUMERO)");
                    }
                    
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("CAJA DE GRANOLA: INGRESE LA CANTIDAD DEL PRODUCTO");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        precio = 32.50;


                        Cantidad004 = Cantidad004 + cantidad;
                        PrecioT = cantidad * precio;

                        precio004 = precio004 + PrecioT;
                        PrecioT = 0;
                        cantidad = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO(UN NUMERO)");
                    }
                    
                    break;

                case 5:
                    try
                    {
                        Console.WriteLine("LITRO DE JUGO DE NARANJA: INGRESE LA CANTIDAD DEL PRODUCTO");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        precio = 17.95;


                        Cantidad005 = Cantidad005 + cantidad;
                        PrecioT = cantidad * precio;

                        precio005 = precio005 + PrecioT;
                        PrecioT = 0;
                        cantidad = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO(UN NUMERO)");
                    }
                    
                    break;

            }//SWITCH

            //PEDIR SI SIGUE INGRESANDO CODIGOS
                  
            Console.WriteLine("¿DESEA SEGUIR AGREGANDO PRODUCTOS? S/N");
            char C = Convert.ToChar(Console.ReadLine());

            if (C == 'S')
            {
                MeterCodigos = true;
                Console.Clear();
            }
            else
            {
                MeterCodigos = false;
                Console.Clear();
            }
        }//WHILE PEDIR CODIGOS

        //CALCULO DE PAGO
        PrecioS = precio001 + precio002 + precio003 + precio004 + precio005;
        double ISR = PrecioS * 0.05, IVA = PrecioS * 0.12;
        CantidadS = Cantidad001 + Cantidad002 + Cantidad003 + Cantidad004 + Cantidad005;

        //ATRIBUTOS PARA REPORTAJE
        DineroGenerado = DineroGenerado + PrecioS;
        ProductosVendidos = ProductosVendidos + CantidadS;

        //TARJETA O EFECTIVO
        Console.WriteLine("¿TARJETA O EFECTIVO? T/E ");
        char T = Convert.ToChar(Console.ReadLine());
        int puntos = 0;
        bool TValido = false;
        while(TValido == false)
        {
            if (T == 'T' || T == 'E')
            {
                if (T == 'T')
                {
                    VentasCredito++;
                    //CALCULO DE PUNTOS
                    if (PrecioS < 50)
                    {
                        puntos = ((int)(PrecioS / 10)) * 1;
                        PuntosGenerados = PuntosGenerados+ puntos;
                    }
                    else if (PrecioS >= 50 && PrecioS < 150)
                    {
                        puntos = ((int)(PrecioS / 10)) * 2;
                        PuntosGenerados = PuntosGenerados + puntos;
                    }
                    else if (PrecioS >= 150)
                    {
                        puntos = ((int)(PrecioS / 15)) * 3;
                        PuntosGenerados = PuntosGenerados + puntos;
                    }

                }
                else if (T == 'E')
                {
                    VentasEfectivo++;
                }
                TValido = true;
            }
            else
            {
                Console.WriteLine("ERROR: INGRESE T O E");
            }


        }

        //NO. FACTURA
        double NoFactura = ((2 * x + Math.Pow(puntos, 2)) + (2021 * CantidadS)) % 1000;
        string eNoFactura = NoFactura.ToString();

        if(eNoFactura.Length < 4)
        {
            eNoFactura = "0" + eNoFactura;
        }
        if (eNoFactura.Length < 3)
        {
            eNoFactura = "00" + eNoFactura;
        }


        //IMPRIMIR FACTURA
        Console.WriteLine("UNA COPIA DE LA FACTURA SE ENVIARA AL CORREO: " + email);
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("                     FACTURA                         ");
        Console.WriteLine("                   PUBLIC MART                     ");
        Console.WriteLine("------------------------------------------------------");

        Console.WriteLine("");
        Console.WriteLine(thisDay.ToString("dd/MM/yyyy"));
        Console.WriteLine("FACTURA NO: " + eNoFactura);
        Console.WriteLine("NIT: " + NIT);
        Console.WriteLine("NOMBRE: " + nombre);
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("LISTA DE PRODUCTOS: ");
        Console.WriteLine("001  PAN FRACES:" + Cantidad001 + "u" + "  Q1.10 c/u   " + "Q" + precio001);
        Console.WriteLine("002  LIBRA DE AZUCAR:" + Cantidad002 + "u" + "  Q5.00 c/u   " + "Q" + precio002);
        Console.WriteLine("003  CAJA DE GALLETAS:" + Cantidad003 + "u" + "  Q7.30 c/u   " + "Q" + precio003);
        Console.WriteLine("004  CAJA DE GRANOLA:" + Cantidad004 + "u" + "  Q32.50 c/u   " + "Q" + precio004);
        Console.WriteLine("005  LITRO DE JUGO DE NARANJA:" + Cantidad005 + "u" + "  Q17.95 c/u   " + "Q" + precio005);
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("SUBTOTAL: Q" + PrecioS);
        Console.WriteLine("ISR: Q" + ISR);
        Console.WriteLine("IVA: Q" + IVA);
        Console.WriteLine("TOTAL: Q" + (PrecioS + ISR + IVA));
        Console.WriteLine("PUNTOS GANADOS: " + puntos);

        FacturasGeneradas++;
    }

    public void Informe()
    {
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("                     REPORTES                         ");
        Console.WriteLine("                   PUBLIC MART                     ");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("FACTURAS GENERADAS: " + FacturasGeneradas + " FACTURAS.");
        Console.WriteLine("PRODUCTOS VENDIDOS: " + ProductosVendidos + " PRODUCTOS.");
        Console.WriteLine("PUNTOS GENERADOS : " + PuntosGenerados + " PUNTOS.");
        Console.WriteLine("");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("----------------VENTAS----------------");
        Console.WriteLine("VENTAS CON CREDITO: " + VentasCredito + " VENTAS");
        Console.WriteLine("VENTAS CON EFECTIVO: " + VentasEfectivo + " VENTAS");
        Console.WriteLine("");
        Console.WriteLine("----------------TOTAL DE VENTAS----------------");
        Console.WriteLine("TOTAL: Q" + DineroGenerado);

        Console.WriteLine("Presione cualquier tecla para continuar");
    }

    public static DateTime Today
    {
        get;
    }
    public void EscribirMenu()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("PUBLIC MART - CAJERO");
        Console.WriteLine("* seleccione una opcion *");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("1) FACTURACION: ");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("2) REPORTES DE FACTURACION: ");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("3) CERRAR PROGRAMA: ");
        Console.WriteLine("--------------------------------");


    }

    static void Main(String[] args)
    {
        

        //LLAMAR METODOS
        Mercado m = new Mercado();
        bool RegresarMenu = true;

        while (RegresarMenu == true)
        {
            int opcion = 0;
            bool OpcionValida = false;
            while (OpcionValida == false)
            {
                //MENU PRINCIPAL
               
                m.EscribirMenu();

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion > 0 && opcion <= 3)
                    {
                        OpcionValida = true;

                    }
                    else
                    {
                        Console.WriteLine("ERROR: INGRESE UN NUMERO ENTRE EL 1 AL 3");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: INGRESE UN VALOR VALIDO (UN NUMERO)");
                    Console.ReadKey();
                }
                Console.Clear();



            }//WHILE MENU

            switch (opcion)
            {
                case 1:
                    bool ContinuarFacturacion = true;
                    while (ContinuarFacturacion == true)
                    {
                        m.Facturacion();
                        Console.WriteLine("¿DESEA AGREGAR MAS FACTURAS? S/N");
                        char opcioncase = Convert.ToChar(Console.ReadLine());
                        if (opcioncase == 'S')
                        {
                            ContinuarFacturacion = true;
                        }
                        else
                        {
                            ContinuarFacturacion = false;
                        }
                        Console.Clear();
                    }

                    break;

                case 2:
                    m.Informe();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    RegresarMenu = false;
                    break;

            }

        }

    }
}//CLASS
