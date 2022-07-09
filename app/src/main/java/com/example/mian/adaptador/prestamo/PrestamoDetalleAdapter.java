package com.example.mian.adaptador.prestamo;

import android.app.ProgressDialog;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mian.R;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;

public class PrestamoDetalleAdapter extends FirebaseRecyclerAdapter<Prestamo,PrestamoDetalleAdapter.mViewHolder> {

    private LayoutInflater layoutInflater;
    private Context context;
    private ProgressDialog dialog;
    public PrestamoDetalleAdapter(@NonNull FirebaseRecyclerOptions<Prestamo> options, Context context, ProgressDialog dialog) {
        super(options);
        this.layoutInflater = LayoutInflater.from(context);
        this.context = context;
        this.dialog = dialog;
    }

    @Override
    public PrestamoDetalleAdapter.mViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_prestamo_detalle,null);
        return new PrestamoDetalleAdapter.mViewHolder(view);
    }

    @Override
    public void onDataChanged() {
        dialog.dismiss();
    }

    @Override
    protected void onBindViewHolder(@NonNull PrestamoDetalleAdapter.mViewHolder holder, int position, @NonNull Prestamo model) {
        holder.bindData(model);
    }


    public class mViewHolder extends  RecyclerView.ViewHolder{

        TextView tvTipoPrestamo,tvFechaPrestamo,tvImporteCredito;

        mViewHolder(View view){
            super(view);
            tvTipoPrestamo = view.findViewById(R.id.tvTipoPrestamo);
            tvFechaPrestamo = view.findViewById(R.id.tvFechaPrestamo);
            tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
        }

        void bindData(final Prestamo prestamo){

            String fecha = DateFormat.getDateInstance(DateFormat.FULL).format(AngLib.ParseFecha(prestamo.getPreFecha()));
          String tipoPago = prestamo.getPreTipoPrestamo();
            String importeCredito = FormatoMoneda(prestamo.getPreImporteCredito());

            tvTipoPrestamo.setText(tipoPago);
            tvFechaPrestamo.setText(fecha);
            tvImporteCredito.setText(importeCredito);

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
