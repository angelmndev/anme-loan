package com.example.mian.adaptador;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mian.R;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Cliente;
import com.example.mian.ui.cliente.ClienteDetalleFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.firebase.ui.database.FirebaseRecyclerOptions;

import java.util.List;

public class ClienteAdapter extends FirebaseRecyclerAdapter<Cliente,ClienteAdapter.ClienteViewHolder> {

    private LayoutInflater layoutInflater;

    public ClienteAdapter(@NonNull FirebaseRecyclerOptions<Cliente> options,Context context) {
        super(options);
        this.layoutInflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public ClienteAdapter.ClienteViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_cliente,null);
        return new ClienteAdapter.ClienteViewHolder(view);
    }

    @Override
    protected void onBindViewHolder(@NonNull ClienteViewHolder holder, int position, @NonNull Cliente model) {
        holder.bindData(model);
    }

    public class ClienteViewHolder extends  RecyclerView.ViewHolder{
        CardView cvListaCliente;
        ImageView ivFoto;
        TextView tvNombre, tvDni ,tvEstado;
        Fragment fragmentClienteDetalle;

        ClienteViewHolder(View view){
            super(view);
            cvListaCliente = view.findViewById(R.id.cvListaCliente);
            ivFoto = view.findViewById(R.id.ivIcono);
            tvNombre = view.findViewById(R.id.tvNombre);
            tvDni = view.findViewById(R.id.tvDni);
            tvEstado = view.findViewById(R.id.tvEstado);
        }

        void bindData(final Cliente cliente){

            switch (cliente.getClieSexo()) {
                case "Femenino":
                    ivFoto.setImageResource(R.drawable.ic_mujer);
                    break;
                case "Masculino":
                    ivFoto.setImageResource(R.drawable.ic_hombre);
                    break;
            }
            tvNombre.setText(cliente.getClieNombre());
            tvDni.setText(cliente.getClieDni());

            if(cliente.getClieEstado().equals("1")){
                tvEstado.setText("Activo");
                tvEstado.setTextColor(Color.rgb(0, 214, 136));
            }else{
                tvEstado.setText("Inactivo");
                tvEstado.setTextColor(Color.rgb(247, 11, 89));
            }
            cvListaCliente.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    fragmentClienteDetalle = new ClienteDetalleFragment();
                    Bundle bundle = new Bundle();
                    bundle.putString(Utilidades.ID_CLIENTE,cliente.getIdCliente());
                    fragmentClienteDetalle.setArguments(bundle);
                    AngLib.showFragment(v.getContext(),R.id.fragmentCliente,fragmentClienteDetalle);
                }
            });
        }
    }
}


