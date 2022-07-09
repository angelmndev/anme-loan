package com.example.mian.modelo;

public class Prestamo {
    private String idPrestamo;
    private String preClieDni;
    private String idPrestamoHistorial;
    private String preTipoPrestamo;
    private double preImporteCredito;
    private String preEstado;
    private String preEstadoCantidad;
    private String preFecha;

    public Prestamo(){}

    public Prestamo(String idPrestamo, String preClieDni, String idPrestamoHistorial, String preTipoPrestamo, double preImporteCredito, String preEstado, String preEstadoCantidad, String preFecha) {
        this.idPrestamo = idPrestamo;
        this.preClieDni = preClieDni;
        this.idPrestamoHistorial = idPrestamoHistorial;
        this.preTipoPrestamo = preTipoPrestamo;
        this.preImporteCredito = preImporteCredito;
        this.preEstado = preEstado;
        this.preEstadoCantidad = preEstadoCantidad;
        this.preFecha = preFecha;
    }


    public String getIdPrestamo() {
        return idPrestamo;
    }

    public void setIdPrestamo(String idPrestamo) {
        this.idPrestamo = idPrestamo;
    }

    public String getPreClieDni() {
        return preClieDni;
    }

    public void setPreClieDni(String preClieDni) {
        this.preClieDni = preClieDni;
    }

    public String getIdPrestamoHistorial() {
        return idPrestamoHistorial;
    }

    public void setIdPrestamoHistorial(String idPrestamoHistorial) {
        this.idPrestamoHistorial = idPrestamoHistorial;
    }

    public String getPreTipoPrestamo() {
        return preTipoPrestamo;
    }

    public void setPreTipoPrestamo(String preTipoPrestamo) {
        this.preTipoPrestamo = preTipoPrestamo;
    }

    public double getPreImporteCredito() {
        return preImporteCredito;
    }

    public void setPreImporteCredito(double preImporteCredito) {
        this.preImporteCredito = preImporteCredito;
    }

    public String getPreEstado() {
        return preEstado;
    }

    public void setPreEstado(String preEstado) {
        this.preEstado = preEstado;
    }

    public String getPreEstadoCantidad() {
        return preEstadoCantidad;
    }

    public void setPreEstadoCantidad(String preEstadoCantidad) {
        this.preEstadoCantidad = preEstadoCantidad;
    }

    public String getPreFecha() {
        return preFecha;
    }

    public void setPreFecha(String preFecha) {
        this.preFecha = preFecha;
    }
}
