package com.example.mian.modelo;

public class PrestamoGrouping {
    private String idPrestamoGrouping;
    private String idCliente;
    private String pgClieDni;
    private String pgClieNombre;
    private String pgClieApellido;
    private String pgClieSexo;
    private double pgImporteCredito;
    private String pgFecha;
    private String pgEstado;

    public PrestamoGrouping(){}

    public PrestamoGrouping(String idPrestamoGrouping, String idCliente, String pgClieDni, String pgClieNombre, String pgClieApellido, String pgClieSexo, double pgImporteCredito, String pgFecha, String pgEstado) {
        this.idPrestamoGrouping = idPrestamoGrouping;
        this.idCliente = idCliente;
        this.pgClieDni = pgClieDni;
        this.pgClieNombre = pgClieNombre;
        this.pgClieApellido = pgClieApellido;
        this.pgClieSexo = pgClieSexo;
        this.pgImporteCredito = pgImporteCredito;
        this.pgFecha = pgFecha;
        this.pgEstado = pgEstado;
    }

    public String getIdPrestamoGrouping() {
        return idPrestamoGrouping;
    }

    public void setIdPrestamoGrouping(String idPrestamoGrouping) {
        this.idPrestamoGrouping = idPrestamoGrouping;
    }

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public String getPgClieDni() {
        return pgClieDni;
    }

    public void setPgClieDni(String pgClieDni) {
        this.pgClieDni = pgClieDni;
    }

    public String getPgClieNombre() {
        return pgClieNombre;
    }

    public void setPgClieNombre(String pgClieNombre) {
        this.pgClieNombre = pgClieNombre;
    }

    public String getPgClieApellido() {
        return pgClieApellido;
    }

    public void setPgClieApellido(String pgClieApellido) {
        this.pgClieApellido = pgClieApellido;
    }

    public String getPgClieSexo() {
        return pgClieSexo;
    }

    public void setPgClieSexo(String pgClieSexo) {
        this.pgClieSexo = pgClieSexo;
    }

    public double getPgImporteCredito() {
        return pgImporteCredito;
    }

    public void setPgImporteCredito(double pgImporteCredito) {
        this.pgImporteCredito = pgImporteCredito;
    }

    public String getPgFecha() {
        return pgFecha;
    }

    public void setPgFecha(String pgFecha) {
        this.pgFecha = pgFecha;
    }

    public String getPgEstado() {
        return pgEstado;
    }

    public void setPgEstado(String pgEstado) {
        this.pgEstado = pgEstado;
    }
}
