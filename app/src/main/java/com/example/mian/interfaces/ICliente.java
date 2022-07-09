package com.example.mian.interfaces;

public interface ICliente {
    void BuscarID(String IDCLIENTE);

    void GenerarID(String IDCLIENTE);

    void ObtenerDatos(String IDCLIENTE,String DNI,String NOMBRE,String APELLIDO,String SEXO);
}
