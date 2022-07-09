package com.example.mian.ui.dialogo;

import android.app.AlertDialog;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import com.example.mian.R;

public class DialogoMain extends Fragment {
    //Muestra un ventana de  dialogo
    public View showDialog(Context context, Accion accion, String titulo, String mensaje) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        LayoutInflater inflater = LayoutInflater.from(context);

        View view = null;
        if (accion == Accion.confirmation) {
            view = inflater.inflate(R.layout.dialogo_confirmation, null);
            TextView tvTitulo = view.findViewById(R.id.tvTitulo);
            TextView tvMensaje = view.findViewById(R.id.tvMensaje);
            tvTitulo.setText(titulo);
            tvMensaje.setText(mensaje);
            builder.setView(view);
            final AlertDialog dialog = builder.create();
            dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

            Button btAceptar = view.findViewById(R.id.btAceptar);

            btAceptar.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                        dialog.dismiss();
                }
            });
            dialog.show();

        } else if (accion == Accion.succes) {
            view = inflater.inflate(R.layout.dialogo, null);
            TextView tvTituloSucces = view.findViewById(R.id.tvTitulo);
            TextView tvMensajeSucces = view.findViewById(R.id.tvMensaje);
            tvTituloSucces.setText(titulo);
            tvMensajeSucces.setText(mensaje);
            builder.setView(view);

            final AlertDialog dialog = builder.create();
            dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

            Button btAceptar = view.findViewById(R.id.btAceptar);

            btAceptar.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    dialog.dismiss();
                }
            });

            dialog.show();
        }
        return  view;
    }


    public enum Accion {
        confirmation,
        succes
    }



}
