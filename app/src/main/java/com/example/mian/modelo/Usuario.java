package com.example.mian.modelo;

import android.graphics.Bitmap;

public class Usuario {
    public int idUsuario;
    public String usuCodigo;
    public Bitmap usuFoto;
    public String usuNombre;
    public String usuApellido;
    public String usuUsuario;
    public String usuPassword;
    public String usuDni;
    public String usuTelefono;
    public String usuDireccion;
    public String usuPrivilegio;
    public String usuEstado;

    public Usuario(int idUsuario, String usuCodigo, Bitmap usuFoto, String usuNombre, String usuApellido,String usuUsuario,String usuPassword, String usuDni, String usuTelefono, String usuDireccion, String usuPrivilegio, String usuEstado) {
        this.idUsuario = idUsuario;
        this.usuCodigo = usuCodigo;
        this.usuFoto = usuFoto;
        this.usuNombre = usuNombre;
        this.usuApellido = usuApellido;
        this.usuUsuario = usuUsuario;
        this.usuPassword= usuPassword;
        this.usuDni = usuDni;
        this.usuTelefono = usuTelefono;
        this.usuDireccion = usuDireccion;
        this.usuPrivilegio = usuPrivilegio;
        this.usuEstado = usuEstado;
    }

    public int getIdUsuario() {
        return idUsuario;
    }

    public void setIdUsuario(int idUsuario) {
        this.idUsuario = idUsuario;
    }

    public String getUsuCodigo() {
        return usuCodigo;
    }

    public void setUsuCodigo(String usuCodigo) {
        this.usuCodigo = usuCodigo;
    }

    public Bitmap getUsuFoto() {
        return usuFoto;
    }

    public void setUsuFoto(Bitmap usuFoto) {
        this.usuFoto = usuFoto;
    }

    public String getUsuNombre() {
        return usuNombre;
    }

    public void setUsuNombre(String usuNombre) {
        this.usuNombre = usuNombre;
    }

    public String getUsuApellido() {
        return usuApellido;
    }

    public void setUsuApellido(String usuApellido) {
        this.usuApellido = usuApellido;
    }

    public String getUsuUsuario() {
        return usuUsuario;
    }

    public void setUsuUsuario(String usuUsuario) {
        this.usuUsuario = usuUsuario;
    }

    public String getUsuPassword() {
        return usuPassword;
    }

    public void setUsuPassword(String usuPassword) {
        this.usuPassword = usuPassword;
    }

    public String getUsuDni() {
        return usuDni;
    }

    public void setUsuDni(String usuDni) {
        this.usuDni = usuDni;
    }

    public String getUsuTelefono() {
        return usuTelefono;
    }

    public void setUsuTelefono(String usuTelefono) {
        this.usuTelefono = usuTelefono;
    }

    public String getUsuDireccion() {
        return usuDireccion;
    }

    public void setUsuDireccion(String usuDireccion) {
        this.usuDireccion = usuDireccion;
    }

    public String getUsuPrivilegio() {
        return usuPrivilegio;
    }

    public void setUsuPrivilegio(String usuPrivilegio) {
        this.usuPrivilegio = usuPrivilegio;
    }

    public String getUsuEstado() {
        return usuEstado;
    }

    public void setUsuEstado(String usuEstado) {
        this.usuEstado = usuEstado;
    }
}
