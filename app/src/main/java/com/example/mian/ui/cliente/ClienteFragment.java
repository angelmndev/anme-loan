package com.example.mian.ui.cliente;

import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.core.view.ViewCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.adaptador.ClienteAdapter;
import com.example.mian.modelo.Cliente;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

import static androidx.core.content.ContextCompat.getColorStateList;
import static androidx.core.content.ContextCompat.getSystemService;

public class ClienteFragment extends Fragment {

    private RecyclerView recyclerView;
    private EditText txtBuscar;
    private Button btEstadoTodo, btEstadoActivo, btEstadoInactivo;
    private ImageButton buttonNuevo, buttonBuscar;
    private Fragment fragmentNuevo;

    private ClienteAdapter clienteAdapter;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_cliente, container, false);

        //::::: REFERENCIA CON ID A CONTROLES DE XML
        recyclerView = view.findViewById(R.id.rvUsuario);
        txtBuscar = view.findViewById(R.id.txtBuscar);
        btEstadoTodo = view.findViewById(R.id.btEstadoTodo);
        btEstadoActivo = view.findViewById(R.id.btEstadoActivo);
        btEstadoInactivo = view.findViewById(R.id.btEstadoInactivo);
        buttonNuevo = view.findViewById(R.id.btNuevoCliente);
        buttonBuscar = view.findViewById(R.id.btBuscarCliente);

        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));


        ShowRecordsUserState(EstadoButton.todo);

        buttonBuscar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (buttonNuevo.getVisibility() == View.VISIBLE) {
                    txtBuscar.setVisibility(View.VISIBLE);
                    txtBuscar.setFocusable(true);
                    txtBuscar.setImeOptions(EditorInfo.IME_ACTION_DONE);
                    if (txtBuscar.requestFocus()) {
                        ((InputMethodManager) getActivity().getSystemService(getContext().INPUT_METHOD_SERVICE)).toggleSoftInput(
                                InputMethodManager.SHOW_FORCED,
                                InputMethodManager.HIDE_IMPLICIT_ONLY
                        );
                    }

                    buttonNuevo.setVisibility(View.GONE);
                } else if (buttonNuevo.getVisibility() == View.GONE) {

                    InputMethodManager imm = (InputMethodManager) getContext().getSystemService(Context.INPUT_METHOD_SERVICE);
                    imm.hideSoftInputFromWindow(((Activity) getContext()).getWindow().getCurrentFocus().getWindowToken(), 0);

                    txtBuscar.setVisibility(View.GONE);
                    buttonNuevo.setVisibility(View.VISIBLE);
                }

            }
        });


        btEstadoTodo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ChangeColorButton(EstadoButton.todo, v.getContext());
                ShowRecordsUserState(EstadoButton.todo);
                ShowRecordsUserState(EstadoButton.todo);
            }
        });

        btEstadoActivo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ChangeColorButton(EstadoButton.activo, v.getContext());
                ShowRecordsUserState(EstadoButton.activo);
                ShowRecordsUserState(EstadoButton.activo);
            }
        });

        btEstadoInactivo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ChangeColorButton(EstadoButton.inactivo, v.getContext());
                ShowRecordsUserState(EstadoButton.inactivo);
                ShowRecordsUserState(EstadoButton.inactivo);
            }
        });

        //::::: REALIZA BUSQUEDA DE CLIENTE POR DNI => EVENTO "TEXTCHANGE"
        txtBuscar.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                ShowRecordsUserSearch(txtBuscar.getText().toString());

            }
        });

        //::::: PERMITE ESCONDER LA CAJA DE TEXTTO
        txtBuscar.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if (actionId == EditorInfo.IME_ACTION_DONE) {
                    txtBuscar.setVisibility(View.GONE);
                    buttonNuevo.setVisibility(View.VISIBLE);
                }
                return false;
            }
        });

        //::::: ABRE EL FRAGMENTO NUEVO CLIENTE
        buttonNuevo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragmentNuevo = new ClienteNuevoFragment();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.fragmentCliente, fragmentNuevo);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });

        return view;
    }


    @Override
    public void onStart() {
        super.onStart();
        clienteAdapter.startListening();
    }

    @Override
    public void onStop() {
        super.onStop();
        clienteAdapter.stopListening();
    }

    //::::: METODO QUE PERMITE LANZAR TODO EL REGISTRO DE CLIENTE
    private void ShowRecordsUserState(EstadoButton estadoButton){
        FirebaseRecyclerOptions<Cliente> options;
        switch (estadoButton){
            case todo:
                options = new FirebaseRecyclerOptions.Builder<Cliente>()
                        .setQuery(FirebaseDatabase.getInstance().getReference().child("Cliente"), Cliente.class)
                        .build();
                RecyclerClienteAdapter(options);
                break;
            case activo:
                options = new FirebaseRecyclerOptions.Builder<Cliente>()
                        .setQuery(FirebaseDatabase.getInstance().getReference().child("Cliente").orderByChild("clieEstado").startAt("1").endAt("1"+"\uf8ff"), Cliente.class)
                        .build();
                RecyclerClienteAdapterCondition(options);
                break;
            case inactivo:
                options = new FirebaseRecyclerOptions.Builder<Cliente>()
                        .setQuery(FirebaseDatabase.getInstance().getReference().child("Cliente").orderByChild("clieEstado").startAt("0").endAt("0"+"\uf8ff"), Cliente.class)
                        .build();
                RecyclerClienteAdapterCondition(options);
                break;
        }
    }

    //::::: METODO QUE PERMITE BUSCAR CLIENTE POR DNI
    private void ShowRecordsUserSearch(String valor) {

        FirebaseRecyclerOptions<Cliente> options = new FirebaseRecyclerOptions.Builder<Cliente>()
                        .setQuery(FirebaseDatabase.getInstance().getReference().child("Cliente").orderByChild("clieDni").startAt(valor).endAt(valor+"\uf8ff"), Cliente.class)
                        .build();
        RecyclerClienteAdapterCondition(options);
    }

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS CON CONDICION A RECYCLERVIEW
    private void RecyclerClienteAdapterCondition(FirebaseRecyclerOptions<Cliente> options){
        clienteAdapter = new ClienteAdapter(options, getContext());
        clienteAdapter.startListening();
        recyclerView.setAdapter(clienteAdapter);
    }

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS SIN CONDICION A RECYCLERVIEW
    private void RecyclerClienteAdapter(FirebaseRecyclerOptions<Cliente> options){
        clienteAdapter = new ClienteAdapter(options, getContext());
        clienteAdapter.startListening();
        recyclerView.setAdapter(clienteAdapter);
    }


    //Metodo que permite controlar colores de cambio de los botones de mostrar todo,activo,inactivo
    private void ChangeColorButton(EstadoButton estadoButton, Context context) {

        switch (estadoButton) {
            case todo:
                ChangeColorButttonNotClick(context);
                btEstadoTodo.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btEstadoTodo, ContextCompat.getColorStateList(context, R.color.Red_150));
                break;
            case activo:
                ChangeColorButttonNotClick(context);
                btEstadoActivo.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btEstadoActivo, ContextCompat.getColorStateList(context, R.color.Red_150));
                break;
            case inactivo:
                ChangeColorButttonNotClick(context);
                btEstadoInactivo.setBackgroundResource(R.drawable.ic_button_radius);
                ViewCompat.setBackgroundTintList(btEstadoInactivo, ContextCompat.getColorStateList(context, R.color.Red_150));
                break;
        }
    }

    //Metodo que permite regresar a color no clicked
    private void ChangeColorButttonNotClick(Context context) {
        ViewCompat.setBackgroundTintList(btEstadoTodo, ContextCompat.getColorStateList(context, R.color.angTransparent));
        ViewCompat.setBackgroundTintList(btEstadoActivo, ContextCompat.getColorStateList(context, R.color.angTransparent));
        ViewCompat.setBackgroundTintList(btEstadoInactivo, ContextCompat.getColorStateList(context, R.color.angTransparent));
    }

    private enum EstadoButton {
        todo,
        activo,
        inactivo
    }
}