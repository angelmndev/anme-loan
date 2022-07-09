package com.example.mian.modelo;

import android.net.wifi.p2p.WifiP2pManager;

public class Cliente {
    public String idCliente;
    public String clieCodigo;
    public String clieNombre;
    public String clieApellido;
    public int clieFoto;
    public String clieDni;
    public String clieTelefono;
    public String clieDireccion;
    public String clieSexo;
    public String clieEstado;


    public Cliente(){}
    public Cliente(String idCliente,String clieCodigo, String clieNombre, String clieApellido, int clieFoto, String clieDni, String clieTelefono, String clieDireccion,String clieSexo, String clieEstado) {
        this.idCliente = idCliente;
        this.clieCodigo = clieCodigo;
        this.clieNombre = clieNombre;
        this.clieApellido = clieApellido;
        this.clieFoto = clieFoto;
        this.clieDni = clieDni;
        this.clieTelefono = clieTelefono;
        this.clieDireccion = clieDireccion;
        this.clieEstado = clieEstado;
        this.clieSexo = clieSexo;
    }

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public String getClieSexo() {
        return clieSexo;
    }

    public void setClieSexo(String clieSexo) {
        this.clieSexo = clieSexo;
    }

    public String getClieCodigo() {
        return clieCodigo;
    }

    public void setClieCodigo(String clieCodigo) {
        this.clieCodigo = clieCodigo;
    }

    public String getClieNombre() {
        return clieNombre;
    }

    public void setClieNombre(String clieNombre) {
        this.clieNombre = clieNombre;
    }

    public String getClieApellido() {
        return clieApellido;
    }

    public void setClieApellido(String clieApellido) {
        this.clieApellido = clieApellido;
    }

    public int getClieFoto() {
        return clieFoto;
    }

    public void setClieFoto(int clieFoto) {
        this.clieFoto = clieFoto;
    }

    public String getClieDni() {
        return clieDni;
    }

    public void setClieDni(String clieDni) {
        this.clieDni = clieDni;
    }

    public String getClieTelefono() {
        return clieTelefono;
    }

    public void setClieTelefono(String clieTelefono) {
        this.clieTelefono = clieTelefono;
    }

    public String getClieDireccion() {
        return clieDireccion;
    }

    public void setClieDireccion(String clieDireccion) {
        this.clieDireccion = clieDireccion;
    }

    public String getClieEstado() {
        return clieEstado;
    }

    public void setClieEstado(String clieEstado) {
        this.clieEstado = clieEstado;
    }
}
