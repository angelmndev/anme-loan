package com.example.mian.ui.prestamo;

import android.app.ProgressDialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import com.example.mian.R;

import com.example.mian.adaptador.prestamo.PrestamoModificarAdapter;

import com.example.mian.interfaces.ICliente;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class PrestamoModificarFragment extends Fragment {

    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    private String mParam1;
    private String mParam2;

    public PrestamoModificarFragment() {

    }

    public static PrestamoModificarFragment newInstance(String param1, String param2) {
        PrestamoModificarFragment fragment = new PrestamoModificarFragment();
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

    //::::: A N G E L :::: C O D E :::: W R I T T E N ::::::
    private EditText etBuscarCliente;
    private TextView tvNombreCliente;
    private RecyclerView rvRegistroPrestamoModificar;
    private FirebaseDatabase mDatabase;
    private DatabaseReference mReference;
    private ProgressDialog mDialog, mProgress;
    private PrestamoModificarAdapter prestamoRegistroAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_prestamo_modificar, container, false);

        etBuscarCliente = view.findViewById(R.id.etBuscarCliente);
        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);
        rvRegistroPrestamoModificar = view.findViewById(R.id.rvRegistroPrestamoModificar);
        rvRegistroPrestamoModificar.setLayoutManager(new LinearLayoutManager(getContext()));
        ShowAdapterPrestamoModificar();

        etBuscarCliente.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if (etBuscarCliente.length() == 8) {
                    ObtenerDatosCliente(new ICliente() {
                        @Override
                        public void BuscarID(String IDCLIENTE) {

                        }

                        @Override
                        public void GenerarID(String IDCLIENTE) {

                        }

                        @Override
                        public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {
                            tvNombreCliente.setText(NOMBRE+" "+APELLIDO);
                            ShowRecordsPrestamoSearch(DNI);
                        }
                    },etBuscarCliente.getText().toString());
                    //ObtenerNombreCLiente(etBuscarCliente.getText().toString());
                }
            }
        });

        return view;
    }

    //Metodo que permite adaptar a recycler view
    private void ShowAdapterPrestamoModificar() {
        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());
        FirebaseRecyclerOptions<Prestamo> options = new FirebaseRecyclerOptions.Builder<Prestamo>()
                .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO).orderByChild(Utilidades.PRE_ESTADO).startAt("1").endAt("1" + "\uf8ff"), Prestamo.class)
                .build();


        RecyclerPrestamoAdapter(options, mDialog);
    }

    //::::: METODO QUE PERMITE BUSCAR CLIENTE POR DNI
    private void ShowRecordsPrestamoSearch(String clieDni) {

                mDialog = AngLib.ShowProgressDialog(mProgress, getContext());
                FirebaseRecyclerOptions<Prestamo> options = new FirebaseRecyclerOptions.Builder<Prestamo>()
                        .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO).orderByChild(Utilidades.PRE_ESTADO_CANTIDAD).startAt(clieDni+"(1)").endAt(clieDni+"(1)"+"\uf8ff"), Prestamo.class)
                        .build();
                RecyclerPrestamoAdapter(options,mDialog);

    }


    // OBTENIENDO DATOS DEL CLIENTE
    private void ObtenerDatosCliente(ICliente iCliente,String clieDni){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mReference.orderByChild(Utilidades.CLIE_DNI).equalTo(clieDni).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String IDCLIENTE = null;
                String DNI = null;
                String NOMBRE = null;
                String APELLIDO = null;
                String SEXO = null;
                for (DataSnapshot ds : snapshot.getChildren()) {
                    IDCLIENTE = ds.child(Utilidades.ID_CLIENTE).getValue().toString();
                    DNI = ds.child(Utilidades.CLIE_DNI).getValue().toString();
                    NOMBRE = ds.child(Utilidades.CLIE_NOMBRE).getValue().toString();
                    APELLIDO = ds.child(Utilidades.CLIE_APELLIDO).getValue().toString();
                    SEXO = ds.child(Utilidades.CLIE_SEXO).getValue().toString();
                }
                iCliente.ObtenerDatos(IDCLIENTE,DNI,NOMBRE,APELLIDO,SEXO);
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS SIN CONDICION A RECYCLERVIEW
    private void RecyclerPrestamoAdapter
    (FirebaseRecyclerOptions<Prestamo> options, ProgressDialog dialog) {
        prestamoRegistroAdapter = new PrestamoModificarAdapter(options, getContext(), dialog);
        prestamoRegistroAdapter.startListening();
        rvRegistroPrestamoModificar.setAdapter(prestamoRegistroAdapter);
    }

    @Override
    public void onStart() {
        super.onStart();
        prestamoRegistroAdapter.startListening();
    }

    @Override
    public void onStop() {
        super.onStop();
        prestamoRegistroAdapter.stopListening();
    }

}