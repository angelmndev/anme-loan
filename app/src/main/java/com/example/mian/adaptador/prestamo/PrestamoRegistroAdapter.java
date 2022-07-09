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
import com.example.mian.modelo.PrestamoGroup;
import com.example.mian.modelo.PrestamoGrouping;
import com.example.mian.ui.prestamo.PrestamoDetalleFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;

public class PrestamoRegistroAdapter extends FirebaseRecyclerAdapter<PrestamoGrouping,PrestamoRegistroAdapter.PrestamoRegistroViewHolder>{

    private LayoutInflater layoutInflater;
    private Context context;
    private ProgressDialog dialog;
    public PrestamoRegistroAdapter(@NonNull FirebaseRecyclerOptions<PrestamoGrouping> options, Context context, ProgressDialog dialog) {
        super(options);
        this.layoutInflater = LayoutInflater.from(context);
        this.context = context;
        this.dialog = dialog;
    }

    @Override
    public PrestamoRegistroAdapter.PrestamoRegistroViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_registro_prestamo,null);
        return new PrestamoRegistroAdapter.PrestamoRegistroViewHolder(view);
    }

    @Override
    public void onDataChanged() {
        dialog.dismiss();
    }

    @Override
    protected void onBindViewHolder(@NonNull PrestamoRegistroViewHolder holder, int position, @NonNull PrestamoGrouping model) {
        holder.bindData(model);
    }

    public class PrestamoRegistroViewHolder extends  RecyclerView.ViewHolder{

        Fragment fragment;
        ImageView ivFoto;
        TextView tvNombre, tvFecha,tvImporteCredito;
        CardView cvListaClientePrestamo;

        PrestamoRegistroViewHolder(View view){
            super(view);
            ivFoto = view.findViewById(R.id.ivFotoCliente);
            tvNombre = view.findViewById(R.id.tvNombre);
            tvFecha = view.findViewById(R.id.tvFechaPrestamo);
            tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
            cvListaClientePrestamo = view.findViewById(R.id.cvListaClientePrestamo);
        }


        void bindData(final PrestamoGrouping prestamoGrouping){
            NumberFormat pen_promedio = NumberFormat.getCurrencyInstance();
            DecimalFormatSymbols dfs = new DecimalFormatSymbols();
            dfs.setCurrencySymbol("S/. ");
            ((DecimalFormat) pen_promedio).setDecimalFormatSymbols(dfs);
            String importeCredito = pen_promedio.format(prestamoGrouping.getPgImporteCredito());

            switch (prestamoGrouping.getPgClieSexo()){
                case "Femenino":
                    ivFoto.setImageResource(R.drawable.ic_mujer);
                    break;
                case "Masculino":
                    ivFoto.setImageResource(R.drawable.ic_hombre);
                    break;
            }
           String fecha = DateFormat.getDateInstance(DateFormat.FULL).format(AngLib.ParseFecha(prestamoGrouping.getPgFecha()));
           tvNombre.setText(prestamoGrouping.getPgClieNombre());
           tvFecha.setText("U.P.: "+fecha);
            tvImporteCredito.setText(importeCredito);


            cvListaClientePrestamo.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    fragment = new PrestamoDetalleFragment();
                    Bundle bundle = new Bundle();
                    bundle.putString(Utilidades.PG_CLIE_DNI, prestamoGrouping.getPgClieDni());
                    bundle.putString(Utilidades.PG_CLIE_NOMBRE, prestamoGrouping.getPgClieNombre());
                    fragment.setArguments(bundle);
                    FragmentManager fragmentManager = ((FragmentActivity) context).getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.fragmentPrestamoRegistro, fragment);
                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.commit();
                }
            });
        }
    }
}
