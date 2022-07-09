package com.example.mian.ui.usuario;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.adaptador.ClienteAdapter;
import com.example.mian.adaptador.UsuarioAdapter;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Cliente;
import com.example.mian.modelo.Usuario;
import com.example.mian.ui.cliente.ClienteNuevoFragment;
import com.example.mian.utilidades.Utilidades;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link UsuarioFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class UsuarioFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public UsuarioFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment UsuarioFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static UsuarioFragment newInstance(String param1, String param2) {
        UsuarioFragment fragment = new UsuarioFragment();
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

    //REFERENCIA CON XML

    RecyclerView recyclerViewUsuario;
    ArrayList<Usuario> listaUsuario;

    ImageButton btNuevoUsuario;
    Fragment fragmentUsuarioNuevo;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_usuario, container, false);

        recyclerViewUsuario = view.findViewById(R.id.rvUsuarioMain);
        recyclerViewUsuario.setLayoutManager(new LinearLayoutManager(getContext()));

        ShowUser();
        UsuarioAdapter usuarioAdapter = new UsuarioAdapter(listaUsuario,getContext());
        recyclerViewUsuario.setAdapter(usuarioAdapter);

        btNuevoUsuario = view.findViewById(R.id.btNuevoUsuario);

        btNuevoUsuario.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragmentUsuarioNuevo = new UsuarioNuevoFragment();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.fragmentInicio, fragmentUsuarioNuevo);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });

        return view;
    }


    private void ShowUser(){
        ConexionSQLiteHelper con = new ConexionSQLiteHelper(getContext(),"dbmian",null,1);
        SQLiteDatabase database = con.getReadableDatabase();
        Cursor cursor = null;
        listaUsuario = new ArrayList<>();
            cursor = database.rawQuery("SELECT * FROM " + Utilidades.TABLA_USUARIO, null);
            if (cursor.getCount() > 0) {
                while (cursor.moveToNext()) {
                    byte[] blob = cursor.getBlob(cursor.getColumnIndex(Utilidades.USU_FOTO));
                    listaUsuario.add(new Usuario(
                            cursor.getInt(0),
                            cursor.getString(1),
                            AngLib.getPhoto(blob),
                            cursor.getString(3),
                            cursor.getString(4),
                            cursor.getString(5),
                            cursor.getString(6),
                            cursor.getString(7),
                            cursor.getString(8),
                            cursor.getString(9),
                            cursor.getString(10),
                            cursor.getString(11)
                    ));
                }
            }
    }

}