package com.example.mian.adaptador;


import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mian.R;
import com.example.mian.modelo.Cliente;
import com.example.mian.modelo.Usuario;

import java.util.List;

public class UsuarioAdapter extends RecyclerView.Adapter<UsuarioAdapter.UsuarioViewHolder> {
    private List<Usuario> listaUsuario;
    private LayoutInflater layoutInflater;
    private Context context;

    public UsuarioAdapter(List<Usuario> listaUsuario, Context context){
        this.layoutInflater = LayoutInflater.from(context);
        this.context = context;
        this.listaUsuario = listaUsuario;
    }

    @Override
    public int getItemCount(){
        return  listaUsuario.size();
    }

    @NonNull
    @Override
    public UsuarioAdapter.UsuarioViewHolder onCreateViewHolder(ViewGroup parent, int viewType){
        View view =layoutInflater.inflate(R.layout.lista_usuario,null);
        return new UsuarioAdapter.UsuarioViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final UsuarioAdapter.UsuarioViewHolder holder, final int position){
        holder.bindData(listaUsuario.get(position));
    }

    public void setItems(List<Usuario> listaUsuario){
        this.listaUsuario = listaUsuario;
    }

    public class UsuarioViewHolder extends  RecyclerView.ViewHolder{

        ImageView ivFoto;
        TextView tvNombre, tvPrivilegio,tvEstado;

        UsuarioViewHolder(View view){
            super(view);
            ivFoto = view.findViewById(R.id.ivUsuarioMainIcono);
            tvNombre = view.findViewById(R.id.tvUsuarioMainNombre);
            tvPrivilegio = view.findViewById(R.id.tvUsuarioMainPrivilegio);
            tvEstado = view.findViewById(R.id.tvUsuarioMainEstado);
        }

        void bindData(final Usuario usuario){
            ivFoto.setImageBitmap(usuario.getUsuFoto());
            tvNombre.setText(usuario.getUsuNombre());
            tvPrivilegio.setText(usuario.getUsuPrivilegio());
            if(tvEstado.getText().equals("1")){
                tvEstado.setTextColor(Color.rgb(0, 214, 136));
            }else{
                tvEstado.setTextColor(Color.rgb(247, 11, 89));
            }
            tvEstado.setText(usuario.getUsuEstado());
        }
    }
}


