package com.example.mian.ui.usuario;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.libreria.AngLib;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.google.android.material.textfield.TextInputLayout;

import static android.app.Activity.RESULT_OK;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link UsuarioNuevoFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class UsuarioNuevoFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public UsuarioNuevoFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment UsuarioNuevoFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static UsuarioNuevoFragment newInstance(String param1, String param2) {
        UsuarioNuevoFragment fragment = new UsuarioNuevoFragment();
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

    //REFERECIA A NUESTRO CAMPOS DE XML
    TextInputLayout txtUsuNombre,txtUsuApellido,txtUsuUsuario,txtUsuPassword,txtUsuDni,txtUsuCodigo,txtUsuTelefono,txtUsuDireccion;
    TextView tvUsuario;
    Spinner spUsuPrivilegio;
    ImageView ivUsuFoto;
    Button btGuardar,btRegresar;

    private static final int GALLERY_REQUEST_CODE = 123;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_usuario_nuevo, container, false);
        tvUsuario = view.findViewById(R.id.tvUsuNewUsuario);
        txtUsuNombre = view.findViewById(R.id.txtUsuNewNombre);
        txtUsuApellido = view.findViewById(R.id.txtUsuNewApellido);
        txtUsuUsuario = view.findViewById(R.id.txtUsuNewUsuario);
        txtUsuPassword = view.findViewById(R.id.txtUsuNewPassword);
        txtUsuDni = view.findViewById(R.id.txtUsuNewDni);
        txtUsuCodigo = view.findViewById(R.id.txtUsuNewCodigo);
        txtUsuTelefono = view.findViewById(R.id.txtUsuNewTelefono);
        txtUsuDireccion = view.findViewById(R.id.txtUsuNewDireccion);
        spUsuPrivilegio = view.findViewById(R.id.spUsuNewPrivilegio);
        ivUsuFoto = view.findViewById(R.id.ivUsuNewFoto);

        btGuardar = view.findViewById(R.id.btGuardarUsuario);

        txtUsuUsuario.getEditText().addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                String usuario = txtUsuUsuario.getEditText().getText().toString();

                tvUsuario.setText(usuario);
            }
        });

        ivUsuFoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(Intent.createChooser(intent,"Selecciona una foto"),GALLERY_REQUEST_CODE);
            }
        });

        btGuardar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AgregarUsuario();
            }
        });

        return view;
    }


    @Override
    public void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        if(requestCode == GALLERY_REQUEST_CODE && resultCode == RESULT_OK && data != null){
            Uri uriImage = data.getData();

            ivUsuFoto.setImageURI(uriImage);
        }
    }

    //METODO QU EPERMITE DATOS DE USURIO
    private void AgregarUsuario(){
        ConexionSQLiteHelper con = new ConexionSQLiteHelper(getContext(),"dbmian",null,1);
        SQLiteDatabase database = con.getWritableDatabase();
        ContentValues values = new ContentValues();
        Bitmap image= ((BitmapDrawable)ivUsuFoto.getDrawable()).getBitmap();

        values.put(Utilidades.USU_CODIGO, txtUsuCodigo.getEditText().getText().toString());
        values.put(Utilidades.USU_FOTO, AngLib.getBytes(image));
        values.put(Utilidades.USU_NOMBRE, txtUsuNombre.getEditText().getText().toString());
        values.put(Utilidades.USU_APELLIDO, txtUsuApellido.getEditText().getText().toString());
        values.put(Utilidades.USU_USUARIO, txtUsuUsuario.getEditText().getText().toString());
        values.put(Utilidades.USU_PASSWORD, txtUsuPassword.getEditText().getText().toString());
        values.put(Utilidades.USU_DNI, txtUsuDni.getEditText().getText().toString());
        values.put(Utilidades.USU_TELEFONO, txtUsuTelefono.getEditText().getText().toString());
        values.put(Utilidades.USU_DIRECCION, txtUsuDireccion.getEditText().getText().toString());
        values.put(Utilidades.USU_PRIVILEGIO, spUsuPrivilegio.getSelectedItem().toString());
        values.put(Utilidades.USU_ESTADO, "1");


        long idResultante = database.insert(Utilidades.TABLA_USUARIO,Utilidades.USU_CODIGO,values);

        if(idResultante>0){
            Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(),"MIAN","Usuario agregado correctamente");
        }
        con.close();
    }



}