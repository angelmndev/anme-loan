package com.example.mian.ui.prestamo;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.core.view.ViewCompat;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import android.text.format.DateFormat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.interfaces.IPrestamo;
import com.example.mian.interfaces.IPrestamoHistorial;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Cliente;
import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoHistorial;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerAdapter;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import kotlin.text.UStringsKt;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PrestamoDetalleEliminarFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PrestamoDetalleEliminarFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoDetalleEliminarFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PrestamoDetalleEliminarFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PrestamoDetalleEliminarFragment newInstance(String param1, String param2) {
        PrestamoDetalleEliminarFragment fragment = new PrestamoDetalleEliminarFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }
    //:::::::: A N G E L ::::: W R I T T E N ::::: C O D E :::::::
    private FirebaseDatabase mDatabase;
    private DatabaseReference mReference;
    private FloatingActionButton fabEliminar;
    private TextView tvNombreCliente,tvCodigoCliente, tvDireccionCliente, tvDniCliente, tvSexoCliente, tvTelefonoCliente, tvEstadoCliente, tvImporteCredito, tvModalidadPago, tvTipoPago, tvNumeroCuota, tvTasaInteres, tvImporteCuota, tvTotalPagar, tvFechaPrestamo;
    private ProgressDialog mDialog, mProgress;
    private NavController navController;
    private String idPrestamo;
    private String preClieDni;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_prestamo_detalle_eliminar, container, false);
        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);
        tvCodigoCliente = view.findViewById(R.id.tvCodigoCliente);
        tvDireccionCliente = view.findViewById(R.id.tvDireccionCliente);
        tvDniCliente = view.findViewById(R.id.tvDniCliente);
        tvSexoCliente = view.findViewById(R.id.tvSexoCliente);
        tvTelefonoCliente = view.findViewById(R.id.tvTelefonoCliente);
        tvEstadoCliente = view.findViewById(R.id.tvEstadoCliente);
        tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
        tvModalidadPago = view.findViewById(R.id.tvModalidadPago);
        tvTipoPago = view.findViewById(R.id.tvTipoPago);
        tvNumeroCuota = view.findViewById(R.id.tvNumeroCuota);
        tvTasaInteres = view.findViewById(R.id.tvTasaInteres);
        tvImporteCuota = view.findViewById(R.id.tvImporteCuota);
        tvTotalPagar = view.findViewById(R.id.tvTotalPagar);
        tvFechaPrestamo = view.findViewById(R.id.tvFechaPrestamo);

        fabEliminar = view.findViewById(R.id.fabEliminar);


        assert getArguments() != null;

        this.idPrestamo = getArguments().getString(Utilidades.ID_PRESTAMO);
        this.preClieDni =  getArguments().getString(Utilidades.PRE_CLIE_DNI);
        ShowClientData(idPrestamo);
        ObtenenerDatosCliente(preClieDni);

        fabEliminar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog(getContext(),"MIAN","Estas seguro que quiere eliminar el prestamo de: "+tvNombreCliente.getText()+" que es la suma de "+ tvImporteCredito.getText(),idPrestamo);
            }
        });

        return view;
    }

    //:::Metodo que permite mostrar los datos del cliente respectivo
    private void ShowClientData(String idPrestamo) {

        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());

        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String idPrestamoHistorial = snapshot.child(Utilidades.PRE_ID_PRESTAMO_HISTORIAL).getValue().toString();

                mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
                mReference.child(idPrestamoHistorial).addValueEventListener(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot snapshot) {

                        PrestamoHistorial ph = snapshot.getValue(PrestamoHistorial.class);

                        tvImporteCredito.setText(String.valueOf(ph.getPhImporteCredito()));
                        tvModalidadPago.setText(ph.getPhModalidadPago());
                        tvTipoPago.setText(ph.getPhTipoPago());
                        tvNumeroCuota.setText(String.valueOf(ph.getPhNumeroCuota()));
                        tvTasaInteres.setText(String.valueOf(ph.getPhTasaInteres()));
                        tvImporteCuota.setText(String.valueOf(ph.getPhImporteCuota()));
                        tvTotalPagar.setText(String.valueOf(ph.getPhTotalPagar()));
                        tvFechaPrestamo.setText(ph.getPhFecha());

                        mDialog.dismiss();
                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError error) {

                    }
                });
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }

    private void ObtenenerDatosCliente(String clieDni){
        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());

        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mReference.orderByChild(Utilidades.CLIE_DNI).equalTo(clieDni).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {

                for(DataSnapshot ds : snapshot.getChildren()){
                    Cliente cliente = ds.getValue(Cliente.class);

                    assert cliente != null;
                    tvNombreCliente.setText(cliente.getClieNombre()+" "+ cliente.getClieApellido());
                    tvCodigoCliente.setText(cliente.getClieCodigo());
                    tvDireccionCliente.setText(cliente.getClieDireccion());
                    tvDniCliente.setText(cliente.getClieDni());
                    tvSexoCliente.setText(cliente.getClieSexo());
                    tvTelefonoCliente.setText(cliente.getClieTelefono());
                    tvEstadoCliente.setText(cliente.getClieEstado());
                }


                mDialog.dismiss();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }


    //Obtener IDPRESTAMOHISTORIAL
    private void GetIDPrestamo(IPrestamoHistorial iPrestamoHistorial){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                iPrestamoHistorial.ObtenerIDPH(snapshot.child(Utilidades.ID_PRESTAMO_HISTORIAL).getValue(String.class));
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }


    //Modificar Prestamo Historial
    private void UpdatePrestamoHistorial(){

        GetIDPrestamo(new IPrestamoHistorial() {
            @Override
            public void ObtenerDatos(PrestamoHistorial prestamoHistorial) {

            }

            @Override
            public void ObtenerIDPH(String idPH) {
                mDatabase = FirebaseDatabase.getInstance();
                mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
                mReference.child(idPH).child(Utilidades.PH_COMENTARIO).setValue("Prestamo Eliminado en la fecha: "+ AngLib.obtenerFechaActual("Ica-Peru")).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        DeleteLoan();
                    }
                });
            }
        });

    }

    //Eliminar prestamo
    private void DeleteLoan(){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).removeValue().addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {

            }
        });

    }



    //::: Controles de cuadro de dialogo
    private ImageView ivEstado;
    private TextView tvTitulo, tvMensaje;
    private Button btAceptar, btCancelar;
    private ImageButton btCerrar;

    public void showDialog(Context context, String titulo, String mensaje,String idPrestamo) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        LayoutInflater inflater = LayoutInflater.from(context);

        View view = inflater.inflate(R.layout.dialogo_confirmation, null);
        ivEstado = view.findViewById(R.id.ivEstado);
        tvTitulo = view.findViewById(R.id.tvTitulo);
        tvMensaje = view.findViewById(R.id.tvMensaje);
        btAceptar = view.findViewById(R.id.btAceptar);
        btCancelar = view.findViewById(R.id.btCancelar);
        btCerrar = view.findViewById(R.id.btCerrar);

        tvTitulo.setText(titulo);
        tvMensaje.setText(mensaje);
        builder.setView(view);

        final AlertDialog dialog = builder.create();
        dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

        btAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                UpdatePrestamoHistorial();
                dialog.dismiss();
                mDialog = AngLib.ShowProgressDialog(mProgress,getContext());
            }
        });

        btCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });

        btCerrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });

        dialog.show();
    }

}