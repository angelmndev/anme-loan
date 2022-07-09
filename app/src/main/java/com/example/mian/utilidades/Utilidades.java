package com.example.mian.utilidades;

import android.app.usage.UsageStats;

public class Utilidades {

    public static final String REF_PRESTAMO_HISTORIAL = "PrestamoHistorial";
    public static final String REF_PRESTAMO = "Prestamo";
    public static final String REF_PRESTAMO_GROUPING = "PrestamoGrouping";
    public static final String REF_CLIENTE = "Cliente";
    public static final String PREF_PRESTAMO_HISTORIAL = "PH";
    public static final String PREF_CLIENTE = "C";
    public static final String PREF_PRESTAMO_GROUPING = "PG";
    public static final String PREF_PRESTAMO = "P";

    public static final String DBNAME = "dbmian";

    //Constantes campos tabla cliente
    public static final String TABLA_CLIENTE = "cliente";
    public static final String ID_CLIENTE = "idCliente";
    public static final String CLIE_CODIGO = "clieCodigo";
    public static final String CLIE_NOMBRE = "clieNombre";
    public static final String CLIE_APELLIDO = "clieApellido";
    public static final String CLIE_FOTO = "clieFoto";
    public static final String CLIE_DNI = "clieDni";
    public static final String CLIE_TELEFONO = "clieTelefono";
    public static final String CLIE_DIRECCION = "clieDireccion";
    public static final String CLIE_SEXO = "clieSexo";
    public static final String CLIE_ESTADO = "clieEstado";



    //crear tabla usuario
    public static final String TABLA_USUARIO = "usuario";
    public static final String ID_USUARIO = "idUsuario";
    public static final String USU_CODIGO = "usuCodigo";
    public static final String USU_FOTO = "usuFoto";
    public static final String USU_NOMBRE = "usuNombre";
    public static final String USU_APELLIDO = "usuApellido";
    public static final String USU_USUARIO = "usuUsuario";
    public static final String USU_PASSWORD = "usuPassword";
    public static final String USU_DNI = "usuDni";
    public static final String USU_TELEFONO = "usuTelefono";
    public static final String USU_DIRECCION = "usuDireccion";
    public static final String USU_PRIVILEGIO = "usuPrivilegio";
    public static final String USU_ESTADO = "usuEstado";


    //create tabla caja
    public static final String TABLA_CAJA = "caja";
    public static final String ID_CAJA = "idCaja";
    public static final String CAJA_NOMBRE = "cajaNombre";
    public static final String CAJA_ESTADO = "cajaEstado";

    //QUERY
    public static final String CREAR_TABLA_CAJA = "CREATE TABLE "+ TABLA_CAJA +"("+ID_CAJA+" INTEGER PRIMARY KEY AUTOINCREMENT,"+CAJA_NOMBRE+" VARCHAR(45),"+CAJA_ESTADO+" CHAR(1))";

    //crear tabla caja movimiento
    public static final String TABLA_CAJA_MOVIMIENTO = "cajaMovimiento";
    public static final String ID_CAJAMOVIMIENTO = "idCajaMovimiento";
    public static final String CAJA_MOV_ID_PRESTAMO_FK = "idPrestamoFK";
    public static final String CAJA_MOV_ID_PAGO_FK = "idPagoFK";
    public static final String CAJA_MOV_CANTIDAD = "cajaMovCantidad";
    public static final String CAJA_MOV_FECHA = "cajaMovFecha";
    public static final String CAJA_MOV_ID_CAJA_FK = "idCajaFK";

    //QUERY
    public static final String CREAR_TABLA_CAJA_MOVIMIENTO = "CREATE TABLE "+TABLA_CAJA_MOVIMIENTO+"("+ID_CAJAMOVIMIENTO+" INTEGER PRIMARY KEY AUTOINCREMENT,"+CAJA_MOV_ID_PRESTAMO_FK+" INTEGER,"+
            CAJA_MOV_ID_PAGO_FK+" INTEGER,"+CAJA_MOV_CANTIDAD+" DECIMAL,"+CAJA_MOV_FECHA+" DATETIME,"+CAJA_MOV_ID_CAJA_FK+"INTEGER)";

    //creat tabla caja entrada salida
    public static final String TABLA_CAJA_ENTRADA_SALIDA = "cajaEntradaSalida";
    public static final String ID_CAJA_ENTRADA_SALIDA = "idCajaEntradaSalida";
    public static final String CAJA_ES_INGRESO = "cajaESIngreso";
    public static final String CAJA_ES_EGRESO = "cajESEgreso";
    public static final String CAJA_ES_SALDO = "cajaESSaldo";
    public static final String CAJA_ES_TOTAL = "cajaESTotal";
    public static final String CAJA_ES_ID_CAJA_MOVIMIENTO_FK = "idCajaMovimientoFK";

    //QUERY
    public static final String CREAR_TABLA_CAJA_ENTRADA_SALIDA = "CREATE TABLE "+TABLA_CAJA_ENTRADA_SALIDA+"("+ID_CAJA_ENTRADA_SALIDA+" INTEGER PRIMARY KEY AUTOINCREMENT,"+CAJA_ES_INGRESO+" DECIMAL,"+
            CAJA_ES_EGRESO+" DECIMAL,"+CAJA_ES_SALDO+" DECIMAL,"+CAJA_ES_TOTAL+" DECIMAL,"+CAJA_ES_ID_CAJA_MOVIMIENTO_FK+" INTEGER)";

    //crear tabla prestamo historial
    public static final String TABLA_PRESTAMO_HISTORIAL = "prestamoHistorial";
    public static final String ID_PRESTAMO_HISTORIAL = "idPrestamoHistorial";
    public static final String PH_ID_CLIENTE = "idCliente";
    public static final String PH_ID_USUARIO = "idUsuarioFK";
    public static final String PH_IMPORTE_CREDITO = "phImporteCredito";
    public static final String PH_MODALIDAD_PAGO = "phModalidadPago";
    public static final String PH_TIPO_PAGO = "phTipoPago";
    public static final String PH_NUMERO_CUOTA = "phNumeroCuota";
    public static final String PH_TASA_INTERES = "phTasaInteres";
    public static final String PH_IMPORTE_CUOTA = "phImporteCuota";
    public static final String PH_TOTAL_PAGAR = "phTotalPagar";
    public static final String PH_FECHA = "phFecha";
    public static final String PH_COMENTARIO = "phComentario";



    //crear tabla prestamo
    public static final String ID_PRESTAMO = "idPrestamo";
    public static final String PRE_CLIE_DNI = "preClieDni";
    public static final String PRE_ID_PRESTAMO_HISTORIAL = "idPrestamoHistorial";
    public static final String PRE_TIPO_PRESTAMO = "preTipoPrestamo";
    public static final String PRE_IMPORTE_CREDITO = "preImporteCredito";
    public static final String PRE_ESTADO = "preEstado";
    public static final String PRE_ESTADO_CANTIDAD = "preEstadoCantidad";
    public static final String PRE_FECHA = "preFecha";




    public static final String ID_PRESTAMO_GROUPING = "idPrestamoGrouping";
    public static final String PG_ID_CLIENTE = "idCliente";
    public static final String PG_CLIE_DNI = "pgClieDni";
    public static final String PG_CLIE_NOMBRE = "pgClieNombre";
    public static final String PG_CLIE_APELLIDO = "pgClieApellido";
    public static final String PG_CLIE_SEXO = "pgClieSexo";
    public static final String PG_IMPORTE_CREDITO = "pgImporteCredito";
    public static final String PG_FECHA = "pgFecha";
    public static final String PG_ESTADO = "pgEstado";

}
