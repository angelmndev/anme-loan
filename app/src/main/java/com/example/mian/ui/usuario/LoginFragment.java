package com.example.mian.ui.usuario;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;

import androidx.annotation.RequiresApi;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.ui.dialogo.DialogoMain;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.ui.inicio.InicioFragment;
import com.example.mian.utilidades.Utilidades;
import com.google.android.material.textfield.TextInputLayout;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link LoginFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class LoginFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public LoginFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment LoginFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static LoginFragment newInstance(String param1, String param2) {
        LoginFragment fragment = new LoginFragment();
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

    //REFERENCIA A DISEÑO XML

    TextInputLayout txtUsuario, txtPassword;
    TextView tvRegistrarse, tvOlvideMiPassword;
    Button btIngresar;
    Fragment fragmentInicio, fragmentRegistrarUsuario;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_login, container, false);

        txtUsuario = view.findViewById(R.id.txtUsuario);
        txtPassword = view.findViewById(R.id.txtPassword);
        tvRegistrarse = view.findViewById(R.id.tvRegistrarse);
        tvOlvideMiPassword = view.findViewById(R.id.tvOlvideMiPassword);

        btIngresar = view.findViewById(R.id.btIngresar);

        btIngresar.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
            @Override
            public void onClick(View v) {
                String usuario = txtUsuario.getEditText().getText().toString();
                String password = txtPassword.getEditText().getText().toString();
                ConexionSQLiteHelper con = new ConexionSQLiteHelper(getContext(), "dbmian", null, 1);
                SQLiteDatabase database = con.getReadableDatabase();
                Cursor cursor = null;
                cursor = database.rawQuery("SELECT * FROM " + Utilidades.TABLA_USUARIO + " WHERE " + Utilidades.USU_USUARIO + " = " + "'" + usuario + "'" + " AND " + Utilidades.USU_PASSWORD + " = " + "'" + password + "'", null);

                if (cursor.getCount() > 0) {
                    Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(), "MIAN", "BIENVENIDO USUARIO");
                    Fragment fragmentInicio = new InicioFragment();
                    FragmentTransaction transaction = getFragmentManager().beginTransaction();
                    transaction.replace(R.id.nav_host_fragment, fragmentInicio);
                    transaction.addToBackStack(null);
                    transaction.commit();

                } else {
                    Dialogo.showDialog(Dialogo.EstadoDialogo.error,getContext(), "MIAN", "USUARIO Y/O CONTRASEÑA INCORRECTO");
                }
            }
        });

        tvRegistrarse.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragmentRegistrarUsuario = new UsuarioNuevoFragment();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.nav_host_fragment, fragmentRegistrarUsuario);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });

        tvOlvideMiPassword.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                DialogoMain dialogoMain = new DialogoMain();
                View viewDialog = dialogoMain.showDialog(getContext(), DialogoMain.Accion.succes, "Mian", "Preuba login");

                Button bt = viewDialog.findViewById(R.id.btAceptar);
                bt.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                    }
                });
            }
        });
        return view;
    }


}