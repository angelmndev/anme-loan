package com.example.mian.modelo;

public class PrestamoHistorial {
    private String idPrestamoHistorial;
    private String idCliente;
    private String idUser;
    private double phImporteCredito;
    private double phImporteCuota;
    private String phModalidadPago;
    private int phNumeroCuota;
    private double phTasaInteres;
    private String phTipoPago;
    private double phTotalPagar;
    private String phFecha;
    private String phComentario;

    public PrestamoHistorial(){}

    public PrestamoHistorial(String idPrestamoHistorial, String idCliente, String idUser, double phImporteCredito, double phImporteCuota, String phModalidadPago, int phNumeroCuota, double phTasaInteres, String phTipoPago, double phTotalPagar, String phFecha, String phComentario) {
        this.idPrestamoHistorial = idPrestamoHistorial;
        this.idCliente = idCliente;
        this.idUser = idUser;
        this.phImporteCredito = phImporteCredito;
        this.phImporteCuota = phImporteCuota;
        this.phModalidadPago = phModalidadPago;
        this.phNumeroCuota = phNumeroCuota;
        this.phTasaInteres = phTasaInteres;
        this.phTipoPago = phTipoPago;
        this.phTotalPagar = phTotalPagar;
        this.phFecha = phFecha;
        this.phComentario = phComentario;
    }

    public String getIdPrestamoHistorial() {
        return idPrestamoHistorial;
    }

    public void setIdPrestamoHistorial(String idPrestamoHistorial) {
        this.idPrestamoHistorial = idPrestamoHistorial;
    }

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public String getIdUser() {
        return idUser;
    }

    public void setIdUser(String idUser) {
        this.idUser = idUser;
    }

    public double getPhImporteCredito() {
        return phImporteCredito;
    }

    public void setPhImporteCredito(double phImporteCredito) {
        this.phImporteCredito = phImporteCredito;
    }

    public double getPhImporteCuota() {
        return phImporteCuota;
    }

    public void setPhImporteCuota(double phImporteCuota) {
        this.phImporteCuota = phImporteCuota;
    }

    public String getPhModalidadPago() {
        return phModalidadPago;
    }

    public void setPhModalidadPago(String phModalidadPago) {
        this.phModalidadPago = phModalidadPago;
    }

    public int getPhNumeroCuota() {
        return phNumeroCuota;
    }

    public void setPhNumeroCuota(int phNumeroCuota) {
        this.phNumeroCuota = phNumeroCuota;
    }

    public double getPhTasaInteres() {
        return phTasaInteres;
    }

    public void setPhTasaInteres(double phTasaInteres) {
        this.phTasaInteres = phTasaInteres;
    }

    public String getPhTipoPago() {
        return phTipoPago;
    }

    public void setPhTipoPago(String phTipoPago) {
        this.phTipoPago = phTipoPago;
    }

    public double getPhTotalPagar() {
        return phTotalPagar;
    }

    public void setPhTotalPagar(double phTotalPagar) {
        this.phTotalPagar = phTotalPagar;
    }

    public String getPhFecha() {
        return phFecha;
    }

    public void setPhFecha(String phFecha) {
        this.phFecha = phFecha;
    }

    public String getPhComentario() {
        return phComentario;
    }

    public void setPhComentario(String phComentario) {
        this.phComentario = phComentario;
    }
}
