package com.example.mian.adaptador.prestamo;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mian.R;
import com.example.mian.interfaces.IPrestamo;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.ui.prestamo.PrestamoDetalleEliminarFragment;
import com.example.mian.ui.prestamo.PrestamoModificarDatosFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;

public class PrestamoCancelarAdapter extends FirebaseRecyclerAdapter<Prestamo,PrestamoCancelarAdapter.mViewHolder> {
    private LayoutInflater layoutInflater;
    private Context context;
    private ProgressDialog dialog;
    private IPrestamo iPrestamo;
    public PrestamoCancelarAdapter(@NonNull FirebaseRecyclerOptions<Prestamo> options, Context context, ProgressDialog dialog,IPrestamo iPrestamo) {
        super(options);
        this.layoutInflater = LayoutInflater.from(context);
        this.context = context;
        this.dialog = dialog;
        this.iPrestamo = iPrestamo;
    }

    @Override
    public PrestamoCancelarAdapter.mViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_prestamo_cancelar,null);
        return new PrestamoCancelarAdapter.mViewHolder(view,iPrestamo);
    }

    @Override
    public void onDataChanged() {
        dialog.dismiss();
    }

    @Override
    protected void onBindViewHolder(@NonNull PrestamoCancelarAdapter.mViewHolder holder, int position, @NonNull Prestamo model) {
        holder.bindData(model);
    }

    public class mViewHolder extends  RecyclerView.ViewHolder{

        Fragment fragment;
        TextView tvTipoPrestamo, tvFechaPrestamo,tvImporteCredito;
        CardView cvCancelarPrestamo;
        CheckBox chkSeleccionar;
        IPrestamo iPrestamo;
        mViewHolder(View view,IPrestamo iPrestamo){
            super(view);
            tvTipoPrestamo = view.findViewById(R.id.tvTipoPrestamo);
            tvFechaPrestamo = view.findViewById(R.id.tvFechaPrestamo);
            tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
            cvCancelarPrestamo = view.findViewById(R.id.cvCancelarPrestamo);
            chkSeleccionar = view.findViewById(R.id.chkSeleccionar);
            this.iPrestamo = iPrestamo;
        }


        void bindData(final Prestamo prestamo){
            String fecha = DateFormat.getDateInstance(DateFormat.FULL).format(AngLib.ParseFecha(prestamo.getPreFecha()));
            String tipoPrestamo = prestamo.getPreTipoPrestamo();
            String importeCredito = FormatoMoneda(prestamo.getPreImporteCredito());

            tvTipoPrestamo.setText(tipoPrestamo);
            tvFechaPrestamo.setText(fecha);
            tvImporteCredito.setText(importeCredito);


            cvCancelarPrestamo.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    fragment = new PrestamoDetalleEliminarFragment();
                    Bundle bundle = new Bundle();
                    bundle.putString(Utilidades.PRE_CLIE_DNI, prestamo.getPreClieDni());
                    bundle.putString(Utilidades.ID_PRESTAMO,prestamo.getIdPrestamo());

                    fragment.setArguments(bundle);
                    FragmentManager fragmentManager = ((FragmentActivity) context).getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.fragmentPrestamoCancelar, fragment);
                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.commit();
                }
            });

            chkSeleccionar.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(chkSeleccionar.isChecked()){
                        iPrestamo.GetDatosPrestamo(prestamo.getIdPrestamo(),prestamo.getPreClieDni());
                        //Toast.makeText(v.getContext(),prestamo.getIdPrestamo(),Toast.LENGTH_SHORT).show();
                    }else {
                        iPrestamo.GetDatosPrestamo(null,null);
                    }
                }
            });
        }


        //Metodo que permite convertir numero con simbolo de moneda
        private String FormatoMoneda(double cantMoney){
            NumberFormat pen_promedio = NumberFormat.getCurrencyInstance();
            DecimalFormatSymbols dfs = new DecimalFormatSymbols();
            dfs.setCurrencySymbol("S/. ");
            ((DecimalFormat) pen_promedio).setDecimalFormatSymbols(dfs);

            return  pen_promedio.format(cantMoney);
        }
    }


}
