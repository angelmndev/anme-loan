package com.example.mian.adaptador.cobro;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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
import com.example.mian.ui.cobro.CobrarDetalleFragment;
import com.example.mian.ui.prestamo.PrestamoModificarDatosFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;

public class CobranzaAdapter extends FirebaseRecyclerAdapter<Prestamo,CobranzaAdapter.MyHolder> {
    private LayoutInflater mLayoutInflater;
    private Context mContext;
    private ProgressDialog mDialog;
    public CobranzaAdapter(@NonNull FirebaseRecyclerOptions<Prestamo> options,Context context,ProgressDialog dialog) {
        super(options);
        this.mLayoutInflater = LayoutInflater.from(context);
        this.mContext = context;
        this.mDialog = dialog;
    }

    @Override
    protected void onBindViewHolder(@NonNull CobranzaAdapter.MyHolder holder, int position, @NonNull Prestamo model) {
        holder.bindData(model);
    }

    @Override
    public void onDataChanged() {
        mDialog.dismiss();
    }

    @NonNull
    @Override
    public CobranzaAdapter.MyHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = mLayoutInflater.inflate(R.layout.lista_cobranza,null);
        return new CobranzaAdapter.MyHolder(view);
    }

    public class MyHolder extends RecyclerView.ViewHolder{
        private Fragment fragment;
        private TextView tvTipoPrestamo, tvFechaPrestamo,tvImporteCredito;
        private CardView cvPrestamo;
        public MyHolder(@NonNull View itemView) {
            super(itemView);
            tvTipoPrestamo = itemView.findViewById(R.id.tvTipoPrestamo);
            tvFechaPrestamo = itemView.findViewById(R.id.tvFechaPrestamo);
            tvImporteCredito = itemView.findViewById(R.id.tvImporteCredito);
            cvPrestamo = itemView.findViewById(R.id.cvPrestamo);
        }

        void bindData(Prestamo prestamo){
            String fecha = DateFormat.getDateInstance(DateFormat.FULL).format(AngLib.ParseFecha(prestamo.getPreFecha()));
            String tipoPrestamo = prestamo.getPreTipoPrestamo();
            String importeCredito = FormatoMoneda(prestamo.getPreImporteCredito());

            tvTipoPrestamo.setText(tipoPrestamo);
            tvFechaPrestamo.setText(fecha);
            tvImporteCredito.setText(importeCredito);

            cvPrestamo.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    fragment = new CobrarDetalleFragment();
                    Bundle bundle = new Bundle();
                    bundle.putString(Utilidades.ID_PRESTAMO,prestamo.getIdPrestamo());
                    bundle.putString(Utilidades.ID_PRESTAMO_HISTORIAL,prestamo.getIdPrestamoHistorial());
                    bundle.putString(Utilidades.PRE_CLIE_DNI,prestamo.getPreClieDni());

                    fragment.setArguments(bundle);
                    FragmentManager fragmentManager = ((FragmentActivity) mContext).getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.fragmentCobrar, fragment);
                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.commit();
                }
            });
        }
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
