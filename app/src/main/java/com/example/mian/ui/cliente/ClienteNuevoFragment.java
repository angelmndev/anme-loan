package com.example.mian.ui.cliente;

import android.app.AlertDialog;
import android.content.ContentValues;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Build;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Cliente;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.firebase.FirebaseApp;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.UUID;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ClienteNuevoFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ClienteNuevoFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public ClienteNuevoFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment ClienteNuevoFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ClienteNuevoFragment newInstance(String param1, String param2) {
        ClienteNuevoFragment fragment = new ClienteNuevoFragment();
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

    //::::: ENLAZANDO CON CONTROLES DE XML
    private TextInputEditText txtNombre, txtApellido, txtDni, txtTeleno, txtDireccion;
    private Button btGuardar, btRegresar;
    private NavController navController;
    private ProgressBar mProgressBar;
    private Spinner cbSexo;
    private String idCliente;

    //::::: FIREBASE
    private FirebaseDatabase firebaseDatabase;
    private DatabaseReference databaseReference;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        //::::: INFLAR EN DISEÑO DE ESTE FRAGMENTO
        View view = inflater.inflate(R.layout.fragment_cliente_nuevo, container, false);
        txtNombre = view.findViewById(R.id.txtClieNombre);
        txtApellido = view.findViewById(R.id.txtClieApellido);
        txtDni = view.findViewById(R.id.txtClieDni);
        txtTeleno = view.findViewById(R.id.txtClieTelefono);
        txtDireccion = view.findViewById(R.id.txtClieDireccion);
        cbSexo = view.findViewById(R.id.cbSexo);
        mProgressBar = view.findViewById(R.id.mProgressBar);
        btGuardar = view.findViewById(R.id.btGuardarCliente);
        btRegresar = view.findViewById(R.id.btRegresarCliente);
        AngLib.ShowProgressBar(mProgressBar, 0);


        btGuardar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RegistrarUsuario();
            }
        });

        btRegresar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                navController = Navigation.findNavController(v);
                navController.navigate(R.id.navigation_cliente);
            }
        });

        return view;
    }


    public void RegistrarUsuario() {

        if (ValidarCampoVacioET()) {
            AngLib.ShowProgressBar(mProgressBar, 1);
            firebaseDatabase = FirebaseDatabase.getInstance();
            databaseReference = firebaseDatabase.getReference();
            databaseReference.child("Cliente")
                    .addListenerForSingleValueEvent(new ValueEventListener() {
                        @Override
                        public void onDataChange(DataSnapshot snapshot) {
                            int cantNodos = (int) snapshot.getChildrenCount();
                            AngLib.ShowProgressBar(mProgressBar, 0);
                            String idClienteNew = String.valueOf(cantNodos+1);
                            String clieCodigo = String.valueOf(cantNodos+1);


                            //Insertando Datos Cliente
                            String clieNombre = txtNombre.getText().toString();
                            String clieApellido = txtApellido.getText().toString();
                            int clieFoto = 2;
                            String clieDni = txtDni.getText().toString();
                            String clieTelefono = txtTeleno.getText().toString();
                            String clieDireccion = txtDireccion.getText().toString();
                            String clieSexo = cbSexo.getSelectedItem().toString();
                            String clieEstado = "1";

                            firebaseDatabase = FirebaseDatabase.getInstance();
                            databaseReference = firebaseDatabase.getReference("Cliente");

                            Cliente cliente = new Cliente("cliente"+idClienteNew,"C-00" + clieCodigo, clieNombre, clieApellido, clieFoto, clieDni, clieTelefono, clieDireccion, clieSexo, clieEstado);
                            databaseReference.child("cliente"+idClienteNew).setValue(cliente)
                                    .addOnSuccessListener(new OnSuccessListener<Void>() {
                                        @Override
                                        public void onSuccess(Void aVoid) {
                                            Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(),"MIAN", "Se guardo correctamente");
                                        }
                                    })
                                    .addOnFailureListener(new OnFailureListener() {
                                        @Override
                                        public void onFailure(@NonNull Exception e) {
                                            Dialogo.showDialog(Dialogo.EstadoDialogo.error,getContext(), "MIAN", "no se gardo");
                                        }
                                    });
                        }

                        @Override
                        public void onCancelled(DatabaseError databaseError) {
                        }
                    });


        }else{
            Dialogo.showDialog(Dialogo.EstadoDialogo.error,getContext(),"Mian","Todos los campos son importantes");
        }

    }

    //::::: METODO QUE PERMITE CONTAR LOS HIJOS DE UN NODO
    /*private void CantidadCliente() {
        firebaseDatabase = FirebaseDatabase.getInstance();
        databaseReference = firebaseDatabase.getReference();
        databaseReference.child("Cliente")
                .addListenerForSingleValueEvent(new ValueEventListener() {
                    @Override
                    public void onDataChange(DataSnapshot snapshot) {
                        int codigo = (int) snapshot.getChildrenCount();
                        codigo(codigo);
                        Toast.makeText(getContext(), String.valueOf(codigo), Toast.LENGTH_SHORT).show();
                    }

                    @Override
                    public void onCancelled(DatabaseError databaseError) {

                    }
                });
    }*/

    //::::: GENERAR ID PRESTAMO
    /*private void GenerarIDCliente() {
        AngLib.ShowProgressBar(mProgressBar, 1);
        firebaseDatabase = FirebaseDatabase.getInstance();
        databaseReference = firebaseDatabase.getReference();
        databaseReference.child("Cliente")
                .addListenerForSingleValueEvent(new ValueEventListener() {
                    @Override
                    public void onDataChange(DataSnapshot snapshot) {
                        int cantNodos = (int) snapshot.getChildrenCount();
                        ObtenerIDPrestamo(cantNodos + 1);
                        AngLib.ShowProgressBar(mProgressBar, 0);
                        Toast.makeText(getContext(), String.valueOf(cantNodos), Toast.LENGTH_SHORT).show();
                    }

                    @Override
                    public void onCancelled(DatabaseError databaseError) {
                    }
                });
    }*/

    //VALIDAR CAMPO VACIO
    private boolean ValidarCampoVacioET() {
        TextInputEditText[] texts = {txtNombre, txtApellido, txtDni, txtTeleno, txtDireccion};
        boolean isEmpty = false;

        for (TextInputEditText text : texts) {

            if (text.getText().toString().equals("")) {
                text.setError("Todos los campos son importanes");
                isEmpty = false;
            } else {
                isEmpty = true;
            }
        }

        return isEmpty;
    }


    //::::: METODO QUE PERMITE LANZAR UN DIALOGO
    /*private void showDialog(Accion accion, String titulo, String mensaje) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        LayoutInflater inflater = getLayoutInflater();

        View view = inflater.inflate(R.layout.dialogo_confirmation, null);
        View viewSucces = inflater.inflate(R.layout.dialogo, null);

        if (accion == Accion.confirmation) {
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
            TextView tvTituloSucces = viewSucces.findViewById(R.id.tvTitulo);
            TextView tvMensajeSucces = viewSucces.findViewById(R.id.tvMensaje);
            tvTituloSucces.setText(titulo);
            tvMensajeSucces.setText(mensaje);
            builder.setView(viewSucces);
            final AlertDialog dialog = builder.create();
            dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

            Button btAceptar = viewSucces.findViewById(R.id.btAceptar);

            btAceptar.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    dialog.dismiss();
                    txtNombre.setText(null);
                    txtApellido.setText(null);
                    txtDni.setText(null);
                    txtTeleno.setText(null);
                    txtDireccion.setText(null);
                    txtNombre.setFocusable(true);
                    txtNombre.requestFocus();
                }
            });
            dialog.show();
        }
    }

    private enum Accion {
        confirmation,
        succes
    }*/
}