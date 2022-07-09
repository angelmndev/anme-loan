package com.example.mian.ui.dialogo;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.telephony.IccOpenLogicalChannelResponse;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.ColorInt;
import androidx.annotation.RequiresApi;
import androidx.core.content.ContextCompat;
import androidx.core.view.ViewCompat;
import androidx.fragment.app.Fragment;

import com.example.mian.R;

public  class Dialogo extends Fragment {

    public static void showDialog(EstadoDialogo estadoDialogo, Context context, String titulo, String mensaje) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        LayoutInflater inflater = LayoutInflater.from(context);

        View view = inflater.inflate(R.layout.dialogo, null);
        ImageView ivEstado = view.findViewById(R.id.ivEstado);
        TextView tvTitulo = view.findViewById(R.id.tvTitulo);
        TextView tvMensaje = view.findViewById(R.id.tvMensaje);
        Button btAceptar = view.findViewById(R.id.btAceptar);

        switch (estadoDialogo){
            case succes:
                ivEstado.setImageResource(R.drawable.ic_success);
                tvTitulo.setTextColor(view.getResources().getColor(R.color.angSuccess));
                btAceptar.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btAceptar, ContextCompat.getColorStateList(context, R.color.angSuccess));
                break;
            case warning:
                ivEstado.setImageResource(R.drawable.ic_advertencia);
                tvTitulo.setTextColor(view.getResources().getColor(R.color.angWarning));
                btAceptar.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btAceptar, ContextCompat.getColorStateList(context, R.color.angWarning));
                break;
            case error:
                ivEstado.setImageResource(R.drawable.ic_error);
                tvTitulo.setTextColor(view.getResources().getColor(R.color.angError));
                btAceptar.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btAceptar, ContextCompat.getColorStateList(context, R.color.angError));
                break;
        }

        tvTitulo.setText(titulo);
        tvMensaje.setText(mensaje);
        builder.setView(view);

        final AlertDialog dialog = builder.create();
        dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

        btAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });

        dialog.show();
    }

    public  enum  EstadoDialogo{
        succes,
        warning,
        error
    }
}
