package com.example.mian.adaptador.prestamo;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mian.R;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoGroup;
import com.example.mian.ui.prestamo.PrestamoDetalleFragment;
import com.example.mian.ui.prestamo.PrestamoModificarDatosFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;

public class PrestamoModificarAdapter extends FirebaseRecyclerAdapter<Prestamo,PrestamoModificarAdapter.mViewHolder> {

    private LayoutInflater layoutInflater;
    private Context context;
    private ProgressDialog dialog;
    public PrestamoModificarAdapter(@NonNull FirebaseRecyclerOptions<Prestamo> options, Context context, ProgressDialog dialog) {
        super(options);
        this.layoutInflater = LayoutInflater.from(context);
        this.context = context;
        this.dialog = dialog;
    }

    @Override
    public PrestamoModificarAdapter.mViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_prestamo_modificar,null);
        return new PrestamoModificarAdapter.mViewHolder(view);
    }

    @Override
    public void onDataChanged() {
        dialog.dismiss();
    }

    @Override
    protected void onBindViewHolder(@NonNull PrestamoModificarAdapter.mViewHolder holder, int position, @NonNull Prestamo model) {
        holder.bindData(model);
    }

    public class mViewHolder extends  RecyclerView.ViewHolder{

        Fragment fragment;
        TextView tvTipoPrestamo, tvFechaPrestamo,tvImporteCredito;
        CardView cvModificarPrestamo;

        mViewHolder(View view){
            super(view);
            tvTipoPrestamo = view.findViewById(R.id.tvTipoPrestamo);
            tvFechaPrestamo = view.findViewById(R.id.tvFechaPrestamo);
            tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
            cvModificarPrestamo = view.findViewById(R.id.cvModificarPrestamo);
        }


        void bindData(final Prestamo prestamo){
            String fecha = DateFormat.getDateInstance(DateFormat.FULL).format(AngLib.ParseFecha(prestamo.getPreFecha()));
            String tipoPrestamo = prestamo.getPreTipoPrestamo();
            String importeCredito = FormatoMoneda(prestamo.getPreImporteCredito());

            tvTipoPrestamo.setText(tipoPrestamo);
            tvFechaPrestamo.setText(fecha);
            tvImporteCredito.setText(importeCredito);

            cvModificarPrestamo.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    fragment = new PrestamoModificarDatosFragment();
                    Bundle bundle = new Bundle();
                    bundle.putString(Utilidades.ID_PRESTAMO,prestamo.getIdPrestamo());
                    bundle.putString(Utilidades.ID_PRESTAMO_HISTORIAL,prestamo.getIdPrestamoHistorial());
                    bundle.putString(Utilidades.PRE_CLIE_DNI,prestamo.getPreClieDni());

                    fragment.setArguments(bundle);
                    FragmentManager fragmentManager = ((FragmentActivity) context).getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.fragmentPrestamoModificar, fragment);
                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.commit();
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
