package com.example.mian.modelo;

import java.util.Date;

public class PrestamoGroup {
    private String idPrestamoDetalle;
    private String idCliente;
    private String clieDni;
    private String clieNombre;
    private String clieSexo;
    private double presCantidad;
    private String presFecha;
    private String presEstado;

    public PrestamoGroup(){}

    public PrestamoGroup(String idPrestamoDetalle, String idCliente, String clieDni, String clieNombre, String clieSexo, double presCantidad, String presFecha) {
        this.idPrestamoDetalle = idPrestamoDetalle;
        this.idCliente = idCliente;
        this.clieDni = clieDni;
        this.clieNombre = clieNombre;
        this.clieSexo = clieSexo;
        this.presCantidad = presCantidad;
        this.presFecha = presFecha;
    }

    public String getIdPrestamoDetalle() {
        return idPrestamoDetalle;
    }

    public void setIdPrestamoDetalle(String idPrestamoDetalle) {
        this.idPrestamoDetalle = idPrestamoDetalle;
    }

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }


    public String getClieDni() {
        return clieDni;
    }

    public void setClieDni(String clieDni) {
        this.clieDni = clieDni;
    }

    public String getClieNombre() {
        return clieNombre;
    }

    public void setClieNombre(String clieNombre) {
        this.clieNombre = clieNombre;
    }

    public String getClieSexo() {
        return clieSexo;
    }

    public void setClieSexo(String clieSexo) {
        this.clieSexo = clieSexo;
    }

    public double getPresCantidad() {
        return presCantidad;
    }

    public void setPresCantidad(double presCantidad) {
        this.presCantidad = presCantidad;
    }

    public String getPresFecha() {
        return presFecha;
    }

    public void setPresFecha(String presFecha) {
        this.presFecha = presFecha;
    }


}
