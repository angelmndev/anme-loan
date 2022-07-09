package com.example.mian.modelo;

public class PrestamoItemModel {

    private int idCliente;
    private int idPrestamoHistorial;
    private int idPrestamo;
    private String clieDni;
    private String clieNombre;
    private String clieApellido;
    private double presImporteCredito;
    private String presModalidad;
    private String presTipoPago;
    private int presNumeroCUota;
    private double presTasaInteres;
    private double presImporteCuota;
    private double presTotal;
    private String presFecha;

    public PrestamoItemModel(int idCliente, int idPrestamoHistorial, int idPrestamo, String clieDni, String clieNombre, String clieApellido, double presImporteCredito, String presModalidad, String presTipoPago, int presNumeroCUota, double presTasaInteres, double presImporteCuota, double presTotal, String presFecha) {
        this.idCliente = idCliente;
        this.idPrestamoHistorial = idPrestamoHistorial;
        this.idPrestamo = idPrestamo;
        this.clieDni = clieDni;
        this.clieNombre = clieNombre;
        this.clieApellido = clieApellido;
        this.presImporteCredito = presImporteCredito;
        this.presModalidad = presModalidad;
        this.presTipoPago = presTipoPago;
        this.presNumeroCUota = presNumeroCUota;
        this.presTasaInteres = presTasaInteres;
        this.presImporteCuota = presImporteCuota;
        this.presTotal = presTotal;
        this.presFecha = presFecha;
    }

    public int getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(int idCliente) {
        this.idCliente = idCliente;
    }

    public int getIdPrestamoHistorial() {
        return idPrestamoHistorial;
    }

    public void setIdPrestamoHistorial(int idPrestamoHistorial) {
        this.idPrestamoHistorial = idPrestamoHistorial;
    }

    public int getIdPrestamo() {
        return idPrestamo;
    }

    public void setIdPrestamo(int idPrestamo) {
        this.idPrestamo = idPrestamo;
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

    public String getClieApellido() {
        return clieApellido;
    }

    public void setClieApellido(String clieApellido) {
        this.clieApellido = clieApellido;
    }

    public double getPresImporteCredito() {
        return presImporteCredito;
    }

    public void setPresImporteCredito(double presImporteCredito) {
        this.presImporteCredito = presImporteCredito;
    }

    public String getPresModalidad() {
        return presModalidad;
    }

    public void setPresModalidad(String presModalidad) {
        this.presModalidad = presModalidad;
    }

    public String getPresTipoPago() {
        return presTipoPago;
    }

    public void setPresTipoPago(String presTipoPago) {
        this.presTipoPago = presTipoPago;
    }

    public int getPresNumeroCUota() {
        return presNumeroCUota;
    }

    public void setPresNumeroCUota(int presNumeroCUota) {
        this.presNumeroCUota = presNumeroCUota;
    }

    public double getPresTasaInteres() {
        return presTasaInteres;
    }

    public void setPresTasaInteres(double presTasaInteres) {
        this.presTasaInteres = presTasaInteres;
    }

    public double getPresImporteCuota() {
        return presImporteCuota;
    }

    public void setPresImporteCuota(double presImporteCuota) {
        this.presImporteCuota = presImporteCuota;
    }

    public double getPresTotal() {
        return presTotal;
    }

    public void setPresTotal(double presTotal) {
        this.presTotal = presTotal;
    }

    public String getPresFecha() {
        return presFecha;
    }

    public void setPresFecha(String presFecha) {
        this.presFecha = presFecha;
    }
}
