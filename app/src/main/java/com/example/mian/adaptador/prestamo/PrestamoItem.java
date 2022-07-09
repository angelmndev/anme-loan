package com.example.mian.adaptador.prestamo;

import android.app.ProgressDialog;

import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoItemModel;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.lang.reflect.Modifier;
import java.util.List;

public class PrestamoItem {

    private String clieNombre;
    private FirebaseRecyclerOptions<Prestamo> listaPrestamo;

    public PrestamoItem(String clieNombre, FirebaseRecyclerOptions<Prestamo> options) {
        this.clieNombre = clieNombre;
        this.listaPrestamo = listaPrestamo;

    }

    public String getClieNombre() {
        return clieNombre;
    }

    public void setClieNombre(String clieNombre) {
        this.clieNombre = clieNombre;
    }

    public FirebaseRecyclerOptions<Prestamo> getListaPrestamo() {
        return listaPrestamo;
    }

    public void setListaPrestamo(FirebaseRecyclerOptions<Prestamo> listaPrestamo) {
        this.listaPrestamo = listaPrestamo;
    }
}
